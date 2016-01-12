using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;


public partial class Mantenimientos_SegAsignarOpcionesA_Roles : System.Web.UI.Page
{
    string message = string.Empty;
    static string CodOpcion = "";

    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        EstadoBoton(true);
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["IdRoles"] != null )
            {
                PintarDatosDeParametros(Request.QueryString["IdRoles"].ToString());
            }
            lblTituloPagina.Text = "Asignar roles a opciones.";
          
           
            CargarGrillaOpcionesDelRo();
            pnRegistro.Visible = false;
            pnListadoUsuarios.Visible = true;
            gvOpcionesDelSistema.Visible = true;
            //Seguridad();   
        }
        Seguridad();      
        Page.Title = lblTituloPagina.Text;
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        //Seguridad();


    }
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    /**************************************************************************/
    #region "/--- Eventos de los Botones de Comando  ---/"
    /**************************************************************************/
    /**************************************************************************/

    private void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        pnRegistro.Visible = true;
        pnListadoUsuarios.Visible = false;
        EstadoBoton(true);
        EstadoDatos(true);
        LimpiarDatos();
        CodOpcion = "Nuevo";
    }

    private void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {

    }

    private void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        pnRegistro.Visible = false;

        pnListadoUsuarios.Visible = true;
        gvOpcionesDelSistema.Visible = true;
        CargarGrillaOpcionesDelRo();

        EstadoBoton(true);
    }

    private void BotonEdicionMantenimiento1_OnBotonRetornarClick(object sender, EventArgs e)
    {
        string script = String.Format("CerrarCancel()", "AsignaOpciones");
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerrarCancelScript"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarCancelScript", script, true);
        }
    }

    private void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        if (ddlOpcionesDelsistema.SelectedIndex <= 0)
        {            
            MessageBox1.ShowInfo("Seleccionar opción del sistema.");
            ddlOpcionesDelsistema.Focus();
            EstadoBoton(false);
            return;
            
        }
        try
        {
            
            RolesOpciones oRolesOpciones = new RolesOpciones();
            getRolesOpciones(oRolesOpciones);

            RolesOpcionesLogic oRolesOpcionesLogic = new RolesOpcionesLogic();
            ReturnValor oReturnValor = new ReturnValor();
            string DATOnULO = oRolesOpcionesLogic.Buscar(oRolesOpciones.CodigoRol, oRolesOpciones.CodigoOpcion).CodigoOpcion;
            if (CodOpcion == "Nuevo")
            {
                oReturnValor = oRolesOpcionesLogic.Registrar(oRolesOpciones);
                if (oReturnValor.Exitosa)
                {
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                    EstadoDatos(false);
                }
                else
                    MessageBox1.ShowWarning(oReturnValor.Message);

            }
            else
            {
                oReturnValor = oRolesOpcionesLogic.Actualizar(oRolesOpciones);
                if (oReturnValor.Exitosa)
                {
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    EstadoDatos(false);
                }
                else
                    MessageBox1.ShowWarning(oReturnValor.Message);
            }
            CargarGrillaOpcionesDelRo();
            CodOpcion = "";
            pnRegistro.Visible = false;
            pnListadoUsuarios.Visible = true;
            EstadoBoton(true);
            //BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
           // MessageBox1.Show(MessageType.Success, oReturnValor.Message, 125, 300);
        }
        catch (Exception ex)
        {
            message = ex.Message;
            MessageBox1.ShowError(message);
        }
    }

    #endregion

    protected void gvOpcionesDelSistema_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[1].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;") 
            {

                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = false;
            }
        }
    }

    protected void gvOpcionesDelSistema_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                RolesOpcionesLogic oRolesOpcionesLogic = new RolesOpcionesLogic();
                RolesOpciones itemRolesOpciones = new RolesOpciones();
                itemRolesOpciones = oRolesOpcionesLogic.Buscar(Request.QueryString["IdRoles"].ToString(), e.CommandArgument.ToString());
                setRolesOpciones(itemRolesOpciones);
                CodOpcion = "Editar";
                pnRegistro.Visible = true;
                pnListadoUsuarios.Visible = false;              
                EstadoBoton(false);
                EstadoDatos(true);
                ddlOpcionesDelsistema.Enabled = false;
                break;
            case "Eliminar":
                EliminarOpcionDelRolDeUsuario(e.CommandArgument.ToString());
                break;
        }
    }

    protected void gvOpcionesDelSistema_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOpcionesDelSistema.PageIndex = e.NewPageIndex;
        CargarGrillaOpcionesDelRo();
       
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs e, string parameter)
    {
        string param = parameter;

    }
  
    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void getRolesOpciones(RolesOpciones pRolesOpciones)
    {
        pRolesOpciones.CodigoOpcion = ddlOpcionesDelsistema.SelectedValue.ToString();
        pRolesOpciones.CodigoRol = Request.QueryString["IdRoles"].ToString();
        pRolesOpciones.Flag_Editar = CheckBox_Editar.Checked;
        pRolesOpciones.Flag_Eliminar = CheckBox_Eliminar.Checked;
        pRolesOpciones.Flag_Nuevo = CheckBox_Nuevo.Checked;
        pRolesOpciones.Flag_Ver = CheckBox_Ver.Checked;
        pRolesOpciones.SegUsuarioRegistro = Master.HelpUsuario().LoginUsuario;
        pRolesOpciones.SegUsuarioModifica = Master.HelpUsuario().LoginUsuario;
    }

    private void setRolesOpciones(RolesOpciones pRolesOpciones)
    {
        ddlOpcionesDelsistema.SelectedValue = pRolesOpciones.CodigoOpcion;
        CheckBox_Editar.Checked = pRolesOpciones.Flag_Editar;
        CheckBox_Eliminar.Checked = pRolesOpciones.Flag_Eliminar;
        CheckBox_Nuevo.Checked = pRolesOpciones.Flag_Nuevo;
        CheckBox_Ver.Checked = pRolesOpciones.Flag_Ver;
    }    

    public string PintarEstado(string pCodigoOpcion, bool pEstado)
    {
        string estado = string.Empty;

        if (pCodigoOpcion.Length != 0)
        {
            if (pEstado)
            {
                estado = "SI";
            }
            else
            {
                estado = "NO";
            }
        }

        return estado;
    }

    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRetornarClick);
    }

    private void EstadoBoton(bool estado)
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegAsignarOpcionesA_Roles.aspx");
         if (oRolesOpciones != null)
         {

             BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
             BotonesEdicionMantenimiento1.BotonEditar = false;
             BotonesEdicionMantenimiento1.BotonGrabarEnabled = !estado;
             BotonesEdicionMantenimiento1.BotonNuevoEnabled = oRolesOpciones.Flag_Nuevo? estado: false;
             BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
         }
            

    }

    private void PintarDatosDeParametros(string pCodigoRol)
    {
        RolesLogic oRolesLogic = new RolesLogic();
        Roles itemRoles = new Roles();
        itemRoles = oRolesLogic.Buscar(pCodigoRol);
        txtCodigoRol.Text = Request.QueryString["IdRoles"].ToString();
        txtNombreRol.Text = itemRoles.NombreRol;

        OpcionesLogic oOpcionesLogic = new OpcionesLogic();
        ddlOpcionesDelsistema.DataSource = oOpcionesLogic.Listar(string.Empty, string.Empty);
        ddlOpcionesDelsistema.DataTextField = "Nombre";
        ddlOpcionesDelsistema.DataValueField = "CodigoOpcion";
        ddlOpcionesDelsistema.DataBind();
        HelpComboBox.AddItemText(ref ddlOpcionesDelsistema, HelpComboBox.Texto.Select);
    }

    private void CargarGrillaOpcionesDelRo()
    {
        if (Request.QueryString["IdRoles"] != null)
        {
            RolesOpcionesLogic oRolesOpcionesLogic = new RolesOpcionesLogic();
            List<RolesOpciones> lstRolesOpciones = new List<RolesOpciones>();
            lstRolesOpciones = oRolesOpcionesLogic.Listar(Request.QueryString["IdRoles"].ToString());
            gvOpcionesDelSistema.DataSource = lstRolesOpciones;
            gvOpcionesDelSistema.DataBind();
  
        }
    }

    private void EstadoDatos(bool estado)
    {

        
             ddlOpcionesDelsistema.Enabled = estado;
             CheckBox_Editar.Enabled = estado;
             CheckBox_Eliminar.Enabled = estado;
             CheckBox_Nuevo.Enabled = estado ;
             CheckBox_Ver.Enabled = estado;
         
    }

    private void LimpiarDatos()
    {
        CheckBox_Editar.Checked = false;
        CheckBox_Eliminar.Checked = false;
        CheckBox_Nuevo.Checked = false;
        CheckBox_Ver.Checked = false;
        ddlOpcionesDelsistema.SelectedIndex = 0;
    }

    private void EliminarOpcionDelRolDeUsuario(string IdCodigoOpcion)
    {
        try
        {
            RolesOpcionesLogic oRolesOpcionesLogic = new RolesOpcionesLogic();
            ReturnValor oReturnValor = new ReturnValor();
            oReturnValor = oRolesOpcionesLogic.Eliminar(IdCodigoOpcion, Request.QueryString["IdRoles"].ToString());
            if (oReturnValor.Exitosa)
            {
                MessageBox1.ShowSuccess(oReturnValor.Message);
                CargarGrillaOpcionesDelRo();
            }
            else
                MessageBox1.ShowInfo(oReturnValor.Message);
            
        }
        catch (Exception ex)
        {
            message = ex.Message;
            MessageBox1.ShowError(message);
        }
    }
   
    private void Seguridad()
    {
        if (Request["Vid"] != null)
        {
            BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
            EstadoDatos(false);
        }
        else
        {

            RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegAsignarOpcionesA_Roles.aspx");
            if (oRolesOpciones != null)
            {
                BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
                
                BotonesEdicionMantenimiento1.BotonEditar= false;
                BotonesEdicionMantenimiento1.BotonNuevoEnabled = oRolesOpciones.Flag_Nuevo;
                BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;

                BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
                gvOpcionesDelSistema.Columns[6].Visible = oRolesOpciones.Flag_Editar;
                gvOpcionesDelSistema.Columns[7].Visible = oRolesOpciones.Flag_Eliminar;

                lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
                //BotonesEdicionMantenimiento1.LoadComplete();
            }
            else
            {
                Response.Redirect("SegListaRoles.aspx");
            }


        }
    }
    
    #endregion
    
}
