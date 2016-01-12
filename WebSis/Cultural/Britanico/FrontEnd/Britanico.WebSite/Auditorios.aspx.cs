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
    Funciones funciones = new Funciones();
    BESede bSede = new BESede();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BEProgramacionAuditorio bAuditorio = new BEProgramacionAuditorio();
    BLProgramacionAuditorioNTAD oAuditorio = new BLProgramacionAuditorioNTAD();

    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    List<BEInformacion> listaInformacion = new List<BEInformacion>();

    public bool tiene_contenido = false;

    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
          Session["tiene_contenido"] = false;
          llenarSede();
          if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
          {
              llenarListaAuditorio(Convert.ToInt32(Request.QueryString["id"]));
          }
          else
          {
              llenarListaInicialAuditorio();
          }
          listaInformacion = oInformacion.ListarTodosXEvento(1);

          if (listaInformacion.Count > 0)
          {
              dlProximosEventos.DataSource = listaInformacion;
              dlProximosEventos.DataBind();
          }

      }
    }

    void llenarListaInicialAuditorio()
    {

        Int32 sede=0;

        List<BESede> listaSede = oSede.ListarTodosSedesAuditorios();

        if (Session["idSede"] != null)
            sede = Convert.ToInt32(Session["idSede"]);
        else
        {
            if(listaSede.Count>0)
            sede = listaSede[0].sede_codi;
        }
        
        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "";

        if (sede != 0)
        {
            

            infoSedeAuditorio(sede);
            List<BEProgramacionAuditorio> listaAuditorios = oAuditorio.ListarTodos(sede);
            if (listaAuditorios.Count > 0) {
                Session["tiene_contenido"] = true;
            }
            else
            {
                og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
            }
            for (int i = 0; i < listaAuditorios.Count; i++)
            {
                if (listaAuditorios[i].prog_imag != null)
                {
                    listaAuditorios[i].prog_imag = string.Format("{0}{1}", rutaUpload, listaAuditorios[i].prog_imag);
                    if (og_image.Content == "")
                    {
                        og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaAuditorios[0].prog_imag.Replace("~/", "");
                    }
                }

                //String del = " del " + listaAuditorios[i].prog_fini.Day.ToString() + " de " + funciones.determinaMes(listaAuditorios[i].prog_fini);
                //String al = " al " + listaAuditorios[i].prog_ffin.Day.ToString() + " de " + funciones.determinaMes(listaAuditorios[i].prog_ffin);
                //String temporada = del + al + "<br>" + listaAuditorios[i].prog_temp;

                //listaAuditorios[i].prog_temp = temporada;
                listaAuditorios[i].prog_desc = listaAuditorios[i].prog_desc + "...";
            }
            dlAuditorio.DataSource = listaAuditorios;
            dlAuditorio.DataBind();
        }
    }

    void llenarListaAuditorio(Int32 sede)
    {
        
        infoSedeAuditorio(sede);
        List<BEProgramacionAuditorio> listaAuditorios = oAuditorio.ListarTodos(sede);
        
        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "";

        if (listaAuditorios.Count > 0)
        {
            Session["tiene_contenido"] = true;

        }
        else {
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
        }
        for (int i = 0; i < listaAuditorios.Count; i++)
        {

            if (listaAuditorios[i].prog_imag != null)
            {
                listaAuditorios[i].prog_imag = string.Format("{0}{1}", rutaUpload, listaAuditorios[i].prog_imag);
                if (og_image.Content == "")
                {
                    og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" +  listaAuditorios[0].prog_imag.Replace("~/","");
                }
            }

            //String del = " del " + listaAuditorios[i].prog_fini.Day.ToString() + " de " + funciones.determinaMes(listaAuditorios[i].prog_fini);
            //String al = " al " + listaAuditorios[i].prog_ffin.Day.ToString() + " de " + funciones.determinaMes(listaAuditorios[i].prog_ffin);
            //String temporada = del + al + "<br>" + listaAuditorios[i].prog_temp;
            //listaAuditorios[i].prog_temp = temporada;
            listaAuditorios[i].prog_desc = listaAuditorios[i].prog_desc + "...";
        }
        
        dlAuditorio.DataSource = listaAuditorios;
        dlAuditorio.DataBind();
    }
    void infoSedeAuditorio(Int32 sede)
    {
        BESede eSede = oSede.ListarRegistro(sede);
        lblTituloSede.Text = "Auditorio " + eSede.sede_nomb;
        lblDireccionSede.Text = eSede.sede_dire.ToUpper();
        Session["id"] = sede;
        
        HtmlMeta og_title = (HtmlMeta)this.Master.FindControl("og_title");
        og_title.Content = lblTituloSede.Text;
        Session["title"] = lblTituloSede.Text;

        HtmlMeta og_description = (HtmlMeta)this.Master.FindControl("og_description");
        og_description.Content = HttpUtility.HtmlDecode(lblDireccionSede.Text);

        HtmlMeta og_url = (HtmlMeta)this.Master.FindControl("og_url");
        string link = HttpContext.Current.Request.Url.AbsoluteUri;
        if (Request.QueryString["id"] == null || Request.QueryString["id"] == String.Empty)
        {
            link += "?id=" + sede.ToString();
        }
        og_url.Content = link;
        Session["url"] = link;
    }

    void llenarSede()
    {
        List<BESede> listaSede = oSede.ListarTodosSedesAuditorios();
        if (listaSede.Count > 0)
        {
            foreach (BESede iSede in listaSede)
            {
                iSede.sede_nomb = "> AUDITORIO " + iSede.sede_nomb.ToUpper();
            }
        }
        dlSedes.DataSource = listaSede;
        dlSedes.DataBind();

    }
    protected void dlSedes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["tiene_contenido"] = false;
        llenarListaAuditorio(Convert.ToInt32(dlSedes.SelectedValue));
    }
    protected void dlAuditorio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProgramacion = Convert.ToInt32(dlAuditorio.SelectedValue);
        Session["idProgramacion"] = idProgramacion.ToString();
        Response.Redirect("Auditorio_Detalle.aspx?id=" + Session["idProgramacion"]);
    }
    protected void dlAuditorio_ItemDataBound(object sender, DataListItemEventArgs e)
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
            pDetalle.Width = 400;
        }
    }
}
