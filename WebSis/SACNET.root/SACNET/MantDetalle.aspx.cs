using System;
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

public partial class MantMaestro : System.Web.UI.Page
{
    
    #region "/--- Eventos de la Pagina ---/"
   
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    #endregion

    #region "/--- Eventos de los Controles  ---/"
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
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
        f_txtCodigoArgumento.Text = "";
        f_txtNombre.Text = "";
        f_txtValorCadena.Text = "";
        f_txtValorCadenaCorta.Text = "";
        f_txtValorCadenaLarga.Text = "";
        f_txtValorDecimal.Text = "";
        f_txtValorEntero.Text = "";
        f_chkValorBoolean.Text = "";
        CargarPagina();
    }
    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        hfEvento.Value = HelpEvento.Editar.ToString();
        EstadoDatosVER(false);
    }
    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            TDetalle item = GetRegistroDetalle();

            if (hfEvento.Value == HelpEvento.Registrar.ToString())
            {
                ReturnValor oReturnValor= new ReturnValor() ;
                oReturnValor = oMaestroLogic.RegistrarDetalle(item);
                if (oReturnValor.Exitosa)
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    EstadoDatosVER(true);
                    //CargarPagina();

                }
                else
                {
                    MessageBox1.ShowWarning(oReturnValor.Message);
                }

            }
            else if (hfEvento.Value == HelpEvento.Editar.ToString())
            {
                ReturnValor oReturnValor = new ReturnValor() ; 
                oReturnValor = oMaestroLogic.ActualizarDetalle(item);
                if (oReturnValor.Exitosa)
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    EstadoDatosVER(true);
                }
                else
                {
                    MessageBox1.ShowWarning(oReturnValor.Message);
                }
            }
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }
    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
    }
    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        TMaestro itemTMaestro = new TMaestro();
        itemTMaestro = (TMaestro)Session["Maestro"];
        Session["Maestro"] = null;

        String querystringENCRYP = HelpEncrypt.Encriptar(hfParameters.Value);
        Response.Redirect("ListaDetalle.aspx?pm=" + querystringENCRYP);
    }
    protected void ddlNivel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel1.SelectedIndex > 0)
        {
            TMaestro itemTMaestro = new TMaestro();
            MaestroLogic oMaestroLogic = new MaestroLogic();
            itemTMaestro = (TMaestro)Session["Maestro"];

            HelpMaestros.CargarListadoGenerico(ref ddlNivel2, itemTMaestro.CodTabla, 2, ddlNivel1.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
            Session["CodArgumento"] = oMaestroLogic.ObtenerCodigoCorrelativo(itemTMaestro.CodTabla, itemTMaestro.Nivel, itemTMaestro.LongNivel, ddlNivel1.SelectedValue.ToString());
            f_txtCodigoArgumento.Text = Session["CodArgumento"].ToString();
        }
    }
    protected void ddlNivel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel1.SelectedIndex > 0)
        {
            TMaestro itemTMaestro = new TMaestro();
            MaestroLogic oMaestroLogic = new MaestroLogic();
            itemTMaestro = (TMaestro)Session["Maestro"];
            HelpMaestros.CargarListadoGenerico(ref ddlNivel3, itemTMaestro.CodTabla, 3, ddlNivel2.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
            Session["CodArgumento"] = oMaestroLogic.ObtenerCodigoCorrelativo(itemTMaestro.CodTabla, itemTMaestro.Nivel, itemTMaestro.LongNivel, ddlNivel2.SelectedValue.ToString());
            f_txtCodigoArgumento.Text = Session["CodArgumento"].ToString();
        }
    }
    protected void ddlNivel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel1.SelectedIndex > 0)
        {
            TMaestro itemTMaestro = new TMaestro();
            MaestroLogic oMaestroLogic = new MaestroLogic();
            itemTMaestro = (TMaestro)Session["Maestro"];
            HelpMaestros.CargarListadoGenerico(ref ddlNivel4, itemTMaestro.CodTabla, 4, ddlNivel3.SelectedValue.ToString(), MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
            Session["CodArgumento"] = oMaestroLogic.ObtenerCodigoCorrelativo(itemTMaestro.CodTabla, itemTMaestro.Nivel, itemTMaestro.LongNivel, ddlNivel3.SelectedValue.ToString());
            f_txtCodigoArgumento.Text = Session["CodArgumento"].ToString();
        }
    }
    protected void ddlNivel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNivel1.SelectedIndex > 0)
        {
            TMaestro itemTMaestro = new TMaestro();
            MaestroLogic oMaestroLogic = new MaestroLogic();
            itemTMaestro = (TMaestro)Session["Maestro"];
            Session["CodArgumento"] = oMaestroLogic.ObtenerCodigoCorrelativo(itemTMaestro.CodTabla, itemTMaestro.Nivel, itemTMaestro.LongNivel, ddlNivel4.SelectedValue.ToString());
            f_txtCodigoArgumento.Text = Session["CodArgumento"].ToString();
        }
    }
    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
        }
    }

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void cargarCbNive()
    {
        TMaestro itemTMaestro = new TMaestro();
        itemTMaestro = (TMaestro)Session["Maestro"];
        bool estado;

        estado = HF_CodiArgumento.Value == string.Empty ? true : false;

        switch (itemTMaestro.Nivel)
        {
            case 1:
                break;
            case 2:
                lblNivel1.Visible = true;
                ddlNivel1.Visible = true;
                ddlNivel1.Enabled = estado;
                lblNivel1.Text = itemTMaestro.NombreNivel1;
                HelpMaestros.CargarListadoGenerico(ref ddlNivel1, itemTMaestro.CodTabla, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                if (!estado)
                {
                    ddlNivel1.SelectedValue = HF_CodiArgumento.Value.Substring(0, itemTMaestro.LongNivel + 5);
                }

                break;
            case 3:
                lblNivel1.Visible = true;
                ddlNivel1.Visible = true;
                lblNivel2.Visible = true;
                ddlNivel2.Visible = true;
                ddlNivel1.Enabled = estado;
                ddlNivel2.Enabled = estado;
                lblNivel1.Text = itemTMaestro.NombreNivel1;
                lblNivel2.Text = itemTMaestro.NombreNivel2;
                HelpMaestros.CargarListadoGenerico(ref ddlNivel1, itemTMaestro.CodTabla, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);
                if (!estado)
                {
                    ddlNivel1.SelectedValue = HF_CodiArgumento.Value.Substring(0, itemTMaestro.LongNivel + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel2, itemTMaestro.CodTabla, 2, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    ddlNivel2.SelectedValue = HF_CodiArgumento.Value.Substring(0, (itemTMaestro.LongNivel * 2) + 5);
                }

                break;
            case 4:
                lblNivel1.Visible = true;
                ddlNivel1.Visible = true;
                lblNivel2.Visible = true;
                ddlNivel2.Visible = true;
                lblNivel3.Visible = true;
                ddlNivel3.Visible = true;
                ddlNivel1.Enabled = estado;
                ddlNivel2.Enabled = estado;
                ddlNivel3.Enabled = estado;

                lblNivel1.Text = itemTMaestro.NombreNivel1;
                lblNivel2.Text = itemTMaestro.NombreNivel2;
                lblNivel3.Text = itemTMaestro.NombreNivel3;

                HelpMaestros.CargarListadoGenerico(ref ddlNivel1, itemTMaestro.CodTabla, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel3, HelpComboBox.Texto.Todos);
                if (!estado)
                {
                    ddlNivel1.SelectedValue = HF_CodiArgumento.Value.Substring(0, itemTMaestro.LongNivel + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel2, itemTMaestro.CodTabla, 2, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    ddlNivel2.SelectedValue = HF_CodiArgumento.Value.Substring(0, (itemTMaestro.LongNivel * 2) + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel3, itemTMaestro.CodTabla, 3, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    ddlNivel3.SelectedValue = HF_CodiArgumento.Value.Substring(0, (itemTMaestro.LongNivel * 3) + 5);
                }
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
                ddlNivel1.Enabled = estado;
                ddlNivel2.Enabled = estado;
                ddlNivel3.Enabled = estado;
                ddlNivel4.Enabled = estado;
                lblNivel1.Text = itemTMaestro.NombreNivel1;
                lblNivel2.Text = itemTMaestro.NombreNivel2;
                lblNivel3.Text = itemTMaestro.NombreNivel3;
                lblNivel4.Text = itemTMaestro.NombreNivel4;
                HelpMaestros.CargarListadoGenerico(ref ddlNivel1, itemTMaestro.CodTabla, 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel2, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel3, HelpComboBox.Texto.Todos);
                HelpComboBox.AddItemText(ref ddlNivel4, HelpComboBox.Texto.Todos);
                if (!estado)
                {
                    ddlNivel1.SelectedValue = HF_CodiArgumento.Value.Substring(0, itemTMaestro.LongNivel + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel2, itemTMaestro.CodTabla, 2, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    ddlNivel2.SelectedValue = HF_CodiArgumento.Value.Substring(0, (itemTMaestro.LongNivel * 2) + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel3, itemTMaestro.CodTabla, 3, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                    ddlNivel3.SelectedValue = HF_CodiArgumento.Value.Substring(0, (itemTMaestro.LongNivel * 3) + 5);
                    HelpMaestros.CargarListadoGenerico(ref ddlNivel4, itemTMaestro.CodTabla, 4, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
                }
                break;
        }
    }

    private void CargarPagina()
    {
        if (Request.QueryString.Get("pm") == null)
            Response.Redirect("ListaDetalle.aspx");
        string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
        hfParameters.Value = querystringDESENCRYP;
        HF_CodTabla.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
        HF_CodiArgumento.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "ca");
        HF_Nivel.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "nv");
        HF_Ver.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "ver");
        MaestroLogic oMaestroLogic = new MaestroLogic();
        f_txtCodigoArgumento.ReadOnly = true;
        if (HF_Nivel.Value == "")
            Response.Redirect("ListaDetalle.aspx");
        TMaestro itemTMaestro = new TMaestro();
        itemTMaestro = oMaestroLogic.BuscarTablaDescripcion(HF_CodTabla.Value, Convert.ToInt32(HF_Nivel.Value));
        itemTMaestro.Nivel = Convert.ToInt32(HF_Nivel.Value);
        Session["Maestro"] = itemTMaestro;

        f_txtValorCadenaCorta.Visible = itemTMaestro.VerValorCadenaCorta;
        f_txtValorCadena.Visible = itemTMaestro.VerValorCadena;
        f_txtValorCadenaLarga.Visible = itemTMaestro.VerValorCadenaLarga;
        f_chkValorBoolean.Visible = itemTMaestro.VerValorBoolean;
        f_txtValorDecimal.Visible = itemTMaestro.VerValorDecimal;
        f_txtValorEntero.Visible = itemTMaestro.VerValorEntero;

        f_lblValorCadenaCorta.Visible = itemTMaestro.VerValorCadenaCorta;
        f_lblValorCadena.Visible = itemTMaestro.VerValorCadena;
        f_lblValorCadenaLarga.Visible = itemTMaestro.VerValorCadenaLarga;
        f_lblValorBoolean.Visible = itemTMaestro.VerValorBoolean;
        f_lblValorDecimal.Visible = itemTMaestro.VerValorDecimal;
        f_lblValorEntero.Visible = itemTMaestro.VerValorEntero;

        f_lblValorCadenaCorta.Text = itemTMaestro.NombreValorCadenaCorta;
        f_lblValorCadena.Text = itemTMaestro.NombreValorCadena;
        f_lblValorCadenaLarga.Text = itemTMaestro.NombreValorCadenaLarga;
        f_lblValorBoolean.Text = itemTMaestro.NombreValorBoolean;
        f_lblValorDecimal.Text = itemTMaestro.NombreValorDecimal;
        f_lblValorEntero.Text = itemTMaestro.NombreValorEntero;
        if (HF_CodiArgumento.Value == string.Empty)
        {
            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
            hfEvento.Value = HelpEvento.Registrar.ToString();
            lblTituloPagina.Text = HelpEvento.Registrar.ToString() + " - Registro de la tabla: " + " " + itemTMaestro.Nombre; 
            f_txtCodigoArgumento.ReadOnly = false;
            cargarCbNive();
            f_txtCodigoArgumento.Text = oMaestroLogic.ObtenerCodigoCorrelativo(itemTMaestro.CodTabla, itemTMaestro.Nivel, itemTMaestro.LongNivel, codigoPadre());
            EstadoDatosVER(false);
            Auditoria1.CargarSeguridadInicio();
        }
        else
        {
            SetRegistroDetalle(oMaestroLogic.ListarDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento,HF_CodTabla.Value,Convert.ToInt32(HF_Nivel.Value), HF_CodiArgumento.Value, string.Empty )[0]);
            cargarCbNive();
            if (HF_Ver.Value == string.Empty)
            {
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
                hfEvento.Value = HelpEvento.Editar.ToString();
                lblTituloPagina.Text = HelpEvento.Editar.ToString().ToUpper() + " - Registro de la tabla: " + " " + itemTMaestro.Nombre;
            }
            else
            {
                lblTituloPagina.Text = "Ver - Registro de la tabla: " + " " + itemTMaestro.Nombre; 
                EstadoDatosVER(true);
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
            }
        }
        Page.Title = lblTituloPagina.Text;
    }

    private string codigoPadre()
    {
        TMaestro itemTMaestro = new TMaestro();
        itemTMaestro = (TMaestro)Session["Maestro"];
        string sCodigoPadre = "";

        switch (itemTMaestro.Nivel)
        {
            case 1:
                sCodigoPadre = itemTMaestro.CodTabla;
                break;
            case 2:
                sCodigoPadre = ddlNivel1.SelectedIndex == 0 ? "" : ddlNivel1.SelectedValue.ToString();
                break;
            case 3:
                sCodigoPadre = ddlNivel2.SelectedIndex == 0 ? "" : ddlNivel2.SelectedValue.ToString();
                break;
            case 4:
                sCodigoPadre = ddlNivel3.SelectedIndex == 0 ? "" : ddlNivel3.SelectedValue.ToString();
                break;
            case 5:
                sCodigoPadre = ddlNivel4.SelectedIndex == 0 ? "" : ddlNivel4.SelectedValue.ToString();
                break;
        }
        return sCodigoPadre;
    }

    private void EstadoDatosVER(bool ESTADO)
    {

        f_txtCodigoArgumento.ReadOnly = true;
        f_txtNombre.ReadOnly = ESTADO;
        f_txtValorCadena.ReadOnly = ESTADO;
        f_txtValorCadenaCorta.ReadOnly = ESTADO;
        f_txtValorCadenaLarga.ReadOnly = ESTADO;
        f_txtValorDecimal.ReadOnly = ESTADO;
        f_txtValorEntero.ReadOnly = ESTADO;
        f_chkValorBoolean.Enabled = ESTADO;
        f_chkActivo.Enabled = !ESTADO;
    }

    private TDetalle GetRegistroDetalle()
    {
        TDetalle item = new TDetalle();
        item.CodTabla = HF_CodTabla.Value;
        item.CodArgu = f_txtCodigoArgumento.Text;
        item.Nivel = Convert.ToInt32(HF_Nivel.Value);
        item.Nombre = f_txtNombre.Text;
        item.ValorCadena = f_txtValorCadena.Text;
        item.ValorCadenaCorta = f_txtValorCadenaCorta.Text;
        item.ValorCadenaLarga = f_txtValorCadenaLarga.Text;
        item.ValorDecimal = f_txtValorDecimal.Text == "" ? 0 : Convert.ToDecimal(f_txtValorDecimal.Text);
        item.ValorEntero = f_txtValorEntero.Text == "" ? 0 : Convert.ToInt32(f_txtValorEntero.Text);
        item.ValorBoolean = f_chkValorBoolean.Checked;
        item.SegUsuarioCreacion = this.Master.HelpUsuario().LoginUsuario;
        item.SegUsuarioModificacion = this.Master.HelpUsuario().LoginUsuario;
        item.Activo = f_chkActivo.Checked;
        item.SegMaquina = Request.ServerVariables["REMOTE_ADDR"];
        return item;
    }

    private void SetRegistroDetalle(TDetalle item)
    {
        f_txtCodigoArgumento.Text=item.CodArgu ;
        f_txtNombre.Text=item.Nombre  ;
        f_txtValorCadena.Text=item.ValorCadena ;
        f_txtValorCadenaCorta.Text=item.ValorCadenaCorta ;
        f_txtValorCadenaLarga.Text=item.ValorCadenaLarga  ;
        f_txtValorDecimal.Text=item.ValorDecimal.ToString() ;
        f_txtValorEntero.Text=item.ValorEntero.ToString() ;
        f_chkValorBoolean.Checked=item.ValorBoolean ;
        f_chkActivo.Checked = item.Activo;
        Auditoria1.CargarSeguridad(item.SegUsuarioCreacion, item.SegUsuarioModificacion, item.SegFechaCreacion, item.SegFechaModificacion, item.SegMaquina);
    }

    private string Validar()
    {
        string mensage = "";
        if (f_txtCodigoArgumento.Text == "") mensage = mensage + "¡ Ingresar código de argumento !" + "</br>";
        if (f_txtNombre.Text == "") mensage = mensage + "¡ Ingresar nombre del registro !" + "</br>";
        //if (mensage.Length > 0)
        //    mensage = mensage.Substring(2);
        return mensage;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaDetalle.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaDetalle.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpcionesEditar = new RolesOpciones();
        RolesOpciones oRolesOpcionesNuevo = new RolesOpciones();

        //if (oRolesOpciones.Flag_Ver)
        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
 
            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();
            bool editar = false;
            bool nuevo = false;

            if (dtEditar.Rows.Count > 0)
            {
                editar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                nuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }

            if (hfEvento.Value == HelpEvento.Editar.ToString())
            {
                BotonesEdicionMantenimiento1.BotonNuevo = false;
                BotonesEdicionMantenimiento1.BotonEditar = false;

                if (nuevo || editar)
                {
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                    EstadoDatosVER(false);
                }
            }
            else if (hfEvento.Value == HelpEvento.Registrar.ToString())
            {
                if (nuevo)
                    EstadoDatosVER(false);
            }
            else
            {
                BotonesEdicionMantenimiento1.BotonEditar = editar;
                BotonesEdicionMantenimiento1.BotonNuevo = nuevo;
                BotonesEdicionMantenimiento1.BotonGrabar = false;
                EstadoDatosVER(true);
            }
            BotonesEdicionMantenimiento1.LoadComplete();


            //if (hfEvento.Value == HelpEvento.Editar.ToString())
            //{
            //    BotonesEdicionMantenimiento1.BotonNuevo = false;
            //    BotonesEdicionMantenimiento1.BotonEditar = false;
            //    if (oRolesOpciones.Flag_Nuevo || oRolesOpciones.Flag_Editar)
            //    {
            //        BotonesEdicionMantenimiento1.BotonGrabar = true;
            //        EstadoDatosVER(false);
            //    }
            //}
            //else if (hfEvento.Value == HelpEvento.Registrar.ToString())
            //{
            //    if (oRolesOpciones.Flag_Nuevo)
            //        EstadoDatosVER(false);
            //}
            //else
            //{
            //    BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
            //    BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //    BotonesEdicionMantenimiento1.BotonGrabar = false;
            //    EstadoDatosVER(true);
            //}
            //BotonesEdicionMantenimiento1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    #endregion

   
}
