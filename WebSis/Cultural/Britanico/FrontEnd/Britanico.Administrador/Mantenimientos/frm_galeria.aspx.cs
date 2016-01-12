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

public partial class Mantenimientos_frm_galeria : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BLActividadTeatroNTAD oActividad = new BLActividadTeatroNTAD();
    BLProgramacionAuditorioNTAD oAuditorio = new BLProgramacionAuditorioNTAD();
    BLConcursoTemporadaNTAD oConcursoTemporrada = new BLConcursoTemporadaNTAD();
    BLGaleriaArteDetalleNTAD oGaleriaDetalle = new BLGaleriaArteDetalleNTAD();
    BEConcurso bConcurso = new BEConcurso();
    BLConcursoNTAD oConcurso = new BLConcursoNTAD();
    BEGaleriaArte bGaleria = new BEGaleriaArte();
    BLGaleriaArteNTAD oGaleria = new BLGaleriaArteNTAD();
    BEGaleriaArchivo bGaleriaArchivo = new BEGaleriaArchivo();
    BECursoTaller bCursos = new BECursoTaller();
    BLCursoTallerNTAD oCurso = new BLCursoTallerNTAD();
    BEHistoriaTeatro bHistoriaTeatro = new BEHistoriaTeatro();
    BLHistoriaTeatroNTAD oHistoriaTeatro = new BLHistoriaTeatroNTAD();
    BEProducciones bProducciones = new BEProducciones();
    BLProduccionesNTAD oProducciones = new BLProduccionesNTAD();
    BLGaleriaArchivoNTAD oGaleriaArchivo = new BLGaleriaArchivoNTAD();
    BLGaleriaArchivoTAD gGaleriaArchivo = new BLGaleriaArchivoTAD();
    Int32 tipoEvento;
    Int32 galeria;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            tipoEvento = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
            cargaGaleria(tipoEvento);
            if (ddlGaleria.SelectedValue != "")
            {
                galeria = Convert.ToInt32(ddlGaleria.SelectedValue);
                lblTituloGaleria.Text = ddlGaleria.SelectedItem.Text;
            }
            else
                lblTituloGaleria.Text = "";

        }
 
    }

    void cargaGaleria(Int32 tipoEvento)
    {
        switch (tipoEvento)
        {
            case 1:
                List<BEProgramacionAuditorio> listaAuditorio = oAuditorio.ListarTodos();
                if (listaAuditorio.Count > 0)
                {
                    ddlGaleria.DataSource = listaAuditorio;
                    ddlGaleria.DataValueField = "prog_codi";
                    ddlGaleria.DataTextField = "prog_titu";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();

                break;
            case 2:
                
                List<BEActividadTeatro> listaTeatro = oActividad.ListarTodos();
                if (listaTeatro.Count > 0)
                {
                    ddlGaleria.DataSource = listaTeatro;
                    ddlGaleria.DataValueField = "teat_codi";
                    ddlGaleria.DataTextField = "teat_titu";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();

                break;
            case 3:
                List<BEConcursoTemporada> listaTemporada = oConcursoTemporrada.ListarTodos();
             
                if (listaTemporada.Count > 0)
                {
                    foreach (BEConcursoTemporada iTemporada in listaTemporada)
                    {
                        bConcurso = oConcurso.ListarRegistro(iTemporada.conc_codi);
                        iTemporada.ctem_anio = bConcurso.conc_nomb + " - " + iTemporada.ctem_anio;
                    }

                    ddlGaleria.DataSource = listaTemporada;
                    ddlGaleria.DataValueField = "ctem_codi";
                    ddlGaleria.DataTextField = "ctem_anio";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();
               


                break;
            case 4:
                List<BEGaleriaArteDetalle> listaDetalle = oGaleriaDetalle.ListarTodos();
                if (listaDetalle.Count > 0)
                {
                    foreach (BEGaleriaArteDetalle iDetalle in listaDetalle)
                    {
                        bGaleria = oGaleria.ListarRegistro(iDetalle.gale_codi);
                        iDetalle.gade_nomb = bGaleria.gale_nomb + " - " + iDetalle.gade_nomb;
                    }
                    ddlGaleria.DataSource = listaDetalle;
                    ddlGaleria.DataValueField = "gade_codi";
                    ddlGaleria.DataTextField = "gade_nomb";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();


                break;

            case 5:
                List<BECursoTaller> listaCursos = oCurso.ListarTodos();
                if (listaCursos.Count > 0)
                {
                    ddlGaleria.DataSource = listaCursos;
                    ddlGaleria.DataValueField = "curs_codi";
                    ddlGaleria.DataTextField = "curs_titu";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();

                break;

            case 6:
                List<BEHistoriaTeatro> listaHistoriaTeatro = oHistoriaTeatro.ListarTodos();
                if (listaHistoriaTeatro.Count > 0)
                {
                    ddlGaleria.DataSource = listaHistoriaTeatro;
                    ddlGaleria.DataValueField = "histo_codi";
                    ddlGaleria.DataTextField = "histo_titu";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();

                break;

            case 7:
                List<BEProducciones> listaProducciones = oProducciones.ListarTodos();
                if (listaProducciones.Count > 0)
                {
                    ddlGaleria.DataSource = listaProducciones;
                    ddlGaleria.DataValueField = "prod_codi";
                    ddlGaleria.DataTextField = "prod_nomb";
                    ddlGaleria.DataBind();
                }
                else
                    ddlGaleria.Items.Clear();

                break;
            default:
                break;
        }


    }

    protected void ddlTipoGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {

        tipoEvento = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
        cargaGaleria(tipoEvento);
        if (ddlGaleria.SelectedValue != "")
        {
            galeria = Convert.ToInt32(ddlGaleria.SelectedValue);
            lblTituloGaleria.Text = ddlGaleria.SelectedItem.Text;
            gvGaleria.DataBind();
        }
        else
            lblTituloGaleria.Text = "";


    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        pNuevo.Visible = true;
        btnNuevo.Visible = false;
        btnAgregar.Visible = true;
        lblECodigo.Visible = false;
        lblCodigo.Visible = false;
        btnGuardar.Visible = false;
        fuImagen.Visible = true;
        txtLink.Visible = false;
        lblVideo.Visible = false;
        pEjemplo.Visible = false;
        lblTituloGaleria.Visible = false;
        gvGaleria.Visible = false;
        lblNombreSeccion.Text = "Agregar";
       
    }

    void limpiarInfo()
    {
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        //ddlGaleria.Dispose();
        txtTitulo.Text = "";
        txtDescripcion.Text = "";
        fuImagen.Dispose();
        txtLink.Text = "";
        lblTituloGaleria.Visible = true;
        gvGaleria.Visible = true;
        ddlTipoArchivo.Enabled = true;
        img.Dispose();
        img.Visible = false; ;
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
       // gvGaleria.DataBind();
    }

    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idArchivo = Convert.ToInt32(btnEliminar.CommandArgument);

        gGaleriaArchivo.Eliminar(idArchivo);
        gvGaleria.DataBind();

    }

    protected void ddlTipoArchivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoArchivo.SelectedValue == "imagen")
        {
            fuImagen.Visible = true;
            txtLink.Visible = false;
            lblVideo.Visible = false;
            pEjemplo.Visible = false;
        }
        else
        {
            fuImagen.Visible = true;
            txtLink.Visible = true;
            lblVideo.Visible = true;
            pEjemplo.Visible = true;
        }
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bGaleriaArchivo.arch_titu = txtTitulo.Text;
        bGaleriaArchivo.arch_desc = txtDescripcion.Text;
        bGaleriaArchivo.arch_tipo = ddlTipoArchivo.SelectedValue;
        bGaleriaArchivo.padr_codi = Convert.ToInt32(ddlGaleria.SelectedValue);
        bGaleriaArchivo.padr_tipo = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
        //guardar imagen
        guardaImagen(bGaleriaArchivo);
        if (bGaleriaArchivo.arch_tipo != "imagen")
        {
            bGaleriaArchivo.arch_link = txtLink.Text;
        }

        gGaleriaArchivo.Agregar(bGaleriaArchivo);
        tipoEvento = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
        galeria = Convert.ToInt32(ddlGaleria.SelectedValue);
        gvGaleria.DataBind();


        limpiarInfo();
    }


    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bGaleriaArchivo.arch_codi = Convert.ToInt32(lblCodigo.Text);
        bGaleriaArchivo.arch_titu = txtTitulo.Text;
        bGaleriaArchivo.arch_desc = txtDescripcion.Text;
        bGaleriaArchivo.arch_tipo = ddlTipoArchivo.SelectedValue;
        bGaleriaArchivo.padr_codi = Convert.ToInt32(ddlGaleria.SelectedValue);
        bGaleriaArchivo.padr_tipo = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
        //guardar imagen
        if (fuImagen.PostedFile.ContentLength > 0)
            guardaImagen(bGaleriaArchivo);
        else
            bGaleriaArchivo.arch_arch = Session["archivo_galeria"].ToString();

        if (bGaleriaArchivo.arch_tipo != "imagen")
        {
            bGaleriaArchivo.arch_link = txtLink.Text;
        }

        gGaleriaArchivo.Modificar(bGaleriaArchivo);
        tipoEvento = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
        galeria = Convert.ToInt32(ddlGaleria.SelectedValue);
        gvGaleria.DataBind();

        limpiarInfo();
    }

    void guardaImagen(BEGaleriaArchivo bGaleriaArchivo)
    {

        //guardar imagen
        if (fuImagen.PostedFile.ContentLength > 0)
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
                    bGaleriaArchivo.arch_arch = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bGaleriaArchivo.arch_arch);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        }
        else
        {

            lblError.Text = "**ERROR: Seleccione una imagen";

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
    

  
    protected void ddlGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblTituloGaleria.Text = ddlGaleria.SelectedItem.Text;
        gvGaleria.DataBind();

    }
    protected void btnVideoGaleria_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = (ImageButton)sender;
        Int32 idgaleria = Convert.ToInt32(btn.CommandArgument);

        BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);

        #region script video

        string infoVideo = "<object width='425' height='344'><param name='movie' value='" + bGaleriaArchivo.arch_link + "'></param><embed src='" + bGaleriaArchivo.arch_link + "' type='application/x-shockwave-flash' width='425' height='344'></embed></object>";
        video.Text = infoVideo;

        #endregion script video
        lblGaleriaVideo.Text = ddlGaleria.SelectedItem.Text;
        lblTituloVideo.Text = bGaleriaArchivo.arch_titu;
        lblDescripcionVideo.Text = bGaleriaArchivo.arch_desc;
        mpeVideo.Show();
    }

    protected void gvGaleria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gvGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idArchivo = Convert.ToInt32(gvGaleria.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnNuevo.Visible = false;
        lblTituloGaleria.Visible = false;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bGaleriaArchivo =oGaleriaArchivo.ListarRegistro(idArchivo);

        lblCodigo.Text = bGaleriaArchivo.arch_codi.ToString();
        txtTitulo.Text = bGaleriaArchivo.arch_titu;
        txtDescripcion.Text =  bGaleriaArchivo.arch_desc;
        ddlTipoArchivo.SelectedValue =  bGaleriaArchivo.arch_tipo;
        ddlGaleria.SelectedValue = bGaleriaArchivo.padr_codi.ToString();
        ddlTipoGaleria.SelectedValue = bGaleriaArchivo.padr_tipo.ToString();
        Session["archivo_galeria"] = bGaleriaArchivo.arch_arch;

        if (bGaleriaArchivo.arch_tipo != "imagen")
        {
            txtLink.Visible = true;
            lblVideo.Visible = true;
            pEjemplo.Visible = true;
            txtLink.Text = bGaleriaArchivo.arch_link;
        }
        else
        {
            txtLink.Visible = false;
            lblVideo.Visible = false;
            pEjemplo.Visible = false;
        }
      
        img.ImageUrl = rutaUpload + bGaleriaArchivo.arch_arch;
        img.Visible = true;
        ddlTipoArchivo.Enabled = false;
        gvGaleria.Visible = false;


    }


    protected void lnkArchivo_Click(object sender, EventArgs e)
    {

        LinkButton lnkArchivo = (LinkButton)sender;
        Int32 idArchivo = Convert.ToInt32(lnkArchivo.CommandArgument);

        BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idArchivo);

        if (bGaleriaArchivo.arch_tipo == "video")
        {
            #region script video

            string infoVideo = "<object width='425' height='344'><param name='movie' value='" + bGaleriaArchivo.arch_link + "'></param><embed src='" + bGaleriaArchivo.arch_link + "' type='application/x-shockwave-flash' width='425' height='344'></embed></object>";
            video.Text = infoVideo;

            #endregion script video
            lblGaleriaVideo.Text = ddlGaleria.SelectedItem.Text;
            lblTituloVideo.Text = bGaleriaArchivo.arch_titu;
            lblDescripcionVideo.Text = bGaleriaArchivo.arch_desc;
            mpeVideo.Show();
        }
        if (bGaleriaArchivo.arch_tipo == "imagen")
        {
               
                ArchivoImagen.ImageUrl = rutaUpload + bGaleriaArchivo.arch_arch;
        
            lblGaleriaImagen.Text = ddlGaleria.SelectedItem.Text;
            lblTituloImagen.Text = bGaleriaArchivo.arch_titu;
            lblDescripcionImagen.Text = bGaleriaArchivo.arch_desc;
            mpeImagen.Show();
        }
    }
}
