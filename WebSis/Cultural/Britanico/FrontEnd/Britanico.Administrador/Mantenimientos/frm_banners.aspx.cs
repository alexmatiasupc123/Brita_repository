using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.BusinessLogic.Transaccionales;
using System.Collections.Generic;
using System.IO;

public partial class Mantenimientos_frm_banners : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEBanner bBanner = new BEBanner();
    BLBannerNTAD oBanner = new BLBannerNTAD();
    BLBannerTAD gBanner = new BLBannerTAD();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();
    string bImagenURL;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {

                cargarBanners();
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            limpiaInfo();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void cargarBanners()
    {
        List<BEBanner> listaBanners = oBanner.ListarTodos();
        foreach (BEBanner iBanner in listaBanners)
        {
            iBanner.bann_imag = rutaUpload + iBanner.bann_imag;

        }
        dlBanners.DataSource = listaBanners;
        dlBanners.DataBind();
    }

    public bool IsDate(string sdate)
    {
        DateTime dt;
        bool isDate = true;
        try
        {
            dt = DateTime.Parse(sdate);
        }
        catch
        {
            isDate = false;
        }
        return isDate;
    }



    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
     
        bBanner.bann_esta = 1;
        bBanner.bann_fech = DateTime.Today.Date;
        bBanner.bann_titu = txtTituto.Text;
        bBanner.bann_link = txtLink.Text;
        txtFecha.Text = txtFecha.Text.Trim();
        DateTime fecha;
        if (txtFecha.Text != "")
        {
            try
            {
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("es-PE");
                fecha = DateTime.ParseExact(txtFecha.Text,"dd/MM/yyyy",ci);
                bBanner.bann_dfec = fecha.ToShortDateString();    
            }
            catch
            {
                lblError.Text = "**ERROR: Formato de fecha invalido (dd/mm/yyyy)";
                return;
            }
        }
        else {
            bBanner.bann_dfec = "";
        }
        
        bBanner.bann_fpri = chkPrincipal.Checked;
        bBanner.bann_redsocial = chkRedSocial.Checked;
        

        //guardar imagen
        if (fuBanner.PostedFile.ContentLength>0)
        {
            long maximo = 307200;
            long tamanio = fuBanner.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bBanner.bann_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuBanner.PostedFile.FileName));
                    fuBanner.SaveAs(Server.MapPath(rutaUpload) + bBanner.bann_imag);

                    //fuBanner.FileName.ToString();
                    gBanner.Agregar(bBanner);
                    cargarBanners();
                    limpiaInfo();
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        }
        else
            lblError.Text = "*Seleccione Banner";



    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        pNuevo.Visible = true;
        dlBanners.Visible = false;
        btnNuevo.Visible = false;
        lblNombreSeccion.Text = "Agregar Banner";
        btnActualizar.Visible = false;
        btnGuardar.Visible = true;
        bImagen.Visible = false;
    }

    void limpiaInfo()
    {
        txtTituto.Text = "";
        txtLink.Text="";
        fuBanner.Dispose();
        pNuevo.Visible = false;
        lblError.Text = "";
        dlBanners.Visible = true;
        btnNuevo.Visible = true;
        txtFecha.Text = "";
        chkPrincipal.Checked = false;
    }
    protected void lnkEliminar_Click(object sender, EventArgs e)
    {
        LinkButton lnkEliminar = (LinkButton)sender;
        Int32 idBanner = Convert.ToInt32(lnkEliminar.CommandArgument);
        bBanner = oBanner.ListarRegistro(idBanner);
        string nombreImagen = rutaUnload + bBanner.bann_imag;
        gBanner.Eliminar(idBanner);

        if (nombreImagen.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(nombreImagen);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }

        cargarBanners();
    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton btnEliminar = (ImageButton)sender;
            Int32 idBanner = Convert.ToInt32(btnEliminar.CommandArgument);
            bBanner = oBanner.ListarRegistro(idBanner);
            string nombreImagen = rutaUnload + bBanner.bann_imag;
            gBanner.Eliminar(idBanner);

            if (nombreImagen.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(nombreImagen);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }

            cargarBanners();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
    {
        bBanner.bann_esta = 1;
        bBanner.bann_fech = DateTime.Today.Date;
        bBanner.bann_titu = txtTituto.Text;
        bBanner.bann_link = txtLink.Text;
        bBanner.bann_dfec = txtFecha.Text;
        bBanner.bann_fpri = chkPrincipal.Checked;
        bBanner.bann_redsocial = chkRedSocial.Checked;
        bBanner.bann_codi = Convert.ToInt32(lblCodigo.Text);
        bBanner.bann_imag = Session["img"].ToString();
        //guardar imagen
        if (fuBanner.PostedFile.ContentLength > 0)
        {
            long maximo = 204800;
            long tamanio = fuBanner.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bBanner.bann_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuBanner.PostedFile.FileName));
                    fuBanner.SaveAs(Server.MapPath(rutaUpload) + bBanner.bann_imag);

                    //fuBanner.FileName.ToString();
                   
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        }
      


        gBanner.Modificar(bBanner);
        cargarBanners();
        limpiaInfo();
    }
    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEditar = (ImageButton)sender;
        Int32 idBanner = Convert.ToInt32(btnEditar.CommandArgument);
        bBanner = oBanner.ListarRegistro(idBanner);
        bImagenURL = rutaUpload + bBanner.bann_imag;
        Session["img"] =bBanner.bann_imag;
        lblCodigo.Text = bBanner.bann_codi.ToString();
        txtTituto.Text = bBanner.bann_titu;
        txtFecha.Text = bBanner.bann_dfec;
        chkPrincipal.Checked = bBanner.bann_fpri;
        chkRedSocial.Checked = bBanner.bann_redsocial;
        bImagen.ImageUrl = bImagenURL;
        txtLink.Text = bBanner.bann_link;
        lblNombreSeccion.Text = "Modificar Banner";
        btnGuardar.Visible = false;
        btnActualizar.Visible = true;
        bImagen.Visible = true;
        pNuevo.Visible = true;
       
       

    }
    protected void chkPrincipal_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRedSocial.Checked == true && chkPrincipal.Checked == true) {
            chkRedSocial.Checked = false;
        }
    }
    protected void chkRedSocial_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPrincipal.Checked == true && chkRedSocial.Checked == true)
        {
            chkPrincipal.Checked = false;
        }
    }
}
