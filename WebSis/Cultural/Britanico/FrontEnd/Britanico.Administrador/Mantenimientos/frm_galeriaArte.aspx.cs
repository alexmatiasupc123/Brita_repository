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

public partial class Mantenimientos_frm_galeriaArte : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEGaleriaArte bGaleriaArte = new BEGaleriaArte();
    BLGaleriaArteNTAD oGaleriaArte = new BLGaleriaArteNTAD();
    BLGaleriaArteTAD gGaleriaArte = new BLGaleriaArteTAD();
    BEGaleriaArteDetalle bGaleriaArteDetalle = new BEGaleriaArteDetalle();
    BLGaleriaArteDetalleNTAD oGaleriaDetalle = new BLGaleriaArteDetalleNTAD();
    BLGaleriaArteDetalleTAD gGaleriaDetalle = new BLGaleriaArteDetalleTAD();
    BLSedeNTAD oSede = new BLSedeNTAD();
    string bImagenURL;
    string bImagenAgendaURL;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Galeria Arte";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvGaleria.Visible = false;
        gvGaleriaDetalle.Visible = false;
        lblGaleriaArteDetalle.Visible = false;
        btnCTNuevo.Visible = false;
      
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
   
        ddlSede.Dispose();
        txtTitulo.Text = "";
        txtHistoria.Text = "";

        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvGaleria.Visible = true;

    }

    void limpiarInfoDeta()
    {

        txtNombreGaleriaDetalle.Text = "";
        //txtCTFechaInicio.Text = "";
        //txtCTFechaFin.Text = "";
        txtCTTemporada.Text = "";
        txtContenido.Text = "";
        fuGaleriaArteDetalle.Dispose();
        lblCTCodigo.Text = "";
        listaFechas.Items.Clear();
        pCTNuevo.Visible = false;
        btnCTNuevo.Visible = true;
        gvGaleriaDetalle.Visible = true;
        btnNuevo.Visible = true;

    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bGaleriaArte.gale_desc = txtHistoria.Text;
        bGaleriaArte.gale_nomb = txtTitulo.Text;
        bGaleriaArte.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        gGaleriaArte.Agregar(bGaleriaArte);
        gvGaleria.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bGaleriaArte.gale_codi = Convert.ToInt32(lblCodigo.Text);
        bGaleriaArte.gale_desc = txtHistoria.Text;
        bGaleriaArte.gale_nomb = txtTitulo.Text;
        bGaleriaArte.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        gGaleriaArte.Modificar(bGaleriaArte);
        gvGaleria.DataBind();
        limpiarInfo();
    }

    protected void gvGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idGaleriaArte = Convert.ToInt32(gvGaleria.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Galeria Arte";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bGaleriaArte = oGaleriaArte.ListarRegistro(idGaleriaArte);

        lblCodigo.Text = bGaleriaArte.gale_codi.ToString();
        txtTitulo.Text = bGaleriaArte.gale_nomb;
        ddlSede.SelectedValue = bGaleriaArte.sede_codi.ToString();
        txtHistoria.Text = bGaleriaArte.gale_desc;
        btnNuevo.Visible = false;
        gvGaleria.Visible = false;
        gvGaleriaDetalle.Visible = false;
        lblGaleriaArteDetalle.Visible = false;
        btnCTNuevo.Visible = false;
        
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idGaleriaArte = Convert.ToInt32(btnEliminar.CommandArgument);

        gGaleriaArte.Eliminar(idGaleriaArte);
        gvGaleria.DataBind();

    }

    void llenarDetalle(Int32 idGaleriaArte)
    {
        BEGaleriaArte iGaleriaArte = oGaleriaArte.ListarRegistro(idGaleriaArte);
        lblGaleriaArteDetalle.Text = "Detalle de " + iGaleriaArte.gale_nomb;
        List<BEGaleriaArteDetalle> listaDetalle = oGaleriaDetalle.ListarTodosDetalle(idGaleriaArte);
        gvGaleriaDetalle.DataSource = listaDetalle;
        gvGaleriaDetalle.DataBind();
    }
    protected void btnCTEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnCTEliminar = (ImageButton)sender;
        Int32 idGaleriaArteDetalle = Convert.ToInt32(btnCTEliminar.CommandArgument);
        bGaleriaArteDetalle = oGaleriaDetalle.ListarRegistro(idGaleriaArteDetalle);
        gGaleriaDetalle.Eliminar(idGaleriaArteDetalle);
        llenarDetalle(bGaleriaArteDetalle.gale_codi);
    }
    protected void gvGaleriaDetalle_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idGaleriaArteTemp = Convert.ToInt32(gvGaleriaDetalle.SelectedValue);
        //llena registro
        pCTNuevo.Visible = true;
        btnCTAgregar.Visible = false;
        btnCTGuardar.Visible = true;
        lblNombreSeccionTemp.Text = "Editar Detalle";
        lblCTCodigo.Visible = true;
        lbleCTCodigo.Visible = true;
        bGaleriaArteDetalle = oGaleriaDetalle.ListarRegistro(idGaleriaArteTemp);


        //cargamos info
        txtNombreGaleriaDetalle.Text = bGaleriaArteDetalle.gade_nomb;
      txtCTTemporada.Text = bGaleriaArteDetalle.gade_temp;
        //txtCTFechaInicio.Text = bGaleriaArteDetalle.gade_fini.ToShortDateString();
        //txtCTFechaFin.Text = bGaleriaArteDetalle.gade_ffin.ToShortDateString();
        txtContenido.Text = bGaleriaArteDetalle.gade_desc;
        lblCTCodigo.Text = bGaleriaArteDetalle.gade_codi.ToString();

        //chkDestacado.Checked = bGaleriaArteDetalle.gade_dest;
        //leer fechas
        if (bGaleriaArteDetalle.gade_lfec != null)
        {
            string[] split = bGaleriaArteDetalle.gade_lfec.Split(new char[] { ',' });
            //
            foreach (string strFecha in split)
            {
                listaFechas.Items.Add(strFecha);
            }

        }
        //

        bImagenURL = rutaUpload + bGaleriaArteDetalle.gade_imag;
        Session["img"] = bGaleriaArteDetalle.gade_imag;

        bImagenAgendaURL = rutaUpload + bGaleriaArteDetalle.gade_aimg;
        Session["aimg"] = bGaleriaArteDetalle.gade_aimg;
        img.Visible = true;
        aimg.Visible = true;
        img.ImageUrl = bImagenURL;
        aimg.ImageUrl = bImagenAgendaURL;

        btnCTNuevo.Visible = false;
        gvGaleriaDetalle.Visible = false;
        btnNuevo.Visible = false;
    }
    protected void btnCTNuevo_Click(object sender, ImageClickEventArgs e)
    {

       lblNombreSeccionTemp.Text = "Agregar Detalle";
        lblCTCodigo.Visible = false;
        lbleCTCodigo.Visible = false;
        pCTNuevo.Visible = true;
        btnCTAgregar.Visible = true;
        btnCTGuardar.Visible = false;
        btnCTNuevo.Visible = false;
        gvGaleriaDetalle.Visible = false;
        btnNuevo.Visible = false;
        img.Visible = false;
        aimg.Visible = false;
    }

    protected void btnCTAgregar_Click(object sender, ImageClickEventArgs e)
    {
         if (listaFechas.Items.Count > 0)
        {

        if (Session["idGaleriaArte"] != null)
        {
            bGaleriaArteDetalle.gale_codi = Convert.ToInt32(Session["idGaleriaArte"]);
            bGaleriaArteDetalle.gade_desc = txtContenido.Text;

            bGaleriaArteDetalle.gade_imag = fuGaleriaArteDetalle.FileName;
            bGaleriaArteDetalle.gade_nomb = txtNombreGaleriaDetalle.Text;
            bGaleriaArteDetalle.gade_temp = txtCTTemporada.Text;
         //   bGaleriaArteDetalle.gade_dest = chkDestacado.Checked;

            //guardamos fechas
            string arrayFechas = "";
            Int32 i = 0;
            List<DateTime> dFecha = new List<DateTime>();

            foreach (ListItem item in listaFechas.Items)
            {
                dFecha.Add(Convert.ToDateTime(item.Text));

                if (i != 0)
                    arrayFechas = arrayFechas + "," + item.Text;
                else
                    arrayFechas = item.Text;

                i++;

            }

            dFecha.Sort();
            Int32 uIndex = dFecha.Count - 1;



            bGaleriaArteDetalle.gade_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
            bGaleriaArteDetalle.gade_ffin = dFecha[uIndex];//Conv

            bGaleriaArteDetalle.gade_lfec = arrayFechas;
            //

            //guardar imagen

            if (fuGaleriaArteDetalle.PostedFile.ContentLength > 0)
            {
                guardaImagen(bGaleriaArteDetalle);

            }

            if (fuArchivoAgenda.PostedFile.ContentLength > 0)
            {
                guardaImagenAgenda(bGaleriaArteDetalle);
            }
           
            
            gGaleriaDetalle.Agregar(bGaleriaArteDetalle);
            llenarDetalle(bGaleriaArteDetalle.gale_codi);
            limpiarInfoDeta();
        }
        }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";
    }
    protected void btnCTGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (listaFechas.Items.Count > 0)
        {

        bGaleriaArteDetalle.gale_codi = Convert.ToInt32(Session["idGaleriaArte"]);
        bGaleriaArteDetalle.gade_desc = txtContenido.Text;

        bGaleriaArteDetalle.gade_imag = fuGaleriaArteDetalle.FileName;
        bGaleriaArteDetalle.gade_nomb = txtNombreGaleriaDetalle.Text;
        bGaleriaArteDetalle.gade_temp = txtCTTemporada.Text;
        bGaleriaArteDetalle.gade_codi = Convert.ToInt32(lblCTCodigo.Text);
    //    bGaleriaArteDetalle.gade_dest = chkDestacado.Checked;

        //guardamos fechas
        string arrayFechas = "";
        Int32 i = 0;
        List<DateTime> dFecha = new List<DateTime>();

        foreach (ListItem item in listaFechas.Items)
        {
            dFecha.Add(Convert.ToDateTime(item.Text));

            if (i != 0)
                arrayFechas = arrayFechas + "," + item.Text;
            else
                arrayFechas = item.Text;

            i++;

        }

        dFecha.Sort();
        Int32 uIndex = dFecha.Count - 1;



        bGaleriaArteDetalle.gade_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bGaleriaArteDetalle.gade_ffin = dFecha[uIndex];//Conv

        bGaleriaArteDetalle.gade_lfec = arrayFechas;
        //

    //    string nombreImagen=null;
 
        //guardar imagen
       // BEGaleriaArteDetalle eTemp = oGaleriaDetalle.ListarRegistro(bGaleriaArteDetalle.gade_codi);
        if (fuGaleriaArteDetalle.PostedFile.ContentLength > 0)
        {
            guardaImagen(bGaleriaArteDetalle);

        }
        else
        {
            if (Session["img"] != null)
            {
                bGaleriaArteDetalle.gade_imag = Session["img"].ToString();
              //  nombreImagen = rutaUnload + Session["img"].ToString();
            }
        }


    if (fuArchivoAgenda.PostedFile.ContentLength > 0)
    {
        guardaImagenAgenda(bGaleriaArteDetalle);
    }
    else
    {
        if (Session["aimg"] != null)
        bGaleriaArteDetalle.gade_aimg = Session["aimg"].ToString();

    }
        //if (nombreImagen != null)
        //eliminaImagen(nombreImagen);

        gGaleriaDetalle.Modificar(bGaleriaArteDetalle);
        llenarDetalle(bGaleriaArteDetalle.gale_codi);
        limpiarInfoDeta();
}
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";

    }
    protected void btnCTCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfoDeta();
    }
   
    protected void lnkGaleriaDetalle_Click(object sender, EventArgs e)
    {
        LinkButton lnkGaleriaDetalle = (LinkButton)sender;
        Int32 idGaleriaArte = Convert.ToInt32(lnkGaleriaDetalle.CommandArgument);
        Session["idGaleriaArte"] = idGaleriaArte.ToString();
        llenarDetalle(idGaleriaArte);
        btnCTNuevo.Visible = true;
        gvGaleriaDetalle.Visible = true;
        lblGaleriaArteDetalle.Visible = true;
       
    }


    void guardaImagen(BEGaleriaArteDetalle bGaleriaArteDetalle)
    {
        
        //guardar imagen
        //if (fuGaleriaArteDetalle.PostedFile.ContentLength > 0)
        //{
            long maximo = 204800;
            long tamanio = fuGaleriaArteDetalle.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bGaleriaArteDetalle.gade_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuGaleriaArteDetalle.PostedFile.FileName));
                    fuGaleriaArteDetalle.SaveAs(Server.MapPath(rutaUpload) + bGaleriaArteDetalle.gade_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

       // }
    }

    void guardaImagenAgenda(BEGaleriaArteDetalle bGaleriaArteDetalle)
    {

        //guardar imagen
        //if (fuArchivoAgenda.PostedFile.ContentLength > 0)
        //{
            long maximo = 204800;
            long tamanio = fuArchivoAgenda.FileContent.Length;

            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen Agenda excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bGaleriaArteDetalle.gade_aimg = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivoAgenda.PostedFile.FileName));
                    fuArchivoAgenda.SaveAs(Server.MapPath(rutaUpload) + bGaleriaArteDetalle.gade_aimg);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR Imagen Agenda: " + ex.Message.ToString();
                }

            }

       // }
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
    protected void gvGaleria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Int32 a = 100;

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    String desc = e.Row.Cells[2].Text;
        //    if (desc.Length < a)
        //    {
        //        a = desc.Length;
        //    }

        //    e.Row.Cells[2].Text = desc.Substring(0, a);


          
        //}
    }
    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idGaleriaDetalle = Convert.ToInt32(lnkDestacar.CommandArgument);
        bGaleriaArteDetalle = oGaleriaDetalle.ListarRegistro(idGaleriaDetalle);
        bGaleriaArteDetalle.gade_dest = true;
        gGaleriaDetalle.Modificar(bGaleriaArteDetalle);
        llenarDetalle(bGaleriaArteDetalle.gale_codi);
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkNoDestacar = (LinkButton)sender;
        Int32 idGaleriaDetalle = Convert.ToInt32(lnkNoDestacar.CommandArgument);
        bGaleriaArteDetalle = oGaleriaDetalle.ListarRegistro(idGaleriaDetalle);
        bGaleriaArteDetalle.gade_dest = false;
        gGaleriaDetalle.Modificar(bGaleriaArteDetalle);
        llenarDetalle(bGaleriaArteDetalle.gale_codi);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string strFecha;
        if (cFechas.SelectedDate.ToShortDateString() != "01/01/0001")
        {
            lblErrorFecha.Text = "";
            strFecha = cFechas.SelectedDate.ToShortDateString();

            listaFechas.Items.Add(strFecha);
        }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";

    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        Int32 index = listaFechas.SelectedIndex;
        listaFechas.Items.RemoveAt(index);
    }

}
