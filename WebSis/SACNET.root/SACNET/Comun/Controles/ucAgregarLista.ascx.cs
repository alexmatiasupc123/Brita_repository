using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;
public partial class Comun_Controles_ucAgregarLista : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                hfCodTabla.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "oCodTabla");
                hfCodItem.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "oCodItem");
                
                CargarDatosLista(hfCodTabla.Value);
            }
        }
    }
    private void CargarDatosLista(string sCodTabla)
    {
        HelpMaestros.CargarListadoGenerico(ref ltbItemsCodArgu, sCodTabla, 1, "", MaestroLogic.EstadoDetalle.Habilitado,txtNombre.Text);
        ClasificacionItems(0, (List<TDetalle>)Session[hfCodTabla.Value]);

    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {
        HelpMaestros.CargarListadoGenerico(ref ltbItemsCodArgu, hfCodTabla.Value, 1, "", MaestroLogic.EstadoDetalle.Habilitado, txtNombre.Text);
        ClasificacionItems(0, (List<TDetalle>)Session[hfCodTabla.Value]);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ltbItemsCodArgu.Items.Count > 0)
        {
            foreach (ListItem item1 in ltbItemsCodArgu.Items)
            {
                if (item1.Selected)
                {
                    item1.Selected = false;
                    if (ltbItemsSelect.Items.Contains(item1) == false)
                    {
                        ltbItemsSelect.Items.Add(item1);


                    }
                        
                }
            }
            foreach (ListItem item2 in ltbItemsSelect.Items)
            {

                if (ltbItemsCodArgu.Items.Contains(item2))
                    ltbItemsCodArgu.Items.Remove(item2);
            }
            CargarDatosSeleccionados();

        }
        
    }
    protected void hfCodTabla_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void btnQuitar_Click(object sender, EventArgs e)
    {
        List<int> ListaIndicesDelete = new List<int>();
        List<TDetalle> ListaItemsTotales = new List<TDetalle>();
        if (Session[hfCodTabla.Value] != null)
        {
            ListaItemsTotales = (List<TDetalle>)Session[hfCodTabla.Value];
        }
        foreach (ListItem itemDelete in ltbItemsSelect.Items)
        {
            if (itemDelete.Selected)
            {
                ListaIndicesDelete.Add(ltbItemsSelect.Items.IndexOf(itemDelete));
                
            }   
        }
        foreach (int index in ListaIndicesDelete)
        {
            ltbItemsCodArgu.Items.Add(ltbItemsSelect.Items[index]);
            ltbItemsSelect.Items.RemoveAt(index);
            
            if (ListaItemsTotales.Count > 0)
            {
                
                if (ListaItemsTotales[index].Activo == true) //nuevo
                {
                    ListaItemsTotales.RemoveAt(index);
                }
                else
                {
                    if (hfCodItem.Value != null)
                    {
                        if (HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems) == ListaItemsTotales[index].CodArgu.Substring(0, 5))
                        {
                            (new ItemLogic()).EliminarAutor(hfCodItem.Value, ListaItemsTotales[index].CodArgu);
                        }
                        if (HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras) == ListaItemsTotales[index].CodArgu.Substring(0, 5))
                        {
                            (new ItemLogic()).EliminarActor(hfCodItem.Value, ListaItemsTotales[index].CodArgu);
                        }
                        if (HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas) == ListaItemsTotales[index].CodArgu.Substring(0, 5))
                        {
                            (new ItemLogic()).EliminarTema(hfCodItem.Value, ListaItemsTotales[index].CodArgu);
                        }
                        if (HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales) == ListaItemsTotales[index].CodArgu.Substring(0, 5))
                        {
                            (new ItemLogic()).EliminarAutorInstitucional(hfCodItem.Value, ListaItemsTotales[index].CodArgu);
                        }
                        ListaItemsTotales.RemoveAt(index);
                    }
                    
                    
                }
                
            }
            
        }
       

        CargarDatosLista(hfCodTabla.Value);
        Session[hfCodTabla.Value] = ListaItemsTotales;
        if (ltbItemsSelect.Items.Count == 0)
            Session[hfCodTabla.Value] = null;

        CargarDatosSeleccionados();

    }
    protected void ltbItemsCodArgu_PreRender(object sender, EventArgs e)
    {
        foreach (ListItem item in ltbItemsCodArgu.Items)
        {
            item.Attributes.Add("title", item.Text);
        }
    }
    protected void ltbItemsSelect_PreRender(object sender, EventArgs e)
    {
        foreach (ListItem item in ltbItemsSelect.Items)
        {
            item.Attributes.Add("title", item.Text);
        }
    }
    private void CargarDatosSeleccionados()
    {
        List<TDetalle> ListaItemsTotales = new List<TDetalle>();
        if (Session[hfCodTabla.Value] != null)
        {
            ListaItemsTotales = (List<TDetalle>)Session[hfCodTabla.Value];
        }

        foreach (ListItem itemListaSelec in ltbItemsSelect.Items)
        {
            if (!ListaItemsTotales.Exists(x => x.CodArgu == itemListaSelec.Value))
            {
                ListaItemsTotales.Add(new TDetalle { CodArgu = itemListaSelec.Value, Nombre = itemListaSelec.Text, Activo = true }); // Item Nuevo.
            }

        }
        ClasificacionItems(1, ListaItemsTotales);        
       
    }
    private void EliminarItemsSeleccionados(List<TDetalle> Lista)
    {
        foreach (TDetalle item in Lista)
        {
            ltbItemsCodArgu.Items.Remove(new ListItem(item.Nombre,item.CodArgu));
        }
    }
    private void ClasificacionItems(int pGetSet, List<TDetalle> Lista)
    {
        if (hfCodTabla.Value != null)
        {
            if (pGetSet == 0)//get-Pintar Datos
            {
                if (Session[hfCodTabla.Value] != null)
                {
                    EliminarItemsSeleccionados(Lista);
                    ltbItemsSelect.DataSource = Lista;//;
                    ltbItemsSelect.DataTextField = "Nombre";
                    ltbItemsSelect.DataValueField = "CodArgu";
                    ltbItemsSelect.DataBind(); 
                }
                
            }
            else if (pGetSet == 1) //get-Asignar Datos
                Session[hfCodTabla.Value] = Lista;
            
        }
                
    }
}
