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
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Configuration;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;



public partial class MasterPage : System.Web.UI.MasterPage
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaImagen =  ConfigurationManager.AppSettings["images"].ToString();
    BECabecera bCabecera = new BECabecera();
    BLCabeceraNTAD oCabecera = new BLCabeceraNTAD();
    
    String tipoCriterio;
    String strfecha;
    String strTitulo;
    String strImagen;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        #region script fecha
        //recogemos la variable fecha
        if (Session["dtFecha"] != null)
        {
            strfecha = "'" + Session["dtFecha"].ToString() + "'";
        }
        else
        {
            strfecha = "'" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "'";

        }
        //definimos el script para fecha
        String appendFecha = " so_lateral.addVariable('fecha'," + strfecha + "); ";
        //escribiendo javascript fecha
        StringBuilder str = new StringBuilder();
        str.Append("<script type='text/javascript'>");
        str.Append(" var so_lateral = new SWFObject('swf/lateral_interna.swf','britanico','248','600','8','#FF0000'); ");
        str.Append(appendFecha);
        str.Append(" so_lateral.addParam('scale', 'noscale'); ");
        str.Append(" so_lateral.addParam('wmode','transparent'); ");
        str.Append("</script>");
        if (!Page.IsClientScriptBlockRegistered("fechacript"))
        {
            Page.RegisterClientScriptBlock("fechacript", str.ToString());
        }

        #endregion script fecha

        #region script titulos

        String paginaActual = Page.Title.Substring(28);
        strTitulo = "'" +  paginaActual + "'";
        strImagen = "'" + determinaCabecera(paginaActual) + "'";
        //definimos script titulos flash
        String appendTitulo = " so.addVariable('titulo'," + strTitulo + "); ";
        String appendImagen = " so.addVariable('imagen'," + strImagen + "); ";
        //escribiendo javascript titulos
        StringBuilder strCabecera = new StringBuilder();
        strCabecera.Append("<script type='text/javascript'>");
        strCabecera.Append(" var so = new SWFObject('swf/cabecera_interna.swf','britanico','700','223','8','#FF0000'); ");
        strCabecera.Append(appendTitulo);
        strCabecera.Append(appendImagen);
        strCabecera.Append(" so.addParam('scale', 'noscale'); ");
        strCabecera.Append(" so.addParam('wmode','transparent'); ");
        strCabecera.Append("</script>");

        if (!Page.IsClientScriptBlockRegistered("tituloscript"))
        {
            Page.RegisterClientScriptBlock("tituloscript", strCabecera.ToString());

        }
        #endregion script titulos

  
    }


    public string determinaCabecera(String tituloPagina)
    {
        
        String nombreImagen = "";
        bCabecera = oCabecera.ListarXTitulo(tituloPagina);
        if (bCabecera != null)
        {
            nombreImagen = rutaUpload.Replace("~/","") + bCabecera.cabe_imag;
        }
        else
        {
            switch (tituloPagina)
            {
                case "Noticias":
                    nombreImagen = ConfigurationManager.AppSettings["NOTICIAS"].ToString(); ;
                    break;
                case "Galería de Arte":
                    nombreImagen = ConfigurationManager.AppSettings["GALERIA DE ARTE"].ToString();
                    break;
                case "Cursos y Talleres":
                    nombreImagen = ConfigurationManager.AppSettings["CURSOS TALLERES"].ToString();
                    break;
                case "Producciones del Centro Cultural":
                    nombreImagen = ConfigurationManager.AppSettings["PRODUCCIONES TEATRALES"].ToString();
                    break;
                case "Agenda Cultural":
                    nombreImagen = ConfigurationManager.AppSettings["AGENDA CULTURAL"].ToString();
                    break;
                case "Teatro Británico":
                    nombreImagen = ConfigurationManager.AppSettings["TEATRO BRITANICO"].ToString();
                    break;
                case "Auditorios":
                    nombreImagen = ConfigurationManager.AppSettings["AUDITORIOS"].ToString();
                    break;
                case "Boletin":
                    nombreImagen = ConfigurationManager.AppSettings["BOLETIN"].ToString();
                    break;
                case "Británico en la Radio":
                    nombreImagen = ConfigurationManager.AppSettings["BRITANICO EN LA RADIO"].ToString();
                    break;
                case "Concursos":
                    nombreImagen = ConfigurationManager.AppSettings["CONCURSOS"].ToString();
                    break;
                case "Contáctenos":
                    nombreImagen = ConfigurationManager.AppSettings["CONTACTENOS"].ToString();
                    break;
                case "Proyectos":
                    nombreImagen = ConfigurationManager.AppSettings["PROYECTOS"].ToString();
                    break;

                case "Publicaciones":
                    nombreImagen = ConfigurationManager.AppSettings["PUBLICACIONES"].ToString();
                    break;
                case "Quiénes somos":
                    nombreImagen = ConfigurationManager.AppSettings["QUIENESSOMOS"].ToString();
                    break;



                default:
                    break;


            }

            nombreImagen = rutaImagen + nombreImagen;
        }
        return nombreImagen;
    }

   
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        String criterio = txtBuscar.Text;
        tipoCriterio = "1";

        //tipos de criterios por sede = 0, por criterio=1, por fecha = 2
        Session["criterio"] = criterio;
        Session["tipoCriterio"] = tipoCriterio;
        Response.Redirect("Agenda_Cultural.aspx");
    }
}
