using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Security.Principal;

using Oxinet.Tools;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;


/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{


    #region "/--- Cargar Menu  ---/"

    public static void CargarMenu(ref TreeView pMenu, string pAgrupar)
    {
        pMenu.ExpandImageUrl = "Comun/Imagenes/Icons/tables_arrow.png";
        pMenu.NoExpandImageUrl = "Comun/Imagenes/Icons/table.png";
        pMenu.CollapseImageUrl = "Comun/Imagenes/Icons/tables.png";
        if (pAgrupar == "S")
        {
            CargarMenuAgrupado(ref  pMenu);
        }
        else if (pAgrupar == "N")
        {
            CargarMenuSimple(ref pMenu);
        }
    }
    private static void CargarMenuSimple(ref TreeView pMenu)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        List<TMaestro> lista = new List<TMaestro>();
        lista = oMaestroLogic.ListarTablas(MaestroLogic.FiltroMaestro.PorTodo, "", "");

        foreach (var item in lista)
        {
            TreeNode oTreeNode = new TreeNode();
            CargarTreeNode(ref oTreeNode, item);
            pMenu.Nodes.Add(oTreeNode);
        }

    }
    private static void CargarMenuAgrupado(ref TreeView pMenu)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        List<TMaestro> lista = new List<TMaestro>();
        lista = oMaestroLogic.ListarTablas(MaestroLogic.FiltroMaestro.PorTodo, "", "");

        var filtros = from x in lista
                      where x.Nivel == 1
                      select x;

        foreach (var item in filtros)
        {

            var filtro = from x in lista
                         where x.CodTabla == item.CodTabla
                         orderby x.Nivel
                         select x;
            List<TMaestro> listaNivel = filtro.ToList<TMaestro>();
            int lcount = listaNivel.Count;
            if (lcount > 1)
            {

                TreeNode oTreeNode = new TreeNode();
                oTreeNode.Text = item.Nombre;
                oTreeNode.ToolTip = item.Descripcion;
                // TreeView1.Nodes.Add(oTreeNode);

                foreach (var itemNivel in listaNivel)
                {
                    TreeNode ooTreeNode = new TreeNode();
                    CargarTreeNode(ref ooTreeNode, itemNivel);
                    oTreeNode.ChildNodes.Add(ooTreeNode);

                }

                pMenu.Nodes.Add(oTreeNode);
            }
            else
            {
                TreeNode oTreeNode = new TreeNode();
                CargarTreeNode(ref oTreeNode, item);
                pMenu.Nodes.Add(oTreeNode);
            }




        }
    }
    private static void CargarTreeNode(ref TreeNode pTreeNode, TMaestro item)
    {
        pTreeNode.Text = item.Nombre;
        pTreeNode.ToolTip = item.Descripcion;

        // pTreeNode.ImageUrl = "Comun/Imagenes/Icons/table.png";
        string lsHelpEncrypt = HelpEncrypt.Encriptar("id=" + item.CodTabla + "&nv=" + item.Nivel);
        pTreeNode.NavigateUrl = "ListaDetalle.aspx?pm=" + lsHelpEncrypt;
    }
    private static string MenuId = "CodigoOpcion";
    private static string PadreId = "CodigoOpcionPadre";
    private static string descripcion = "CodigoOpcionNombre";
    private static string Url = "CodigoOpcionEnlace";
    public static void CreateMenu(ref Menu mnuPrincipal, DataTable dtMenuItems)
    {
        mnuPrincipal.DynamicMenuItemStyle.CssClass = "cssLabel";
        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {

            //esta condicion indica q son elementos padre.
            //if (drMenuItem[MenuId].Equals(drMenuItem[PadreId]) || drMenuItem[PadreId].ToString().Trim() == "")
            if (drMenuItem[MenuId].Equals(drMenuItem[PadreId]) || 
                drMenuItem[PadreId].ToString().Trim() == "" ||
                drMenuItem[PadreId].ToString().Trim() == "0")//ELVP:11-10-2011
            {
                MenuItem mnuMenuItem = new MenuItem();
                mnuMenuItem.Value = drMenuItem[MenuId].ToString();

                mnuMenuItem.Text = drMenuItem[descripcion].ToString();
                //mnuMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                mnuMenuItem.NavigateUrl = drMenuItem[Url].ToString();

                //agregamos el Ítem al menú
                mnuPrincipal.Items.Add(mnuMenuItem);

                //hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                AddMenuItem(ref mnuMenuItem, dtMenuItems);

            }


        }

    }
    private static void AddMenuItem(ref MenuItem mnuMenuItem, DataTable dtMenuItems)
    {
        //recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        //del menuitem dado pasado como parametro ByRef.
        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (drMenuItem[PadreId].ToString().Equals(mnuMenuItem.Value) && !drMenuItem[MenuId].Equals(drMenuItem[PadreId]))
            {
                MenuItem mnuNewMenuItem = new MenuItem();
                mnuNewMenuItem.Value = drMenuItem[MenuId].ToString();
                mnuNewMenuItem.Text = drMenuItem[descripcion].ToString();
                //mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                mnuNewMenuItem.NavigateUrl = drMenuItem[Url].ToString();

                //Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem);

                //llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(ref mnuNewMenuItem, dtMenuItems);
            }

        }



    }


    #endregion

    public static int ObtenerPaginacion()
    {
        return Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Paginacion));
        
    }

    public static string PintarEstado(string pCodigoTabla, bool pEstado)
    {
        string estado = string.Empty;

        if (pCodigoTabla.Length != 0)
        {
            if (pEstado)
            {
                estado = "SI";
            }
            else
            {
                estado = "NO";
            }
        }
        return estado;
    }

   
    public static Boolean EsCorreoValido(string email)
    {
        return (System.Text.RegularExpressions.Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"));

    }

    public static ReturnValor CrearEnDiscoDuro(string Nombre, byte[] Archivo)
    {
        ReturnValor oReturn = new ReturnValor();
        try
        {
            string sTemp1 = Nombre;
            FileStream fs = new FileStream(sTemp1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Flush();
            fs.Write(Archivo, 0, Archivo.Length);
            fs.Close();
            oReturn.Exitosa = true;

        }
        catch (Exception ex)
        {
            oReturn.Message = ex.Message;
            oReturn.Exitosa = false;
        }
        return oReturn;

    }

    public static int DiasDePrestamo(DateTime prmFechaInicio, int DefaultDiasPrestamo, int DIAS_EXCESO, bool prmREDONDEA,string prmSabado)
    {
        int DIAS_DE_PRESTAMO = 0;
        List<TFeriados> lista = new List<TFeriados>();
        TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
        lista = oTFeriadosLogic.Listar(DateTime.Now.Year.ToString(), string.Empty, null, true);

        //int TOTAL_DIAS_A_CONTAR = (DefaultDiasPrestamo + DIAS_EXCESO); 
        int TOTAL_DIAS_A_CONTAR = (DefaultDiasPrestamo + DIAS_EXCESO) - 1;
        int TOTAL_DIAS = TOTAL_DIAS_A_CONTAR;
        
        DateTime Fecha_Final = DateTime.Now;
        DateTime DiaInicial = Fecha_Final;

        for (int dia = 1; dia <= TOTAL_DIAS_A_CONTAR; ++dia)
        {
            DateTime FechaABuscar = prmFechaInicio.AddDays(dia);
            string FechaFijaAnual = "0000" + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');
            string FechaVariaAnual = DateTime.Now.Year.ToString().Trim() + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');

            if (FechaABuscar.DayOfWeek == DayOfWeek.Sunday)
                ++TOTAL_DIAS_A_CONTAR;
            else
            {
                if (lista.Exists(x => x.sFeriado == FechaFijaAnual))
                    if (DiaInicial.DayOfWeek == DayOfWeek.Saturday && FechaABuscar.DayOfWeek == DayOfWeek.Saturday)
                        TOTAL_DIAS_A_CONTAR = TOTAL_DIAS_A_CONTAR + TOTAL_DIAS;
                    else
                        ++TOTAL_DIAS_A_CONTAR;

                if (lista.Exists(x => x.sFeriado == FechaVariaAnual))
                    if (DiaInicial.DayOfWeek == DayOfWeek.Saturday && FechaABuscar.DayOfWeek == DayOfWeek.Saturday)
                        TOTAL_DIAS_A_CONTAR = TOTAL_DIAS_A_CONTAR + TOTAL_DIAS;
                    else
                        ++TOTAL_DIAS_A_CONTAR;
            }
            Fecha_Final = FechaABuscar;
        }
        double ndiasx = 0;

        if (prmREDONDEA)
            ndiasx = HelpDates.Intervalo(Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(Fecha_Final.ToShortDateString() + " 23:59"), HelpDates.Tipo.Dias);
        else
            ndiasx = HelpDates.Intervalo(Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(Fecha_Final.ToShortDateString()), HelpDates.Tipo.Dias);

        return DIAS_DE_PRESTAMO = Convert.ToInt32(ndiasx);
    }

    public static DateTime DiasDeDevolucion(DateTime prmFechaFinal,DateTime prmFechaFinalNormal, int DefaultDiasAnticipado, int DIAS_EXCESO, bool prmREDONDEA, string prmSabado)
    {
        //int DIAS_DE_PRESTAMO = 0;
        List<TFeriados> lista = new List<TFeriados>();
        TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
        lista = oTFeriadosLogic.Listar(DateTime.Now.Year.ToString(), string.Empty, null, true);

        if(prmSabado == "S") DefaultDiasAnticipado = 0;

        int TOTAL_DIAS_A_DESCONTAR = (DefaultDiasAnticipado + DIAS_EXCESO);

        

        DateTime Fecha_Final = prmFechaFinal;

        ////ELVP:09/07/2011
        //if (prmFechaFinalNormal <= prmFechaFinal.AddDays(-1 * DefaultDiasAnticipado))
        //    return prmFechaFinalNormal;

        for (int dia = 0; dia <= TOTAL_DIAS_A_DESCONTAR; ++dia)
        {
            DateTime FechaABuscar = prmFechaFinal.AddDays(dia * -1);
            string FechaFijaAnual = "0000" + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');
            string FechaVariaAnual = DateTime.Now.Year.ToString().Trim() + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');

            if (FechaABuscar.DayOfWeek == DayOfWeek.Sunday)
                ++TOTAL_DIAS_A_DESCONTAR;
            else
            {
                if (lista.Exists(x => x.sFeriado == FechaFijaAnual))
                    ++TOTAL_DIAS_A_DESCONTAR;
                if (lista.Exists(x => x.sFeriado == FechaVariaAnual))
                    ++TOTAL_DIAS_A_DESCONTAR;
            }
            Fecha_Final = FechaABuscar;
        }
        double ndiasx = 0;
        if (prmREDONDEA)
            ndiasx = HelpDates.Intervalo(Convert.ToDateTime(Fecha_Final.ToShortDateString()), Convert.ToDateTime(prmFechaFinalNormal.ToShortDateString() + " 23:59"), HelpDates.Tipo.Dias);
        else
            ndiasx = HelpDates.Intervalo(Convert.ToDateTime(Fecha_Final.ToShortDateString()), Convert.ToDateTime(prmFechaFinalNormal.ToShortDateString()), HelpDates.Tipo.Dias);

        return Fecha_Final; // prmFechaFinalNormal.AddDays(Convert.ToInt32(ndiasx) * -1);
    }

    public static DateTime DiasDeDevolucionNuevo(DateTime prmFechaFinalClase, DateTime prmFechaEntrega, int DefaultDiasAntesFinCurso, int DIAS_EXCESO, bool prmREDONDEA)
    {
        List<TFeriados> lista = new List<TFeriados>();
        TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
        lista = oTFeriadosLogic.Listar(DateTime.Now.Year.ToString(), string.Empty, null, true);

        DateTime fechaEntrega = prmFechaEntrega;

        bool diaHabil = false;
        if (fechaEntrega <= prmFechaFinalClase.AddDays(-1 * DefaultDiasAntesFinCurso))
            return fechaEntrega;
        else
        {
            fechaEntrega = prmFechaFinalClase.AddDays(-1 * DefaultDiasAntesFinCurso);
            string FechaFijaAnual = "0000" + fechaEntrega.Month.ToString().Trim().PadLeft(2, '0') + fechaEntrega.Day.ToString().Trim().PadLeft(2, '0');
            string FechaVariaAnual = DateTime.Now.Year.ToString().Trim() + fechaEntrega.Month.ToString().Trim().PadLeft(2, '0') + fechaEntrega.Day.ToString().Trim().PadLeft(2, '0');

            while (diaHabil == false)
            {
                if (fechaEntrega.DayOfWeek == DayOfWeek.Sunday ||
                    (lista.Exists(x => x.sFeriado == FechaFijaAnual)) ||
                    (lista.Exists(x => x.sFeriado == FechaVariaAnual)))
                {
                    diaHabil = false;
                    fechaEntrega = fechaEntrega.AddDays(-1);
                }
                else
                    diaHabil = true;
            }//Fin while dia hábil

        }

        return fechaEntrega; // prmFechaFinalNormal.AddDays(Convert.ToInt32(ndiasx) * -1);
    }

    public static void ExportTextoAll(string fileName, GridView gv)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "text/plain"; //application/ms-excel
        string[] columnasdelete = new string[10];
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {

                //  Create a form to contain the grid                              

                Table table = new Table();
                //GridView gv2 = gv;
                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    Util.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    Util.PrepareControlForExport(row);
                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    Util.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];

            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).ToolTip));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                Util.PrepareControlForExport(current);

            }
        }
    }

    //ELVP: 21-10-2011 Para acceso desde la Intranet en caso el password llegue encriptado
    public static string SRT_DesEncripta(string pstrPalabra)
    {
        try
        {
            string inversoE, original;
            int b, i1d;

            original = "";
            inversoE = DesEncriptaBritanico(pstrPalabra);
            i1d = inversoE.Length;

            for (b = i1d - 1; b >= 0; b--)
                original = original + inversoE.Substring(b, 1);

            return original;
        }
        catch
        {
            throw;
        }

    }
    public static string DesEncriptaBritanico(string par_password)
    {
        float Caracter, semilla;
        int longitud, counter;
        string cifrado = "", prueba;

        longitud = par_password.Length;


        for (counter = 1; counter <= longitud; counter++)
        {
            // El caracter debera estar en un rango de 1 a 256
            Caracter = par_password.Substring(counter - 1, 1).ToUpper().ToCharArray()[0];
            semilla = counter;
            Caracter -= semilla;
            prueba = ((char)Caracter).ToString();
            cifrado = String.Format("{0}{1}", cifrado, prueba);
        }
        return cifrado;
    }
}
