using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
public partial class PopupAgregarEjemplar : System.Web.UI.Page
{
    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        this.InicializarEventos();
        if (!Page.IsPostBack)
        {
            Usuarios oUsuario = new Usuarios();            
            oUsuario = (Usuarios)Session["Usuario"];
            if (oUsuario != null)
            {
                this.CargarPagina();
            }
            else
                Response.Redirect("Login.aspx");
            
        }
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
           LimpiarDatos();
           EstadoDatosActivo(true);
           hfEvento.Value = HelpEvento.Registrar.ToString();        
    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
            hfEvento.Value = HelpEvento.Editar.ToString();
            txtCodigoEjemplar.Enabled = false;
            txtNotas.Enabled = true;
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        try
        {
            string mensaje = Validar();
        if (mensaje == "")
        {
            string MessageAccion = string.Empty;
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();

            List<ItemEjemplar> ListaEjemplar = new List<ItemEjemplar>();
            if (Session["Ejemplares"] != null)
            {
                ListaEjemplar = (List<ItemEjemplar>)Session["Ejemplares"];
            }
            if (hfEvento.Value == HelpEvento.Registrar.ToString())
            {
                
                ItemEjemplarLogic oEjemplarLogic = new ItemEjemplarLogic();
                if (oEjemplarLogic.DetectarExisteEjemplar(txtCodigoEjemplar.Text))
                {
                    MessageBox1.ShowWarning("El ejemplar ya existe, ya fue registrado.");
                    return;
                }
                int pIndex;
                pIndex = ListaEjemplar.FindIndex(x => x.sCodEjemplar == txtCodigoEjemplar.Text);
                if (pIndex != -1)
                {
                    MessageBox1.ShowWarning("El ejemplar ya existe, ya fue registrado.");
                    return;
                }
                string CodItem=string.Empty;
                string querystringDESENCRYP = string.Empty;
                if (Request.QueryString["pm"] != null)
                {
                    querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                }
                
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "oCodItem") != string.Empty)
                    CodItem = HelpEncrypt.QueryString(querystringDESENCRYP, "oCodItem");
                else if (HelpEncrypt.QueryString(querystringDESENCRYP, "oIdItem") != string.Empty)
                    CodItem = HelpEncrypt.QueryString(querystringDESENCRYP, "oIdItem");
                string CodItemEjemplar = txtCodigoEjemplar.Text ;
                ReturnValor oReturnValor = new ReturnValor();
                if (string.IsNullOrEmpty(CodItem) == true) //Se registra en memoria,session
                {
                    ItemEjemplar item = GetRegistroItemEjemplar(CodItem, CodItemEjemplar);
                    item.sEstadoReg = true;
                    ListaEjemplar.Add(item);
                    Session["Ejemplares"] = ListaEjemplar;
                    MessageAccion = "Ejemplar asignado satisfactoriamente.";
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                    MessageBox1.ShowSuccess(MessageAccion);
                    EstadoDatosActivo(false);
                }
                else    //Se registra en Base de Datos.
                {
                    ItemEjemplar item = GetRegistroItemEjemplar(CodItem, CodItemEjemplar);
                    oReturnValor = oItemEjemplarLogic.Registrar(item);
                    if (oReturnValor.Exitosa)
                    {
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        MessageBox1.ShowSuccess(oReturnValor.Message + ", este nuevo ejemplar debe ser asignado a un sac.");
                        EstadoDatosActivo(false);
                        ListaEjemplar = oItemEjemplarLogic.Listar(CodItem, string.Empty,string.Empty);
                        Session["Ejemplares"] = ListaEjemplar;

                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturnValor.Message);
                    }
                }

            }
            else if (hfEvento.Value == HelpEvento.Editar.ToString())//Actualizacion en la Base de Datos.
            {
                ReturnValor oReturnValor = new ReturnValor();
                string querystringDESENCRYP = string.Empty;
                if (Request.QueryString["pm"] != null)
                {
                    querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                }
                
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "aId") != string.Empty)
                {
                    string CodEjemplar = txtCodigoEjemplar.Text;
                    string CodItem = HelpEncrypt.QueryString(querystringDESENCRYP, "oIdItem");
                    ItemEjemplar item = GetRegistroItemEjemplar(CodItem, CodEjemplar);
                    oReturnValor = oItemEjemplarLogic.Actualizar(item);
                    if (oReturnValor.Exitosa)
                    {
                        ListaEjemplar = oItemEjemplarLogic.Listar(CodItem, string.Empty,string.Empty);
                        Session["Ejemplares"] = ListaEjemplar;
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                        MessageBox1.ShowSuccess(oReturnValor.Message);
                        EstadoDatosActivo(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturnValor.Message);
                    }
 
                }
                else if (HelpEncrypt.QueryString(querystringDESENCRYP, "aIndex") != string.Empty) //Actualizacion en Memoria- session.
                {
                    string CodIndex = HelpEncrypt.QueryString(querystringDESENCRYP, "aIndex");
                    ListaEjemplar[Convert.ToInt32(CodIndex)].sCodItem = string.Empty;
                    ListaEjemplar[Convert.ToInt32(CodIndex)].sCodEjemplar = txtCodigoEjemplar.Text;
                    ListaEjemplar[Convert.ToInt32(CodIndex)].sCodSac = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Value;
                    ListaEjemplar[Convert.ToInt32(CodIndex)].sCodSacNombre = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Text;
                    ListaEjemplar[Convert.ToInt32(CodIndex)].bReservado = chkReservado.Checked;
                    ListaEjemplar[Convert.ToInt32(CodIndex)].sNotas = txtNotas.Text;
                    Session["Ejemplares"] = ListaEjemplar;
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    MessageAccion = "Ejemplar actualizado satisfactoriamente.";
                    MessageBox1.ShowSuccess(MessageAccion);
                    EstadoDatosActivo(false);

                }
                else
                {
                    int IndexList;
                    IndexList = ListaEjemplar.FindIndex(x => x.sCodEjemplar == txtCodigoEjemplar.Text);
                    ListaEjemplar[IndexList].sCodItem = string.Empty;
                    ListaEjemplar[IndexList].sCodEjemplar = txtCodigoEjemplar.Text;
                    ListaEjemplar[IndexList].sCodSac = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Value;
                    ListaEjemplar[IndexList].sCodSacNombre = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Text;
                    ListaEjemplar[IndexList].bReservado = chkReservado.Checked;
                    ListaEjemplar[IndexList].sNotas = txtNotas.Text;
                    Session["Ejemplares"] = ListaEjemplar;
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    MessageAccion = "Ejemplar actualizado satisfactoriamente.";
                    MessageBox1.ShowSuccess(MessageAccion);
                    EstadoDatosActivo(false);
                }

                
            }
        }
        else
        {
            MessageBox1.ShowWarning("Falta ingresar los siguientes datos: </br>" + mensaje);
        }
        }
        catch (Exception ex)
        {   
            MessageBox1.ShowError(ex.Message);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
           
       
        string script = String.Format("CerrarCancel()", "");
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerrarCancelScript"))
        {
            //Client Script CallBack.. la capacidad del servidor de ejecutar una funcion JavaScript desde el servidor.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarCancelScript", script, true);
        }

    }
    
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private void CargarPagina()
    {
        this.CargarCombos();
        LimpiarDatos();
        this.EstadoDatosActivo(true);
        hfEvento.Value = HelpEvento.Registrar.ToString();
        this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
        if (Session["Ejemplares"] == null)
        {
            Session["Ejemplares"] = new List<ItemEjemplar>();
            
        }
        else
        {
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "aId") != string.Empty)
                {
                    hfCodEjemplar.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "aId");
                    hfEvento.Value = HelpEvento.Editar.ToString();
                    this.PintarDatosEjemplarBD(hfCodEjemplar.Value);
                }
                else
                {
                    if (HelpEncrypt.QueryString(querystringDESENCRYP, "aIndex") != string.Empty)
                    {

                        hfEvento.Value = HelpEvento.Editar.ToString();
                        this.PintarDatosEjemplarLista(HelpEncrypt.QueryString(querystringDESENCRYP, "aIndex"));
                    }

                }
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") != string.Empty)
                {
                    if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") == HelpEvento.Ver.ToString())
                    {
                        this.BotonesEdicionMantenimiento1.BotonCancelar = false;
                        this.BotonesEdicionMantenimiento1.BotonEditar = false;
                        this.BotonesEdicionMantenimiento1.BotonGrabar = false;
                        this.BotonesEdicionMantenimiento1.BotonNuevo = false;
                        this.BotonesEdicionMantenimiento1.BotonRegresar = true;
                        txtCodigoEjemplar.Enabled = false;
                        txtNotas.Enabled = false;
                    }
                }
            }
        }
        
    }
    
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlEstadoEjemplar, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.EstadosDeEjemplares), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        ddlEstadoEjemplar.DataBind();
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();

        ddlSac.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSac.DataValueField = "CodLocalSAC";
        ddlSac.DataTextField = "NombreLocal";
        ddlSac.DataBind();
        ddlSac.Items.Insert(0, (new ListItem("-- Seleccionar --", "")));
    }
    private void PintarDatosEjemplarBD(string pCodEjemplar)
    {
        try
        {
            ItemEjemplar oItemEjemplar = new ItemEjemplar();
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            oItemEjemplar = oItemEjemplarLogic.Buscar(pCodEjemplar);
            if (oItemEjemplar != null)
            {
                txtCodigoEjemplar.Enabled = false;
                txtCodigoEjemplar.Text = oItemEjemplar.sCodEjemplar;
                ddlSac.SelectedValue = oItemEjemplar.sCodSac;
                ddlEstadoEjemplar.SelectedValue = oItemEjemplar.sCodArguEstadoEjemplar;
                chkReservado.Checked = oItemEjemplar.bReservado;
                txtNotas.Text = oItemEjemplar.sNotas;
            }
        }
        catch (Exception ex)
        {
            MessageBox1.ShowSuccess(ex.Message); 
        } 
    }
    private void PintarDatosEjemplarLista(string pIndex)
    {
        ItemEjemplar oItemEjemplar = ((List<ItemEjemplar>)Session["Ejemplares"])[Convert.ToInt32(pIndex)];
        txtCodigoEjemplar.Enabled = false;
        txtCodigoEjemplar.Text = oItemEjemplar.sCodEjemplar;
        ddlSac.SelectedValue = oItemEjemplar.sCodSac;
        txtNotas.Text = oItemEjemplar.sNotas;
        ddlEstadoEjemplar.SelectedValue = oItemEjemplar.sCodArguEstadoEjemplar;
        chkReservado.Checked = oItemEjemplar.bReservado;
    }
    private void EstadoDatosActivo(bool ESTADO)
    {

        txtCodigoEjemplar.Enabled = ESTADO;       
        txtNotas.Enabled = ESTADO;
        
    }
    private void LimpiarDatos()
    {
        txtCodigoEjemplar.Text=string.Empty;
        ddlEstadoEjemplar.SelectedIndex = 0;
        ddlSac.SelectedIndex = 0;
        chkReservado.Checked = false;
        txtNotas.Text = string.Empty;
        txtCodigoEjemplar.Focus();
    }
    private ItemEjemplar GetRegistroItemEjemplar(string pCodItem,string pCodEjemplar)
    {
        ItemEjemplar oItemEjemplar = new ItemEjemplar();
        oItemEjemplar.sCodItem = pCodItem;
        oItemEjemplar.sCodEjemplar = pCodEjemplar;
        oItemEjemplar.sCodArguEstadoEjemplar = ddlEstadoEjemplar.SelectedIndex == 0 ? string.Empty : ddlEstadoEjemplar.SelectedItem.Value;
        oItemEjemplar.sCodSac = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Value;
        oItemEjemplar.sCodSacNombre = ddlSac.SelectedIndex == 0 ? string.Empty : ddlSac.SelectedItem.Text;
        oItemEjemplar.sNotas = txtNotas.Text;
        oItemEjemplar.bReservado = chkReservado.Checked;
        oItemEjemplar.SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario;
        oItemEjemplar.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
        oItemEjemplar.SSIHost = Context.Request.UserHostName;
        return oItemEjemplar;
    }
    private string Validar()
    {
        string mensage = "";
        if (txtCodigoEjemplar.Text == "") mensage = mensage + ",¡ Ingresar el código del ejemplar. !";
        if (mensage.Length > 0)
            mensage = mensage.Substring(1);
        return mensage;
    }
    #endregion
}
