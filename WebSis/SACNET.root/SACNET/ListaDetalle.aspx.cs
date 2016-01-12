using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oxinet.Tools;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Britanico.SacNet.BusinessEntities;



public partial class ListaDetalle : System.Web.UI.Page
{

    private TMaestro propTMaestro { get; set; }

    #region "/--- Eventos de la Pagina ---/"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            ConfigurarPage();
        }
        Seguridad();
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Util.CargarMenu(ref TreeView1, "S");

            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                string POSindex = HelpEncrypt.QueryString(querystringDESENCRYP, "xSI");
                if (POSindex != string.Empty)
                    RadioButtonBuscar.SelectedIndex = Convert.ToInt32(POSindex);
                txtBuscar.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xTF");
                RadioButtonBuscar_SelectedIndexChanged(sender, e);
            }

            BuscarLista(); 
        }
        Page.Title = lblTituloPagina.Text;
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
        BuscarLista();
    }
    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        String querystringENCRYP = HelpEncrypt.Encriptar("id=" + HF_CodTabla.Value + "&nv=" + HF_Nivel.Value);
        Response.Redirect("MantDetalle.aspx?pm=" + querystringENCRYP);
    }
    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "Nave")
            {
                txtBuscar.Text = Valores[2].ToString();
            }
        }
    }
    protected void gvTablasDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
        string[] valores = e.CommandArgument.ToString().Split(new char[]{'&'} );
        string codtabla = valores[0];
        string codargum = string.Empty;
        string nivel = string.Empty;
        if (valores.Length > 1)
        {
            codargum = valores[1];
            nivel = valores[2];
        }
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "Eliminar":
                Eliminar(e.CommandArgument.ToString());
                BuscarLista();
                break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codtabla + "&ca=" + codargum + "&nv=" + nivel + ParametrosDelFiltro());
                Response.Redirect("MantDetalle.aspx?pm=" + querystringENCRYP);
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codtabla + "&ca=" + codargum + "&nv=" + nivel + "&ver=1" + ParametrosDelFiltro());
                Response.Redirect("MantDetalle.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;
        }
    }
   
    protected void gvTablasDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTablasDetalle.PageIndex = e.NewPageIndex;
        BuscarLista();
    }
    protected void ddlNivel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel1.SelectedIndex > 0)
        {
            HelpMaestros.CargarListadoGenerico(ref ddlNivel2, HF_CodTabla.Value, 2, ddlNivel1.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, ddlNivel1.SelectedValue.ToString(), txtBuscar.Text);
            enabledCombo(ddlNivel2, true);
        }
        else
        {
            enabledCombo(ddlNivel2, false);
            enabledCombo(ddlNivel3, false);
            enabledCombo(ddlNivel4, false);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, "", txtBuscar.Text);

        }
    }
    protected void ddlNivel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel2.SelectedIndex > 0)
        {
            HelpMaestros.CargarListadoGenerico(ref ddlNivel3, HF_CodTabla.Value, 3, ddlNivel2.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, ddlNivel2.SelectedValue.ToString(), txtBuscar.Text);
            enabledCombo(ddlNivel3, true);
        }
        else
        {

            enabledCombo(ddlNivel3, false);
            enabledCombo(ddlNivel4, false);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, "", txtBuscar.Text);
        }
    }
    protected void ddlNivel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel3.SelectedIndex > 0)
        {
            HelpMaestros.CargarListadoGenerico(ref ddlNivel4, HF_CodTabla.Value, 4, ddlNivel3.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, ddlNivel3.SelectedValue.ToString(), txtBuscar.Text);
            enabledCombo(ddlNivel4, true);
        }
        else
        {
            enabledCombo(ddlNivel4, false);
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, "", txtBuscar.Text);
        }
    }
    protected void ddlNivel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel4.SelectedIndex > 0)
        {
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, ddlNivel4.SelectedValue.ToString(), txtBuscar.Text);
        }
        else
        {
            CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, "", txtBuscar.Text);
        }
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        BuscarLista();
    }
    protected void RadioButtonBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonBuscar.Items[0].Selected)
        {
            txtBuscar.Text = string.Empty;
            txtBuscar.Visible = false;
        }
            
        if (RadioButtonBuscar.Items[1].Selected)
            txtBuscar.Visible = true;
        if (RadioButtonBuscar.Items[2].Selected)
            txtBuscar.Visible = true;
    }
    
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;

        sParameters = "&xSI=" + RadioButtonBuscar.SelectedIndex.ToString();
        sParameters = sParameters + "&xTF=" + txtBuscar.Text.ToString();
        return sParameters;
    }

    private void BuscarLista()
    {
        if (Request.QueryString.Get("pm") != null)
        {
            string codArgu;
            codArgu = ddlNivel1.SelectedIndex > 0 ? ddlNivel1.SelectedValue.ToString() : "";
            codArgu = ddlNivel2.SelectedIndex > 0 ? ddlNivel2.SelectedValue.ToString() : codArgu;
            codArgu = ddlNivel3.SelectedIndex > 0 ? ddlNivel3.SelectedValue.ToString() : codArgu;
            codArgu = ddlNivel4.SelectedIndex > 0 ? ddlNivel4.SelectedValue.ToString() : codArgu;

            if (RadioButtonBuscar.Items[0].Selected)
                CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, codArgu, "");
            if (RadioButtonBuscar.Items[1].Selected)
            {
                if (txtBuscar.Text.Length >= codArgu.Length && txtBuscar.Text.Contains(codArgu))
                    CargarDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento, txtBuscar.Text, "");
                else
                    CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, codArgu, "");
            }
            if (RadioButtonBuscar.Items[2].Selected)
                CargarDetalle(MaestroLogic.FiltroDetalle.PorCodArguNombreCoincidencia, codArgu, txtBuscar.Text);
        }
    }

    private void CargarDetalle(MaestroLogic.FiltroDetalle pFiltroDetalle, string pCodArgu, string pNombre)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        List<TDetalle> lista = oMaestroLogic.ListarDetalle(pFiltroDetalle, HF_CodTabla.Value, Convert.ToInt32(HF_Nivel.Value), pCodArgu, pNombre);
        gvTablasDetalle.DataSource = HelpConvert<TDetalle>.ConvertList(lista);
        gvTablasDetalle.DataBind();
        HelpGridView.Caption(ref gvTablasDetalle, "Lista de registros", lista.Count.ToString());
    }

    private void ConfigurarPage()
    {
        if (Request.QueryString.Get("pm") != null)
        {
            BotonesEdicionLista1.Visible = true;
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            HF_CodTabla.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
            HF_Nivel.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "nv");
            MaestroLogic oMaestroLogic = new MaestroLogic();
            propTMaestro = oMaestroLogic.BuscarTablaDescripcion(HF_CodTabla.Value, Convert.ToInt32(HF_Nivel.Value));

            lblTituloPagina.Text = "TABLA: " + propTMaestro.Nombre;

            Page.Title = lblTituloPagina.Text;
            switch (Convert.ToInt32(HF_Nivel.Value))
            {
                case 2:
                    lblNivel1.Visible = true;
                    ddlNivel1.Visible = true;
                    lblNivel1.Text = propTMaestro.NombreNivel1;
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel1, HF_CodTabla.Value, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    break;
                case 3:
                    lblNivel1.Visible = true;
                    ddlNivel1.Visible = true;
                    lblNivel2.Visible = true;
                    ddlNivel2.Visible = true;
                    lblNivel1.Text = propTMaestro.NombreNivel1;
                    lblNivel2.Text = propTMaestro.NombreNivel2;
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel1, HF_CodTabla.Value, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);

                    break;
                case 4:
                    lblNivel1.Visible = true;
                    ddlNivel1.Visible = true;
                    lblNivel2.Visible = true;
                    ddlNivel2.Visible = true;
                    lblNivel3.Visible = true;
                    ddlNivel3.Visible = true;
                    lblNivel1.Text = propTMaestro.NombreNivel1;
                    lblNivel2.Text = propTMaestro.NombreNivel2;
                    lblNivel3.Text = propTMaestro.NombreNivel3;
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel1, HF_CodTabla.Value, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel3, HelpComboBox.Texto.Todos);
                    break;

                case 5:
                    lblNivel1.Visible = true;
                    ddlNivel1.Visible = true;
                    lblNivel2.Visible = true;
                    ddlNivel2.Visible = true;
                    lblNivel3.Visible = true;
                    ddlNivel3.Visible = true;
                    lblNivel4.Visible = true;
                    ddlNivel4.Visible = true;
                    lblNivel1.Text = propTMaestro.NombreNivel1;
                    lblNivel2.Text = propTMaestro.NombreNivel2;
                    lblNivel3.Text = propTMaestro.NombreNivel3;
                    lblNivel4.Text = propTMaestro.NombreNivel4;
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel1, HF_CodTabla.Value, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel3, HelpComboBox.Texto.Todos);
                    HelpComboBox.AddItemText(ref ddlNivel4, HelpComboBox.Texto.Todos);
                    break;
            }

            gvTablasDetalle.Columns[4].Visible = propTMaestro.VerValorCadena;
            gvTablasDetalle.Columns[5].Visible = propTMaestro.VerValorCadenaCorta;
            gvTablasDetalle.Columns[6].Visible = propTMaestro.VerValorCadenaLarga;
            gvTablasDetalle.Columns[7].Visible = propTMaestro.VerValorDecimal;
            gvTablasDetalle.Columns[8].Visible = propTMaestro.VerValorEntero;
            gvTablasDetalle.Columns[9].Visible = propTMaestro.VerValorBoolean;

            gvTablasDetalle.Columns[4].HeaderText = propTMaestro.NombreValorCadena;
            gvTablasDetalle.Columns[5].HeaderText = propTMaestro.NombreValorCadenaCorta;
            gvTablasDetalle.Columns[6].HeaderText = propTMaestro.NombreValorCadenaLarga;
            gvTablasDetalle.Columns[7].HeaderText = propTMaestro.NombreValorDecimal;
            gvTablasDetalle.Columns[8].HeaderText = propTMaestro.NombreValorEntero;
            gvTablasDetalle.Columns[9].HeaderText = propTMaestro.NombreValorBoolean;
        }
        else
        {
            RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaDetalle.aspx");
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            Page.Title = oRolesOpciones.CodigoOpcionNombre;
            pnlPanelGeneral.Visible = false;
        }
    }

    private void Eliminar(string pCodigoArgumento)
    {
        MaestroLogic oMaestroLogic = new MaestroLogic();
        ReturnValor oReturn=new ReturnValor() ; //
        oReturn = oMaestroLogic.EliminarDetalle(pCodigoArgumento);
        if (oReturn.Exitosa)
        {
            MessageBox1.ShowSuccess(oReturn.Message);
            BuscarLista();
        }
        else
        {
            MessageBox1.ShowWarning(oReturn.Message);
            return;
        }
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaDetalle.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaDetalle.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drVer = dt.Select("Tipo=2");
            DataTable dtVer = drVer.Length>0? drVer.CopyToDataTable(): new DataTable();

            DataRow[] drEliminar = dt.Select("Tipo=3");
            DataTable dtEliminar = drEliminar.Length>0? drEliminar.CopyToDataTable(): new DataTable();

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();
            
            if (dtVer.Rows.Count > 0)
            {
                gvTablasDetalle.Columns[12].Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
            }
            if (dtEliminar.Rows.Count > 0)
            {
                gvTablasDetalle.Columns[13].Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
            }
            if (dtEditar.Rows.Count > 0)
            {
                gvTablasDetalle.Columns[14].Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                BotonesEdicionLista1.BotonNuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }

            BotonesEdicionLista1.LoadComplete();

            //gvTablasDetalle.Columns[12].Visible = oRolesOpciones.Flag_Ver;
            //gvTablasDetalle.Columns[13].Visible = oRolesOpciones.Flag_Editar;
            //gvTablasDetalle.Columns[14].Visible = oRolesOpciones.Flag_Eliminar;
            //BotonesEdicionLista1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionLista1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
  
    private void enabledCombo(DropDownList pControl, bool pValor)
    {

        if (pControl.SelectedIndex > 0)
        { pControl.SelectedIndex = 0; }
        pControl.Enabled = pValor;
    }
  
    #endregion
   
}
