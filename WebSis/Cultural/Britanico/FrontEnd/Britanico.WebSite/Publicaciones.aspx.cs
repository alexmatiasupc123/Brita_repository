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

public partial class Publicaciones : System.Web.UI.Page
{
    BEPublicaciones bPublicaciones = new BEPublicaciones();
    BLPublicacionesNTAD oPublicaciones = new BLPublicacionesNTAD();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["tiene_contenido"] = false;
            llenarPublicaciones();
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                Int32 idPublicacion = Convert.ToInt32(Request.QueryString["id"]);
                llenarRegistroPublicacion(idPublicacion);
            }
            else
            {
                llenarRegistroInicialPublicaciones();
            }
        }
    }

    void llenarRegistroInicialPublicaciones()
    {
        List<BEPublicaciones> listaPublicaciones = oPublicaciones.ListarTodos();
        if (listaPublicaciones.Count > 0)
        {
            Int32 idPublicacion = listaPublicaciones[0].publ_codi;
            llenarRegistroPublicacion(idPublicacion);
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "Muy Pronto Informacion sobre Publicaciones";
        }
    }

    void llenarRegistroPublicacion(Int32 idPublicacion)
    {
        BEPublicaciones RegistroPublicacion = oPublicaciones.ListarRegistro(idPublicacion);
        lblTitulo.Text =  RegistroPublicacion.publ_nomb;
        lblContenido.Text = RegistroPublicacion.publ_desc;
        if (RegistroPublicacion.publ_desc != "") {
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
        if (Request.QueryString["id"] == null || Request.QueryString["id"] == String.Empty)
        {
            link += "?id=" + idPublicacion.ToString();
        }
        og_url.Content = link;
        Session["url"] = link;
        Session["id"] = idPublicacion.ToString();

        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";

        lblSubtitulo.Text = RegistroPublicacion.publ_subt;
    }


    void llenarPublicaciones()
    {
        List<BEPublicaciones> listaPublicaciones = oPublicaciones.ListarTodos();
        if (listaPublicaciones.Count > 0)
        {
            foreach (BEPublicaciones iPublicacion in listaPublicaciones)
            {
                iPublicacion.publ_nomb = "> " + iPublicacion.publ_nomb.ToUpper();
            }
        }
        dlPublicaciones.DataSource = listaPublicaciones;
        dlPublicaciones.DataBind();

    }

    protected void dlPublicaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idPublicacion = Convert.ToInt32(dlPublicaciones.SelectedValue);
        llenarRegistroPublicacion(idPublicacion);
    }
}
