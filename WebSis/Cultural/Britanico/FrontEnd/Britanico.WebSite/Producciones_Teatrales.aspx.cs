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


public partial class Producciones_Teatrales : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEProducciones bProducciones = new BEProducciones();
    BLProduccionesNTAD oProducciones = new BLProduccionesNTAD();
    BLGaleriaArchivoNTAD oGaleriaArchivo = new BLGaleriaArchivoNTAD();
    Funciones funciones = new Funciones();
    String tipoArchivo = "imagen";
    Int32 tipoEvento = 7;
    Int32 tamPag = 4;

    String vtipoArchivo = "video";
    Int32 vtipoEvento = 7;
    Int32 vtamPag = 4;

    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
          
          llenarProducciones();
          llenarRegistroInicialProducciones();
      }
    }

    void llenarRegistroInicialProducciones()
    { 
    List<BEProducciones> listaProducciones = oProducciones.ListarTodos();
    Int32 idProduccion = listaProducciones[0].prod_codi;
    llenarRegistroProduccion(idProduccion);    
    }

    void llenarRegistroProduccion(Int32 idProduccion)
    {
        bProducciones  = oProducciones.ListarRegistro(idProduccion);
        lblTitulo.Text = bProducciones.prod_anio.ToString() + ". " + bProducciones.prod_nomb;
        lblContenido.Text = bProducciones.prod_desc;
        Session["bProducciones.prod_codi"] = bProducciones.prod_codi;

        if (bProducciones.prod_desc != "")
        {
            //cargar galerias
            Int32 idPadre = Convert.ToInt32(bProducciones.prod_codi);
            List<BEGaleriaArchivo> total = oGaleriaArchivo.ListarTodosXValores(idPadre, tipoEvento, tipoArchivo);
            List<BEGaleriaArchivo> vtotal = oGaleriaArchivo.ListarTodosXValores(idPadre, vtipoEvento, vtipoArchivo);


            Session[SessionValores.SESSIONTotalImagenes] = total.Count;
            Session[SessionValores.SESSIONvTotalImagenes] = vtotal.Count;
            Session[SessionValores.SESSIONNumPagina] = 0;
            Session[SessionValores.SESSIONCNumPagina] = 0;

            cargaGaleria();
            cargaVideo();
        }
    }
   

    void llenarProducciones()
    {
        List<BEProducciones> listaProducciones = oProducciones.ListarTodos();
        if (listaProducciones.Count > 0)
        {
            foreach (BEProducciones iProduccion in listaProducciones)
            {
                iProduccion.prod_nomb = "> " + iProduccion.prod_anio.ToString() + ". " + iProduccion.prod_nomb.ToUpper();
            }
        }
        dlProducciones.DataSource = listaProducciones;
        dlProducciones.DataBind();

    }

    protected void dlProducciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProduccion = Convert.ToInt32(dlProducciones.SelectedValue);
        llenarRegistroProduccion(idProduccion);    
    }

    #region galeria
    void cargaGaleria()
    {
        Int32 idPadre = Convert.ToInt32(Session["bProducciones.prod_codi"]);
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

                btnAnterior.Enabled = false;
                if (Convert.ToInt32(Session[SessionValores.SESSIONTotalImagenes]) < tamPag)
                    btnSiguiente.Enabled = false;
                else
                    btnSiguiente.Enabled = true;

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
        Int32 idPadre = Convert.ToInt32(Session["bProducciones.prod_codi"]);
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
