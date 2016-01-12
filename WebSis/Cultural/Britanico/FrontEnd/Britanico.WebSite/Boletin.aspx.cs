using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.BusinessLogic.Transaccionales;

public partial class Boletin : System.Web.UI.Page
{
    String archivoB = ConfigurationManager.AppSettings["upLoad"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tipoCriterio"] != null && Session["tipoCriterio"].ToString() == "5")
        {
            enviaBoletin();
        }
        else if (Session["tipoCriterio"] != null && Session["tipoCriterio"].ToString() == "4")
        {    
                        BESuscriptor bSuscriptor = new BESuscriptor();
                        BLSuscriptorTAD oSuscriptor = new BLSuscriptorTAD();
                        bSuscriptor.susc_esta = 1;
                        bSuscriptor.susc_fech = DateTime.Now.Date;
                        bSuscriptor.susc_mail =  Session["criterio"].ToString();
                        bSuscriptor.susc_nomb = "No Especificado";
                        oSuscriptor.Agregar(bSuscriptor);
            if(bSuscriptor.susc_codi !=0)
            {
                        //enviaBoletin();
                        confirmar();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
                      //  lblMsg.Text = "Suscripcion Satisfactoria!!";
        
     
        }


      
    }

    void enviaBoletin()
    {
        BLBoletinNTAD oBoletin = new BLBoletinNTAD();
        BEBoletin bBoletin = oBoletin.UltimoBoletin();
        if (bBoletin != null)
        {
            //Establecer el ContentType adecuado.
            String archivo = string.Format("{0}{1}", archivoB, bBoletin.bole_nomb);

            Response.ContentType = "Application/pdf";
            //Escribir el archivo directamente en la secuencia de contenido HTTP.
            Response.WriteFile(archivo);
            Response.End();
        }

       
    }

    void  confirmar(){
        Type cstype = this.GetType();
        ClientScriptManager cs= Page.ClientScript;
        
        if (! cs.IsClientScriptBlockRegistered(cstype, "confirmar")) {

            StringBuilder cstxt = new StringBuilder();
            cstxt.Append("<script type=text/javascript> ");
            cstxt.Append("alert('Gracias por suscribirse a nuestro boletín virtual');");
            cstxt.Append("top.location.href='Default.aspx';");
            cstxt.Append("</script>");
            cs.RegisterClientScriptBlock(cstype, "confirmar", cstxt.ToString(), false);

        }
    }
}
