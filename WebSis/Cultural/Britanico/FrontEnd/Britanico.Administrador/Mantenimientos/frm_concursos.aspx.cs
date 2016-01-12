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

public partial class Mantenimientos_frm_concursos : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEConcurso bConcurso = new BEConcurso();
    BLConcursoNTAD oConcurso = new BLConcursoNTAD();
    BLConcursoTAD gConcurso = new BLConcursoTAD();
    BEConcursoTemporada bConcursoTemp = new BEConcursoTemporada();
    BLConcursoTemporadaNTAD oConcursoTemp = new BLConcursoTemporadaNTAD();
    BLConcursoTemporadaTAD gConcursoTemp = new BLConcursoTemporadaTAD();
    BLSedeNTAD oSede = new BLSedeNTAD();
    string bImagenURL;
    string bImagenAgendaURL;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Concurso";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvConcurso.Visible = false;
       
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
        txtContenido.Text = "";
        txtSubtitulo.Text = "";
        txtTitulo.Text = "";

        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvConcurso.Visible = true;
    }

    void limpiarInfoTemp()
    {
        ddlSede.Dispose();
        txtAnio.Text = "";
        //txtCTFechaInicio.Text = "";
        //txtCTFechaFin.Text = "";
        txtCTBases.Text = "";
        txtPremios.Text = "";
        txtCTTemporada.Text = "";
        txtResultados.Text = "";
        txtJurado.Text = "";
        fuConcursoTemporada.Dispose();
      //  chkDestacado.Dispose();
        lblCTCodigo.Text = "";
        pCTNuevo.Visible = false;
        listaFechas.Items.Clear();
        btnCTNuevo.Visible = true;
        gvConcursoTemporada.Visible = true;
        btnNuevo.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bConcurso.conc_desc = txtContenido.Text;
        bConcurso.conc_nomb = txtTitulo.Text;
        bConcurso.conc_subt = txtSubtitulo.Text;
        gConcurso.Agregar(bConcurso);
        gvConcurso.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bConcurso.conc_codi = Convert.ToInt32(lblCodigo.Text);
        bConcurso.conc_desc = txtContenido.Text;
        bConcurso.conc_nomb = txtTitulo.Text;
        bConcurso.conc_subt = txtSubtitulo.Text;
        gConcurso.Modificar(bConcurso);
        gvConcurso.DataBind();
        limpiarInfo();
    }

    protected void gvConcurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idConcurso = Convert.ToInt32(gvConcurso.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Concurso";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bConcurso = oConcurso.ListarRegistro(idConcurso);

        lblCodigo.Text = bConcurso.conc_codi.ToString();
        txtTitulo.Text = bConcurso.conc_nomb;
        txtSubtitulo.Text = bConcurso.conc_subt;
        txtContenido.Text = bConcurso.conc_desc;
        btnNuevo.Visible = false;
        gvConcurso.Visible = false;
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idConcurso = Convert.ToInt32(btnEliminar.CommandArgument);

        gConcurso.Eliminar(idConcurso);
        gvConcurso.DataBind();

    }
    protected void lnkTemporada_Click(object sender, EventArgs e)
    {
        LinkButton lnkTemporada = (LinkButton)sender;
        Int32 idConcurso = Convert.ToInt32(lnkTemporada.CommandArgument);
        Session["idConcurso"] = idConcurso.ToString();
        llenarTemporada(idConcurso);
        btnCTNuevo.Visible = true;
    }

    void llenarTemporada(Int32 idConcurso)
    {
        BEConcurso iConcurso = oConcurso.ListarRegistro(idConcurso);
        lblConcursoTemporada.Text = "Temporadas de " + iConcurso.conc_nomb;
        List<BEConcursoTemporada> listaTemp = oConcursoTemp.ListarTodos(idConcurso);
        gvConcursoTemporada.DataSource = listaTemp;
        gvConcursoTemporada.DataBind();
    }
    protected void btnCTEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnCTEliminar = (ImageButton)sender;
        Int32 idConcursoTemp = Convert.ToInt32(btnCTEliminar.CommandArgument);
        bConcursoTemp = oConcursoTemp.ListarRegistro(idConcursoTemp);
        gConcursoTemp.Eliminar(idConcursoTemp);
        llenarTemporada(bConcursoTemp.conc_codi);
    }
    protected void gvConcursoTemporada_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idConcursoTemp = Convert.ToInt32(gvConcursoTemporada.SelectedValue);
        //llena registro
        pCTNuevo.Visible = true;
        btnCTAgregar.Visible = false;
        btnCTGuardar.Visible = true;
        lblNombreSeccionTemp.Text = "Editar Temporada";
        lblCTCodigo.Visible = true;
        lbleCTCodigo.Visible = true;
        bConcursoTemp = oConcursoTemp.ListarRegistro(idConcursoTemp);


        //cargamos info
        List<BESede> listaSede = oSede.ListarTodos();
        ddlSede.DataSource = listaSede;

        ddlSede.DataTextField = "sede_nomb";
        ddlSede.DataValueField = "sede_codi";
        ddlSede.DataBind();
        ddlSede.SelectedValue = bConcursoTemp.sede_codi.ToString();

        txtAnio.Text = bConcursoTemp.ctem_anio;
        //txtCTFechaInicio.Text = bConcursoTemp.ctem_fini.ToShortDateString();
        //txtCTFechaFin.Text = bConcursoTemp.ctem_ffin.ToShortDateString();
        txtCTBases.Text = bConcursoTemp.ctem_base;
        txtPremios.Text = bConcursoTemp.ctem_prem;
        txtCTTemporada.Text = bConcursoTemp.ctem_temp;
        txtResultados.Text = bConcursoTemp.ctem_result;
        txtJurado.Text = bConcursoTemp.ctem_jura;
     //   chkDestacado.Checked = bConcursoTemp.ctem_dest;

        //leer fechas
        if (bConcursoTemp.ctem_lfec != null)
        {
            string[] split = bConcursoTemp.ctem_lfec.Split(new char[] { ',' });
            //
            foreach (string strFecha in split)
            {
                listaFechas.Items.Add(strFecha);
            }

        }
        //

        lblCTCodigo.Text = bConcursoTemp.ctem_codi.ToString();

        bImagenURL = rutaUpload + bConcursoTemp.ctem_imag;
        Session["img"] = bConcursoTemp.ctem_imag;

        bImagenAgendaURL = rutaUpload + bConcursoTemp.ctem_aimg;
        Session["aimg"] = bConcursoTemp.ctem_aimg;
        img.Visible = true;
        aimg.Visible = true;
        img.ImageUrl = bImagenURL;
        aimg.ImageUrl = bImagenAgendaURL;

        btnCTNuevo.Visible = false;
        gvConcursoTemporada.Visible = false;
        btnNuevo.Visible = false;
    }
    protected void btnCTNuevo_Click(object sender, ImageClickEventArgs e)
    {

        lblNombreSeccionTemp.Text = "Agregar Temporada";
        lblCTCodigo.Visible = false;
        lbleCTCodigo.Visible = false;
        pCTNuevo.Visible = true;
        //cargamos info
        List<BESede> listaSede = oSede.ListarTodos();
        ddlSede.DataSource = listaSede;

        ddlSede.DataTextField = "sede_nomb";
        ddlSede.DataValueField = "sede_codi";
        ddlSede.DataBind();
        btnNuevo.Visible = false;
        btnCTAgregar.Visible = true;
        btnCTGuardar.Visible = false;
        btnCTNuevo.Visible = false;
        gvConcursoTemporada.Visible = false;
        img.Visible = false;
        aimg.Visible = false;
    }

    protected void btnCTAgregar_Click(object sender, ImageClickEventArgs e)
    {
        if (listaFechas.Items.Count > 0)
        {
        if (Session["idConcurso"] != null)
        {
            bConcursoTemp.conc_codi = Convert.ToInt32(Session["idConcurso"]);
            bConcursoTemp.ctem_anio = txtAnio.Text;
            bConcursoTemp.ctem_base = txtCTBases.Text;
          //  bConcursoTemp.ctem_dest = chkDestacado.Checked;

            bConcursoTemp.ctem_imag = fuConcursoTemporada.FileName;
            bConcursoTemp.ctem_jura = txtJurado.Text;
            bConcursoTemp.ctem_prem = txtPremios.Text;
            bConcursoTemp.ctem_result = txtResultados.Text;
            bConcursoTemp.ctem_temp = txtCTTemporada.Text;
            bConcursoTemp.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);

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



            bConcursoTemp.ctem_ffin = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
            bConcursoTemp.ctem_fini = dFecha[uIndex];//Conv

            bConcursoTemp.ctem_lfec = arrayFechas;
            //

            guardaImagen(bConcursoTemp);
            guardaImagenAgenda(bConcursoTemp);
            gConcursoTemp.Agregar(bConcursoTemp);
            llenarTemporada(bConcursoTemp.conc_codi);
            limpiarInfoTemp();

             }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";
        }
    }
    protected void btnCTGuardar_Click(object sender, ImageClickEventArgs e)
    {
 if (listaFechas.Items.Count > 0)
        {
        bConcursoTemp.conc_codi = Convert.ToInt32(Session["idConcurso"]);
        bConcursoTemp.ctem_anio = txtAnio.Text;
        bConcursoTemp.ctem_base = txtCTBases.Text;
       // bConcursoTemp.ctem_dest = chkDestacado.Checked;

        bConcursoTemp.ctem_imag = fuConcursoTemporada.FileName;
        bConcursoTemp.ctem_jura = txtJurado.Text;
        bConcursoTemp.ctem_prem = txtPremios.Text;
        bConcursoTemp.ctem_result = txtResultados.Text;
        bConcursoTemp.ctem_temp = txtCTTemporada.Text;
        bConcursoTemp.sede_codi = Convert.ToInt32(ddlSede.SelectedValue);
        bConcursoTemp.ctem_codi = Convert.ToInt32(lblCTCodigo.Text);

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



        bConcursoTemp.ctem_ffin = dFecha[0];//Convert.ToDateTime(txtFechaInicio.Text);
        bConcursoTemp.ctem_fini = dFecha[uIndex];//Conv


        bConcursoTemp.ctem_lfec = arrayFechas;
        //
       
     //   string nombreImagen=null;
      
      

       // BEConcursoTemporada eTemp = oConcursoTemp.ListarRegistro(bConcursoTemp.ctem_codi);
    if (fuConcursoTemporada.PostedFile.ContentLength > 0)
    {

        guardaImagen(bConcursoTemp);
    }
    else
    {
        if (Session["img"] != null)
        {
            bConcursoTemp.ctem_imag = Session["img"].ToString();
         //   nombreImagen = rutaUnload + Session["img"].ToString();

        }
    }

    if (fuArchivoAgenda.PostedFile.ContentLength > 0)
    {
        guardaImagenAgenda(bConcursoTemp);
    }
    else 
    {
        if (Session["aimg"] != null)
            bConcursoTemp.ctem_aimg = Session["aimg"].ToString();
    
    }
        //if (nombreImagen != null)
        //eliminaImagen(nombreImagen);

        gConcursoTemp.Modificar(bConcursoTemp);
        llenarTemporada(bConcursoTemp.conc_codi);
        limpiarInfoTemp();

 }
        else
            lblErrorFecha.Text = "*Seleccione fecha a agregar";

    }
    protected void btnCTCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfoTemp();
    }
    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 idConcursoTemp = Convert.ToInt32(lnkDestacar.CommandArgument);
        bConcursoTemp = oConcursoTemp.ListarRegistro(idConcursoTemp);
        bConcursoTemp.ctem_dest = true;
        gConcursoTemp.Modificar(bConcursoTemp);
        llenarTemporada(bConcursoTemp.conc_codi);
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkNoDestacar = (LinkButton)sender;
        Int32 idConcursoTemp = Convert.ToInt32(lnkNoDestacar.CommandArgument);
        bConcursoTemp = oConcursoTemp.ListarRegistro(idConcursoTemp);
        bConcursoTemp.ctem_dest = false;
        gConcursoTemp.Modificar(bConcursoTemp);
        llenarTemporada(bConcursoTemp.conc_codi);
    }

    void guardaImagen(BEConcursoTemporada bConcursoTemp)
    {
        //guardar imagen
        //if (fuConcursoTemporada.PostedFile.ContentLength > 0)
        //{
            long maximo = 204800;
            long tamanio = fuConcursoTemporada.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bConcursoTemp.ctem_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuConcursoTemporada.PostedFile.FileName));
                    fuConcursoTemporada.SaveAs(Server.MapPath(rutaUpload) + bConcursoTemp.ctem_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

     //   }
    }

    void guardaImagenAgenda(BEConcursoTemporada bConcursoTemp)
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
                    bConcursoTemp.ctem_aimg = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivoAgenda.PostedFile.FileName));
                    fuArchivoAgenda.SaveAs(Server.MapPath(rutaUpload) + bConcursoTemp.ctem_aimg);
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

    protected void gvConcurso_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[3].Text;
            if (desc.Length < a)
            {
                a = desc.Length;
            }

            e.Row.Cells[3].Text = desc.Substring(0, a);

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
