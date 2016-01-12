using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;


public partial class Mantenimientos_SegAsignarRoles_AUsuarios : System.Web.UI.Page
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
            
            if (Request.QueryString["IdUsuario"] != null)
            {
                PintarDatosDeParametros(Request.QueryString["IdUsuario"].ToString());
            }            
            CargarGrillaOpcionesDelRol();
            pnRegistro.Visible = false;
            pnListadoUsuarios.Visible = true;
            gvUsuariosRoles.Visible = true;
        }
        Seguridad(); 
        Page.Title = lblTituloPagina.Text;
    }

    #endregion

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
        ddlRolesDeUsuario.Enabled = true;
        CodOpcion = "Nuevo";
    }

    private void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {

    }

    private void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        pnRegistro.Visible = false;
      
      
        pnListadoUsuarios.Visible = true;
        gvUsuariosRoles.Visible = true;
        CargarGrillaOpcionesDelRol();
        EstadoBoton(true);
    }

    private void BotonEdicionMantenimiento1_OnBotonRetornarClick(object sender, EventArgs e)
    {
        string script = String.Format("CerrarCancel()", "");
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerrarCancelScript"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarCancelScript", script, true);
        }
    }

    private void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        if (ddlRolesDeUsuario.SelectedIndex <= 0)
        {
            MessageBox1.ShowInfo("Seleccionar opción del sistema.");
            ddlRolesDeUsuario.Focus();
            EstadoBoton(false);
            return;
        }
        try
        {            
            UsuariosRoles oUsuariosRoles = new UsuariosRoles();
            getUsuariosRoles(oUsuariosRoles);

            UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();
            ReturnValor oReturnValor = new ReturnValor();
            if (CodOpcion == "Nuevo")
            {                
                    oReturnValor = oUsuariosRolesLogic.Registrar(oUsuariosRoles);
                    if (oReturnValor.Exitosa)
                    {
                        MessageBox1.ShowSuccess(oReturnValor.Message);
                        BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                        EstadoBoton(false);
                        EstadoDatos(false);
                    }
                    else
                        MessageBox1.ShowInfo(oReturnValor.Message);
               
                
            }
            else
            {
                
                    oReturnValor = oUsuariosRolesLogic.Actualizar(oUsuariosRoles);
                    if (oReturnValor.Exitosa)
                    {
                        MessageBox1.ShowSuccess(oReturnValor.Message);
                        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                        EstadoBoton(false);
                        EstadoDatos(false);
                    }
                    else
                        MessageBox1.ShowInfo(oReturnValor.Message);
                
            }
            CargarGrillaOpcionesDelRol();
            CodOpcion = "";
            pnRegistro.Visible = false;
            pnListadoUsuarios.Visible = true;
            EstadoBoton(true);
            
        }
        catch (Exception ex)
        {
            message = ex.Message;
            MessageBox1.ShowError(message);
        }
    }

    private void getUsuariosRoles(UsuariosRoles poUsuariosRoles)
    {
        poUsuariosRoles.CodigoRol = ddlRolesDeUsuario.SelectedValue.ToString();
        poUsuariosRoles.CodigoUsuario = Request.QueryString["IdUsuario"].ToString();
        poUsuariosRoles.Estado = rblEstado.Items[0].Selected ? true:false;
        poUsuariosRoles.SegUsuarioRegistro = Master.HelpUsuario().LoginUsuario;
        poUsuariosRoles.SegUsuarioModifica = Master.HelpUsuario().LoginUsuario;
    }

    private void setUsuariosRoles(UsuariosRoles pUsuariosRoles)
    {
        ddlRolesDeUsuario.SelectedValue= pUsuariosRoles.CodigoRol ;
        ddlRolesDeUsuario.Enabled = false;
        if (pUsuariosRoles.Estado)
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

    private void ValidarDatos()
    {
        if (ddlRolesDeUsuario.SelectedIndex <= 0)
        {
            ddlRolesDeUsuario.Focus();
            throw new Exception("¡ Seleccionar opción del sistema !");
        }
    }

    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/

    public string PintarEstado(string pCodigoUsuarioRol, bool pEstado)
    {
        string estado = string.Empty;
        if (pCodigoUsuarioRol.Length != 0)
        {
            if (pEstado)
                estado = "ACTIVO";
            else
                estado = "INACTIVO";
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
         RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegAsignarRoles_AUsuarios.aspx");
         if (oRolesOpciones != null)
         {
             BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
             BotonesEdicionMantenimiento1.BotonEditar = false;
             BotonesEdicionMantenimiento1.BotonGrabarEnabled = !estado;
             BotonesEdicionMantenimiento1.BotonNuevoEnabled = oRolesOpciones.Flag_Nuevo?estado:false;
             BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
         }
         
        
    }

    private void PintarDatosDeParametros(string pCodigoUsuario)
    {
        UsuariosLogic oUsuariosLogic = new UsuariosLogic();
        Usuarios itemUsuarios = new Usuarios();
        itemUsuarios = oUsuariosLogic.Buscar(pCodigoUsuario);
        txtCodigoRol.Text = Request.QueryString["IdUsuario"].ToString();
        txtNombreRol.Text = itemUsuarios.ApellidosyNombres;

        RolesLogic oRolesLogic = new RolesLogic();
        List<Roles> mListaRoles = new List<Roles>();
        mListaRoles = oRolesLogic.Listar(string.Empty, string.Empty);
        var query = from item in mListaRoles
                    where item.Estado == "A"
                    select item;
        ddlRolesDeUsuario.DataSource = query.ToList();
        ddlRolesDeUsuario.DataTextField = "NombreRol";
        ddlRolesDeUsuario.DataValueField = "CodigoRol";
        ddlRolesDeUsuario.DataBind();
        HelpComboBox.AddItemText(ref ddlRolesDeUsuario,HelpComboBox.Texto.Select);
    }

    private void CargarGrillaOpcionesDelRol()
    {
        if (Request.QueryString["IdUsuario"] != null)
        {
            UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();
            List<UsuariosRoles> lstUsuariosRoles = new List<UsuariosRoles>();
            string Filtro = string.Empty;
            if (!chkSeekTodos.Checked)
                Filtro = Request.QueryString["IdUsuario"].ToString();
            lstUsuariosRoles = oUsuariosRolesLogic.Listar(Filtro);
            gvUsuariosRoles.DataSource = lstUsuariosRoles;
            gvUsuariosRoles.DataBind();
        }
    }

    private void EstadoDatos(bool estado)
    {
        ddlRolesDeUsuario.Enabled = estado;
        rblEstado.Enabled = estado;
    }
 
    private void LimpiarDatos()
    {
        ddlRolesDeUsuario.SelectedIndex = 0;
        rblEstado.Items[0].Selected = true;
    }

    private void EliminarOpcionDelRolDeUsuario(string IdCodigoRolUsuario)
    {
        try
        {
            UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();
            ReturnValor oReturnValor = new ReturnValor();
            oReturnValor = oUsuariosRolesLogic.Eliminar(Request.QueryString["IdUsuario"].ToString(), IdCodigoRolUsuario);
            if (oReturnValor.Exitosa)
            {
                CargarGrillaOpcionesDelRol();
                MessageBox1.ShowSuccess(oReturnValor.Message);
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

    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    /**************************************************************************/

    protected void gvUsuariosRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[0].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  // || e.Row.Cells[0].Text.Trim() == "0"
            {
                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Enabled = true;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = true;
            }
            else
            {
                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = false;
            }
            string IdUsuario = gvUsuariosRoles.DataKeys[e.Row.RowIndex]["CodigoUsuario"].ToString();
            if (Request["IdUsuario"].ToString() != IdUsuario)
            {
                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Visible = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Visible = false;
            }
        }
    }

    protected void gvUsuariosRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();
                UsuariosRoles itemUsuariosRoles = new UsuariosRoles();
                itemUsuariosRoles = oUsuariosRolesLogic.Buscar(Request.QueryString["IdUsuario"].ToString(), e.CommandArgument.ToString());
                setUsuariosRoles(itemUsuariosRoles);
                CodOpcion = "Editar";
                pnRegistro.Visible = true;
                pnListadoUsuarios.Visible = false;
              
                
                EstadoBoton(false);
                EstadoDatos(true);
                ddlRolesDeUsuario.Enabled = false;
                break;
            case "Eliminar":
                EliminarOpcionDelRolDeUsuario(e.CommandArgument.ToString());
                break;
        }
    }

    protected void gvUsuariosRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuariosRoles.PageIndex = e.NewPageIndex;
        CargarGrillaOpcionesDelRol();

    }

    protected void chkSeekTodos_CheckedChanged(object sender, EventArgs e)
    {
        CargarGrillaOpcionesDelRol();
    }

    #endregion

    private void Seguridad()
    {
        if (Request["Vid"] != null)
        {
            BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = false;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
            EstadoDatos(false);
        }
        else
        {

            RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegAsignarRoles_AUsuarios.aspx");
            if (oRolesOpciones != null)
            {
                
                BotonesEdicionMantenimiento1.BotonCancelarEnabled = false;
                BotonesEdicionMantenimiento1.BotonNuevoEnabled = oRolesOpciones.Flag_Nuevo;
                BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;

                
                gvUsuariosRoles.Columns[6].Visible = oRolesOpciones.Flag_Editar;
                gvUsuariosRoles.Columns[7].Visible = oRolesOpciones.Flag_Eliminar;
                lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            
        }
    }
}
