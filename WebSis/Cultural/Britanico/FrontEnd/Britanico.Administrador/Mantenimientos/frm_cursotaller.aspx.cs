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

public partial class Mantenimientos_frm_cursotaller : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BECursoTaller bCurso = new BECursoTaller();
    BLCursoTallerNTAD oCurso = new BLCursoTallerNTAD();
    BLCursoTallerTAD gCurso = new BLCursoTallerTAD();
    string bImagenURL;
    string bImagenAgendaURL;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void limpiarInfo()
    {
        lblCodigo.Text = "";
        ddlSede.Dispose();
        ddlSegmento.Dispose();
        txtNombre.Text = "";
        txtDescripcion.Text ="";
      //  txtInformes.Text = "";
      //  txtFechaInicio.Text = "";
       // txtFechaFin.Text = "";
       txtHorario.Text = "";
        txtDirige.Text = "";
        txtSubtitulo.Text = "";
       // txtPrecio.Text = "";
        txtProfesor.Text = "";
        listaFechas.Items.Clear();
        fuCurso.Dispose();
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
      //  chkDestacado.Checked = false;
        gvCurso.Visible = true;
    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idCurso = Convert.ToInt32(btnEliminar.CommandArgument);
        gCurso.Eliminar(idCurso);
        gvCurso.DataBind();
    }
  
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Curso Taller";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvCurso.Visible = false;
        img.Visible = false;
        aimg.Visible = false;
    }


    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }
    protected void gvCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idCurso = Convert.ToInt32(gvCurso.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Curso Taller";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bCurso = oCurso.ListarRegistro(idCurso);

        lblCodigo.Text = bCurso.curs_codi.ToString();
        ddlSede.SelectedValue = bCurso.sede_codi.ToString();
        ddlSegmento.SelectedValue = bCurso.segm_codi.ToString();
        txtNombre.Text = bCurso.curs_titu;
        txtDescripcion.Text = bCurso.curs_desc;
     //   txtInformes.Text = bCurso.curs_info;
        //txtFechaInicio.Text = bCurso.curs_fini.ToShortDateString();
        //txtFechaFin.Text = bCurso.curs_ffin.ToShortDateString();
        txtHorario.Text = bCurso.curs_hora;
        txtDirige.Text = bCurso.curs_diri;
        txtSubtitulo.Text = bCurso.curs_prev;
       // txtPrecio.Text = bCurso.curs_prec.ToString();
        txtProfesor.Text = bCurso.curs_prof;
       // chkDestacado.Checked = bCurso.curs_dest;
       //leer fechas
        if (bCurso.curs_lfec != null)
        {
            string[] split = bCurso.curs_lfec.Split(new char[] { ',' });
            //
            foreach (string strFecha in split)
            {
                listaFechas.Items.Add(strFecha);
            }
           
        }
        //
        bImagenURL = rutaUpload + bCurso.curs_imag;
        Session["img"] = bCurso.curs_imag;

        bImagenAgendaURL = rutaUpload + bCurso.curs_aimg;
        Session["aimg"] = bCurso.curs_aimg;
        img.Visible = true;
        aimg.Visible = true;
        img.ImageUrl = bImagenURL;
        aimg.ImageUrl = bImagenAgendaURL;

        btnNuevo.Visible = false;
        gvCurso.Visible = false;
        


    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        if (listaFechas.Items.Count>0)
        {
            lblErrorFecha.Text = "";
         bCurso.sede_codi=Convert.ToInt32(ddlSede.SelectedValue);
         bCurso.segm_codi= Convert.ToInt32(ddlSegmento.SelectedValue);
         bCurso.curs_titu= txtNombre.Text;
         bCurso.curs_desc= txtDescripcion.Text;
         bCurso.curs_info ="";

         bCurso.curs_hora = txtHorario.Text;
         bCurso.curs_diri = txtDirige.Text;
         bCurso.curs_prev = txtSubtitulo.Text;
         bCurso.curs_prec = 0;
         bCurso.curs_prof = txtProfesor.Text;
       //  bCurso.curs_dest = chkDestacado.Checked;
        //guardamos fechas
         string arrayFechas ="";
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



         bCurso.curs_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
         bCurso.curs_ffin = dFecha[uIndex];//Convert.ToDateTime(txtFechaFin.Text);

         bCurso.curs_lfec = arrayFechas;

        //
         //guardar imagen
         if (fuCurso.PostedFile.ContentLength > 0)
         {
             guardaImagen(bCurso);
         }
         if (fuArchivoAgenda.PostedFile.ContentLength > 0)
         {
             guardaImagenAgenda(bCurso);
         }

        gCurso.Agregar(bCurso);
        gvCurso.DataBind();
        limpiarInfo();

    }
    else
        lblErrorFecha.Text = "*Seleccione fecha a agregar";

    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (listaFechas.Items.Count > 0)
        {
            lblErrorFecha.Text = "";
            bCurso.curs_codi = Convert.ToInt32(lblCodigo.Text);
            bCurso.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
            bCurso.segm_codi = Convert.ToInt32(ddlSegmento.SelectedValue);
            bCurso.curs_titu = txtNombre.Text;
            bCurso.curs_desc = txtDescripcion.Text;
            bCurso.curs_info = "";

            bCurso.curs_hora = txtHorario.Text;
            bCurso.curs_diri = txtDirige.Text;
            bCurso.curs_prev = txtSubtitulo.Text;
            bCurso.curs_prec = 0;
            bCurso.curs_prof = txtProfesor.Text;
          //  bCurso.curs_dest = chkDestacado.Checked;
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



            bCurso.curs_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
            bCurso.curs_ffin = dFecha[uIndex];//Convert.ToDateTime(txtFechaFin.Text);


            bCurso.curs_lfec = arrayFechas;
            //

            //string nombreImagen=null;



            //guardar imagen
            // BECursoTaller eCurso = oCurso.ListarRegistro(bCurso.curs_codi);
            if (fuCurso.PostedFile.ContentLength > 0)
            {
                guardaImagen(bCurso);
            }
            else
            {
                if (Session["img"] != null)
                {
                    bCurso.curs_imag = Session["img"].ToString();
                    // nombreImagen = rutaUnload + Session["img"].ToString();

                }
            }


            if (fuArchivoAgenda.PostedFile.ContentLength > 0)
            {
                guardaImagenAgenda(bCurso);
            }
            else
            {
                if (Session["aimg"] != null)
                    bCurso.curs_aimg = Session["aimg"].ToString();

            }


            //if (nombreImagen != null)
            //eliminaImagen(nombreImagen);

            gCurso.Modificar(bCurso);
            gvCurso.DataBind();
            limpiarInfo();

        }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";


      
    }


    void guardaImagen(BECursoTaller bCurso)
    {

        //guardar imagen
        //if (fuCurso.PostedFile.ContentLength > 0)
        //{
            long maximo = 204800;
            long tamanio = fuCurso.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                   bCurso.curs_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuCurso.PostedFile.FileName));
                    fuCurso.SaveAs(Server.MapPath(rutaUpload) + bCurso.curs_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

       // }
    }

    void guardaImagenAgenda(BECursoTaller bCurso)
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
                    bCurso.curs_aimg = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivoAgenda.PostedFile.FileName));
                    fuArchivoAgenda.SaveAs(Server.MapPath(rutaUpload) + bCurso.curs_aimg);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR Imagen Agenda: " + ex.Message.ToString();
                }

            }

      //  }
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
    protected void gvCurso_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[2].Text;
            if (desc.Length < a)
            {
                a = desc.Length;
            }

            e.Row.Cells[2].Text = desc.Substring(0, a);

        }
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkNoDestacar = (LinkButton)sender;
        Int32 idCurso = Convert.ToInt32(lnkNoDestacar.CommandArgument);
        bCurso = oCurso.ListarRegistro(idCurso);
        bCurso.curs_dest = false;
        gCurso.Modificar(bCurso);
        gvCurso.DataBind();
    }
    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idCurso = Convert.ToInt32(lnkDestacar.CommandArgument);
        bCurso = oCurso.ListarRegistro(idCurso);
        bCurso.curs_dest = true;
        gCurso.Modificar(bCurso);
        gvCurso.DataBind();
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
