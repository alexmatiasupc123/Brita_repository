using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Mantenimientos_SegMantenimientoOpciones : System.Web.UI.Page
{
   
    #region "/--- Eventos de la Pagina  ---/"

    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        EstadoBoton(true);
        if (!Page.IsPostBack)
        {
            
            Limpiar();
            CargarCombos();
            CargarPage();
            
            ActivarPermisosAlFormularioActual();
        }
        //ActivarPermisosAlFormularioActual();
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        ActivarPermisosAlFormularioActual();
        Page.Title = lblTituloPagina.Text;
    }
    #endregion
   
    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    # region --Funciones de Menu--->
     
    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        String querystringENCRYP = HelpEncrypt.Encriptar(hfParameters.Value);
        Response.Redirect("SegListaOpciones.aspx?pm=" + querystringENCRYP);
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {        
        EstadoBoton(false);       
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        OpcionesLogic oOpcionesLogic = new OpcionesLogic();
        Opciones oOpciones = new Opciones();
        getOpciones(oOpciones);
        ReturnValor oReturn;
        try
        {
            string xCodOpcion = HelpEncrypt.QueryString(hfParameters.Value, "id");
            if (xCodOpcion == string.Empty)
            {
                Opciones itemOpcion = new Opciones();
                List<Opciones> ListaOpciones = oOpcionesLogic.Listar(txtNombre.Text, string.Empty);
                if (!ListaOpciones.Exists(x => x.Nombre == txtNombre.Text))
                {
                    oReturn = oOpcionesLogic.Registrar(oOpciones);
                    if (oReturn.Exitosa)
                    {
                        MessageBox1.ShowSuccess(oReturn.Message);
                        BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        txtCodigoOpcion.Text = oReturn.CodigoRetorno;
                        EstadoBoton(false);
                        EstadoDatos(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturn.Message);
                    }
                }
                else
                    MessageBox1.ShowInfo("Esta Opción ya está registrada.");

            }
            else
            {
                Opciones itemOpcion = new Opciones();
                List<Opciones> ListaSeek = new List<Opciones>();
                List<Opciones> ListaOpciones = oOpcionesLogic.Listar(txtNombre.Text, string.Empty);
                var query = from item in ListaOpciones
                            where item.Nombre == txtNombre.Text
                            select item;
                ListaSeek = query.ToList();
                if ((ListaSeek.Exists(x => x.CodigoOpcion == txtCodigoOpcion.Text)) || ListaSeek.Count == 0)
                {
                    oReturn = oOpcionesLogic.Actualizar(oOpciones);
                    if (oReturn.Exitosa)
                    {
                        MessageBox1.ShowSuccess(oReturn.Message);
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                        EstadoBoton(false);
                        EstadoDatos(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturn.Message);
                    }
                }
                else
                    MessageBox1.ShowInfo("Esta Opción ya está registrada.");

            }
        }
        catch (Exception ex)
        {
            MessageBox1.ShowError(ex.Message);
        }
        

    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        if (txtCodigoOpcion.Text.Trim().Length != 0)
        {
            CargarPage();
            EstadoBoton(true);
            EstadoDatos(true);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        string cadeParametros = hfParameters.Value.Substring(hfParameters.Value.ToString().IndexOf("&xNO"), hfParameters.Value.Trim().Length - hfParameters.Value.ToString().IndexOf("xNO") + 1);
        Response.Redirect("SegMantenimientoOpciones.aspx?pm=" + HelpEncrypt.Encriptar(cadeParametros), false);
       
        EstadoDatos(true);
    }
 
    #endregion

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }

    private void EstadoBoton(bool pEstado)
    {
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = !pEstado;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = !pEstado;
        BotonesEdicionMantenimiento1.BotonGrabarEnabled = pEstado;
        BotonesEdicionMantenimiento1.BotonCancelarEnabled = pEstado;
        BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
        BotonesEdicionMantenimiento1.BotonNuevo = false;
    }

    private void getOpciones(Opciones pOpciones)
    {
        pOpciones.CodigoOpcion = txtCodigoOpcion.Text;
        pOpciones.Nombre = txtNombre.Text;
        pOpciones.Descripcion = txtDescripcion.Text;
        pOpciones.Enlace = txtEnlace.Text;
        if (ddlCodigoPadre.SelectedIndex > 0)
            pOpciones.CodigoPadre = ddlCodigoPadre.SelectedValue;
        if (rblMenus.Items[0].Selected)
            pOpciones.FlagMenu = "S";
        else
            pOpciones.FlagMenu = "N";
        if (rblEstado.Items[0].Selected)
            pOpciones.Estado = "A";
        else
            pOpciones.Estado = "I";
        pOpciones.SegUsuarioRegistro = Master.HelpUsuario().LoginUsuario;
        pOpciones.SegUsuarioModifica = Master.HelpUsuario().LoginUsuario;
    }

    private void setOpciones(Opciones pOpciones)
    {
        txtCodigoOpcion.Text = pOpciones.CodigoOpcion;
        txtNombre.Text = pOpciones.Nombre;
        txtDescripcion.Text = pOpciones.Descripcion;
        txtEnlace.Text = pOpciones.Enlace.Trim();
        if (pOpciones.CodigoPadre != null)
            ddlCodigoPadre.SelectedValue = pOpciones.CodigoPadre;

        if (pOpciones.FlagMenu == "S")
        {
            rblMenus.Items[0].Selected = true;
            rblMenus.Items[1].Selected = false;
        }
        else
        {
            rblMenus.Items[0].Selected = false;
            rblMenus.Items[1].Selected = true;
        }
        if (pOpciones.Estado == "A")
        {
            rblEstado.Items[0].Selected = true;
            rblEstado.Items[1].Selected = false;
        }
        else
        {
            rblEstado.Items[0].Selected = false;
            rblEstado.Items[1].Selected = true;
        }
        Auditoria1.CargarSeguridad(pOpciones.SegUsuarioRegistro, pOpciones.SegUsuarioModifica, pOpciones.SegFechaRegistro, pOpciones.SegFechaModifica, pOpciones.SegMaquina);
    }

    private void Limpiar()
    {
        txtCodigoOpcion.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtNombre.Text = string.Empty;
        rblEstado.Items[0].Selected = true;
        rblMenus.Items[0].Selected = true;
        
    }

    private void CargarPage()
    {
        if (Request.QueryString.Get("pm") != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            hfParameters.Value = querystringDESENCRYP;

            string xCodOpcion = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
            if (xCodOpcion != string.Empty)
            {
                OpcionesLogic oOpcionesLogic = new OpcionesLogic();
                Opciones itemOpciones = oOpcionesLogic.Buscar(xCodOpcion);
                setOpciones(itemOpciones);
            }
            else
                Auditoria1.CargarSeguridadInicio();
        }
        
    }

    private void CargarCombos()
    {
        OpcionesLogic oOpcionesLogic = new OpcionesLogic();
        ddlCodigoPadre.DataSource = oOpcionesLogic.Listar(string.Empty,string.Empty);
        ddlCodigoPadre.DataTextField = "Nombre";
        ddlCodigoPadre.DataValueField = "CodigoOpcion";
        ddlCodigoPadre.DataBind();
        HelpComboBox.AddItemText(ref ddlCodigoPadre,HelpComboBox.Texto.Select);
    }

    private void EstadoDatos(bool estado)
    {
        txtNombre.Enabled = estado;
        txtCodigoOpcion.Enabled = false;
        txtDescripcion.Enabled = estado;
        rblEstado.Enabled = estado;
        rblMenus.Enabled = estado;
        ddlCodigoPadre.Enabled = estado;
        txtEnlace.Enabled = estado;
    }

    #endregion

    private void ActivarPermisosAlFormularioActual()
    {
        string xCodOpcionVer = HelpEncrypt.QueryString(hfParameters.Value, "Vid");
        if (xCodOpcionVer != string.Empty)
        {
            BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
            BotonesEdicionMantenimiento1.BotonEditarEnabled = false;
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
            EstadoDatos(false);
        }
        else
        {
            Usuarios oUsuario = new Usuarios();
            List<RolesOpciones> lstRolesOpciones = new List<RolesOpciones>();
            oUsuario = (Usuarios)Session["Usuario"];
            if (oUsuario != null)
            {
                lstRolesOpciones = oUsuario.RolOpcionesMenus;
                var query = from item in lstRolesOpciones
                            where item.CodigoOpcionEnlace == "SegMantenimientoOpciones.aspx"
                            select item;
                if (query.Count() > 0)
                {
                    RolesOpciones itemRolesOpciones = new RolesOpciones();
                    itemRolesOpciones = query.ToList()[0];
                    if (itemRolesOpciones != null)
                    {
                        lblTituloPagina.Text = itemRolesOpciones.CodigoOpcionNombre;
                        BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
                        BotonesEdicionMantenimiento1.BotonEditar = itemRolesOpciones.Flag_Editar;
                        BotonesEdicionMantenimiento1.BotonNuevo = itemRolesOpciones.Flag_Nuevo;
                        BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
                        BotonesEdicionMantenimiento1.BotonNuevo = false;
                        if (itemRolesOpciones.Flag_Nuevo || itemRolesOpciones.Flag_Editar)
                        {
                            BotonesEdicionMantenimiento1.BotonGrabar = true;
                        }
                        else
                        {
                            BotonesEdicionMantenimiento1.BotonGrabar = false;
                        }
                        BotonesEdicionMantenimiento1.LoadComplete();
                    }
                }
                else
                    Response.Redirect("Login.aspx");
            }
            else
                Response.Redirect("Login.aspx");
        }
    }
}
