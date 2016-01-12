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

public partial class DataXml_dSucursal : System.Web.UI.Page
{
    BESede bSede = new BESede();
    BLSedeNTAD oSede = new BLSedeNTAD();
    Funciones funciones = new Funciones();
    GeneraXML generaXML = new GeneraXML();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<BESede> listaSede = oSede.ListarTodos();
        string sede = generaXML.xmlSucursalInfo(listaSede);
        Response.Write(sede);
    }



}