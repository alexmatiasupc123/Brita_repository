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

public partial class ListaFeriados : System.Web.UI.Page
{
    string message = string.Empty;
    static string CodFeriado = "";

    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        EstadoBoton(true);

        if (!Page.IsPostBack)
        {
            TextBoxprm_prm_sAnio.Text = DateTime.Now.Year.ToString();
            ConfigurarValidaciones();
            CargarGrilla();
        }
        pnRegistro.Visible = false;
        pnBusqueda.Visible = true;
        ButtonBuscar.Visible = true;
        pnAuditoria.Visible = false;
        pnListadoUsuarios.Visible = true;
        gvFeriados.Visible = true;
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
       
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
        pnAuditoria.Visible = true;
        pnListadoUsuarios.Visible = false;
        EstadoBoton(true);
        EstadoDatos(true);
        LimpiarDatos();
        Auditoria1.CargarSeguridadInicio();
        HiddenFieldProceso.Value = "N";
        TextBoxNroRegistro.Visible = false;
        TextBoxNroRegistroFecha.Visible = true;
        //btiFecha1erUso.Visible = true;
        TextBoxNroRegistroFecha.Text = string.Empty;
        pnBusqueda.Visible = false;
    }

    private void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {

    }

    private void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        pnRegistro.Visible = false;
        ButtonBuscar.Visible = true;
        pnAuditoria.Visible = false;
        pnListadoUsuarios.Visible = true;
        gvFeriados.Visible = true;
        CargarGrilla();
        EstadoBoton(true);
        pnLeyenda.Visible = true;
        pnBusqueda.Visible = true;
    }

    private void BotonEdicionMantenimiento1_OnBotonRetornarClick(object sender, EventArgs e)
    {
        if (HiddenFieldProceso.Value == "N" || HiddenFieldProceso.Value == "E")
        {
            pnRegistro.Visible = false;
            ButtonBuscar.Visible = true;
            pnAuditoria.Visible = false;
            pnListadoUsuarios.Visible = true;
            gvFeriados.Visible = true;
            CargarGrilla();
            EstadoBoton(true);
            pnLeyenda.Visible = true;
            pnBusqueda.Visible = true;
        }
        else
            Response.Redirect("Default.aspx");
    }

    private void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string date1 = HelpDates.EsFechaValida(TextBoxNroRegistroFecha.Text);
        if (date1.Length > 0)
        {
            MessageBox1.ShowInfo(date1);
            TextBoxNroRegistro.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            pnRegistro.Visible = true;
            ButtonBuscar.Visible = false;
            pnListadoUsuarios.Visible = false;
            return;
        }
        DateTime fechaSELEC = DateTime.Now;

        if (HiddenFieldProceso.Value == "N")
        {
            fechaSELEC = Convert.ToDateTime(TextBoxNroRegistroFecha.Text);
            TextBoxNroRegistro.Text = fechaSELEC.Month.ToString().PadLeft(2, '0') + fechaSELEC.Day.ToString().PadLeft(2, '0');
        }
        else
        {
            fechaSELEC = Convert.ToDateTime(TextBoxNroRegistroFecha.Text);
            if (TextBoxNroRegistro.Text.Trim() == "")
            {
                message = "¡ Ingresar fecha del feriado !";
                MessageBox1.Show(MessageType.Info, message, 125, 300);
                TextBoxNroRegistro.Focus();
                BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
                BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
                pnRegistro.Visible = true;
                ButtonBuscar.Visible = false;
                pnListadoUsuarios.Visible = false;
                return;
            }
        }
        if (TextBoxDescripcion.Text.Trim() == "")
        {
            message = "¡ Ingresar descripción del feriado !";
            MessageBox1.Show(MessageType.Info, message, 125, 300);
            TextBoxDescripcion.Focus();
            BotonesEdicionMantenimiento1.BotonGrabarEnabled = true;
            BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
            pnRegistro.Visible = true;
            ButtonBuscar.Visible = false;
            pnListadoUsuarios.Visible = false;
            return;
        }

        TFeriados item = new TFeriados()
        {
            sFeriado = TextBoxNroRegistro.Text,
            sDescripcion = TextBoxDescripcion.Text,
            bFijo = CheckBoxbEsFijo.Checked,
            bEstado = CheckBoxbEstado.Checked,
            SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName
        };
        item.sCodRegistro = lblIdUsuario.Text;
        if (!CheckBoxbEsFijo.Checked)
            item.sFeriado = fechaSELEC.Year.ToString() + fechaSELEC.Month.ToString().Trim().PadLeft(2, '0') + fechaSELEC.Day.ToString().Trim().PadLeft(2, '0');
        else
            item.sFeriado = "0000" + fechaSELEC.Month.ToString().Trim().PadLeft(2, '0') + fechaSELEC.Day.ToString().Trim().PadLeft(2, '0');

        TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
        try
        {
            ReturnValor oReturnValor = new ReturnValor();
            if (CodFeriado == "")
            {

                oReturnValor = oTFeriadosLogic.Registrar(item);
                if (oReturnValor.Exitosa)
                {
                    message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    TextBoxNroRegistro.Text = oReturnValor.CodigoRetorno;
                    EstadoBoton(false);
                    EstadoDatos(false);
                }
                else
                    message = oReturnValor.Message;
            }
            else
            {
                oReturnValor = oTFeriadosLogic.Actualizar(item);
                if (oReturnValor.Exitosa)
                {
                    message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    EstadoDatos(false);
                }
                else
                    message = oReturnValor.Message;
            }
            if (oReturnValor.Exitosa)
            {
                CargarGrilla();
                CodFeriado = "";
                pnRegistro.Visible = false;
                ButtonBuscar.Visible = true;
                pnListadoUsuarios.Visible = true;
             
                EstadoBoton(true);
            }
            if (oReturnValor.Exitosa)
                MessageBox1.Show(MessageType.Success, message, 125, 300);
            else
            {
                MessageBox1.Show(MessageType.Warning, message, 125, 300);
                pnRegistro.Visible = true;
                ButtonBuscar.Visible = false;
                pnAuditoria.Visible = true;
                pnListadoUsuarios.Visible = false;
                EstadoBoton(false);
                BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
            }
        }
        catch (Exception ex)
        {

            message = ex.Message;
            MessageBox1.Show(MessageType.Error, message, 125, 300);
        }
    }

    #endregion
    
    protected void gvFeriados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[1].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  
            {
                ((ImageButton)e.Row.Cells[6].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[7].FindControl("btnEliminar")).Enabled = false;
            }
        }
    }

    protected void gvFeriados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
                TFeriados item = oTFeriadosLogic.Buscar(e.CommandArgument.ToString()); 

                if (!item.bFijo)
                    TextBoxNroRegistroFecha.Text = item.dFechaIndicada.Value.ToShortDateString();
                else
                    TextBoxNroRegistroFecha.Text =item.sFeriado.Substring(6, 2) + "/" +
                                                  item.sFeriado.Substring(4, 2) + "/" +
                                                  DateTime.Now.Year.ToString();

                lblIdUsuario.Text = item.sCodRegistro;
                CodFeriado = item.sFeriado;
                TextBoxNroRegistro.Text = item.sFeriado;
                TextBoxDescripcion.Text = item.sDescripcion;
                
                CheckBoxbEstado.Checked = item.bEstado;
                CheckBoxbEsFijo.Checked = item.bFijo;
                Auditoria1.CargarSeguridad(item.SSIUsuario_Creacion, item.SSIUsuario_Modificacion, item.SSIFechaHora_Creacion, item.SSIFechaHora_Modificacion, item.SSIHost);

                pnRegistro.Visible = true;
                ButtonBuscar.Visible = false;
                pnListadoUsuarios.Visible = false;
                pnAuditoria.Visible = true;
                EstadoBoton(false);
                EstadoDatos(true);
                BotonesEdicionMantenimiento1.BotonRegresarEnabled = true;
                HiddenFieldProceso.Value = "E";
                TextBoxNroRegistro.Visible = false;
                TextBoxNroRegistroFecha.Visible = true;
                pnBusqueda.Visible = false;
                break;
            case "Eliminar":
                Eliminar(e.CommandArgument.ToString());
                break;
        }
    }

    protected void gvFeriados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFeriados.PageIndex = e.NewPageIndex;
        CargarGrilla();
    }
    
    protected void ButtonBuscar_Click(object sender, EventArgs e)
    {
        CargarGrilla();
    }
    
    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaFeriados.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaFeriados.aspx");//ELVP:11-10-2011
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
                gvFeriados.Columns[7].Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
            }
            if (dtEditar.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtEditar.Rows[0]["CodigoOpcionNombre"].ToString();
                Page.Title = lblTituloPagina.Text;
                gvFeriados.Columns[6].Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]); 
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

            //gvFeriados.Columns[6].Visible = oRolesOpciones.Flag_Editar;
            //gvFeriados.Columns[7].Visible = oRolesOpciones.Flag_Eliminar;
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
        TextBoxDescripcion.Attributes.Add("OnKeyPress", "return filterInput(0, event, false ,' ')");
        TextBoxNroRegistro.Attributes.Add("OnKeyPress", "return filterInput(1, event, false ,' ')");
        TextBoxprm_prm_sAnio.Attributes.Add("OnKeyPress", "return filterInput(1, event, false ,' ')");
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
        BotonesEdicionMantenimiento1.BotonCancelarEnabled = !estado;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = false;
        BotonesEdicionMantenimiento1.BotonGrabarEnabled = !estado;
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = estado;
        BotonesEdicionMantenimiento1.BotonRegresarEnabled = estado;
    }

    private void CargarGrilla()
    {
        bool? bFIJOS = false;        
        if (CheckBoxprm_TipoFeriado.Checked)
            bFIJOS = true;
        bool? bESTADOS;
        if (ddlEstado.SelectedIndex == 0)
        {
            bESTADOS = null;
        }
        else
        {
            bESTADOS = ddlEstado.SelectedItem.Value == "1" ? true : false;
        }
        TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
        List<TFeriados> lista = oTFeriadosLogic.Listar(TextBoxprm_prm_sAnio.Text, TextBoxprm_sDescripcion.Text, bFIJOS, bESTADOS);
        gvFeriados.DataSource = lista;
        gvFeriados.DataBind();
        HelpGridView.Caption(ref gvFeriados, "Lista de feriados", lista.Count.ToString());
    }

    private void EstadoDatos(bool estado)
    {
        if (CodFeriado == string.Empty)
            TextBoxNroRegistro.ReadOnly = false;
        else
            TextBoxNroRegistro.ReadOnly = true;
        TextBoxNroRegistro.Enabled = estado;
        TextBoxDescripcion.Enabled = estado;
        CheckBoxbEsFijo.Enabled = estado;
        CheckBoxbEstado.Enabled = estado;
        pnLeyenda.Visible = !estado;
    }

    private void LimpiarDatos()
    {
        TextBoxDescripcion.Text = string.Empty;
        TextBoxNroRegistro.Text = string.Empty;
        CheckBoxbEstado.Checked = true;
        CheckBoxbEsFijo.Checked = true;
    }

    private void Eliminar(string sCodigoFeriado)
    {
        try
        {
            TFeriadosLogic oTFeriadosLogic = new TFeriadosLogic();
            ReturnValor oReturnValor = new ReturnValor();
            oReturnValor = oTFeriadosLogic.Eliminar(sCodigoFeriado);
            if (oReturnValor.Exitosa)
            {
                MessageBox1.Show(MessageType.Success, HelpMessage.Message(HelpMessage.TMessage.Eliminar), 125, 300);
                CargarGrilla();
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            MessageBox1.Show(MessageType.Error, message, 125, 300);
        }
    }

    public string PintarEstado(string pCodigoTabla, bool pEstado, string TIPO)
    {
        string estado = string.Empty;

        if (pCodigoTabla.Length != 0)
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
    
    #endregion
}
