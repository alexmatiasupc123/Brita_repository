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

public partial class Auditorios : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEActividadTeatro bActividad = new BEActividadTeatro();
    BLActividadTeatroNTAD oActividad = new BLActividadTeatroNTAD();
    Funciones funciones = new Funciones();

    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    List<BEInformacion> listaInformacion = new List<BEInformacion>();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["tiene_contenido"] = false;

        List<BEActividadTeatro> listaActividad = oActividad.ListarTodosResumen();

        if (listaActividad.Count > 0)
        {
            Session["tiene_contenido"] = true;

            HtmlMeta og_title = (HtmlMeta)this.Master.FindControl("og_title");
            og_title.Content = this.Page.Title;
            Session["title"] = this.Page.Title;

            HtmlMeta og_description = (HtmlMeta)this.Master.FindControl("og_description");
            og_description.Content = HttpUtility.HtmlDecode(lblDireccion.Text);

            HtmlMeta og_url = (HtmlMeta)this.Master.FindControl("og_url");
            string link = HttpContext.Current.Request.Url.AbsoluteUri;
            og_url.Content = link;
            Session["url"] = link;

            HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
            //og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";

            for (int i = 0; i < listaActividad.Count; i++)
            {
                if (listaActividad[i].teat_imag != null)
                {
                    listaActividad[i].teat_imag = string.Format("{0}{1}", rutaUpload, listaActividad[i].teat_imag);
                    if (og_image.Content == "")
                    {
                        //og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaActividad[0].teat_imag.Replace("~/", "");
                        listaActividad[i].teat_imag = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaActividad[i].teat_imag.Replace("~/", "");
                    }

                }
                //String del = "del " +  listaActividad[i].teat_init.Day.ToString() + " de " + funciones.determinaMes( listaActividad[i].teat_init);
                //String al = " al " + listaActividad[i].teat_fint.Day.ToString() + " de " + funciones.determinaMes(listaActividad[i].teat_fint);
                //String temporada = " " + del + al + "<br>" + listaActividad[i].teat_temp;

                //listaActividad[i].teat_temp = temporada;
                listaActividad[i].teat_desc = listaActividad[i].teat_desc + "...";

            }
            dlActividad.DataSource = listaActividad;
            dlActividad.DataBind();


        }

        if (!Page.IsPostBack)
        {

            listaInformacion = oInformacion.ListarTodosXEvento(2);

            if (listaInformacion.Count > 0)
            {
                dlProximosEventos.DataSource = listaInformacion;
                dlProximosEventos.DataBind();
            }

            
        }
    }
    protected void dlActividad_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idActividad = Convert.ToInt32(dlActividad.SelectedValue);
        Session["idActividad"] = idActividad.ToString();
        Response.Redirect("Teatro_Detalle.aspx?id=" + Session["idActividad"]);
    }
    protected void dlActividad_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image foto = (Image)e.Item.FindControl("imgFoto");
        Panel pDetalle = (Panel)e.Item.FindControl("pDetalle");
        if (foto.ImageUrl != null)
        {
            foto.Visible = true;
            pDetalle.Width = 334;
        }
        else
        {
            foto.Visible = false;
            pDetalle.Width = 400;
        }
    }
}
