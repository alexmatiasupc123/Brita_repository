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

public partial class Noticia_Detalle : System.Web.UI.Page
{

    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BENoticia bNoticias = new BENoticia();
    BLNoticiaNTAD oNoticias = new BLNoticiaNTAD();

    

    protected void Page_Load(object sender, EventArgs e)
    {
            Session["tiene_contenido"] = false;
        
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                llenarRegistroNoticia(Convert.ToInt32(Request.QueryString["id"]));
            }    
            else if (Session["idNoticia"] != null)
            {
                llenarRegistroNoticia(Convert.ToInt32(Session["idNoticia"]));
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
       

        llenarNoticias();
    }

    //void llenarRegistroInicialNoticias()
    //{
    //    List<BENoticia> listaNoticias = oNoticias.ListarTodosXMes();
       
    //    if (listaNoticias.Count>0)
    //     {
    //         for (int i = 0; i < listaNoticias.Count; i++)
    //         {
    //             if(listaNoticias[i].noti_imag!=null)
    //             {
    //             listaNoticias[i].noti_imag = string.Format("{0}{1}", rutaUpload, listaNoticias[i].noti_imag);
    //             }
    //         }
    //        Int32 idNoticia = listaNoticias[0].noti_codi;
    //        llenarRegistroNoticia(idNoticia);
    //        lblError.Text = "";
    //    }
    //    else
    //    {
    //        lblError.Text = "Muy Pronto Informacion sobre Noticias";
    //    }
    
    //}

    void llenarRegistroNoticia(Int32 idNoticia)
    {
        BENoticia RegistroNoticia = oNoticias.ListarRegistro(idNoticia);
        lblTitulo.Text = RegistroNoticia.noti_titu;
        lblContenido.Text = RegistroNoticia.noti_desc;
        //if (RegistroNoticia.noti_desc != "") {
        Session["tiene_contenido"] = true;
        //}
        Session["id"] = idNoticia;


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
        if (Request.QueryString["id"] == null || Request.QueryString["id"] == String.Empty)
        {
            link += "?id=" + idNoticia.ToString();
        }
        og_url.Content = link;
        Session["url"] = link;
        


        lblSubtitulo.Text = RegistroNoticia.noti_subt;
        if (RegistroNoticia.noti_imag != null)
        {
            imgFoto.ImageUrl = string.Format("{0}{1}", rutaUpload, RegistroNoticia.noti_imag);
            imgFoto.Visible = true;

            HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + imgFoto.ResolveClientUrl(imgFoto.ImageUrl);
            

        }
        else
        {
            imgFoto.Visible = false;
            HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
        }

        if (Convert.ToBoolean(Session["tiene_contenido"]) == true)
        {
            
            this.litRecomendar.Text = redes_sociales.btn_recomendar_id(Convert.ToString(Session["id"]));
            this.litPublicar.Text = redes_sociales.btn_publicar(Convert.ToString(Session["url"]), Convert.ToString(Session["title"]));
            this.litCompartir.Text = redes_sociales.btn_compartir;
        }
        else
        {
            this.litRecomendar.Text = "";
            this.litPublicar.Text = "";
            this.litCompartir.Text = "";
        }

    }


    void llenarNoticias()
    {
        List<BENoticia> listaNoticias = oNoticias.ListarTodos();
        if (listaNoticias.Count > 0)
        {
            foreach (BENoticia iNoticia in listaNoticias)
            {
                iNoticia.noti_titu = "> " + iNoticia.noti_titu.ToUpper();
            }
        }
        dlNoticias.DataSource = listaNoticias;
        dlNoticias.DataBind();

    }

    protected void dlNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idNoticia = Convert.ToInt32(dlNoticias.SelectedValue);
        Session["idNoticia"] = idNoticia.ToString();
        llenarRegistroNoticia(idNoticia);
    }
   
}
