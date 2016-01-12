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

public partial class Mantenimientos_frm_actividadteatro : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEActividadTeatro bActividad = new BEActividadTeatro();
    BLActividadTeatroNTAD oActividad = new BLActividadTeatroNTAD();
    BLActividadTeatroTAD gActividad = new BLActividadTeatroTAD();
    string bImagenURL;
    string bImagenAgendaURL;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void limpiarInfo()
    {
        ddlSede.Dispose();
        ddlSegmento.Dispose();
        txtNombre.Text = "";
        txtDescripcion.Text = "";
        //txtFechaInicio.Text ="";
        //txtFechaFin.Text = "";
        txtTemporada.Text = "";
      //  txtEntrada.Text ="";
        listaFechas.Items.Clear();
        txtSubtitulo.Text = "";
       // chkDestacado.Checked=false;
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvActividades.Visible = true;

    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idActividad = Convert.ToInt32(btnEliminar.CommandArgument);
        bActividad = oActividad.ListarRegistro(idActividad);
        string nombreImagen = rutaUnload + bActividad.teat_imag;

        
        gActividad.Eliminar(idActividad);

        if (nombreImagen.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(nombreImagen);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }

        gvActividades.DataBind();
    }
    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idActividad = Convert.ToInt32(lnkDestacar.CommandArgument);
        bActividad = oActividad.ListarRegistro(idActividad);
        bActividad.teat_dest = true;
        gActividad.Modificar(bActividad);
        gvActividades.DataBind();
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idActividad = Convert.ToInt32(lnkDestacar.CommandArgument);
        bActividad = oActividad.ListarRegistro(idActividad);
        bActividad.teat_dest = false;
        gActividad.Modificar(bActividad);
        gvActividades.DataBind();
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Actividad Teatral";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvActividades.Visible = false;
        img.Visible = false;
        aimg.Visible = false;

    }


    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }
    protected void gvActividades_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idActividad = Convert.ToInt32(gvActividades.SelectedValue);

        //llena registro
        pNuevo.Visible = true;
        btnNuevo.Visible = false;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text= "Editar Actividad Teatral";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bActividad = oActividad.ListarRegistro(idActividad);
        bImagenURL = rutaUpload +bActividad.teat_imag;
        Session["img"] = bActividad.teat_imag;

        bImagenAgendaURL = rutaUpload + bActividad.teat_aimg;
        Session["aimg"] = bActividad.teat_aimg;

        lblCodigo.Text = bActividad.teat_codi.ToString();
        ddlSede.SelectedValue = bActividad.sede_codi.ToString();
        ddlSegmento.SelectedValue = bActividad.segm_codi.ToString();
        txtNombre.Text = bActividad.teat_titu;
        txtDescripcion.Text = bActividad.teat_desc;
        //txtFechaInicio.Text = DateTime.Today.Date;//bActividad.teat_init.ToShortDateString();
        //txtFechaFin.Text = DateTime.Today.Date;//bActividad.teat_fint.ToShortDateString();
        txtTemporada.Text = bActividad.teat_temp;
       // chkDestacado.Checked = bActividad.teat_dest;

        //leer fechas
        if (bActividad.teat_lfec != null)
        {
            string[] split = bActividad.teat_lfec.Split(new char[] { ',' });
            //
            foreach (string strFecha in split)
            {
                listaFechas.Items.Add(strFecha);
            }

        }
        //

        txtSubtitulo.Text = bActividad.teat_subt;
        img.ImageUrl = bImagenURL;
        aimg.ImageUrl = bImagenAgendaURL;

        img.Visible = true;
        aimg.Visible = true;
        gvActividades.Visible = false;

    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
         if (listaFechas.Items.Count > 0)
        {

        bActividad.sede_codi= Convert.ToInt32(ddlSede.SelectedValue);
        bActividad.segm_codi = Convert.ToInt32(ddlSegmento.SelectedValue);
        bActividad.teat_titu = txtNombre.Text;
        bActividad.teat_desc =txtDescripcion.Text;

        bActividad.teat_subt = txtSubtitulo.Text;
        bActividad.teat_temp =txtTemporada.Text;
        bActividad.teat_entr ="";
      //  bActividad.teat_dest= chkDestacado.Checked;

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



        bActividad.teat_init = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bActividad.teat_fint = dFecha[uIndex];//Conv

        bActividad.teat_lfec = arrayFechas;
        //

        //guardar imagen
        if (fuTeatro.PostedFile.ContentLength > 0)
        {
            guardaImagen(bActividad);
        }
       
        if (fuArchivoAgenda.PostedFile.ContentLength > 0)
        {
            guardaImagenAgenda(bActividad);
        }
        
        gActividad.Agregar(bActividad);
        gvActividades.DataBind();
        limpiarInfo();
    }
    else
        lblErrorFecha.Text = "*Seleccione fecha a agregar";
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
         if (listaFechas.Items.Count > 0)
        {

        bActividad.teat_codi = Convert.ToInt32(lblCodigo.Text);
        bActividad.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        bActividad.segm_codi = Convert.ToInt32(ddlSegmento.SelectedValue);
        bActividad.teat_titu = txtNombre.Text;
        bActividad.teat_desc = txtDescripcion.Text;

        bActividad.teat_temp = txtTemporada.Text;
        bActividad.teat_entr = "";
       // bActividad.teat_dest = chkDestacado.Checked;
        bActividad.teat_subt = txtSubtitulo.Text;

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



        bActividad.teat_init = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bActividad.teat_fint = dFecha[uIndex];//Conv

        bActividad.teat_lfec = arrayFechas;
        //

       //  string nombreImagen=null;
        

        
        //guardar imagen
       // BEActividadTeatro eActividad = oActividad.ListarRegistro(bActividad.teat_codi);
    if (fuTeatro.PostedFile.ContentLength > 0)
    {
        guardaImagen(bActividad);
    }
    else
    {
        if (Session["img"] != null)
        {
            bActividad.teat_imag = Session["img"].ToString();
          //  nombreImagen = rutaUnload + Session["img"].ToString();

        }
    }
    if (fuArchivoAgenda.PostedFile.ContentLength > 0)
    {
        guardaImagenAgenda(bActividad);
    }
    else
    {
        if (Session["aimg"] != null)
            bActividad.teat_aimg = Session["aimg"].ToString();

    }
        //if (nombreImagen != null)
        //eliminaImagen(nombreImagen);

        gActividad.Modificar(bActividad);
        gvActividades.DataBind();
        limpiarInfo();
              }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";
    }
    

    void guardaImagen(BEActividadTeatro bActividad)
    {
        
        //guardar imagen
        //if (fuTeatro.PostedFile.ContentLength > 0)
        //{
            long maximo = 204800;
            long tamanio = fuTeatro.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bActividad.teat_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuTeatro.PostedFile.FileName));
                    fuTeatro.SaveAs(Server.MapPath(rutaUpload) + bActividad.teat_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR Imagen: " + ex.Message.ToString();
                }

            }

       // }
    }

    void guardaImagenAgenda(BEActividadTeatro bActividad)
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
                    bActividad.teat_aimg = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivoAgenda.PostedFile.FileName));
                    fuArchivoAgenda.SaveAs(Server.MapPath(rutaUpload) + bActividad.teat_aimg);
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
    protected void gvActividades_RowCreated(object sender, GridViewRowEventArgs e)
    {
       

    }
    protected void gvActividades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;
  
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[2].Text;
            if (desc.Length < a)
            { 
                a=desc.Length;
            }

            e.Row.Cells[2].Text = desc.Substring(0, a);

    
        }

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
