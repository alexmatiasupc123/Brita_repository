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

public partial class Proyectos : System.Web.UI.Page
{
    BEProyecto bProyectos = new BEProyecto();
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    BLProyectoNTAD oProyectos = new BLProyectoNTAD();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["tiene_contenido"] = false;
            llenarProyectos();
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                Int32 idProyecto = Convert.ToInt32(Request.QueryString["id"]);
                llenarRegistroProyecto(idProyecto);
            }
            else
            {
                llenarRegistroInicialProyectos();
            }
        }
    }

    void llenarRegistroInicialProyectos()
    {
        List<BEProyecto> listaProyectos = oProyectos.ListarTodos();
       
        if (listaProyectos.Count>0)
         {
            Int32 idProyecto = listaProyectos[0].proy_codi;
            llenarRegistroProyecto(idProyecto);
            lblError.Text = "";
        }
        else
        {
            lblError.Text = "Muy Pronto Informacion sobre Proyectos";
        }
    
    }

    void llenarRegistroProyecto(Int32 idProyecto)
    {
        BEProyecto RegistroProyecto = oProyectos.ListarRegistro(idProyecto);
        lblTitulo.Text = RegistroProyecto.proy_nomb;
        lblContenido.Text = RegistroProyecto.proy_desc;
        if (RegistroProyecto.proy_desc != "") {
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
            link += "?id=" + idProyecto.ToString();
        }
        og_url.Content = link;
        Session["url"] = link;
        Session["id"] = idProyecto.ToString();

        if (RegistroProyecto.proy_subt!=null)
        {
        lblSubtitulo.Text = RegistroProyecto.proy_subt+ "<BR><BR>";
        }
        else
        {
        lblSubtitulo.Text = RegistroProyecto.proy_subt;
        }


        if (RegistroProyecto.proy_imag != null)
        {
            imgFoto.Visible = true;
            imgFoto.ImageUrl =  string.Format("{0}{1}", rutaUpload, RegistroProyecto.proy_imag);
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


    void llenarProyectos()
    {
        List<BEProyecto> listaProyectos = oProyectos.ListarTodos();
        if (listaProyectos.Count > 0)
        {
            foreach (BEProyecto iProyecto in listaProyectos)
            {
                iProyecto.proy_nomb = "> " + iProyecto.proy_nomb.ToUpper();
            }
        }
        dlProyectos.DataSource = listaProyectos;
        dlProyectos.DataBind();

    }

    protected void dlProyectos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProyecto = Convert.ToInt32(dlProyectos.SelectedValue);
        llenarRegistroProyecto(idProyecto);
    }
}
