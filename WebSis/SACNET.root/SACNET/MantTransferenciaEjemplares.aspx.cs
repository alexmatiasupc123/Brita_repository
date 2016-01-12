using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.Interface;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using System.Configuration;
public partial class MantTransferenciaEjemplares : System.Web.UI.Page
{
    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {

        this.InicializarEventos();
        if (!Page.IsPostBack)
        {
            this.CargarCombos();
            this.CargarConfiguraciones();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                hfParameters.Value = querystringDESENCRYP;
                hfCodTransferencia.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "tId");
                if (hfCodTransferencia.Value != string.Empty)
                {
                    
                    if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") == HelpEvento.Ver.ToString())
                    {
                        pnRegistroTransferencia.Enabled = false;
                        this.BotonesEdicionMantenimiento1.BotonCancelar = false;
                        this.BotonesEdicionMantenimiento1.BotonEditar = false;
                        this.BotonesEdicionMantenimiento1.BotonGrabar = false;
                        this.BotonesEdicionMantenimiento1.BotonNuevo = false;
                        btnBuscarEjemplar.ImageUrl = "~/Comun/Imagenes/Botones/Buscar_I.jpg";
                        btnAgregar.ImageUrl = "~/Comun/Imagenes/Botones/Agregar_I.png";
                        hfEvento.Value = HelpEvento.Ver.ToString();
                        this.PintarDatosTransferencia(hfCodTransferencia.Value);
                        
                    }
                    else
                    {
                        this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
                        hfEvento.Value = HelpEvento.Editar.ToString();
                        txtUsuarioSacOrigen.Enabled = false;
                        txtUsuarioSacDestino.Enabled = false;
                        ddlSacOrigen.Enabled = false;
                        ddlSacDestino.Enabled = false;
                        this.PintarDatosTransferencia(hfCodTransferencia.Value);

                        
                    }
                    TrTransferenciaPost.Visible = true;
                }
                else
                {
                    this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
                    hfEvento.Value = HelpEvento.Registrar.ToString();
                    TrTransferenciaPost.Visible = false;
                    gvEjemplaresATransferir.DataSource = null;
                    gvEjemplaresATransferir.DataBind();
                    ucAuditoria1.CargarSeguridadInicio();
                }
            }

        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Seguridad();
    
    }
    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaTransferenciaEjemplares.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaTransferenciaEjemplares.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)  
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            
            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtEditar.Rows.Count > 0)
            {
                if (hfEvento.Value == HelpEvento.Editar.ToString())
                    BotonesEdicionMantenimiento1.BotonGrabar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                if (hfEvento.Value == HelpEvento.Registrar.ToString())
                    BotonesEdicionMantenimiento1.BotonGrabar = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }

            ////BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            ////BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
            //if (hfEvento.Value == HelpEvento.Registrar.ToString()) //;   || BotonesEdicionMantenimiento1.BotonEditar)
            //{
            //    BotonesEdicionMantenimiento1.BotonGrabar = oRolesOpciones.Flag_Nuevo;

            //}
            //else if (hfEvento.Value == HelpEvento.Editar.ToString())
            //{
            //    BotonesEdicionMantenimiento1.BotonGrabar = oRolesOpciones.Flag_Editar;
                
            //}

            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") == HelpEvento.Ver.ToString())
                {

                    this.BotonesEdicionMantenimiento1.BotonCancelar = false;
                    this.BotonesEdicionMantenimiento1.BotonEditar = false;
                    this.BotonesEdicionMantenimiento1.BotonGrabar = false;
                    this.BotonesEdicionMantenimiento1.BotonNuevo = false;

                }
            }
            this.BotonesEdicionMantenimiento1.BotonEditar = false;
            this.BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
   
    private void PintarDatosTransferencia(string pCodTransferencia)
    {
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        SolicitudTransferencia itemSolicitudTransferencia = new SolicitudTransferencia();
        itemSolicitudTransferencia = oSolicitudTransferenciaLogic.Buscar(pCodTransferencia,"T");
        ddlSacOrigen.SelectedValue = itemSolicitudTransferencia.sCodSacOrigen;
        ddlSacDestino.SelectedValue = itemSolicitudTransferencia.sCodSacDestino;
        txtUsuarioSolicitante.Text = itemSolicitudTransferencia.sUsuarioSolicitante;
        txtUsuarioSacOrigen.Text = itemSolicitudTransferencia.sUsuarioSacOrigen;
        txtUsuarioSacDestino.Text = itemSolicitudTransferencia.sUsuarioSacDestino;
        txtFechaProcesoSolicitud.Text = itemSolicitudTransferencia.dFechaProcesoSolicitud.ToShortDateString();
        ddlEstadoTransferencia.SelectedValue = itemSolicitudTransferencia.sCodArguEstadoTransferencia;
        if (itemSolicitudTransferencia.sCodArguEstadoTransferencia == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoTransferencia_Ingreso))
        {
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
            pnRegistroTransferencia.Enabled = false;
            btnBuscarEjemplar.ImageUrl = "~/Comun/Imagenes/Botones/Buscar_I.jpg";
            btnAgregar.ImageUrl = "~/Comun/Imagenes/Botones/Agregar_I.png";
           // gvEjemplaresATransferir.Enabled = true;
        }
            
        gvEjemplaresATransferir.DataSource = itemSolicitudTransferencia.ListaDetalleTransferencia;
        gvEjemplaresATransferir.DataBind();
        HelpGridView.Caption(ref gvEjemplaresATransferir, "Lista de ejemplares a transferir", itemSolicitudTransferencia.ListaDetalleTransferencia.Count.ToString());
        Session["TransferenciaEjemplares"] = itemSolicitudTransferencia.ListaDetalleTransferencia;
        ucAuditoria1.CargarSeguridad(itemSolicitudTransferencia.SSIUsuario_Creacion, itemSolicitudTransferencia.SSIUsuario_Modificacion, itemSolicitudTransferencia.SSIFechaHora_Creacion, itemSolicitudTransferencia.SSIFechaHora_Modificacion, itemSolicitudTransferencia.SSIHost);
    }
   
    private string Validar()
    {
        string mensage = "";
        if (ddlSacOrigen.SelectedIndex == 0) mensage = mensage + ",Seleccionar el SAC de origen.";
        if (ddlSacDestino.SelectedIndex == 0) mensage = mensage + ", Seleccionar el SAC de destino.";
        if (gvEjemplaresATransferir.Rows.Count == 0) mensage = mensage + ", Ingresar como mínimo un ejemplar para registrar.";
        if (mensage.Length > 0)
            mensage = mensage.Substring(1);
        return mensage;
    }
  
    private void EstadoDatosActivo(bool ESTADO)
    {
        pnRegistroTransferencia.Enabled = ESTADO;
        gvEjemplaresATransferir.Enabled = ESTADO;
    }

    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlEstadoTransferencia, HelpMaestros.TablasMaestras.EstadosDeTransferencias, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        ddlSacOrigen.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSacOrigen.DataValueField = "CodLocalSAC";
        ddlSacOrigen.DataTextField = "NombreLocal";
        ddlSacOrigen.DataBind();
        ddlSacOrigen.Items.Insert(0, (new ListItem("-- Seleccionar --", "")));

        
        ddlSacDestino.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSacDestino.DataValueField = "CodLocalSAC";
        ddlSacDestino.DataTextField = "NombreLocal";
        ddlSacDestino.DataBind();
        ddlSacDestino.Items.Insert(0, (new ListItem("-- Seleccionar --", "")));

        
    }
   
    private void CargarConfiguraciones()
    {
        txtUsuarioSolicitante.Text = Master.HelpUsuario().LoginUsuario;
        txtFechaProcesoSolicitud.Text = DateTime.Today.ToShortDateString();
        ddlEstadoTransferencia.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoTransferencia_VXDF);
 
    }
   
    private SolicitudTransferencia GetTransferencia()
    {
        SolicitudTransferencia oSolicitudTransferencia = new SolicitudTransferencia();
        List<SolicitudTransferenciaDetalle> ListaDetalleTransferencia=new List<SolicitudTransferenciaDetalle>();
        oSolicitudTransferencia.sCodTransferencia = hfCodTransferencia.Value;
        oSolicitudTransferencia.sCodSacOrigen = ddlSacOrigen.SelectedItem.Value;
        oSolicitudTransferencia.sCodSacDestino = ddlSacDestino.SelectedItem.Value;
        oSolicitudTransferencia.sUsuarioSolicitante = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.sUsuarioSacOrigen = null;
        oSolicitudTransferencia.sUsuarioSacDestino = null;
        oSolicitudTransferencia.sUsuarioSolicitante = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.dFechaProcesoSolicitud = DateTime.Now;
        oSolicitudTransferencia.dFechaProcesoIngreso = null;
        oSolicitudTransferencia.dFechaProcesoRetiro = null;
        oSolicitudTransferencia.sCodArguEstadoTransferencia = ddlEstadoTransferencia.SelectedItem.Value;
        oSolicitudTransferencia.SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.SSIHost = Context.Request.UserHostName;
        if (Session["TransferenciaEjemplares"] != null)
        {
            oSolicitudTransferencia.ListaDetalleTransferencia = (List<SolicitudTransferenciaDetalle>)Session["TransferenciaEjemplares"];
        }


        return oSolicitudTransferencia;
    }
   
    private void EliminarEjemplarTransferencia(string pCodEjemplar, string pCodTransferencia, string IndexRow)
    {
        ReturnValor oReturnValor = new ReturnValor();
        List<SolicitudTransferenciaDetalle> oListaDetalle = (List<SolicitudTransferenciaDetalle>)Session["TransferenciaEjemplares"];
        if (string.IsNullOrEmpty(pCodTransferencia) == false)
        {
            SolicitudTransferenciaDetalleLogic oSolicitudTransferenciaDetalleLogic = new SolicitudTransferenciaDetalleLogic();
            oReturnValor = oSolicitudTransferenciaDetalleLogic.Eliminar(pCodTransferencia, pCodEjemplar, Master.HelpUsuario().LoginUsuario);
            if (oReturnValor.Exitosa)
            {
                oListaDetalle = oSolicitudTransferenciaDetalleLogic.Listar(pCodTransferencia);                
                MessageBox1.ShowSuccess(oReturnValor.Message);
            }
            else
                MessageBox1.ShowError(oReturnValor.Message);
        }
        else
        {
            
            oListaDetalle.RemoveAt(Convert.ToInt32(IndexRow));
            MessageBox1.ShowSuccess("¡ Ejemplar ha sido eliminado de la lista !");
        }
        gvEjemplaresATransferir.DataSource = oListaDetalle;
        gvEjemplaresATransferir.DataBind();
        Session["TransferenciaEjemplares"] = oListaDetalle;

    }

    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void btnBuscarEjemplar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCodigoItem.Text) == false && ddlSacOrigen.SelectedIndex != 0)
        {
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            List<ItemEjemplar> ListaEjemplar = new List<ItemEjemplar>();
            string CodArguEjemplarDisponible = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
            ListaEjemplar = oItemEjemplarLogic.Listar(txtCodigoItem.Text, ddlSacOrigen.SelectedItem.Value, string.Empty);
            ddlCodigoEjemplar.DataSource = ListaEjemplar.Where(x => x.sCodArguEstadoEjemplar == CodArguEjemplarDisponible);
            ddlCodigoEjemplar.DataTextField = "sCodEjemplar";
            ddlCodigoEjemplar.DataValueField = "sCodEjemplar";
            ddlCodigoEjemplar.DataBind();
            if (ddlCodigoEjemplar.Items.Count > 0)
            {
                ddlCodigoEjemplar.Items.Insert(0, new ListItem("-- Seleccione --"));
                btnAgregar.Enabled = true;
            }

        }
        else
        {
            if (ddlSacOrigen.SelectedIndex == 0)
            {
                MessageBox1.ShowInfo("¡ Seleccionar el SAC de origen. !");
                return;
            }
            if (string.IsNullOrEmpty(txtCodigoItem.Text) == true)
            {
                MessageBox1.ShowInfo("¡ Ingresar código del ítem para seleccionar ejemplar. !");
                return;
            }
        }
        

    }
  
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (ddlCodigoEjemplar.SelectedItem != null)
        {
            List<SolicitudTransferenciaDetalle> ListaDetalleTransferencia = new List<SolicitudTransferenciaDetalle>();
            if (Session["TransferenciaEjemplares"] != null)
            {
                ListaDetalleTransferencia = (List<SolicitudTransferenciaDetalle>)Session["TransferenciaEjemplares"];
            }
            if (ddlCodigoEjemplar.SelectedIndex != 0)
            {
                if (ListaDetalleTransferencia.Count > 0)
                {
                    if (ListaDetalleTransferencia.Exists(x => x.sCodEjemplar == ddlCodigoEjemplar.SelectedItem.Value))
                    {
                        MessageBox1.ShowInfo("¡ El ejemplar ya esta adicionado a la lista a transferir. !");
                        return;
                    }
                }
                if (ddlSacDestino.SelectedIndex == 0)
                {
                    MessageBox1.ShowInfo("¡ Seleccionar el SAC de destino. !");
                    ddlSacDestino.Focus();
                    return;
                }
                if (ddlCodigoEjemplar.SelectedItem == null)
                {
                    MessageBox1.ShowInfo("¡ Buscar un ítem para poder seleccionar ejemplares. !");
                    ddlCodigoEjemplar.Focus();
                    return;
                }
                SolicitudTransferenciaDetalle oSolicitudTransferenciaDetalle = new SolicitudTransferenciaDetalle();
                oSolicitudTransferenciaDetalle.sCodTransferencia = string.Empty;
                oSolicitudTransferenciaDetalle.sCodSacNombre = ddlSacOrigen.SelectedItem.Text;
                oSolicitudTransferenciaDetalle.sCodEjemplar = ddlCodigoEjemplar.SelectedItem.Value;
                oSolicitudTransferenciaDetalle.sCodItem = txtCodigoItem.Text.Trim();
                oSolicitudTransferenciaDetalle.bAprobacionIngreso = false;
                oSolicitudTransferenciaDetalle.bAprobacionRetiro = false;
                oSolicitudTransferenciaDetalle.SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario;
                oSolicitudTransferenciaDetalle.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
                oSolicitudTransferenciaDetalle.SSIHost = Context.Request.UserHostName;
                ListaDetalleTransferencia.Add(oSolicitudTransferenciaDetalle);
                gvEjemplaresATransferir.DataSource = ListaDetalleTransferencia;
                gvEjemplaresATransferir.DataBind();
                Session["TransferenciaEjemplares"] = ListaDetalleTransferencia;
                HelpGridView.Caption(ref gvEjemplaresATransferir, "Lista de ejemplares a transferir", ListaDetalleTransferencia.Count.ToString());


            }
            else
                MessageBox1.ShowInfo("¡ Seleccionar un ejemplar para poder agregar a la lista. !");
        }
        else
            MessageBox1.ShowInfo("¡ Buscar un ítem para poder seleccionar ejemplares. !");
    }
  
    protected void gvEjemplaresATransferir_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            GridViewRow row = ((GridViewRow)((Control)e.CommandSource).NamingContainer);
            string Parametros = e.CommandArgument.ToString();
            string[] pValor = Parametros.Split(new char[] { '%' });
            string index = row.RowIndex.ToString();
            EliminarEjemplarTransferencia(pValor[0].ToString(), pValor[1].ToString(), index);
        }
    }

    #region "/--- Eventos de los Botones de Comando  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }
 
    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Session["TransferenciaEjemplares"] = null;
        string cadeParametros = hfParameters.Value.Substring(hfParameters.Value.ToString().IndexOf("&xFI"), hfParameters.Value.Trim().Length - hfParameters.Value.ToString().IndexOf("xFI") + 1);        
        Response.Redirect("MantTransferenciaEjemplares.aspx?pm=" + HelpEncrypt.Encriptar(cadeParametros), true);

    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        hfEvento.Value = HelpEvento.Editar.ToString();        
        this.PintarDatosTransferencia(hfCodTransferencia.Value);
        EstadoDatosActivo(true);
        ddlSacOrigen.Enabled = false;
        ddlSacDestino.Enabled = false;
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            try
            {
                ReturnValor oReturnValor = new ReturnValor();
                SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
                SolicitudTransferencia itemTransferencia = new SolicitudTransferencia();
                itemTransferencia = GetTransferencia();
                if (hfEvento.Value == HelpEvento.Registrar.ToString())
                {
                    oReturnValor = oSolicitudTransferenciaLogic.Registrar(itemTransferencia);
                    if (oReturnValor.Exitosa)
                    {
                        hfCodTransferencia.Value = oReturnValor.CodigoRetorno;
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        MessageBox1.ShowSuccess(oReturnValor.Message);
                        EstadoDatosActivo(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturnValor.Message);
                    }

                }
                else if (hfEvento.Value == HelpEvento.Editar.ToString())
                {
                    oReturnValor = oSolicitudTransferenciaLogic.Actualizar(itemTransferencia);
                    if (oReturnValor.Exitosa)
                    {
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        MessageBox1.ShowSuccess(oReturnValor.Message);
                        EstadoDatosActivo(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturnValor.Message);
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox1.ShowError(ex.Message);
            }
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {


    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
        Response.Redirect("ListaTransferenciaEjemplares.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);


    }
    #endregion
    #endregion

    protected void gvEjemplaresATransferir_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
                SolicitudTransferenciaDetalle Fil = (SolicitudTransferenciaDetalle)e.Row.DataItem;
                if (Fil.sCodSac == ddlSacOrigen.SelectedItem.Value)
                {
                    if (hfEvento.Value == HelpEvento.Editar.ToString())
                    {
                        ((ImageButton)e.Row.Cells[3].FindControl("btnEliminar")).Visible = true;
                    }
                    else
                    {
                        ((ImageButton)e.Row.Cells[3].FindControl("btnEliminar")).Visible = false;
                    }
                    
                }
                else
                {
                    ((ImageButton)e.Row.Cells[3].FindControl("btnEliminar")).Visible = false;
                }           
            
        }
    }
    protected void ddlSacOrigen_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["TransferenciaEjemplares"] = null;        
        ddlSacDestino.SelectedIndex = 0;
        gvEjemplaresATransferir.DataSource = null;
        gvEjemplaresATransferir.DataBind();
    }
}
