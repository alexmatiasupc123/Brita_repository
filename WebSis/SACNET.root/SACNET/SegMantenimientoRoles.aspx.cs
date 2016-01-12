using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Mantenimientos_SegMantenimientoRoles : System.Web.UI.Page
{
   
    #region "/--- Eventos de la Pagina  ---/"

    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!Page.IsPostBack)
        {
            EstadoBoton(true);
            Limpiar();
            EstadoBoton(true);
            CargarPage();
          
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }
  
    #endregion
  
    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    #region --Funciones de Menu--->
     
    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        String querystringENCRYP = HelpEncrypt.Encriptar(hfParameters.Value);
        Response.Redirect("SegListaRoles.aspx?pm=" + querystringENCRYP);
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        EstadoBoton(false);
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        RolesLogic oRolesLogic = new RolesLogic();
        Roles oRoles = new Roles();
        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            MessageBox1.ShowInfo("Ingrese el nombre del rol.");
            return;
        }
        getRoles(oRoles);
        ReturnValor oReturn;
        try
        {
            if (string.IsNullOrEmpty(txtCodigoRol.Text) == true)
            {
                List<Roles> ListaRoles = oRolesLogic.Listar(txtNombre.Text, string.Empty);
                if (!ListaRoles.Exists(x => x.NombreRol == txtNombre.Text))
                {
                    oReturn = oRolesLogic.Registrar(oRoles);
                    if (oReturn.Exitosa)
                    {
                        MessageBox1.ShowSuccess(oReturn.Message);
                        BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        txtCodigoRol.Text = oReturn.CodigoRetorno;
                        EstadoBoton(false);
                        EstadoDatos(false);
                    }
                    else
                    {
                        MessageBox1.ShowWarning(oReturn.Message);
                    }
                }
                else
                    MessageBox1.ShowInfo("Este Rol ya está registrado.");

            }
            else
            {

                List<Roles> ListaSeek = new List<Roles>();
                List<Roles> ListaRoles = oRolesLogic.Listar(txtNombre.Text, string.Empty);
                var query = from item in ListaRoles
                            where item.NombreRol == txtNombre.Text
                            select item;
                ListaSeek = query.ToList();
                if ((ListaSeek.Exists(x => x.CodigoRol == txtCodigoRol.Text)) || ListaSeek.Count==0)
                {
                    oReturn = oRolesLogic.Actualizar(oRoles);
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
                    MessageBox1.ShowInfo("Este Rol ya está registrado.");


            }

        }
        catch (Exception ex)
        {
            MessageBox1.ShowError(ex.Message);
        }
        
    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        if (txtCodigoRol.Text.Trim().Length != 0)
        {
            CargarPage();
            EstadoBoton(true);
            EstadoDatos(true);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        string cadeParametros = hfParameters.Value.Substring(hfParameters.Value.ToString().IndexOf("&xNO"), hfParameters.Value.Trim().Length - hfParameters.Value.ToString().IndexOf("xNO") + 1);
        Response.Redirect("SegMantenimientoRoles.aspx?pm=" + HelpEncrypt.Encriptar(cadeParametros), false);

        EstadoDatos(true);
    }

    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }
 
    #endregion

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    
    private void EstadoBoton(bool pEstado)
    {
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = !pEstado;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = !pEstado;
        BotonesEdicionMantenimiento1.BotonGrabarEnabled = pEstado;
        BotonesEdicionMantenimiento1.BotonCancelarEnabled = pEstado;
        BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
    }
   
    private void getRoles(Roles pRoles)
    {
        pRoles.CodigoRol = txtCodigoRol.Text;
        pRoles.NombreRol = txtNombre.Text;
        pRoles.DescripcionRol = txtDescripcion.Text;

        if (rblEstado.Items[0].Selected)
            pRoles.Estado = "A";
        else
            pRoles.Estado = "I";
        pRoles.SegUsuarioRegistro = Master.HelpUsuario().LoginUsuario;
        pRoles.SegUsuarioModifica = Master.HelpUsuario().LoginUsuario;
    }

    private void setRoles(Roles pRoles)
    {
        txtCodigoRol.Text = pRoles.CodigoRol;
        txtNombre.Text = pRoles.NombreRol;
        txtDescripcion.Text = pRoles.DescripcionRol;
        Auditoria1.CargarSeguridad(pRoles.SegUsuarioRegistro, pRoles.SegUsuarioModifica, pRoles.SegFechaRegistro, pRoles.SegFechaModifica, pRoles.SegMaquina);
        if (pRoles.Estado== "A")
        {
            rblEstado.Items[0].Selected = true;
            rblEstado.Items[1].Selected = false;
        }
        else
        {
            rblEstado.Items[0].Selected = false;
            rblEstado.Items[1].Selected = true;
        }
    }

    private void Limpiar()
    {
        txtCodigoRol.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtNombre.Text = string.Empty;
        rblEstado.Items[0].Selected = true;
    }

    private void CargarPage()
    {
        CargarCombos();
        if (Request.QueryString.Get("pm") != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            hfParameters.Value = querystringDESENCRYP;

            string xCodOpcion = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
            if (xCodOpcion != string.Empty)
            {
                RolesLogic oRolesLogic = new RolesLogic();
                Roles oItemRoles = oRolesLogic.Buscar(xCodOpcion);
                setRoles(oItemRoles);
                EstadoBoton(true);
            }
            else
                Auditoria1.CargarSeguridadInicio();
        }
        else
            Auditoria1.CargarSeguridadInicio();
    }

    private void CargarCombos()
    {
        // ES ESTA PÁGINA NO HAY COMBOS
    }

    private void EstadoDatos(bool estado)
    {
        txtNombre.Enabled = estado;
        txtCodigoRol.Enabled = false;
        txtDescripcion.Enabled = estado;
        rblEstado.Enabled = estado;
    }
    private void Seguridad()
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

            //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegMantenimientoRoles.aspx");
            List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("SegMantenimientoRoles.aspx");//ELVP:11-10-2011
            RolesOpciones oRolesOpciones = new RolesOpciones();

            if (lstRolesOpciones != null)
            {
                var queryEditar = from item in lstRolesOpciones
                                  where item.Tipo == "4"
                                  select item;
                var queryNuevo = from item in lstRolesOpciones
                                 where item.Tipo == "5"
                                 select item;

                if (queryEditar.Count() > 0)
                {
                    oRolesOpciones = queryEditar.ToList()[0];
                    if (oRolesOpciones != null)
                    {
                        lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
                        BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
                        BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
                        BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
                        if (oRolesOpciones.Flag_Nuevo || oRolesOpciones.Flag_Editar)
                            BotonesEdicionMantenimiento1.BotonGrabar = true;
                        else
                            BotonesEdicionMantenimiento1.BotonGrabar = false;
                        BotonesEdicionMantenimiento1.LoadComplete();
                    }
                }
                if (queryNuevo.Count() > 0)
                {
                    oRolesOpciones = queryNuevo.ToList()[0];
                    if (oRolesOpciones != null)
                    {
                        BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
                        if (oRolesOpciones.Flag_Nuevo || oRolesOpciones.Flag_Editar)
                            BotonesEdicionMantenimiento1.BotonGrabar = true;
                        else
                            BotonesEdicionMantenimiento1.BotonGrabar = false;
                    }
                }

                //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
                //BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
                //BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
                //BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
                //BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
                //if (oRolesOpciones.Flag_Nuevo || oRolesOpciones.Flag_Editar)
                //{
                //    BotonesEdicionMantenimiento1.BotonGrabar = true;
                //}
                //else
                //{
                //    BotonesEdicionMantenimiento1.BotonGrabar = false;
                //}
                //BotonesEdicionMantenimiento1.LoadComplete();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
    #endregion

   
}
