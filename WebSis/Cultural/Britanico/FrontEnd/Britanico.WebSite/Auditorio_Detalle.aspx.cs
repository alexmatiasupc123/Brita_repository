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
using Britanico.Utilitario.Funciones;
using Britanico.Utilitario;
using System.Collections.Generic;

public partial class Auditorio_Detalle : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    BEProgramacionAuditorio bAuditorio = new BEProgramacionAuditorio();
    BLProgramacionAuditorioNTAD oAuditorio = new BLProgramacionAuditorioNTAD();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BLGaleriaArchivoNTAD oGaleriaArchivo = new BLGaleriaArchivoNTAD();
    Funciones funciones = new Funciones();
    String tipoArchivo = "imagen";
    Int32 tipoEvento = 1;
    Int32 tamPag = 4;

    String vtipoArchivo = "video";
    Int32 vtipoEvento = 1;
    Int32 vtamPag = 4;


    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    List<BEInformacion> listaInformacion = new List<BEInformacion>();
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["tiene_contenido"] = false;

            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString())==true )
            {
                Int32 idProgramacion = Convert.ToInt32(Request.QueryString["id"]);
                Session["idPadre"] = idProgramacion;
                CargarRegistro(idProgramacion);
            }
            else if (Session["idProgramacion"] != null)
            {
                Int32 idProgramacion = Convert.ToInt32(Session["idProgramacion"]);
                Session["idPadre"] = Session["idProgramacion"];
                CargarRegistro(idProgramacion);
            }
            else
            {
                Response.Redirect("Auditorios.aspx");
            }

            listaInformacion = oInformacion.ListarTodosXEvento(1);

            if (listaInformacion.Count > 0)
            {
                dlProximosEventos.DataSource = listaInformacion;
                dlProximosEventos.DataBind();
            }
        }
        
    }

    void CargarRegistro(Int32 idProgramacion)
    {

        bAuditorio = oAuditorio.ListarRegistro(idProgramacion);
        lblTitulo.Text = bAuditorio.prog_titu;
        lblContenido.Text = bAuditorio.prog_desc;
        if (bAuditorio.prog_desc != "") {
            Session["tiene_contenido"] = true;
        }

        HtmlMeta og_title = (HtmlMeta)this.Master.FindControl("og_title");
        og_title.Content = lblTitulo.Text;
        Session["title"] = lblTitulo.Text;

        HtmlMeta og_description = (HtmlMeta)this.Master.FindControl("og_description");
        int len;
        if (lblContenido.Text.Length < 200) { len = lblContenido.Text.Length; }
        else { len = 200; }
        og_description.Content = HttpUtility.HtmlDecode(functions.RemoveHTML(lblContenido.Text.Substring(0, len)));


        HtmlMeta og_url = (HtmlMeta)this.Master.FindControl("og_url");
        string link = HttpContext.Current.Request.Url.AbsoluteUri;
        if (Request.QueryString["id"] == null || Request.QueryString["id"]==String.Empty)
        {
            link += "?id=" + Session["idPadre"].ToString();
        }
        og_url.Content = link;
        Session["url"] = link;

        //String del = "del " + bAuditorio.prog_fini.Day.ToString() + " de " + funciones.determinaMes(bAuditorio.prog_fini);
        //String al = " al " + bAuditorio.prog_ffin.Day.ToString() + " de " + funciones.determinaMes(bAuditorio.prog_ffin);
        //String temporada = " " + del + al + "<br>" + bAuditorio.prog_temp;
        //bAuditorio.prog_temp = temporada;

        lblDetalle.Text = bAuditorio.prog_temp;

        if (bAuditorio.prog_imag != null)
        {
            imgFoto.ImageUrl = string.Format("{0}{1}", rutaUpload, bAuditorio.prog_imag);
            imgFoto.Visible = true;
            pDetalle.Width = 334;

            HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + imgFoto.ResolveClientUrl(imgFoto.ImageUrl);
            


        }
        else
        {
            imgFoto.Visible = false;
            pDetalle.Width = 400;
            HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
            
        }

        //sede
        BESede eSede = oSede.ListarRegistro(bAuditorio.sede_codi);
        lblDireccionSede.Text = eSede.sede_dire.ToUpper() + " - " + eSede.sede_nomb.ToUpper();
        //lblInformes.Text = bAuditorio.prog_deta;

        //carga galerias
        Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
        List<BEGaleriaArchivo> total = oGaleriaArchivo.ListarTodosXValores(idPadre, tipoEvento, tipoArchivo);
        List<BEGaleriaArchivo> vtotal = oGaleriaArchivo.ListarTodosXValores(idPadre, vtipoEvento, vtipoArchivo);


        Session[SessionValores.SESSIONTotalImagenes] = total.Count;
        Session[SessionValores.SESSIONvTotalImagenes] = vtotal.Count;

        cargaGaleria();
        cargaVideo();

    }

    #region galeria
    void cargaGaleria()
    {
        Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
        Int32 numPag = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]);
        List<BEGaleriaArchivo> listaGaleriaArchivo = oGaleriaArchivo.ListarTodosXFiltro(idPadre, tipoEvento, tipoArchivo, numPag);

        foreach (BEGaleriaArchivo iGaleria in listaGaleriaArchivo)
        {

            iGaleria.arch_arch = string.Format("{0}{1}", rutaUpload, iGaleria.arch_arch);

        }

        if (numPag == 0)
        {

            if (listaGaleriaArchivo.Count > 0)
            {

                pGaleria.Visible = true;

                btnvAnterior.Enabled = false;

                if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
                    btnvSiguiente.Enabled = false;
                else
                    btnvSiguiente.Enabled = true;

            }

            else
            {
                pGaleria.Visible = false;

            }

        }
        else
            pGaleria.Visible = true;

        dlGaleriaImagenes.DataSource = listaGaleriaArchivo;
        dlGaleriaImagenes.DataBind();

    }

    protected void btnAnterior_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) > 0)
            Session[SessionValores.SESSIONNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) - 1;

        if (Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) == 0)
        {
            btnAnterior.Enabled = false;



            if (Convert.ToInt32(Session[SessionValores.SESSIONTotalImagenes]) < tamPag)
                btnSiguiente.Enabled = false;
            else
                btnSiguiente.Enabled = true;

        }

        cargaGaleria();

    }
    protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Session[SessionValores.SESSIONNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) + 1;
        btnAnterior.Enabled = true;
        Int32 totalImagenes = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) * tamPag;
        Int32 restaImagenes = Convert.ToInt32(Session[SessionValores.SESSIONTotalImagenes]) - totalImagenes;
        if (restaImagenes < tamPag)
        {
            btnSiguiente.Enabled = false;
        }
        else
        {
            btnSiguiente.Enabled = true;
        }
        cargaGaleria();
    }
    protected void dlGaleriaImagenes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnImagen_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnImagen = (ImageButton)sender;
        Int32 idgaleria = Convert.ToInt32(btnImagen.CommandArgument);

        BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);
        lblDNombreGaleria.Text = lblTitulo.Text;
        dVerImagen.ImageUrl = string.Format("{0}{1}", rutaUpload, bGaleriaArchivo.arch_arch);

        lbldTitulo.Text = bGaleriaArchivo.arch_titu;
        lbldDescripcion.Text = bGaleriaArchivo.arch_desc;
        mpeImagen.Show();
    }
    protected void btnVideo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnVideo = (ImageButton)sender;
        Int32 idgaleria = Convert.ToInt32(btnVideo.CommandArgument);

        BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);

        #region script video

        string infoVideo = "<object width='425' height='344'><param name='movie' value='" + bGaleriaArchivo.arch_link + "'></param><embed src='" + bGaleriaArchivo.arch_link + "' type='application/x-shockwave-flash' width='425' height='344'></embed></object>";
        video.Text = infoVideo;

        #endregion script video
        lblGaleriaVideo.Text = lblTitulo.Text;
        lblTituloVideo.Text = bGaleriaArchivo.arch_titu;
        lblDescripcionVideo.Text = bGaleriaArchivo.arch_desc;
        mpeVideo.Show();
    }
    protected void dlGaleriaVideo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnvAnterior_Click(object sender, ImageClickEventArgs e)
    {

        if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) > 0)
            Session[SessionValores.SESSIONCNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) - 1;

        if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) == 0)
        {
            btnvAnterior.Enabled = false;



            if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
                btnvSiguiente.Enabled = false;
            else
                btnvSiguiente.Enabled = true;

        }

        cargaVideo();

    }
    protected void btnvSiguiente_Click(object sender, ImageClickEventArgs e)
    {
        Session[SessionValores.SESSIONCNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) + 1;
        btnvAnterior.Enabled = true;
        Int32 totalImagenes = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) * vtamPag;
        Int32 restaImagenes = Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) - totalImagenes;
        if (restaImagenes < tamPag)
        {
            btnvSiguiente.Enabled = false;
        }
        else
        {
            btnvSiguiente.Enabled = true;
        }
        cargaVideo();
    }

    void cargaVideo()
    {
        Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
        Int32 vnumPag = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]);
        List<BEGaleriaArchivo> listaGaleriaArchivo = oGaleriaArchivo.ListarTodosXFiltro(idPadre, vtipoEvento, vtipoArchivo, vnumPag);

        foreach (BEGaleriaArchivo iGaleria in listaGaleriaArchivo)
        {

            iGaleria.arch_arch = string.Format("{0}{1}", rutaUpload, iGaleria.arch_arch);

        }


        if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) == 0)
        {
            if (listaGaleriaArchivo.Count > 0)
            {

                pVideo.Visible = true;
                btnvAnterior.Enabled = false;

                if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
                    btnvSiguiente.Enabled = false;
                else
                    btnvSiguiente.Enabled = true;

            }

            else
            {
                pVideo.Visible = false;

            }
        }

        else
            pVideo.Visible = true;

        dlGaleriaVideo.DataSource = listaGaleriaArchivo;
        dlGaleriaVideo.DataBind();

    }
    #endregion
}
