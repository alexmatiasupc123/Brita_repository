using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;

public partial class ListaEjemplaresEnTransitoDeCentros : System.Web.UI.Page
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

    #endregion

    #region "/--- Eventos de los Controles  ---/"

    #region "/--- Eventos de la Barra de Botones  ---/"

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmarEjemplaresRecepcionados();
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

    protected void gvEjemplaresEnTransito_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] valores = e.CommandArgument.ToString().Split(new char[] { '&' });
        string codsCodSolicitud = valores[0];
        string nivel = string.Empty;
        if (valores.Length > 1)
            nivel = valores[1];
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
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

    protected void gvEjemplaresEnTransito_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEjemplaresEnTransito.PageIndex = e.NewPageIndex;
        Buscar();
    }

    protected void gvEjemplaresEnTransito_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView IOK = (DataRowView)e.Row.DataItem;

            if (IOK.Row[2].ToString() == string.Empty)
                ((CheckBox)e.Row.Cells[10].FindControl("chkRecibidoSAC")).Visible = true;
            else
                ((CheckBox)e.Row.Cells[10].FindControl("chkRecibidoSAC")).Visible = false;

        }
    }

    protected void chkRecibidoSACTODOS_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvEjemplaresEnTransito.Rows)
        {
            CheckBox TieneRecibidoTodos = (CheckBox)sender;
            CheckBox TieneFoto;
            if (item.RowType == DataControlRowType.DataRow)
            {
                TieneFoto = ((CheckBox)item.Cells[10].FindControl("chkRecibidoSAC"));
                TieneFoto.Checked = TieneRecibidoTodos.Checked;
            }
        }
    }

    protected void ButtonConfirmaRecepcion_Click(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma la recepción de ejemplares en tránsito al SAC actual ?", HelpEvento.Guardar.ToString());
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

    private void CargarPagina()
    {
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        prm_sEstablecimientoCodigo.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        prm_sEstablecimientoCodigo.DataValueField = "CodLocalSAC";
        prm_sEstablecimientoCodigo.DataTextField = "NombreLocal";
        HelpComboBox.AddItemText(ref prm_sEstablecimientoCodigo, HelpComboBox.Texto.Todos);
        prm_sEstablecimientoCodigo.DataBind();

        prm_dFechaProcesoINI.Text = DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        prm_dFechaProcesoFIN.Text = DateTime.Now.ToShortDateString();

        string CODE_LOCAL_SAC =  this.Master.HelpUsuariosSAC().CodLocalSAC;
        if (CODE_LOCAL_SAC != null)
        {
            if (CODE_LOCAL_SAC != string.Empty)
            {
                prm_sEstablecimientoCodigo.SelectedValue = CODE_LOCAL_SAC.Trim();
                prm_sEstablecimientoCodigo.Enabled = false;
            }
        }

        if (Session["paramXX"] != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Session["paramXX"].ToString());
            prm_dFechaProcesoINI.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFI");
            prm_dFechaProcesoFIN.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFF");
            prm_sCodEjemplar.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xCU");
            prm_sEstablecimientoCodigo.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xCS");
            Session["paramXX"] = null;
        }
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaEjemplaresEnTransitoDeCentros.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaEjemplaresEnTransitoDeCentros.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtNuevo.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtNuevo.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvEjemplaresEnTransito.Columns[10].Visible = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
                BotonesEdicionLista1.BotonNuevo = false;
                ButtonConfirmaRecepcion.Enabled = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
                ButtonConfirmaRecepcion.Visible = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }

            BotonesEdicionLista1.LoadComplete();

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = lblTituloPagina.Text;
            //gvEjemplaresEnTransito.Columns[10].Visible = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionLista1.BotonNuevo = false;
            //ButtonConfirmaRecepcion.Enabled = oRolesOpciones.Flag_Nuevo;
            //ButtonConfirmaRecepcion.Visible = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionLista1.LoadComplete();

            dt = null;
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
        ItemEjemplarTransitoLogic oItemEjemplarTransitoLogic = new ItemEjemplarTransitoLogic();
        List<ItemEjemplarTransito> lista = new List<ItemEjemplarTransito>();
        lista = oItemEjemplarTransitoLogic.Listar(Convert.ToDateTime(prm_dFechaProcesoINI.Text), Convert.ToDateTime(prm_dFechaProcesoFIN.Text), prm_sCodEjemplar.Text, prm_sEstablecimientoCodigo.SelectedValue.ToString().Trim());
        gvEjemplaresEnTransito.DataSource = HelpConvert<ItemEjemplarTransito>.ConvertList(lista);
        gvEjemplaresEnTransito.DataBind();
        HelpGridView.Caption(ref gvEjemplaresEnTransito, "Lista de ejemplares en tránsito de devolución", lista.Count.ToString());

        if (lista.Count == 0)
            ButtonConfirmaRecepcion.Visible = false;
    }

    private void ConfirmarEjemplaresRecepcionados()
    {
        List<ItemEjemplarTransito> listaItemEjemplarTransito = new List<ItemEjemplarTransito>();
        EjemplaresARecepcionar(listaItemEjemplarTransito);
        if (listaItemEjemplarTransito.Count > 0)
        {
            ReturnValor oReturnValor = new ReturnValor();
            ItemEjemplarTransitoLogic oItemEjemplarTransitoLogic = new ItemEjemplarTransitoLogic();
            PrestamoLogic oPrestamoLogic = new PrestamoLogic();
            foreach (ItemEjemplarTransito xItemEjemplarTransito in listaItemEjemplarTransito)
            {
                oReturnValor = oItemEjemplarTransitoLogic.Actualizar(xItemEjemplarTransito.sCodPrestamo, xItemEjemplarTransito.sCodEjemplar, xItemEjemplarTransito.SSIUsuario_Modificacion);
                if (oReturnValor.Exitosa)
                    oReturnValor.Exitosa = AvisarPorEmailSiEstaReservado(xItemEjemplarTransito.sCodPrestamo, xItemEjemplarTransito.sCodEjemplar);
                else
                    break;
            }
            if (oReturnValor.Exitosa)
            {
                Session["paramXX"] = HelpEncrypt.Encriptar(ParametrosDelFiltro());
                Response.Redirect("ListaEjemplaresEnTransitoDeCentros.aspx");
                

            }
            else
                MessageBox1.ShowWarning(oReturnValor.Message);
        }
    }

    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;
        sParameters = "&xFI=" + prm_dFechaProcesoINI.Text.ToString();
        sParameters = sParameters + "&xFF=" + prm_dFechaProcesoFIN.Text.ToString();
        sParameters = sParameters + "&xCU=" + prm_sCodEjemplar.Text.Trim();
        sParameters = sParameters + "&xCS=" + prm_sEstablecimientoCodigo.SelectedValue.ToString();
        return sParameters;
    }

    private bool AvisarPorEmailSiEstaReservado(string p_sCodPrestamo, string p_sCodEjemplar)
    {
        bool ESTA_RESERVADO = true;
        ReturnValor oReturnValor = new ReturnValor();
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        Prestamo itemPrestamo = new Prestamo();
        Prestamo miReservaDeEjemplar = new Prestamo();
        itemPrestamo = oPrestamoLogic.Buscar(p_sCodPrestamo);
        
        miReservaDeEjemplar = oPrestamoLogic.BuscarReservasSolicitadas(string.Empty, p_sCodEjemplar, PrestamoLogic.TipoDeOperacion.OperReserva);

        if (miReservaDeEjemplar.sCodPrestamo != null)
        {
            if (miReservaDeEjemplar.sCodPrestamo != itemPrestamo.sCodPrestamo)
            {
                bool SUCEDIDO = oPrestamoLogic.ActivarReservaDePrestamo(miReservaDeEjemplar.sCodPrestamo).Exitosa;
                oReturnValor.Message = oReturnValor.Message + "¡ El ejemplar que se está recepcionando está en reserva !";
                ESTA_RESERVADO = true;
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
                vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
                itemvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(itemPrestamo.sCodUsuarioSAC);

                List<HelpMailDatos> listaHelpMailDatos = new List<HelpMailDatos>();
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Código de reserva: ", descripcion = itemPrestamo.sCodPrestamo });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Código de ejemplar: ", descripcion = itemPrestamo.sCodEjemplar });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Titulo : ", descripcion = miReservaDeEjemplar.sCodEjemplarNombreTitulo });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Fecha solicitada : ", descripcion = miReservaDeEjemplar.dFechaSolicitudReserva.Value.ToLongDateString() });
                string EMAIL = HelpMail.CrearBody("Reserva de ejemplar disponible", listaHelpMailDatos, "Ya puede acercarse a realizar su préstamo de ejemplar", "BRITANICO");

                HelpMail.Enviar("SACNET: Ejemplar reservado", EMAIL, itemvwUsuariosSAC.CorreoElectronico);
            }
        }
        return ESTA_RESERVADO;
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
            List<ItemEjemplarTransito> listaItemEjemplarTransito = new List<ItemEjemplarTransito>();
            EjemplaresARecepcionar(listaItemEjemplarTransito);
            if (listaItemEjemplarTransito.Count == 0)
                mensage = mensage + "¡ No ha seleccionado ningún registro !";
        }
        return mensage;
    }

    private void EjemplaresARecepcionar(List<ItemEjemplarTransito> listaItemEjemplarTransito)
    {
        foreach (GridViewRow item in gvEjemplaresEnTransito.Rows)
        {
            if (item.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRecibidoSAC = ((CheckBox)item.Cells[10].FindControl("chkRecibidoSAC"));
                if (chkRecibidoSAC.Visible)
                {
                    if (chkRecibidoSAC.Checked)
                        listaItemEjemplarTransito.Add(new ItemEjemplarTransito
                        {
                            sCodPrestamo = item.Cells[0].Text,
                            sCodEjemplar = item.Cells[2].Text,
                            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
                        });
                }
            }
        }
    }

    #endregion


}
