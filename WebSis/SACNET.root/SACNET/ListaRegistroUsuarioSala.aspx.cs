using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;


public partial class ListaRegistroUsuarioSala : System.Web.UI.Page
{
    
    #region "/--- Eventos de la Página ---/"

    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                prm_dFechaINI.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFI") == string.Empty ? prm_dFechaINI.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFI");
                prm_dFechaFIN.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFF") == string.Empty ? prm_dFechaFIN.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFF");
                prm_sCodUsuarioSAC.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xCU");

                if (this.Master.HelpUsuariosSAC().CodLocalSAC != null)
                {
                    if (this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() != string.Empty)
                    {
                        prm_sEstablecimientoCodigo.SelectedValue = this.Master.HelpUsuariosSAC().CodLocalSAC.Trim();
                        prm_sEstablecimientoCodigo.Enabled = false;
                    }
                    else
                        prm_sEstablecimientoCodigo.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xCS");
                }
                else
                    prm_sEstablecimientoCodigo.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xCS");

                prm_sNombresUsuarioSAC.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xNU");

            }
            Buscar();
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    #endregion
    
    #region "/--- Eventos de los Controles  ---/"

    #region "/--- Eventos de la Barra de Botones  ---/"

    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonNuevoClick += new EventHandler(BotonesEdicionLista1_OnBotonNuevoClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
    }
    
    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        String querystringENCRYP = string.Empty;
        querystringENCRYP = HelpEncrypt.Encriptar(ParametrosDelFiltro());
        Response.Redirect("ProRegistroUsuarioSala.aspx?pm=" + querystringENCRYP);
        Response.Redirect("ProRegistroUsuarioSala.aspx");
    }

    //ELVP: 15-07-2011
    //void BotonesEdicionLista1_OnBotonGuardarClick(object sender, EventArgs e)
    //{
    //    Response.Redirect("Default.aspx");
    //}

    void BotonesEdicionLista1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    void BotonesEdicionLista1_OnBotonBuscarClick(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void ButtonConfirmaSolicitud_Click(object sender, EventArgs e)
    {
        //string mensaje = Validar();
        //if (mensaje == "")
        //{
        //    MessageBox1.ShowConfirm("¿ Confirma actualizar las solicitudes a estado Solicitud de impresión ?", HelpEvento.Guardar.ToString());
        //}
        //else
        //{
        //    MessageBox1.ShowInfo(mensaje);
        //}
    }
    #endregion

    //protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    //{
    //    if (parameter.Trim() != "")
    //    {
    //        string[] Valores = parameter.Split(new char[] { '&' });
    //        if (Valores[0].ToString() == "")
    //        {

    //        }
    //    }
    //}

    protected void gvRegistroUsuarioSala_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { '&' });
        string sCodRegistro = valores[0];
        string nivel = string.Empty;
        if (valores.Length > 1)
            nivel = valores[1];
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            //case "Eliminar":
            //    Eliminar(e.CommandArgument.ToString());
            //    Buscar();
            //    break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + sCodRegistro + "&nv=01" + ParametrosDelFiltro());
                Response.Redirect("ProRegistroUsuarioSala.aspx?pm=" + querystringENCRYP);
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + sCodRegistro + "&nv=00" + "&ver=1" + ParametrosDelFiltro());
                Response.Redirect("ProRegistroUsuarioSala.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;
        }
    }

    protected void gvRegistroUsuarioSala_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRegistroUsuarioSala.PageIndex = e.NewPageIndex;
        Buscar();
    }

    protected void gvRegistroUsuarioSala_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkEnSala;
            chkEnSala = (CheckBox)e.Row.Cells[7].FindControl("chkEnSala");

            //DataRowView IOK = (DataRowView)e.Row.DataItem;

            if (e.Row.Cells[6].Text == "01/01/1900 12:00:00 a.m.")
            {
                e.Row.Cells[6].Text = "";
            }

            if (chkEnSala.Checked)//En sala
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#FFE6E6");
                //((ImageButton)e.Row.Cells[10].FindControl("btnEditar")).Visible = true;
                //((ImageButton)e.Row.Cells[11].FindControl("btnEliminar")).Visible = true;
            }
            else//No está en sala
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                //((ImageButton)e.Row.Cells[10].FindControl("btnEditar")).Visible = false;
                //((ImageButton)e.Row.Cells[11].FindControl("btnEliminar")).Visible = false;
            }
        }
    }

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"

    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;
        sParameters = "&xFI=" + prm_dFechaINI.Text.ToString();
        sParameters = sParameters + "&xFF=" + prm_dFechaFIN.Text.ToString();
        sParameters = sParameters + "&xCU=" + prm_sCodUsuarioSAC.Text.Trim();
        sParameters = sParameters + "&xCS=" + prm_sEstablecimientoCodigo.SelectedValue.ToString();
        sParameters = sParameters + "&xNU=" + prm_sNombresUsuarioSAC.Text.ToString();
        return sParameters;
    }

    private void CargarPagina()
    {
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        prm_sEstablecimientoCodigo.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        prm_sEstablecimientoCodigo.DataValueField = "CodLocalSAC";
        prm_sEstablecimientoCodigo.DataTextField = "NombreLocal";
        HelpComboBox.AddItemText(ref prm_sEstablecimientoCodigo, HelpComboBox.Texto.Todos);
        prm_sEstablecimientoCodigo.DataBind();

        //ELVP: 19-09-2011
        prm_dFechaINI.Text = DateTime.Now.ToShortDateString();//DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        prm_dFechaFIN.Text = DateTime.Now.ToShortDateString();

        if (this.Master.HelpUsuariosSAC().CodLocalSAC != null)
        {
            if (this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() != string.Empty)
            {
                prm_sEstablecimientoCodigo.SelectedValue = this.Master.HelpUsuariosSAC().CodLocalSAC.Trim();
                prm_sEstablecimientoCodigo.Enabled = false;
            }
        }
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaRegistroUsuarioSala.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaRegistroUsuarioSala.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drVer = dt.Select("Tipo=2");
            DataTable dtVer = drVer.Length>0? drVer.CopyToDataTable(): new DataTable();

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtVer.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtVer.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvRegistroUsuarioSala.Columns[9].Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
            }
            if (dtEditar.Rows.Count > 0)
            {
                gvRegistroUsuarioSala.Columns[10].Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                BotonesEdicionLista1.BotonNuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }
            
            BotonesEdicionLista1.LoadComplete();

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = lblTituloPagina.Text;
            //gvRegistroUsuarioSala.Columns[9].Visible = oRolesOpciones.Flag_Ver;
            //gvRegistroUsuarioSala.Columns[10].Visible = oRolesOpciones.Flag_Editar;
            ////gvRegistroUsuarioSala.Columns[11].Visible = oRolesOpciones.Flag_Eliminar;
            //BotonesEdicionLista1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionLista1.LoadComplete();

            dt = null;
            dtVer = null;
            dtEditar = null;
            dtNuevo = null;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void Buscar()
    {
        string date1 = HelpDates.EsFechaValida(prm_dFechaINI.Text);
        string date2 = HelpDates.EsFechaValida(prm_dFechaFIN.Text);
        if (date1.Length > 0)
        {
            MessageBox1.ShowInfo(date1);
            return;
        }
        if (date2.Length > 0)
        {
            MessageBox1.ShowInfo(date2);
            return;
        }
        if (Convert.ToDateTime(prm_dFechaINI.Text) > Convert.ToDateTime(prm_dFechaFIN.Text))
        {
            MessageBox1.ShowInfo("¡ La fecha de inicio debe de ser menor o igual que la fecha de fin para la búsqueda !");
            return;
        }
        UsuarioSalaLogic oUsuarioSalaLogic = new UsuarioSalaLogic();
        List<UsuarioSala> lista = new List<UsuarioSala>();
        lista = oUsuarioSalaLogic.ListarUsuarioSala(prm_sEstablecimientoCodigo.SelectedValue.ToString().Trim(), 
                                    Convert.ToDateTime(prm_dFechaINI.Text), 
                                    Convert.ToDateTime(prm_dFechaFIN.Text), 
                                    prm_sCodUsuarioSAC.Text, 
                                    prm_sNombresUsuarioSAC.Text);
        gvRegistroUsuarioSala.DataSource = lista;//HelpConvert<UsuarioSala>.ConvertList(lista);
        gvRegistroUsuarioSala.DataBind();
        HelpGridView.Caption(ref gvRegistroUsuarioSala, "Lista de Registro de Usuario en Sala", lista.Count.ToString());
    }

    private void Eliminar(string pCodRegistro)
    {
        UsuarioSala oUsuarioSalaLogic = new UsuarioSala();
        ReturnValor oReturn = new ReturnValor(); 
        //oReturn = oUsuarioSalaLogic.Eliminar(pCodRegistro);
        //if (oReturn.Exitosa)
        //{
        //    MessageBox1.ShowSuccess(oReturn.Message);
        //    Buscar();
        //}
        //else
        //{
        //    MessageBox1.ShowWarning(oReturn.Message);
        //    return;
        //}
    }

    //ELVP: 15-07-2011
    //private string Validar()
    //{
    //    string mensage = "";
    //    if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
    //    {
    //        mensage = "¡ Usuario del sistema no puede realizar la operación, no esta asignado a un SAC. !";
    //    }
    //    else
    //    {
    //        bool selec = false;
    //        foreach (GridViewRow item in gvRegistroUsuarioSala.Rows)
    //        {
    //            CheckBox chkConfirmar = ((CheckBox)item.Cells[10].FindControl("chkConfirmar"));
    //            if (chkConfirmar.Checked)
    //                selec = true;
    //        }
    //        if (!selec)
    //            mensage = mensage + "¡ No ha seleccionado ningún registro de solicitud de impresión !";
    //    }
    //    return mensage;
    //}

    #endregion
    
}
