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
public partial class Cursos_Talleres : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BESede bSede = new BESede();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BECursoTaller bCurso = new BECursoTaller();
    Funciones funciones = new Funciones();
    BLCursoTallerNTAD oCurso = new BLCursoTallerNTAD();

    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    List<BEInformacion> listaInformacion = new List<BEInformacion>();
    
    public bool tiene_contenido = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["tiene_contenido"] = false;
            llenarSede();
            if (Request.QueryString["id"] != null && functions.IsInteger(Request.QueryString["id"].ToString()) == true)
            {
                llenarListaCurso(Convert.ToInt32(Request.QueryString["id"]));
            }
            else
            {
                llenarListaInicialCursos();
            }
            listaInformacion = oInformacion.ListarTodosXEvento(4);

            if (listaInformacion.Count > 0)
            {
                dlProximosEventos.DataSource = listaInformacion;
                dlProximosEventos.DataBind();
            }

        }
    }

    void llenarListaInicialCursos()
    {
        Int32 sede=0;
        List<BESede> listaSede = oSede.ListarTodosSedesCursos();
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
            infoSedeCursos(sede);
            List<BECursoTaller> listaCursos = oCurso.ListarTodos(sede);
            if (listaCursos.Count > 0) {
                Session["tiene_contenido"] = true;
            }
            else
            {
                og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
            }
            for (int i = 0; i < listaCursos.Count; i++)
            {
                if (listaCursos[i].curs_imag != null)
                {
                    listaCursos[i].curs_imag = string.Format("{0}{1}", rutaUpload, listaCursos[i].curs_imag);
                    if (og_image.Content == "")
                    {
                       // og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaCursos[i].curs_imag.Replace("~/", "");
                        listaCursos[i].curs_imag = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaCursos[i].curs_imag.Replace("~/", "");
                    }
                }

                //String inicio = " Inicio " + listaCursos[i].curs_fini.Day.ToString() + " de " + funciones.determinaMes(listaCursos[i].curs_fini);
                //String horario = inicio + "<br>" + listaCursos[i].curs_hora;
                //listaCursos[i].curs_hora = horario;
                listaCursos[i].curs_desc = listaCursos[i].curs_desc + "...";
            }
            dlCursos.DataSource = listaCursos;
            dlCursos.DataBind();
        }
    }

    void llenarListaCurso(Int32 sede )
    {
        
        infoSedeCursos(sede);
        List<BECursoTaller> listaCursos = oCurso.ListarTodos(sede);
        
        HtmlMeta og_image = (HtmlMeta)this.Master.FindControl("og_image");
        og_image.Content = "";

        if (listaCursos.Count > 0)
        {
            Session["tiene_contenido"] = true;
        }
        else
        {
            og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/images/transparent.png";
        }

        for (int i = 0; i < listaCursos.Count; i++)
        {

          if (listaCursos[i].curs_imag != null)
          {
              listaCursos[i].curs_imag = string.Format("{0}{1}", rutaUpload, listaCursos[i].curs_imag);
              if (og_image.Content == "")
              {
                  //og_image.Content = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaCursos[0].curs_imag.Replace("~/", "");
                  listaCursos[i].curs_imag = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/" + listaCursos[0].curs_imag.Replace("~/", "");
              }
          }

          //String inicio = " Inicio " + listaCursos[i].curs_fini.Day.ToString() + " de " + funciones.determinaMes(listaCursos[i].curs_fini);
          //String horario = inicio + "<br>" + listaCursos[i].curs_hora;
          //listaCursos[i].curs_hora = horario;
          listaCursos[i].curs_desc = listaCursos[i].curs_desc + "...";
        }
      

        dlCursos.DataSource = listaCursos;
        dlCursos.DataBind();
    }
    void infoSedeCursos(Int32 sede)
    {
        BESede eSede = oSede.ListarRegistro(sede);
        lblTituloSede.Text = "Cursos y Talleres " + eSede.sede_nomb;
        lblDireccionSede.Text = eSede.sede_dire.ToUpper() + " - " + eSede.sede_nomb.ToUpper();
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
        List<BESede> listaSede = oSede.ListarTodosSedesCursos();
        
        if (listaSede.Count > 0)
        {
            foreach (BESede iSede in listaSede)
            {
                
                iSede.sede_nomb = "> CURSOS Y TALLERES " + iSede.sede_nomb.ToUpper();
               
            }
        }
        dlSedes.DataSource = listaSede;
        dlSedes.DataBind();

    }
    protected void dlSedes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["tiene_contenido"] = false;
        llenarListaCurso( Convert.ToInt32(dlSedes.SelectedValue));
    }
    protected void dlCursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idCurso = Convert.ToInt32(dlCursos.SelectedValue);
        Session["idCurso"] = idCurso.ToString();
        Response.Redirect("CursoTaller_Detalle.aspx?id=" + Session["idCurso"]);
    }
    protected void dlCursos_ItemDataBound(object sender, DataListItemEventArgs e)
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
