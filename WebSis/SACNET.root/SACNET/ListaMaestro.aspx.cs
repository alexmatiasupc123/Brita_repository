using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oxinet.Tools;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Britanico.SacNet.BusinessEntities;

public partial class ListaTablasMaestro : System.Web.UI.Page
{

    #region "/--- Eventos de la Pagina ---/"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
            Buscar();
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Response.Redirect("MantMaestro.aspx");
    }

    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonNuevoClick += new EventHandler(BotonesEdicionLista1_OnBotonNuevoClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
    }

    void BotonesEdicionLista1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    void BotonesEdicionLista1_OnBotonBuscarClick(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "")
            {
                txtBuscar.Text = Valores[2].ToString();
            }
            
        }
    }
    
    protected void gvTablasMaestras_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
        string[] valores = e.CommandArgument.ToString().Split(new char[]{'&'} );
        string codtabla = valores[0];
        string nivel = string.Empty;
        if(valores.Length>1)
        nivel = valores[1];
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "VerDetalle":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codtabla + "&nv=" + nivel);
                Response.Redirect("ListaDetalle.aspx?pm="+ querystringENCRYP);
                break;
            case "Eliminar":
                Eliminar(e.CommandArgument.ToString());
                Buscar();
                break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codtabla + "&nv=" + nivel);
                Response.Redirect("MantMaestro.aspx?pm="+ querystringENCRYP);
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codtabla + "&nv=" + nivel + "&ver=1");
                Response.Redirect("MantMaestro.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;
        }

    }
   
    protected void gvTablasMaestras_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTablasMaestras.PageIndex = e.NewPageIndex;
        Buscar();
    }
 
    protected void gvTablasMaestras_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private void CargarPagina()
    {
        
    }

    private void Buscar()
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();

        if (RadioButtonBuscar.Items[0].Selected) // TODOS
            CargarMaestra(MaestroLogic.FiltroMaestro.PorTodo, "", "");
        if (RadioButtonBuscar.Items[1].Selected) // CÓDIGO
            CargarMaestra(MaestroLogic.FiltroMaestro.PorCodigoTabla, txtBuscar.Text, "");
        if (RadioButtonBuscar.Items[2].Selected) // NOMBRES
            CargarMaestra(MaestroLogic.FiltroMaestro.PorNombreCoincidencia, "", txtBuscar.Text);
    }

    private void CargarMaestra(MaestroLogic.FiltroMaestro pFiltroMaestro, string pCodTabla, string pNombre)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        List<TMaestro> lista = new List<TMaestro>();
        lista = oMaestroLogic.ListarTablas(pFiltroMaestro, pCodTabla, pNombre);
        gvTablasMaestras.DataSource = HelpConvert<TMaestro>.ConvertList(lista);
        gvTablasMaestras.DataBind();
        tsNumeroRegistros.Text = "Nº de regs: " + lista.Count.ToString().PadLeft(5, '0');
       
    }

    private void Eliminar(string pCodigoTabla)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        ReturnValor oReturn=new ReturnValor() ; //
        TMaestro item = new TMaestro();
        item = oMaestroLogic.ListarTablas(MaestroLogic.FiltroMaestro.PorCodigoTabla, pCodigoTabla, string.Empty)[0];
        oReturn = oMaestroLogic.EliminarMaestra(pCodigoTabla, item.Nivel);
        if (oReturn.Exitosa)
        {
            MessageBox1.ShowSuccess(oReturn.Message);
            Buscar();
        }
        else
        {
            MessageBox1.ShowWarning(oReturn.Message);
            return;
        }
    }

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaMaestro.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
            gvTablasMaestras.Columns[9].Visible = oRolesOpciones.Flag_Eliminar;
            gvTablasMaestras.Columns[8].Visible = oRolesOpciones.Flag_Editar;
            gvTablasMaestras.Columns[7].Visible = oRolesOpciones.Flag_Ver;
            BotonesEdicionLista1.BotonNuevo = false;
            BotonesEdicionLista1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
  
    #endregion

   
}
