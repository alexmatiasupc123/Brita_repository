using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.Web.BusinessEntities;
using System.Collections.Generic;
using Britanico.Utilitario.Funciones;
using Britanico.XML;

public partial class DataXml_dEventoPrincipal : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();

    Funciones funciones = new Funciones();
    GeneraXML generaXML = new GeneraXML();
    BLEventoNTAD oEvento = new BLEventoNTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<BEEvento> listaEvento = oEvento.ListarTodosDestacados();
        string evento = generaXML.xmlEventoPrincipalInfo(listaEvento, rutaUpload);
        Response.Write(evento);

    }



}