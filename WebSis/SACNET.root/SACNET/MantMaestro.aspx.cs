using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Oxinet.Tools;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
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
        f_txtCodigoTabla.ReadOnly = false;
        f_ddlNivel.Enabled = true;
        f_txtCodigoTabla.CssClass = "cssTextBox";
        f_txtCodigoTabla.Text = "";
        f_txtLongitudNivel.Text = "2";
        f_txtNombre.Text = "";
        f_txtDescripcion.Text = "";
        f_ddlNivel.SelectedIndex = 0;
        f_txtVerValorCadena.Text = "";
        f_txtVerValorCadenaCorta.Text = "";
        f_txtVerValorCadenaLarga.Text = "";
        f_txtVerValorDecimal.Text = "";
        f_txtVerValorEntero.Text = "";
        f_txtVerValorLogico.Text = "";

        f_chkVerValorCadena.Text = "";
        f_chkVerValorCadenaCorta.Text = "";
        f_chkVerValorCadenaLarga.Text = "";
        f_chkVerValorDecimal.Text = "";
        f_chkVerValorEntero.Text = "";
        f_chkVerValorLogico.Text = "";
        
    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        hfEvento.Value = HelpEvento.Editar.ToString();
    }
    
    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            TMaestro item = GetTablaMaestra();

            if (hfEvento.Value == HelpEvento.Registrar.ToString())
            {
                ReturnValor oReturnValor= new ReturnValor() ;
                oReturnValor = oMaestroLogic.RegistrarMaestra(item);
                if (oReturnValor.Exitosa)
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    EstadoDatosVER();
                }
                else
                {
                    MessageBox1.ShowWarning(oReturnValor.Message);
                }

            }
            else if (hfEvento.Value == HelpEvento.Editar.ToString())
            {
                ReturnValor oReturnValor = new ReturnValor() ; 
                oReturnValor = oMaestroLogic.ActualizarMaestra(item);

                if (oReturnValor.Exitosa)
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    MessageBox1.ShowSuccess(oReturnValor.Message);
                    EstadoDatosVER();
                }
                else
                {
                    MessageBox1.ShowWarning(oReturnValor.Message);
                }
            }
        }
        else
        {
            MessageBox1.ShowWarning("Falta ingresar los sigientes campos: </br>" +mensaje);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("ListaMaestro.aspx");
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
        }
    }
   
    protected void f_chkVerValoresAdicionales_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox miControl = (CheckBox)sender;
        switch (miControl.ID)
        {
            case "f_chkVerValorCadena":
                if (f_chkVerValorCadena.Checked)
                {
                    f_txtVerValorCadena.Visible = true;
                    f_txtVerValorCadena.Focus();
                }
                else
                {
                    f_txtVerValorCadena.Text = string.Empty;
                    f_txtVerValorCadena.Visible = false;
                }
                break;
            case "f_chkVerValorCadenaCorta":
                if (f_chkVerValorCadenaCorta.Checked)
                {
                    f_txtVerValorCadenaCorta.Visible = true;
                    f_txtVerValorCadenaCorta.Focus();
                }
                else
                {
                    f_txtVerValorCadenaCorta.Text = string.Empty;
                    f_txtVerValorCadenaCorta.Visible = false;
                }
                break;
            case "f_chkVerValorCadenaLarga":
                if (f_chkVerValorCadenaLarga.Checked)
                {
                    f_txtVerValorCadenaLarga.Visible = true;
                    f_txtVerValorCadenaLarga.Focus();
                }
                else
                {
                    f_txtVerValorCadenaLarga.Text = string.Empty;
                    f_txtVerValorCadenaLarga.Visible = false;
                }
                break;
            case "f_chkVerValorDecimal":
                if (f_chkVerValorDecimal.Checked)
                {
                    f_txtVerValorDecimal.Visible = true;
                    f_txtVerValorDecimal.Focus();
                }
                else
                {
                    f_txtVerValorDecimal.Text = string.Empty;
                    f_txtVerValorDecimal.Visible = false;
                }
                break;
            case "f_chkVerValorEntero":
                if (f_chkVerValorEntero.Checked)
                {
                    f_txtVerValorEntero.Visible = true;
                    f_txtVerValorEntero.Focus();
                }
                else
                {
                    f_txtVerValorEntero.Text = string.Empty;
                    f_txtVerValorEntero.Visible = false;
                }
                break;
            case "f_chkVerValorLogico":
                if (f_chkVerValorLogico.Checked)
                {
                    f_txtVerValorLogico.Visible = true;
                    f_txtVerValorLogico.Focus();
                }
                else
                {
                    f_txtVerValorLogico.Text = string.Empty;
                    f_txtVerValorLogico.Visible = false;
                }
                break;
        }
    }
    
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void CargarPagina()
    {
        String querystringDESENCRYP = string.Empty;
        if (Request.QueryString.Get("pm") != null)
            querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
        HF_CodTabla.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
        HF_Nivel.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "nv");
        HF_Ver.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "ver");
        if (HF_CodTabla.Value == string.Empty && HF_Nivel.Value == string.Empty)
        {
            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
            hfEvento.Value = HelpEvento.Registrar.ToString();
            lblTituloPagina.Text = HelpEvento.Registrar.ToString() + " - " + this.Master.HelpOpcion_Permiso("ListaMaestro.aspx").CodigoOpcionNombre;

            f_txtCodigoTabla.ReadOnly = false;
            f_ddlNivel.Enabled = true;
        }
        else
        {
            f_txtCodigoTabla.ReadOnly = true;
            f_ddlNivel.Enabled = false;

            MaestroLogic oMaestroLogic = new MaestroLogic();
            SetTablaMaestra(oMaestroLogic.BuscarTablaDescripcion(HF_CodTabla.Value, Convert.ToInt32(HF_Nivel.Value)));
            if (HF_Ver.Value == string.Empty)
            {
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
                hfEvento.Value = HelpEvento.Editar.ToString();
                lblTituloPagina.Text = HelpEvento.Editar.ToString().ToUpper() + " - Registro " + this.Master.HelpOpcion_Permiso("ListaMaestro.aspx").CodigoOpcionNombre;
                f_txtCodigoTabla.CssClass = "cssTextBoxReadOnly";
            }
            else
            {
                lblTituloPagina.Text = "Ver - Registro " +  this.Master.HelpOpcion_Permiso("ListaMaestro.aspx").CodigoOpcionNombre;
                EstadoDatosVER();
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
                BotonesEdicionMantenimiento1.LoadComplete();
            }
        }
        Page.Title = lblTituloPagina.Text;
    }

    private void EstadoDatosVER()
    {
        f_ddlNivel.Enabled = false;
        f_txtCodigoTabla.ReadOnly = true;
        f_txtCodigoTabla.CssClass = "cssTextBoxReadOnly";
        f_txtLongitudNivel.ReadOnly = true;
        f_txtLongitudNivel.CssClass = "cssTextBoxReadOnly";
        f_txtNombre.ReadOnly = true;
        f_txtNombre.CssClass = "cssTextBoxReadOnly";
        f_txtDescripcion.ReadOnly = true;
        f_txtDescripcion.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorCadena.ReadOnly = true;
        f_txtVerValorCadena.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorCadenaCorta.ReadOnly = true;
        f_txtVerValorCadenaCorta.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorCadenaLarga.ReadOnly = true;
        f_txtVerValorCadenaLarga.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorDecimal.ReadOnly = true;
        f_txtVerValorDecimal.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorEntero.ReadOnly = true;
        f_txtVerValorEntero.CssClass = "cssTextBoxReadOnly";
        f_txtVerValorLogico.ReadOnly = true;
        f_txtVerValorLogico.CssClass = "cssTextBoxReadOnly";
        f_chkVerValorCadena.Enabled = false;
        f_chkVerValorCadenaCorta.Enabled = false;
        f_chkVerValorCadenaLarga.Enabled = false;
        f_chkVerValorDecimal.Enabled = false;
        f_chkVerValorEntero.Enabled = false;
        f_chkVerValorLogico.Enabled = false;
        f_chkActivo.Enabled = false;
    }

    private TMaestro GetTablaMaestra()
    {
        TMaestro item = new TMaestro();
        item.CodTabla=f_txtCodigoTabla.Text ;
        item.LongNivel=Convert.ToInt32(f_txtLongitudNivel.Text);
        item.Nivel = Convert.ToInt32(f_ddlNivel.SelectedValue);
        item.Nombre = f_txtNombre.Text;
        item.Descripcion = f_txtDescripcion.Text;
        item.NombreValorCadena = f_txtVerValorCadena.Text;
        item.NombreValorCadenaCorta = f_txtVerValorCadenaCorta.Text;
        item.NombreValorCadenaLarga = f_txtVerValorCadenaLarga.Text;
        item.NombreValorDecimal = f_txtVerValorDecimal.Text;
        item.NombreValorEntero = f_txtVerValorEntero.Text;
        item.NombreValorBoolean = f_txtVerValorLogico.Text;

        item.VerValorCadena = f_chkVerValorCadena.Checked;
        item.VerValorCadenaCorta = f_chkVerValorCadenaCorta.Checked;
        item.VerValorCadenaLarga = f_chkVerValorCadenaLarga.Checked;
        item.VerValorDecimal= f_chkVerValorDecimal.Checked;
        item.VerValorEntero = f_chkVerValorEntero.Checked;
        item.VerValorBoolean = f_chkVerValorLogico.Checked;
        item.SegUsuarioCreacion = this.Master.HelpUsuario().LoginUsuario;
        item.SegUsuarioModificacion = this.Master.HelpUsuario().LoginUsuario;
        item.Activo = f_chkActivo.Checked;
        return item;
    }

    private void SetTablaMaestra(TMaestro item)
    {
        f_txtCodigoTabla.Text = item.CodTabla;
        f_txtLongitudNivel.Text = item.LongNivel.ToString();
        f_ddlNivel.SelectedValue = item.Nivel.ToString() ;
        f_txtNombre.Text=item.Nombre;
        f_txtDescripcion.Text=item.Descripcion ;
        f_txtVerValorCadena.Text=item.NombreValorCadena  ;
        f_txtVerValorCadenaCorta.Text=item.NombreValorCadenaCorta ;
        f_txtVerValorCadenaLarga.Text=item.NombreValorCadenaLarga ;
        f_txtVerValorDecimal.Text=item.NombreValorDecimal ;
        f_txtVerValorEntero.Text=item.NombreValorEntero ;
        f_txtVerValorLogico.Text = item.NombreValorBoolean;

        f_chkVerValorCadena.Checked = item.VerValorCadena;
        f_chkVerValorCadenaCorta.Checked = item.VerValorCadenaCorta;
        f_chkVerValorCadenaLarga.Checked = item.VerValorCadenaLarga;
        f_chkVerValorDecimal.Checked = item.VerValorDecimal;
        f_chkVerValorEntero.Checked = item.VerValorEntero;
        f_chkVerValorLogico.Checked = item.VerValorBoolean;

        f_txtVerValorCadena.Visible = item.VerValorCadena;
        f_txtVerValorCadenaCorta.Visible = item.VerValorCadenaCorta;
        f_txtVerValorCadenaLarga.Visible = item.VerValorCadenaLarga;
        f_txtVerValorDecimal.Visible = item.VerValorDecimal;
        f_txtVerValorEntero.Visible = item.VerValorEntero;
        f_txtVerValorLogico.Visible = item.VerValorBoolean;
        f_chkActivo.Checked = item.Activo;
    }

    private string Validar()
    {
        string mensage = "";
        if (f_txtCodigoTabla.Text == "") mensage = mensage + ", Código de tabla";
        if (f_ddlNivel.SelectedIndex == -1) mensage = mensage + ", Nivel de la tabla";
        if (f_txtLongitudNivel.Text == "0") mensage = mensage + ", Longitud por nivel debe ser mayor que cero";
        if (f_txtNombre.Text == "") mensage = mensage + ", Nombre de la tabla";
        if (f_txtDescripcion.Text == "") mensage = mensage + ", Descripción de la tabla";
        if (mensage.Length > 0)
            mensage = mensage.Substring(2);
        return mensage;
    }

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaMaestro.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
            BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                BotonesEdicionMantenimiento1.BotonGrabar = true;
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = false;
                EstadoDatosVER();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    #endregion


    
}
