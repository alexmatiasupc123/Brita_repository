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

public partial class Mantenimientos_frm_muestraGaleria : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEMuestraGaleria bMuestraGaleria = new BEMuestraGaleria();
    BLMuestraGaleriaNTAD oMuestraGaleria = new BLMuestraGaleriaNTAD();
    BLMuestraGaleriaTAD gMuestraGaleria = new BLMuestraGaleriaTAD();
   
    string bImagenURL;
    string bImagenAgendaURL;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }


    void limpiarInfo()
    {

        txtNombre.Text = "";
        txtContenido.Text = "";
        txtAnio.Text = "";
        fuImagen.Dispose();
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvMuestraGaleria.Visible = true;
        btnNuevo.Visible = true;

    }



    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idMuestra = Convert.ToInt32(btnEliminar.CommandArgument);
        gMuestraGaleria.Eliminar(idMuestra);
        gvMuestraGaleria.DataBind();

    }
    protected void gvMuestraGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idMuestraGaleria = Convert.ToInt32(gvMuestraGaleria.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Muestra";
        lblCodigo.Visible = true;
        lbleCodigo.Visible = true;
        bMuestraGaleria = oMuestraGaleria.ListarRegistro(idMuestraGaleria);

        //cargamos info
        txtNombre.Text = bMuestraGaleria.mues_nomb;
        txtContenido.Text = bMuestraGaleria.mues_desc;
        txtAnio.Text = bMuestraGaleria.mues_anio.ToString();
        lblCodigo.Text = bMuestraGaleria.mues_codi.ToString();
        ddlGaleria.SelectedValue = bMuestraGaleria.gale_codi.ToString();
        bImagenURL = rutaUpload + bMuestraGaleria.mues_imag;
        Session["img"] = bMuestraGaleria.mues_imag;
        img.Visible = true;
        img.ImageUrl = bImagenURL;

        btnNuevo.Visible = false;
        gvMuestraGaleria.Visible = false;
        btnNuevo.Visible = false;
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {

        lblNombreSeccion.Text = "Agregar Muestra";
        lblCodigo.Visible = false;
        lbleCodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvMuestraGaleria.Visible = false;
        btnNuevo.Visible = false;
        img.Visible = false;
    }

    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {

            bMuestraGaleria.gale_codi = Convert.ToInt32(ddlGaleria.SelectedValue);
            bMuestraGaleria.mues_desc = txtContenido.Text;
            bMuestraGaleria.mues_imag = fuImagen.FileName;
            bMuestraGaleria.mues_nomb = txtNombre.Text;
            bMuestraGaleria.mues_anio = Convert.ToInt32(txtAnio.Text);
            //guardar imagen

            if (fuImagen.PostedFile.ContentLength > 0)
            {
                guardaImagen(bMuestraGaleria);

            }

            gMuestraGaleria.Agregar(bMuestraGaleria);
            gvMuestraGaleria.DataBind();
            limpiarInfo();
        
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bMuestraGaleria.gale_codi = Convert.ToInt32(ddlGaleria.SelectedValue);
        bMuestraGaleria.mues_desc = txtContenido.Text;
        bMuestraGaleria.mues_imag = fuImagen.FileName;
        bMuestraGaleria.mues_nomb = txtNombre.Text;
        bMuestraGaleria.mues_codi = Convert.ToInt32(lblCodigo.Text);
        bMuestraGaleria.mues_anio = Convert.ToInt32(txtAnio.Text);


        if (fuImagen.PostedFile.ContentLength > 0)
        {
            guardaImagen(bMuestraGaleria);

        }
        else
        {
            if (Session["img"] != null)
            {
                bMuestraGaleria.mues_imag = Session["img"].ToString();

            }
        }


        gMuestraGaleria.Modificar(bMuestraGaleria);
        gvMuestraGaleria.DataBind();
        limpiarInfo();

    }



    void guardaImagen(BEMuestraGaleria bMuestraGaleria)
    {

            long maximo = 204800;
            long tamanio = fuImagen.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bMuestraGaleria.mues_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bMuestraGaleria.mues_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

    }


    void eliminaImagen(String nombreImagen)
    {

        if (nombreImagen.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(nombreImagen);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }


}
