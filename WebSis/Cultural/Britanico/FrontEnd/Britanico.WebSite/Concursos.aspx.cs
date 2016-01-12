using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.Design;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using System.Collections.Generic;
using Britanico.Utilitario.Funciones;
using Britanico.Utilitario;
using System.Text;

public partial class Concursos : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    BEConcurso bConcurso = new BEConcurso();
    BLConcursoNTAD oConcurso = new BLConcursoNTAD();
    BEConcursoTemporada bConcursoTemporada = new BEConcursoTemporada();
    BLConcursoTemporadaNTAD oConcursoTemporada = new BLConcursoTemporadaNTAD();
    BLGaleriaArchivoNTAD oGaleriaArchivo = new BLGaleriaArchivoNTAD();
    Funciones funciones = new Funciones();
    String tipoArchivo = "imagen";
    Int32 tipoEvento = 3;
    Int32 tamPag = 4;

    String vtipoArchivo = "video";
    Int32 vtipoEvento = 3;
    Int32 vtamPag = 4;
    public string lblContenido;
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["tiene_contenido"] = false;
            llenarConcursos();
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                Int32 idConcurso = Convert.ToInt32(Request.QueryString["id"]);
                llenarInfoConcurso(idConcurso);
            }
            else
            {
                llenarListaInicialConcurso();
            }
                        
        }

   
    }

    void llenarListaInicialConcurso()
    {
        if (Session["idConcursoTemporada"] != null)
        {

            Int32 idConcursoTemporada = Convert.ToInt32(Session["idConcursoTemporada"]);
            llenarRegistroConcursoTemporada(idConcursoTemporada);
        }
        else
        {
            List<BEConcurso> listaConcursos = oConcurso.ListarTodos();
            if (listaConcursos.Count > 0)
            {
                Int32 idConcurso = listaConcursos[0].conc_codi;
                llenarInfoConcurso(idConcurso);
            }
        }
        
    }

    void llenarInfoConcurso(Int32 idConcurso)
   {
       if (idConcurso != 0)
       {
           lblDetalle.Text = "";
           lblPremios.Text = "";
           lblAnio.Text = "";

           bConcurso = oConcurso.ListarRegistro(idConcurso);
           lblTitulo.Text = bConcurso.conc_nomb;
           lblSubtitulo.Text = bConcurso.conc_subt;
           lblContenido = bConcurso.conc_desc;
           if (bConcurso.conc_desc != "") {
               Session["tiene_contenido"] = true;
           }

           HtmlMeta og_title = (HtmlMeta)this.Master.FindControl("og_title");
           og_title.Content = lblTitulo.Text;
           Session["title"] = lblTitulo.Text;

           HtmlMeta og_description = (HtmlMeta)this.Master.FindControl("og_description");
           int len;
           if (lblContenido.Length < 200) { len = lblContenido.Length; }
           else { len = 200; }
           og_description.Content = HttpUtility.HtmlDecode(functions.RemoveHTML(lblContenido.Substring(0, len)));


           HtmlMeta og_url = (HtmlMeta)this.Master.FindControl("og_url");
           string link = HttpContext.Current.Request.Url.AbsoluteUri;
           if (Request.QueryString["id"] == null || Request.QueryString["id"] == String.Empty)
           {
               link += "?id=" + idConcurso.ToString();
           }
           og_url.Content = link;
           Session["url"] = link;
           Session["id"] = idConcurso.ToString();

           bConcursoTemporada = oConcursoTemporada.ListarRegistroXConcurso(idConcurso);
           if (bConcursoTemporada != null)
           {
               Session["idPadre"] = bConcursoTemporada.ctem_codi.ToString();
               lblNombreGaleriaImagen.Text = bConcurso.conc_nomb.ToUpper() + " " + bConcursoTemporada.ctem_anio.ToString();

               //
               lblNombreGaleriaVideo.Text = bConcurso.conc_nomb.ToUpper() + " " + bConcursoTemporada.ctem_anio.ToString();

               if (bConcursoTemporada.ctem_imag != "")
               {
                   imgFoto.Visible = true;
                   imgFoto.ImageUrl = string.Format("{0}{1}", rutaUpload, bConcursoTemporada.ctem_imag);
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

           }
           else
           {
               Session["idPadre"] = "0";
           }

           Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
           List<BEGaleriaArchivo> total = oGaleriaArchivo.ListarTodosXValores(idPadre, tipoEvento, tipoArchivo);
           List<BEGaleriaArchivo> vtotal = oGaleriaArchivo.ListarTodosXValores(idPadre, vtipoEvento, vtipoArchivo);


           Session[SessionValores.SESSIONTotalImagenes] = total.Count;
           Session[SessionValores.SESSIONvTotalImagenes] = vtotal.Count;

           cargaGaleria();
           cargaVideo();

           validaInfo(bConcursoTemporada);

       }
    }

    void llenarRegistroConcursoTemporada(Int32 idConcursoTemporada)
    {
        if (idConcursoTemporada != 0)
        {
            lblDetalle.Text = "";
            lblPremios.Text = "";
            lblAnio.Text = "";

            bConcursoTemporada = oConcursoTemporada.ListarRegistro(idConcursoTemporada);
            if (bConcursoTemporada != null)
            {
                Session["idPadre"] = bConcursoTemporada.ctem_codi.ToString();
            }
            else
            {
                Session["idPadre"] = "0";

            }

            bConcurso = oConcurso.ListarRegistro(bConcursoTemporada.conc_codi);
            lblTitulo.Text = bConcurso.conc_nomb;
            lblSubtitulo.Text = bConcurso.conc_subt;
            lblContenido = bConcurso.conc_desc;
            if (bConcurso.conc_desc != "") {
                Session["tiene_contenido"] = true;
            }
            Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
            List<BEGaleriaArchivo> total = oGaleriaArchivo.ListarTodosXValores(idPadre, tipoEvento, tipoArchivo);
            List<BEGaleriaArchivo> vtotal = oGaleriaArchivo.ListarTodosXValores(idPadre, vtipoEvento, vtipoArchivo);


            Session[SessionValores.SESSIONTotalImagenes] = total.Count;
            Session[SessionValores.SESSIONvTotalImagenes] = vtotal.Count;

            cargaGaleria();
            cargaVideo();
            validaInfo(bConcursoTemporada);
            lblNombreGaleriaImagen.Text = bConcurso.conc_nomb.ToUpper() + " " + bConcursoTemporada.ctem_anio.ToString();

        }
    }

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

    void validaInfo(BEConcursoTemporada bConcursoTemporada)
    {
        if (bConcursoTemporada != null)
        {

           
            if (bConcursoTemporada.ctem_base != null)
            {
                btnBases.Visible = true;
                pBases.Visible = true;
           
                CollapsiblePanelExtender1.Enabled = true;

            }
            else
            {
                btnBases.Visible = false;
                pBases.Visible = false;
                
                CollapsiblePanelExtender1.Enabled = false;

            }

            if (bConcursoTemporada.ctem_jura != null)
            {
                btnComentarios.Visible = true;
                pComentarios.Visible = true;
                CollapsiblePanelExtender2.Enabled = true;
            }
            else
            {
                btnComentarios.Visible = false;
                pComentarios.Visible = false;
                CollapsiblePanelExtender2.Enabled = false;
            }

            if (bConcursoTemporada.ctem_result != null)
            {
                btnResultados.Visible = true;
                pResultados.Visible = true;
                CollapsiblePanelExtender3.Enabled = true;
            }
            else
            {
                btnResultados.Visible = false;
                pResultados.Visible = false;
                CollapsiblePanelExtender3.Enabled = false;
            }

            //String del = "del " + bConcursoTemporada.ctem_fini.Day.ToString() + " de " + funciones.determinaMes(bConcursoTemporada.ctem_fini);
            //String al = " al " + bConcursoTemporada.ctem_ffin.Day.ToString() + " de " + funciones.determinaMes(bConcursoTemporada.ctem_ffin);

            lblDetalle.Text = bConcursoTemporada.ctem_temp;
            lblPremios.Text = bConcursoTemporada.ctem_prem;
            lblAnio.Text = bConcursoTemporada.ctem_anio;

            //paneles
            lblBase.Text = bConcursoTemporada.ctem_base;
            lblResultados.Text = bConcursoTemporada.ctem_result;
            lblComentarios.Text = bConcursoTemporada.ctem_jura;

        }
        else
        {
            
            btnBases.Visible = false;
            btnComentarios.Visible = false;
            btnResultados.Visible = false;

            pBases.Visible = false;
            pResultados.Visible = false;
            pComentarios.Visible = false;

        }
    
    }

    void llenarConcursos()
    {
        List<BEConcurso> listaConcursos = oConcurso.ListarTodos();
        if (listaConcursos.Count > 0)
        {
            foreach (BEConcurso iConcurso in listaConcursos)
            {
                iConcurso.conc_nomb = "> " + iConcurso.conc_nomb.ToUpper();
            }

            dlConcursos.DataSource = listaConcursos;
            dlConcursos.DataBind();
        }
       

    }
    protected void dlConcursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idConcurso = Convert.ToInt32(dlConcursos.SelectedValue);
        llenarInfoConcurso(idConcurso);
    }



    protected void btnBases_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnResultados_Click(object sender, ImageClickEventArgs e)
    {

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
        Int32 totalImagenes = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina])* tamPag;
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
        Int32 idgaleria= Convert.ToInt32(btnImagen.CommandArgument);

        BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);
        lblDNombreGaleria.Text = lblNombreGaleriaImagen.Text;
        dVerImagen.ImageUrl= string.Format("{0}{1}", rutaUpload, bGaleriaArchivo.arch_arch);

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
        lblGaleriaVideo.Text = lblNombreGaleriaImagen.Text;
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

}
