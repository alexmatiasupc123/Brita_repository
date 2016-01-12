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
using Britanico.Utilitario.Funciones;

public partial class Mantenimientos_frm_programacionauditorio : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();
    Funciones funcion = new Funciones();
    BEProgramacionAuditorio bProgramacion = new BEProgramacionAuditorio();
    BLProgramacionAuditorioNTAD oProgramacion = new BLProgramacionAuditorioNTAD();
    BLProgramacionAuditorioTAD gProgramacion = new BLProgramacionAuditorioTAD();

    string bImagenURL;
    string bImagenAgendaURL;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void limpiarInfo()
    {
        ddlSede.Dispose();
        txtNombre.Text = "";
        txtDescripcion.Text = "";
        //txtDetalle.Text = "";
        //txtFechaInicio.Text = "";
        //txtFechaFin.Text = "";
        txtTemporada.Text = "";
       // chkDestacado.Checked = false;
        listaFechas.Items.Clear();
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvProgramacion.Visible = true;
    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idProgramacion = Convert.ToInt32(btnEliminar.CommandArgument);
        bProgramacion = oProgramacion.ListarRegistro(idProgramacion);
        string nombreImagen = rutaUnload + bProgramacion.prog_imag;
        gProgramacion.Eliminar(idProgramacion);
        eliminaImagen(nombreImagen);
        gvProgramacion.DataBind();


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

    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idProgramacion = Convert.ToInt32(lnkDestacar.CommandArgument);
        bProgramacion = oProgramacion.ListarRegistro(idProgramacion);
        bProgramacion.prog_dest = true;
        gProgramacion.Modificar(bProgramacion);
        gvProgramacion.DataBind();
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idProgramacion = Convert.ToInt32(lnkDestacar.CommandArgument);
        bProgramacion = oProgramacion.ListarRegistro(idProgramacion);
        bProgramacion.prog_dest = false;
        gProgramacion.Modificar(bProgramacion);
        gvProgramacion.DataBind();
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Programación Auditorio";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvProgramacion.Visible = false;
        img.Visible = false;
        aimg.Visible = false;
    }


    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }
    protected void gvProgramacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProgramacion = Convert.ToInt32(gvProgramacion.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Programación Auditorio";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bProgramacion = oProgramacion.ListarRegistro(idProgramacion);
        btnNuevo.Visible = false;
        lblCodigo.Text = bProgramacion.prog_codi.ToString();
        ddlSede.SelectedValue = bProgramacion.sede_codi.ToString();
        txtNombre.Text = bProgramacion.prog_titu;
        txtDescripcion.Text = bProgramacion.prog_desc;
       // txtDetalle.Text = bProgramacion.prog_deta;
        //txtFechaInicio.Text = bProgramacion.prog_fini.ToShortDateString();
        //txtFechaFin.Text = bProgramacion.prog_ffin.ToShortDateString();
       txtTemporada.Text = bProgramacion.prog_temp;
       // chkDestacado.Checked = bProgramacion.prog_dest;

        //leer fechas
        if (bProgramacion.prog_lfec != null)
        {
            string[] split = bProgramacion.prog_lfec.Split(new char[] { ',' });
            //
            foreach (string strFecha in split)
            {
                listaFechas.Items.Add(strFecha);
            }

        }
        //

        bImagenURL = rutaUpload + bProgramacion.prog_imag;
        Session["img"] = bProgramacion.prog_imag;

        bImagenAgendaURL = rutaUpload + bProgramacion.prog_aimg;
        Session["aimg"] = bProgramacion.prog_aimg;
        img.Visible = true;
        aimg.Visible = true;
        img.ImageUrl = bImagenURL;
        aimg.ImageUrl = bImagenAgendaURL;


        gvProgramacion.Visible = false;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
          if (listaFechas.Items.Count > 0)
        {
        bProgramacion.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        bProgramacion.prog_titu = txtNombre.Text;
        bProgramacion.prog_desc = txtDescripcion.Text;

        bProgramacion.prog_temp = txtTemporada.Text;
        bProgramacion.prog_deta = "";
       // bProgramacion.prog_dest = chkDestacado.Checked;
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



        bProgramacion.prog_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bProgramacion.prog_ffin = dFecha[uIndex];//Convert.ToDateTime(txtFechaFin.Text);


        bProgramacion.prog_lfec = arrayFechas;
        //
        //guardar imagen
        if (fuImagen.PostedFile.ContentLength > 0)
        {
            guardaImagen(bProgramacion);
        }
       

        if (fuArchivoAgenda.PostedFile.ContentLength > 0)
        {
            guardaImagenAgenda(bProgramacion);
        }
       
        gProgramacion.Agregar(bProgramacion);
        gvProgramacion.DataBind();
  
        limpiarInfo();
    }
    else
        lblErrorFecha.Text = "*Seleccione fecha a agregar";
    }

    void guardaImagen(BEProgramacionAuditorio bProgramacion)
    {

        //guardar imagen
        //if (fuImagen.PostedFile.ContentLength > 0)
        //{
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
                  bProgramacion.prog_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                  fuImagen.SaveAs(Server.MapPath(rutaUpload) + bProgramacion.prog_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        //}
       
    }

    void guardaImagenAgenda(BEProgramacionAuditorio bProgramacion)
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
                    bProgramacion.prog_aimg = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivoAgenda.PostedFile.FileName));
                    fuArchivoAgenda.SaveAs(Server.MapPath(rutaUpload) + bProgramacion.prog_aimg);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR Imagen Agenda: " + ex.Message.ToString();
                }

            }

        //}
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        if (listaFechas.Items.Count > 0)
        {
        bProgramacion.prog_codi = Convert.ToInt32(lblCodigo.Text);
        bProgramacion.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        bProgramacion.prog_titu = txtNombre.Text;
        bProgramacion.prog_desc = txtDescripcion.Text;
        bProgramacion.prog_deta = "";

        bProgramacion.prog_temp = txtTemporada.Text;
       // bProgramacion.prog_dest = chkDestacado.Checked;

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



        bProgramacion.prog_fini = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bProgramacion.prog_ffin = dFecha[uIndex];//Convert.ToDateTime(txtFechaFin.Text);


        bProgramacion.prog_lfec = arrayFechas;
        //

       // string nombreImagen=null;
       
     

        if (fuImagen.PostedFile.ContentLength > 0)
        {
            guardaImagen(bProgramacion);
        }
        else
        {
            if (Session["img"] != null)
            {
                bProgramacion.prog_imag = Session["img"].ToString();
                //nombreImagen = rutaUnload + Session["img"].ToString();
            }
        }


        if (fuArchivoAgenda.PostedFile.ContentLength > 0)
        {
            guardaImagenAgenda(bProgramacion);
        }
        else
        {
            if (Session["aimg"] != null)
                bProgramacion.prog_aimg = Session["aimg"].ToString();
        }
       
        //if (nombreImagen != null)
        //eliminaImagen(nombreImagen);

        gProgramacion.Modificar(bProgramacion);
        gvProgramacion.DataBind();
        limpiarInfo();

        }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";
    }
    protected void gvProgramacion_RowDataBound(object sender, GridViewRowEventArgs e)
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
