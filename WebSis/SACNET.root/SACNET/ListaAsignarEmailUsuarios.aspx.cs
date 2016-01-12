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
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;

public partial class ListaAsignarEmailUsuarios : System.Web.UI.Page
{
    string message = string.Empty;
    static string CodUsuario = "";

    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        EstadoBoton(true);

        if (!Page.IsPostBack)
        {
            ConfigurarValidaciones();
            CargarCombos(); 
            CargarGrillaEmailDeUsuarios();
            pnRegistro.Visible = false;
            ButtonBuscar.Visible = true;
            pnListadoUsuarios.Visible = true;
            gvUsuariosCorreos.Visible = true;
            pnLeyenda.Visible = true;
            pnBusqueda.Visible = true;
            pnAuditoria.Visible = false;
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
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
        ButtonBuscar.Visible = false;
        pnListadoUsuarios.Visible = false;
        EstadoBoton(true);
        EstadoDatos(true);
        LimpiarDatos();
        pnBusqueda.Visible = false;
        Auditoria1.CargarSeguridadInicio();
        pnAuditoria.Visible = true;
    
    }

    private void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        pnRegistro.Visible = false;
        ButtonBuscar.Visible = true;
       
        pnListadoUsuarios.Visible = true;
        gvUsuariosCorreos.Visible = true;
        CargarGrillaEmailDeUsuarios();
        EstadoBoton(true);
        pnBusqueda.Visible = true;
        pnAuditoria.Visible = false;
    }

    private void BotonEdicionMantenimiento1_OnBotonRetornarClick(object sender, EventArgs e)
    {
        if (pnListadoUsuarios.Visible)
            Response.Redirect("default.aspx", false);
        else
            Response.Redirect("ListaAsignarEmailUsuarios.aspx", false);
    }

    private void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        if (TextBoxNombre.Text.Trim() == "")
        {
            message = "¡ Ingresar nombre del usuario !";
            MessageBox1.ShowInfo(message);
            TextBoxNombre.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            return;
        }
        if (TextBoxApellido.Text.Trim() == "")
        {
            message = "¡ Ingresar apellidos del usuario !";
            MessageBox1.ShowInfo(message);
            TextBoxApellido.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            return;
        }
        if (TextBoxEmail1.Text.Trim() == "" || !HelpMail.IsValidEmail(TextBoxEmail1.Text.Trim()))
        {
            message = "¡ Ingresar correo electrónico 1 del usuario, no es válido !";
            MessageBox1.ShowInfo(message);
            TextBoxEmail1.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            return;
        }

        if (TextBoxEmail2.Text.Trim() != "")
            if (!HelpMail.IsValidEmail(TextBoxEmail2.Text.Trim()))
            {
                message = "¡ Ingresar correo electrónico 2 del usuario, no es válido !";
                MessageBox1.ShowInfo(message);
                TextBoxEmail2.Focus();
                BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
                BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
                return;
            }

        if (DropDownListCargosUsuarios.SelectedIndex == 0)
        {
            message = "¡ Seleccionar tipo de cargo para el usuario !";
            MessageBox1.ShowInfo(message);
            DropDownListCargosUsuarios.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            return;
        }
        if (DropDownListMotivoDeEnvio.SelectedIndex == 0)
        {
            message = "¡ Seleccionar motivo de envio de correo electrónico !";
            MessageBox1.ShowInfo(message);
            DropDownListMotivoDeEnvio.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            return;
        }

        UsuariosMotivoCorreos item = new UsuariosMotivoCorreos()
        {
            sCodArguAccionMotivo = DropDownListMotivoDeEnvio.SelectedValue.ToString(),
            sCodArguCargo = DropDownListCargosUsuarios.SelectedValue.ToString(),
            sCorreoElectronico1 = TextBoxEmail1.Text,
            sCorreoElectronico2 = TextBoxEmail2.Text,
            sNombre = TextBoxNombre.Text,
            sApellidos = TextBoxApellido.Text,
            SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            bEstado = chkEstado.Checked,
            SSIHost = Context.Request.UserHostName
        };

        item.sCodUsuario = CodUsuario;
        UsuariosMotivoCorreosLogic oUsuariosMotivoCorreosLogic = new UsuariosMotivoCorreosLogic();
        try
        {
            ReturnValor oReturnValor = new ReturnValor();
            if (CodUsuario == "")
            {

                oReturnValor = oUsuariosMotivoCorreosLogic.Registrar(item);
                TextBoxNroRegistro.Text = oReturnValor.CodigoRetorno;
                EstadoBoton(false);
                EstadoDatos(false);
            }
            else
            {
                oReturnValor = oUsuariosMotivoCorreosLogic.Actualizar(item);
                EstadoDatos(false);
            }
            if (oReturnValor.Exitosa)
            {
                CodUsuario = "";
                MessageBox1.ShowSuccess(oReturnValor.Message);
                CargarGrillaEmailDeUsuarios();
                pnRegistro.Visible = false;
                ButtonBuscar.Visible = true;
                pnListadoUsuarios.Visible = true;
                EstadoBoton(true);
                pnAuditoria.Visible = false;
                pnBusqueda.Visible = true;
            }
            else
                MessageBox1.ShowWarning(oReturnValor.Message);
        }
        catch (Exception ex)
        {

            message = ex.Message;
            MessageBox1.ShowError(message);
        }
    }

    #endregion
    
    protected void gvUsuariosCorreos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[1].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  // || e.Row.Cells[0].Text.Trim() == "0"
            {
                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = false;

            }
        }
    }

    protected void gvUsuariosCorreos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                UsuariosMotivoCorreosLogic oUsuariosMotivoCorreosLogic = new UsuariosMotivoCorreosLogic();
                UsuariosMotivoCorreos item = oUsuariosMotivoCorreosLogic.Buscar(e.CommandArgument.ToString(), DropDownListprm_sCodArguAccionMotivo.ToString()); 
                CodUsuario = item.sCodUsuario;
                TextBoxNroRegistro.Text = item.sCodUsuario;
                TextBoxNombre.Text = item.sNombre;
                TextBoxApellido.Text = item.sApellidos;
                TextBoxEmail1.Text = item.sCorreoElectronico1;
                TextBoxEmail2.Text = item.sCorreoElectronico2;
                DropDownListCargosUsuarios.SelectedValue = item.sCodArguCargo;
                lblIdUsuario.Text = item.sCodUsuario;
                DropDownListMotivoDeEnvio.SelectedValue = item.sCodArguAccionMotivo;
                chkEstado.Checked = item.bEstado;
                Auditoria1.CargarSeguridad(item.SSIUsuario_Creacion, item.SSIUsuario_Modificacion, item.SSIFechaHora_Creacion, item.SSIFechaHora_Modificacion, item.SSIHost);
                pnRegistro.Visible = true;
                ButtonBuscar.Visible = false;
                pnListadoUsuarios.Visible = false;
                EstadoBoton(false);
                EstadoDatos(true);
                pnBusqueda.Visible = false;
                pnAuditoria.Visible = true;
                break;
            case "Eliminar":
                EliminarCorreoDeUsuario(e.CommandArgument.ToString());
                break;
        }
    }

    protected void gvUsuariosCorreos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuariosCorreos.PageIndex = e.NewPageIndex;
        CargarGrillaEmailDeUsuarios();
    }

    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        CargarGrillaEmailDeUsuarios();
    }

    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaAsignarEmailUsuarios.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaAsignarEmailUsuarios.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)  
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            
            DataRow[] drEliminar = dt.Select("Tipo=3");
            DataTable dtEliminar = drEliminar.Length>0? drEliminar.CopyToDataTable(): new DataTable();

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtEliminar.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtEliminar.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvUsuariosCorreos.Columns[7].Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
            }
            if (dtEditar.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtEditar.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvUsuariosCorreos.Columns[6].Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]); 
                BotonesEdicionMantenimiento1.BotonEditar = false;
                if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                else
                    BotonesEdicionMantenimiento1.BotonGrabar = false;
            }
            if (dtNuevo.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtNuevo.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                BotonesEdicionMantenimiento1.BotonNuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]); 
                if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                else
                    BotonesEdicionMantenimiento1.BotonGrabar = false;
            }
            BotonesEdicionMantenimiento1.LoadComplete();

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = oRolesOpciones.CodigoOpcionNombre;
            //gvUsuariosCorreos.Columns[6].Visible = oRolesOpciones.Flag_Editar;
            //gvUsuariosCorreos.Columns[7].Visible = oRolesOpciones.Flag_Eliminar;
            //BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionMantenimiento1.BotonEditar = false;
            //if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
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
  
    private void ConfigurarValidaciones()
    {
        TextBoxNombre.Attributes.Add("OnKeyPress", "return filterInput(0, event, false ,' ')");
        TextBoxApellido.Attributes.Add("OnKeyPress", "return filterInput(0, event, false ,' ')");
        TextBoxEmail1.Attributes.Add("onKeyPress", "return filterInput(2, event,false,' .@')");
        TextBoxEmail2.Attributes.Add("onKeyPress", "return filterInput(2, event,false,' .@')");
    }

    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRetornarClick);
    }

    private void EstadoBoton(bool estado)
    {
        BotonesEdicionMantenimiento1.BotonCancelarEnabled = !estado;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = false;
        BotonesEdicionMantenimiento1.BotonGrabarEnabled = !estado;
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = estado;
        BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
    }

    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref DropDownListCargosUsuarios, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeCargos), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        DropDownListCargosUsuarios.DataBind();
        HelpMaestros.CargarListadoGenerico(ref DropDownListMotivoDeEnvio, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.MotivoDeEnvioDeEmail), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        DropDownListMotivoDeEnvio.DataBind();

        HelpMaestros.CargarListadoGenerico(ref DropDownListprm_sCodArguCargo, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeCargos), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        DropDownListprm_sCodArguCargo.DataBind();
        HelpMaestros.CargarListadoGenerico(ref DropDownListprm_sCodArguAccionMotivo, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.MotivoDeEnvioDeEmail), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        DropDownListprm_sCodArguAccionMotivo.DataBind();
        ddlEstado.SelectedIndex = 0;

        
    }

    private void CargarGrillaEmailDeUsuarios()
    {
            UsuariosMotivoCorreosLogic oUsuariosMotivoCorreosLogic = new UsuariosMotivoCorreosLogic();
            bool? Estado;
            if (ddlEstado.SelectedIndex == 0)
            {
                Estado = null;
            }
            else
            {
                Estado = ddlEstado.SelectedItem.Value == "1" ? true : false;
            }
            List<UsuariosMotivoCorreos> item = oUsuariosMotivoCorreosLogic.Listar(TextBoxprm_sApellidos.Text, DropDownListprm_sCodArguCargo.SelectedValue.ToString(), DropDownListprm_sCodArguAccionMotivo.SelectedValue.ToString(), Estado);
            gvUsuariosCorreos.DataSource = item;
            gvUsuariosCorreos.DataBind();
            HelpGridView.Caption(ref gvUsuariosCorreos, "Listado de usuarios", item.Count.ToString());
    }

    private void EstadoDatos(bool estado)
    {
        TextBoxNombre.Enabled = estado;
        TextBoxEmail1.Enabled = estado;
        TextBoxEmail2.Enabled = estado;
        TextBoxApellido.Enabled = estado;
        DropDownListCargosUsuarios.Enabled = estado;
        pnLeyenda.Visible = !estado;
    }

    private void LimpiarDatos()
    {
        TextBoxNroRegistro.Text = string.Empty;
        TextBoxNombre.Text = string.Empty;
        TextBoxEmail1.Text = string.Empty;
        TextBoxEmail2.Text = string.Empty;
        TextBoxApellido.Text = string.Empty;
        DropDownListCargosUsuarios.SelectedIndex = 0;
        DropDownListMotivoDeEnvio.SelectedIndex = 0;
        chkEstado.Checked = true;
    }

    private void EliminarCorreoDeUsuario(string IdUsuario)
    {
        try
        {
            UsuariosMotivoCorreosLogic oUsuariosMotivoCorreosLogic = new  UsuariosMotivoCorreosLogic();
            ReturnValor oReturnValor = new ReturnValor();
            oReturnValor = oUsuariosMotivoCorreosLogic.Eliminar(IdUsuario, "525");
            if (oReturnValor.Exitosa)
                MessageBox1.ShowSuccess(oReturnValor.Message);
            else
                MessageBox1.ShowWarning(oReturnValor.Message);
            CargarGrillaEmailDeUsuarios();
        }
        catch (Exception ex)
        {
            message = ex.Message;
            MessageBox1.ShowError( message);
        }
    }

    #endregion

}
