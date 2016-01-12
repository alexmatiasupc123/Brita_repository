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

public partial class MuestraGaleria_Detalle : System.Web.UI.Page
{

    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    BEMuestraGaleria bMuestraGaleria = new BEMuestraGaleria();
    BLMuestraGaleriaNTAD oMuestraGaleria = new BLMuestraGaleriaNTAD();
  
    Funciones funciones = new Funciones();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["idDetalleMuestra"] != null)
            {
                Int32 idDetalleMuestra= Convert.ToInt32(Session["idDetalleMuestra"]);
               
                CargarRegistro(idDetalleMuestra);
            }
            else
            {
                Response.Redirect("Muestra_Galeria.aspx");
            }
        }
      
    }

    void CargarRegistro(Int32 idDetalleMuestra)
    {

        bMuestraGaleria = oMuestraGaleria.ListarRegistro(idDetalleMuestra);
        lblTitulo.Text = bMuestraGaleria.mues_nomb;
        lblTituloDetalle.Text = bMuestraGaleria.gale_nomb;
        lblContenido.Text = bMuestraGaleria.mues_desc;
        if (bMuestraGaleria.mues_imag != null)
        {
            imgFoto.ImageUrl = string.Format("{0}{1}", rutaUpload, bMuestraGaleria.mues_imag);
            imgFoto.Visible = true;
            pDetalle.Width = 334;
        }
        else
        {
            imgFoto.Visible = false;
            pDetalle.Width = 400;
        }

      
    }


    #region galeria
    //void cargaGaleria()
    //{
    //    Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
    //    Int32 numPag = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]);
    //    List<BEGaleriaArchivo> listaGaleriaArchivo = oGaleriaArchivo.ListarTodosXFiltro(idPadre, tipoEvento, tipoArchivo, numPag);

    //    foreach (BEGaleriaArchivo iGaleria in listaGaleriaArchivo)
    //    {

    //        iGaleria.arch_arch = string.Format("{0}{1}", rutaUpload, iGaleria.arch_arch);

    //    }

    //    if (numPag == 0)
    //    {

    //        if (listaGaleriaArchivo.Count > 0)
    //        {

    //            pGaleria.Visible = true;

    //            btnvAnterior.Enabled = false;

    //            if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
    //                btnvSiguiente.Enabled = false;
    //            else
    //                btnvSiguiente.Enabled = true;

    //        }

    //        else
    //        {
    //            pGaleria.Visible = false;

    //        }

    //    }
    //    else
    //        pGaleria.Visible = true;

    //    dlGaleriaImagenes.DataSource = listaGaleriaArchivo;
    //    dlGaleriaImagenes.DataBind();

    //}

    //protected void btnAnterior_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) > 0)
    //        Session[SessionValores.SESSIONNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) - 1;

    //    if (Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) == 0)
    //    {
    //        btnAnterior.Enabled = false;



    //        if (Convert.ToInt32(Session[SessionValores.SESSIONTotalImagenes]) < tamPag)
    //            btnSiguiente.Enabled = false;
    //        else
    //            btnSiguiente.Enabled = true;

    //    }

    //    cargaGaleria();

    //}
    //protected void btnSiguiente_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session[SessionValores.SESSIONNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) + 1;
    //    btnAnterior.Enabled = true;
    //    Int32 totalImagenes = Convert.ToInt32(Session[SessionValores.SESSIONNumPagina]) * tamPag;
    //    Int32 restaImagenes = Convert.ToInt32(Session[SessionValores.SESSIONTotalImagenes]) - totalImagenes;
    //    if (restaImagenes < tamPag)
    //    {
    //        btnSiguiente.Enabled = false;
    //    }
    //    else
    //    {
    //        btnSiguiente.Enabled = true;
    //    }
    //    cargaGaleria();
    //}
    //protected void dlGaleriaImagenes_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void btnImagen_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton btnImagen = (ImageButton)sender;
    //    Int32 idgaleria = Convert.ToInt32(btnImagen.CommandArgument);

    //    BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);
    //    lblDNombreGaleria.Text = lblTitulo.Text;
    //    dVerImagen.ImageUrl = string.Format("{0}{1}", rutaUpload, bGaleriaArchivo.arch_arch);

    //    lbldTitulo.Text = bGaleriaArchivo.arch_titu;
    //    lbldDescripcion.Text = bGaleriaArchivo.arch_desc;
    //    mpeImagen.Show();
    //}
    //protected void btnVideo_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton btnVideo = (ImageButton)sender;
    //    Int32 idgaleria = Convert.ToInt32(btnVideo.CommandArgument);

    //    BEGaleriaArchivo bGaleriaArchivo = oGaleriaArchivo.ListarRegistro(idgaleria);

    //    #region script video

    //    string infoVideo = "<object width='425' height='344'><param name='movie' value='" + bGaleriaArchivo.arch_link + "'></param><embed src='" + bGaleriaArchivo.arch_link + "' type='application/x-shockwave-flash' width='425' height='344'></embed></object>";
    //    video.Text = infoVideo;

    //    #endregion script video
    //    lblGaleriaVideo.Text = lblTitulo.Text;
    //    lblTituloVideo.Text = bGaleriaArchivo.arch_titu;
    //    lblDescripcionVideo.Text = bGaleriaArchivo.arch_desc;
    //    mpeVideo.Show();
    //}
    //protected void dlGaleriaVideo_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    //protected void btnvAnterior_Click(object sender, ImageClickEventArgs e)
    //{

    //    if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) > 0)
    //        Session[SessionValores.SESSIONCNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) - 1;

    //    if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) == 0)
    //    {
    //        btnvAnterior.Enabled = false;



    //        if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
    //            btnvSiguiente.Enabled = false;
    //        else
    //            btnvSiguiente.Enabled = true;

    //    }

    //    cargaVideo();

    //}
    //protected void btnvSiguiente_Click(object sender, ImageClickEventArgs e)
    //{
    //    Session[SessionValores.SESSIONCNumPagina] = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) + 1;
    //    btnvAnterior.Enabled = true;
    //    Int32 totalImagenes = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) * vtamPag;
    //    Int32 restaImagenes = Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) - totalImagenes;
    //    if (restaImagenes < tamPag)
    //    {
    //        btnvSiguiente.Enabled = false;
    //    }
    //    else
    //    {
    //        btnvSiguiente.Enabled = true;
    //    }
    //    cargaVideo();
    //}

    //void cargaVideo()
    //{
    //    Int32 idPadre = Convert.ToInt32(Session["idPadre"].ToString());
    //    Int32 vnumPag = Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]);
    //    List<BEGaleriaArchivo> listaGaleriaArchivo = oGaleriaArchivo.ListarTodosXFiltro(idPadre, vtipoEvento, vtipoArchivo, vnumPag);

    //    foreach (BEGaleriaArchivo iGaleria in listaGaleriaArchivo)
    //    {

    //        iGaleria.arch_arch = string.Format("{0}{1}", rutaUpload, iGaleria.arch_arch);

    //    }


    //    if (Convert.ToInt32(Session[SessionValores.SESSIONCNumPagina]) == 0)
    //    {
    //        if (listaGaleriaArchivo.Count > 0)
    //        {

    //            pVideo.Visible = true;
    //            btnvAnterior.Enabled = false;

    //            if (Convert.ToInt32(Session[SessionValores.SESSIONvTotalImagenes]) < tamPag)
    //                btnvSiguiente.Enabled = false;
    //            else
    //                btnvSiguiente.Enabled = true;

    //        }

    //        else
    //        {
    //            pVideo.Visible = false;

    //        }
    //    }

    //    else
    //        pVideo.Visible = true;

    //    dlGaleriaVideo.DataSource = listaGaleriaArchivo;
    //    dlGaleriaVideo.DataBind();

    //}
    #endregion
}
