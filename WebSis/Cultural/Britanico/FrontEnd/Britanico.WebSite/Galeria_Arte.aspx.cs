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
using System.Collections.Generic;
using Britanico.Utilitario.Funciones;

public partial class Galeria_Arte : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    BEGaleriaArte bGaleria = new BEGaleriaArte();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BLGaleriaArteDetalleNTAD oDetalleGaleria = new BLGaleriaArteDetalleNTAD();
    BLGaleriaArteNTAD oGaleria = new BLGaleriaArteNTAD();
    Funciones funciones = new Funciones();
    Int32 sede;
    Int32 idGaleria;
    BESede eSede = new BESede();
    int num;

    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    List<BEInformacion> listaInformacion = new List<BEInformacion>();
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Session["tiene_contenido"] = false;
            llenarGalerias();
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                llenarListaDetalleGaleria(Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                llenarListaInicialDetalleGaleria();
            }
          

                listaInformacion = oInformacion.ListarTodosXEvento(0);

                if (listaInformacion.Count > 0)
                {
                    dlProximosEventos.DataSource = listaInformacion;
                    dlProximosEventos.DataBind();
                }
            
        }
        //ScriptManager sm = this.Master.FindControl("ScriptManager1") as ScriptManager;
        

    }

    void llenarListaInicialDetalleGaleria()
    {

        List<BEGaleriaArte> listaGaleria = oGaleria.ListarTodos();

        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "";

        if (listaGaleria.Count > 0)
        {
           
           if (Session["idGaleria"] != null)
               idGaleria = Convert.ToInt32(Session["idGaleria"]);
           else
           {
               if (listaGaleria.Count > 0)
               {
                   idGaleria = listaGaleria[0].gale_codi;
                   Session["idGaleria"] = idGaleria.ToString();
               }
           }
          
            llenarListaDetalleGaleria(idGaleria);
        }
        else
        {
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
        }
        
    }

    void llenarListaDetalleGaleria(Int32 idGaleria)
    {
        
        bGaleria = oGaleria.ListarRegistro(idGaleria);
        eSede = oSede.ListarRegistro(bGaleria.sede_codi);
        num = bGaleria.gale_codi;
        lblIdGaleria.Text = Convert.ToString(num);
        lblTituloGaleria.Text = bGaleria.gale_nomb;
        lblDireccion.Text = eSede.sede_dire.ToUpper() + " - " + eSede.sede_nomb.ToUpper();
        lblHistoria.Text = bGaleria.gale_desc;
        Session["idGaleria"] = idGaleria;
        Session["id"] = idGaleria;

        HtmlMeta og_title = (HtmlMeta)this.Master.FindControl("og_title");
        og_title.Content = lblTituloGaleria.Text;
        Session["title"] = lblTituloGaleria.Text;

        HtmlMeta og_description = (HtmlMeta)this.Master.FindControl("og_description");
        og_description.Content = HttpUtility.HtmlDecode(lblDireccion.Text);

        HtmlMeta og_url = (HtmlMeta)this.Master.FindControl("og_url");
        string link = HttpContext.Current.Request.Url.AbsoluteUri;
        if (Request.QueryString["id"] == null || Request.QueryString["id"] == String.Empty)
        {
            link += "?id=" + idGaleria.ToString();
        }
        og_url.Content = link;
        Session["url"] = link;

        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "";

        List<BEGaleriaArteDetalle> listaDetalle = oDetalleGaleria.ListarTodos(idGaleria);
        if (listaDetalle.Count > 0) {
            Session["tiene_contenido"] = true;
        }
        else
        {
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
        }
        foreach (BEGaleriaArteDetalle iDetalle in listaDetalle)
        {
            if (iDetalle.gade_imag != null)
            {
                iDetalle.gade_imag = string.Format("{0}{1}", rutaUpload, iDetalle.gade_imag);
                if (og_image.Content == "")
                {
                    og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + iDetalle.gade_imag.Replace("~/", "");
                }

            }

            iDetalle.gade_desc = iDetalle.gade_desc +"...";
        }
        
        
        dlDetalleGaleria.DataSource = listaDetalle;
        dlDetalleGaleria.DataBind();

        if (Convert.ToBoolean(Session["tiene_contenido"]) == true)
        {
            this.litRecomendar.Text = redes_sociales.btn_recomendar_id(Convert.ToString(Session["id"]));
            this.litPublicar.Text = redes_sociales.btn_publicar(Convert.ToString(Session["url"]), Convert.ToString(Session["title"]));
            this.litCompartir.Text = redes_sociales.btn_compartir;
        }
        else {
            this.litRecomendar.Text = "";
            this.litPublicar.Text = "";
            this.litCompartir.Text = "";
        }

    }

  
    protected void dlDetalleGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idDetalleGaleria = Convert.ToInt32(dlDetalleGaleria.SelectedValue);
        Session["idDetalleGaleria"] = idDetalleGaleria.ToString();
        Response.Redirect("GaleriaArte_Detalle.aspx?id=" + Session["idDetalleGaleria"]);
    }
    protected void dlGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
       idGaleria = Convert.ToInt32(dlGaleria.SelectedValue);
        bGaleria = oGaleria.ListarRegistro(idGaleria);
        sede = bGaleria.sede_codi;
        Session["tiene_contenido"] = false;
        llenarListaDetalleGaleria(idGaleria);
        lblHistoria.Text = bGaleria.gale_desc;

    }

    void llenarGalerias()
    {
        List<BEGaleriaArte> listaGalerias = oGaleria.ListarTodos();
        if (listaGalerias.Count > 0)
        {
            foreach (BEGaleriaArte iGaleria in listaGalerias)
            {
                iGaleria.gale_nomb = "> " + iGaleria.gale_nomb.ToUpper();
            }
            dlGaleria.DataSource = listaGalerias;
            dlGaleria.DataBind();

        }
       
    }
  
    protected void dlDetalleGaleria_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image foto = (Image)e.Item.FindControl("imgFoto");
        Panel pDetalle = (Panel)e.Item.FindControl("pDetalle");
        if (foto.ImageUrl != "")
        {
            foto.Visible = true;
            pDetalle.Width = 334;
        }
        else
        {
            foto.Visible = false;
            pDetalle.Width =400;
        }
    }
    protected void btnHistoria_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnMuestras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Muestra_Galeria.aspx");
    }
    //

    protected void btnMundoHombre_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Write("<script>");
        //Response.Write("window.open('hhtp://www.google.com','_blank')");
        //Response.Write("</script>");
        Response.Write("<script type='text/javascript'>window.open('http://www.google.com');</script>");
        

    }

    protected void btnYoNoCoso_Click(object sender, ImageClickEventArgs e)
    {

    }
}
