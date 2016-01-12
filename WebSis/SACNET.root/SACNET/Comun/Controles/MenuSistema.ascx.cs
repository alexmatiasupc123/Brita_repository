using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class Comun_Controles_MenuSistema : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //OpcionesLogic oOpcionesLogic = new OpcionesLogic();
            //Usuarios oUsuarios = (Usuarios)Session["oUsuario"];
            //List<Opciones> lista = oOpcionesLogic.Listar(oUsuarios.CodigoRol);
            //foreach (Opciones item in lista)
            //{
            //    item.Enlace = "../../Mantenimientos/" + item.Enlace;

            //}
            //DataTable dt = Converter<Opciones>.ConvertList(lista);
            //Menus menu = new Menus();
            //menu.CreateMenu(ref Menu1, dt);


           
        }

    }

}
