using System;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Text;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.Web.BusinessEntities;
using System.Collections.Generic;
using Britanico.Utilitario.Funciones;
using Britanico.XML;

public partial class DataXml_dNoticia : System.Web.UI.Page
{
    BENoticia bNoticia = new BENoticia();
    Funciones funciones = new Funciones();
    GeneraXML generaXML = new GeneraXML();
    BLNoticiaNTAD oNoticia = new BLNoticiaNTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<BENoticia> listaNoticias = oNoticia.ListarTodosXMes();
        string noticia = generaXML.xmlNoticiaInfo(listaNoticias);
        Response.Write(noticia);
      
    }



}