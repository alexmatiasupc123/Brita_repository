using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;

using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;

public partial class ListaSolicitudCarnetRecibidoSAC : System.Web.UI.Page
{

    #region "/--- Eventos de la Pagina ---/"

    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                prm_dFechaProcesoINI.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFI") == string.Empty ? prm_dFechaProcesoINI.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFI");
                prm_dFechaProcesoFIN.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFF") == string.Empty ? prm_dFechaProcesoFIN.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFF");
                prm_sCodUsuarioSAC.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xCU");
                prm_sEstablecimientoCodigo.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xCS");
                prm_sCodArguEstado1.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xEt");
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

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmarCarneRecepcionados();
        }
    }

    private void InicializarEventos()
    {
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
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

   

    #endregion
    
    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "")
            {
 
            }

        }
    }

    protected void gvSolicitudesImpresionCarnet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { '&' });
        string codsCodSolicitud = valores[0];
        string nivel = string.Empty;
        if (valores.Length > 1)
            nivel = valores[1];
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "Eliminar":
                Eliminar(e.CommandArgument.ToString());
                Buscar();
                break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codsCodSolicitud + "&nv=01" + ParametrosDelFiltro());
                Response.Redirect("MantSolicitudImpresionCarnet.aspx?pm=" + querystringENCRYP);
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + codsCodSolicitud + "&nv=03" + "&ver=1" + ParametrosDelFiltro());
                Response.Redirect("MantSolicitudImpresionCarnet.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;
        }
    }

    protected void gvSolicitudesImpresionCarnet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSolicitudesImpresionCarnet.PageIndex = e.NewPageIndex;
        Buscar();
    }

    protected void gvSolicitudesImpresionCarnet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             DataRowView IOK = (DataRowView)e.Row.DataItem;

            if (IOK.Row[7].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP03))
                ((CheckBox)e.Row.Cells[12].FindControl("chkRecibidoSAC")).Visible = true;
            else
                ((CheckBox)e.Row.Cells[12].FindControl("chkRecibidoSAC")).Visible = false;

        }
    }

    protected void chkRecibidoSACTODOS_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvSolicitudesImpresionCarnet.Rows)
        {
            CheckBox TieneRecibidoTodos = (CheckBox)sender;
            CheckBox TieneFoto;
            if (item.RowType == DataControlRowType.DataRow)
            {
                TieneFoto = ((CheckBox)item.Cells[12].FindControl("chkRecibidoSAC"));
                TieneFoto.Checked = TieneRecibidoTodos.Checked;
            }
        }
    }

    protected void ButtonConfirmaRecepcion_Click(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma actualizar las solicitudes a estado carné recibido en SAC ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"

    public string PintarEstado(string pCodigoTabla, bool pEstado, string TIPO)
    {
        string estado = string.Empty;

        if (pCodigoTabla.Length != 0)
        {
            if (pEstado)
            {
                if (TIPO == "E")
                    estado = "Si";
                else
                    estado = "Duplicado";
            }
            else
            {
                if (TIPO == "E")
                    estado = "No";
                else
                    estado = "Nuevo";
            }
        }
        return estado;
    }

    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;
        sParameters = "&xFI=" + prm_dFechaProcesoINI.Text.ToString();
        sParameters = sParameters + "&xFF=" + prm_dFechaProcesoFIN.Text.ToString();
        sParameters = sParameters + "&xCU=" + prm_sCodUsuarioSAC.Text.Trim();
        sParameters = sParameters + "&xCS=" + prm_sEstablecimientoCodigo.SelectedValue.ToString();
        sParameters = sParameters + "&xEt=" + prm_sCodArguEstado1.SelectedValue.ToString();
        sParameters = sParameters + "&xNU=" + prm_sNombresUsuarioSAC.Text.ToString();
        return sParameters;
    }

    private void CargarPagina()
    {

        HelpMaestros.CargarListadoGenerico(ref prm_sCodArguEstado1, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.EstadosDeCarne), HelpMaestros.NivelTabla(HelpMaestros.TablasMaestras.EstadosDeCarne), "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        prm_sCodArguEstado1.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP03);
        prm_sCodArguEstado1.DataBind();

        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        prm_sEstablecimientoCodigo.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        prm_sEstablecimientoCodigo.DataValueField = "CodLocalSAC";
        prm_sEstablecimientoCodigo.DataTextField = "NombreLocal";
        HelpComboBox.AddItemText(ref prm_sEstablecimientoCodigo, HelpComboBox.Texto.Todos);
        prm_sEstablecimientoCodigo.DataBind();

        prm_dFechaProcesoINI.Text = DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        prm_dFechaProcesoFIN.Text = DateTime.Now.ToShortDateString();

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
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoSAC.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaSolicitudCarnetRecibidoSAC.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drVer = dt.Select("Tipo=2");
            DataTable dtVer = drVer.Length>0? drVer.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtVer.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtVer.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvSolicitudesImpresionCarnet.Columns[11].Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                BotonesEdicionLista1.BotonNuevo = false;
                ButtonConfirmaRecepcion.Enabled = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
                ButtonConfirmaRecepcion.Visible = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }

            BotonesEdicionLista1.LoadComplete();

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = lblTituloPagina.Text;
            //BotonesEdicionLista1.BotonNuevo = false;
            //gvSolicitudesImpresionCarnet.Columns[11].Visible = oRolesOpciones.Flag_Ver;
            //ButtonConfirmaRecepcion.Enabled = oRolesOpciones.Flag_Nuevo;
            //ButtonConfirmaRecepcion.Visible = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionLista1.LoadComplete();

            dt = null;
            dtVer = null;
            dtNuevo = null;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void Buscar()
    {
        string date1 = HelpDates.EsFechaValida(prm_dFechaProcesoINI.Text);
        string date2 = HelpDates.EsFechaValida(prm_dFechaProcesoFIN.Text);
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
        if (Convert.ToDateTime(prm_dFechaProcesoINI.Text) > Convert.ToDateTime(prm_dFechaProcesoFIN.Text))
        {
            MessageBox1.ShowInfo("¡ La fecha de inicio debe de ser menor o igual que la fecha de fin para la búsqueda !");
            return;
        }
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
        List<SolicitudCarnet> lista = new List<SolicitudCarnet>();
        lista = oSolicitudCarnetLogic.Listar(Convert.ToDateTime(prm_dFechaProcesoINI.Text), Convert.ToDateTime(prm_dFechaProcesoFIN.Text), prm_sCodUsuarioSAC.Text, prm_sNombresUsuarioSAC.Text, prm_sEstablecimientoCodigo.SelectedValue.ToString().Trim(), prm_sCodArguEstado1.SelectedValue.ToString().Trim(), prm_sCodArguEstado1.SelectedValue.ToString().Trim());
        gvSolicitudesImpresionCarnet.DataSource = HelpConvert<SolicitudCarnet>.ConvertList(lista);
        gvSolicitudesImpresionCarnet.DataBind();
        HelpGridView.Caption(ref gvSolicitudesImpresionCarnet, "Lista de solicitudes de impresión", lista.Count.ToString());
      
        if (lista.Count == 0)
            ButtonConfirmaRecepcion.Visible = false;
    }

    private void Eliminar(string pSolicitudCarnet)
    {
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
        ReturnValor oReturn = new ReturnValor(); 
        oReturn = oSolicitudCarnetLogic.Eliminar(pSolicitudCarnet);
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

    private void ConfirmarCarneRecepcionados()
    {
        List<SolicitudCarnet> listaSolicitudCarnet = new List<SolicitudCarnet>();
        SolicitudesARecepcionar(listaSolicitudCarnet);
        if (listaSolicitudCarnet.Count > 0)
        {
            ReturnValor oReturnValor = new ReturnValor();
            SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
            foreach (SolicitudCarnet xSolicitudCarnet in listaSolicitudCarnet)
            {
                oReturnValor = oSolicitudCarnetLogic.ActualizarSolicitudCarnet(xSolicitudCarnet, 3);
            }
            if (oReturnValor.Exitosa)
            {
                Response.Redirect("ListaSolicitudCarnetRecibidoSAC.aspx");
            }
            else
                MessageBox1.ShowWarning(oReturnValor.Message);
        }
    }

    private string Validar()
    {
        string mensage = "";
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        {
            mensage = "¡ Usuario del sistema no puede realizar la operación, no esta asignado a un SAC. !";
        }
        else
        {
            List<SolicitudCarnet> listaSolicitudCarnet = new List<SolicitudCarnet>();
            SolicitudesARecepcionar(listaSolicitudCarnet);
            if (listaSolicitudCarnet.Count == 0)
                mensage = mensage + "¡ No ha seleccionado ningun registro de solicitud de carné !";
        }
        return mensage;
    }

    private void SolicitudesARecepcionar(List<SolicitudCarnet> listaSolicitudCarnet)
    {
        foreach (GridViewRow item in gvSolicitudesImpresionCarnet.Rows)
        {
            if (item.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRecibidoSAC = ((CheckBox)item.Cells[11].FindControl("chkRecibidoSAC"));
                if (chkRecibidoSAC.Visible)
                {
                    if (chkRecibidoSAC.Checked)
                        listaSolicitudCarnet.Add(new SolicitudCarnet
                        {
                            sCodSolicitud = item.Cells[0].Text,
                            sCodArguEstado = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP04),
                            sUsuarioEntregaSAC = this.Master.HelpUsuario().LoginUsuario,
                            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
                        });
                }
            }
        }
    }

    #endregion

}
