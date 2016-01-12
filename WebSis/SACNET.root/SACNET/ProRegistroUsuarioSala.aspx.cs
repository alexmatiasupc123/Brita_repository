using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;
using Oxinet.Maestros.BusinessLogic;

public partial class ProRegistroUsuarioSala : System.Web.UI.Page
{

    #region "/--- Eventos de la Pagina ---/"

    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();

        if (!IsPostBack)
        {
            CargarPagina();
        }
        else
        {
            String parameter;

            if (HiddenField1.Value != null && HiddenField1.Value != "")
            {
                parameter = (String)HiddenField1.Value;
            }
        }

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    
    #region "/--- Eventos de la Barra de Botones  ---/"
    
    private void InicializarEventos()
    {
        BotonesEdicionMantenimiento1.BotonNuevo = false;
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            GuardarRegistroUsuarioSala();
        }
    }

    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        HF_Evento.Value = HelpEvento.Editar.ToString();
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "" || HF_Evento.Value == "Editar")
        {
            if(HF_Evento.Value == HelpEvento.Registrar.ToString())//Registrar
                MessageBox1.ShowConfirm("¿ Confirma guardar el registro de usuario en sala ?", HelpEvento.Guardar.ToString());
            else if(HF_Evento.Value == "Editar")//Editar
                MessageBox1.ShowConfirm("¿ Confirma guardar la salida de usuario ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    private void GuardarRegistroUsuarioSala()
    {
        UsuarioSalaLogic oUsuarioSalaLogic = new UsuarioSalaLogic();
        UsuarioSala item = new UsuarioSala();

        if (HF_Evento.Value == HelpEvento.Registrar.ToString())//Registrar
        {
            item = GetTablaUsuarioSala();
            ReturnValor oReturnValor = new ReturnValor();

            oReturnValor = oUsuarioSalaLogic.RegistrarUsuarioSala(item);
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
        else if (HF_Evento.Value == HelpEvento.Editar.ToString())//Editar
        {
            string resultValidar = fValidaFechaSalida();
            if (resultValidar != "0")
            {
                MessageBox1.ShowInfo(resultValidar);
                return;
            }

            item = GetTablaUsuarioSalaSalida();
            ReturnValor oReturnValor = new ReturnValor();

            oReturnValor = oUsuarioSalaLogic.RegistrarUsuarioSala_Salida(item);

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

    private string fValidaFechaSalida()
    {
        string sreturn = "0";

        if (Convert.ToDateTime(f_TextBoxFechaFin.Text) < Convert.ToDateTime(f_TextBoxFechaInicio.Text) ||
            Convert.ToDateTime(f_TextBoxFechaFin.Text) != Convert.ToDateTime(f_TextBoxFechaInicio.Text))
        {
            sreturn = "¡ Fecha de salida debe ser igual a fecha de inicio de uso de sala !";
            return sreturn;
        }
        if (Convert.ToDateTime(f_TextBoxFechaFin.Text).Date == Convert.ToDateTime(f_TextBoxFechaInicio.Text).Date &&
            Convert.ToInt16(f_DropDownListHoraFin.Text) < Convert.ToInt16(f_DropDownListHoraInicio.Text))
        {
            sreturn = "¡ Hora de salida debe ser mayor que hora de ingreso a sala !";
            return sreturn;
        }
        if (Convert.ToDateTime(f_TextBoxFechaFin.Text).Date == Convert.ToDateTime(f_TextBoxFechaInicio.Text).Date &&
            Convert.ToInt16(f_DropDownListHoraFin.Text) == Convert.ToInt16(f_DropDownListHoraInicio.Text) &&
            Convert.ToInt16(f_txtMinutoFin.Text) < Convert.ToInt16(f_txtMinutoInicio.Text))
        {
            sreturn = "¡ Minuto de salida debe ser mayor que minuto de ingreso a sala !";
            return sreturn;
        }

        return sreturn;
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("ListaRegistroUsuarioSala.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
    }
  
    #endregion

    protected void ButtonBuscarUsuarioSAC_Click(object sender, EventArgs e)
    {
        BuscarPersonaParaRegistro();
    }

    private void BuscarPersonaParaRegistro()
    {
        if (f_txtCodigoUsuarioSAC.Text.Trim() != string.Empty)
        {
            vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
            vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
            itemvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(f_txtCodigoUsuarioSAC.Text);
            if (itemvwUsuariosSAC.CodUsuarioSAC != null)
            {
                if (itemvwUsuariosSAC.CodLocalSACNombre != null)
                {
                    f_txtNombres.Text = itemvwUsuariosSAC.Nombres;
                    f_txtApellidos.Text = itemvwUsuariosSAC.Apellidos;
                    f_txtSAC.Text = itemvwUsuariosSAC.CodLocalSACNombre;
                    f_txtSACID.Text = itemvwUsuariosSAC.CodLocalSAC;
                    f_labelsCodLocalSACRegistro.Text = this.Master.HelpUsuariosSAC().CodLocalSACNombre;

                    if (itemvwUsuariosSAC.EsAlumno == "A")//Es alumno
                    {
                        if (!itemvwUsuariosSAC.EsMatriculado)
                            HF_Matricul.Value = "0";
                        else
                            HF_Matricul.Value = "1";

                        //**************Verificar que no tenga un registro con estado sala activo*************
                        UsuarioSalaLogic oUsuarioSalaLogic = new UsuarioSalaLogic();
                        UsuarioSala itemUsuarioSala = new UsuarioSala();
                        itemUsuarioSala = oUsuarioSalaLogic.BuscarRegistroUsuarioSala_x_Usuario(itemvwUsuariosSAC.CodUsuarioSAC);
                        
                        //if (itemUsuarioSala.bSala == true)
                        if (itemUsuarioSala.bSala != null)//ELVP:22-12-2011
                        {
                            MessageBox1.ShowInfo("¡ No se ha registrado salida de sala de Usuario !");
                            f_labelsCodRegistro.Text = itemUsuarioSala.sCodRegistro;

                            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                            //EstadoDatosVER();
                        }
                        else
                        {
                            f_labelsCodRegistro.Text = string.Empty;
                            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
                        }
                        //************************************************************************************

                        MostrarFotografia(itemvwUsuariosSAC.CodUsuarioSAC);
                    }//Fin es alumno
                    
                }
                else//Usuario no pertenece a ningún SAC
                {
                    string codixusu = f_txtCodigoUsuarioSAC.Text;
                    MessageBox1.ShowWarning("¡ Código de usuario SAC no pertenece a ningún SAC. !");
                    LimpiarControles();
                    f_txtCodigoUsuarioSAC.Text = codixusu;
                }
            }
            else//Código de usuario no existe
            {
                string codixusu = f_txtCodigoUsuarioSAC.Text;
                MessageBox1.ShowWarning("¡ Código de usuario SAC ingresado no existe !");
                LimpiarControles();
                f_txtCodigoUsuarioSAC.Text = codixusu;
            }
        }
        else//No se ha ingresado código de alumno
        {
            MessageBox1.ShowInfo("¡ Ingresar código de usuario SAC para buscar sus datos !");
            LimpiarControles();
        }
    }

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    
    private void LimpiarControles()
    {
        f_txtCodigoUsuarioSAC.Text = "";
        f_txtSAC.Text = "";
        f_txtNombres.Text = "";
        f_txtApellidos.Text = "";
        f_labelsCodLocalSACRegistro.Text = "";
        f_txtSACID.Text = "";

        //Colocar fecha por defecto
        f_TextBoxFechaInicio.Text = DateTime.Now.ToShortDateString();
        f_TextBoxFechaFin.Text = DateTime.Now.ToShortDateString();
        f_DropDownListHoraInicio.SelectedIndex = DateTime.Now.Hour;
        f_DropDownListHoraFin.SelectedIndex = DateTime.Now.Hour;
        f_txtMinutoInicio.Text = DateTime.Now.Minute.ToString("00");
        f_txtMinutoFin.Text = DateTime.Now.Minute.ToString("00");

        MostrarFotografia(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario));
    }

    private void CargarPagina()
    {
        String querystringDESENCRYP = string.Empty;
        
        if (Request.QueryString.Get("pm") != null)
            querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
        hfParameters.Value = querystringDESENCRYP;
        HF_CodRegistro.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
        HF_Proceso.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "nv");
        HF_Ver.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "ver");
        
        if (HF_Proceso.Value == "")//NUEVO
        {
            NuevoRegistro();
        }
        else
        {
            UsuarioSalaLogic oUsuarioSalaLogic = new UsuarioSalaLogic();
            UsuarioSala itemUsuarioSala = new UsuarioSala();

            itemUsuarioSala = oUsuarioSalaLogic.BuscarRegistroUsuarioSala(HF_CodRegistro.Value);
            //HF_CodUsuarioSAC.Value = itemSolicitudCarnet.sCodUsuarioSAC;
            LlenarDatosUsuarioSala(itemUsuarioSala);
            ButtonBuscarUsuarioSAC.Visible = false;

            if (HF_Ver.Value == string.Empty)//EDITAR
            {
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
                HF_Evento.Value = HelpEvento.Editar.ToString();

                //if (itemSolicitudCarnet.sCodArguEstado == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP01))
                //{
                //    BotonesEdicionMantenimiento1.BotonNuevo = false;
                //    BotonesEdicionMantenimiento1.BotonEditar = false;
                //}
                if (HF_Proceso.Value == "" || HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    lblTituloPagina.Text = HelpEvento.Editar.ToString().ToUpper() + " - " + this.Master.HelpOpcion_Permiso("ListaRegistroUsuarioSala.aspx").CodigoOpcionNombre;
                    f_txtCodigoUsuarioSAC.ReadOnly = true;
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                    BotonesEdicionMantenimiento1.LoadComplete();
                }
            }
            else//VER
            {
                if (HF_Proceso.Value == "" || HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
                    lblTituloPagina.Text = "Ver - " + this.Master.HelpOpcion_Permiso("ListaRegistroUsuarioSala.aspx").CodigoOpcionNombre;
                EstadoDatosVER();
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
            }
            Auditoria1.CargarSeguridad(itemUsuarioSala.SSIUsuario_Creacion, itemUsuarioSala.SSIUsuario_Modificacion, Convert.ToDateTime(itemUsuarioSala.SSIFechaHora_Creacion), Convert.ToDateTime(itemUsuarioSala.SSIFechaHora_Modificacion), itemUsuarioSala.SSIHost);
        }
        Page.Title = lblTituloPagina.Text;
    }

    private void NuevoRegistro()
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
        HF_Evento.Value = HelpEvento.Registrar.ToString();

        //Colocar fecha por defecto
        f_TextBoxFechaInicio.Text = DateTime.Now.ToShortDateString();
        f_TextBoxFechaFin.Text = DateTime.Now.ToShortDateString();
        f_DropDownListHoraInicio.SelectedIndex = DateTime.Now.Hour;
        f_DropDownListHoraFin.SelectedIndex = 0;
        f_txtMinutoInicio.Text = DateTime.Now.Minute.ToString("00");
        f_txtMinutoFin.Text = "";
        
        f_TextBoxFechaFin.Enabled = false;
        f_DropDownListHoraFin.Enabled = false;
        f_txtMinutoFin.Enabled = false;

        Auditoria1.CargarSeguridadInicio();
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = false;
    }

    private void EstadoDatosVER()
    {
        f_txtSACID.ReadOnly = true;
        f_txtCodigoUsuarioSAC.ReadOnly = true;
    }

    private UsuarioSala GetTablaUsuarioSala()
    {
        UsuarioSala item = new UsuarioSala();
        DateTime fechaInicio = Convert.ToDateTime(f_TextBoxFechaInicio.Text.Trim()).AddHours(Convert.ToInt32(f_DropDownListHoraInicio.Text.Trim())).AddMinutes(Convert.ToInt32(f_txtMinutoInicio.Text.Trim()));

        item.sCodUsuarioSAC = f_txtCodigoUsuarioSAC.Text;
        item.sCodSac = this.Master.HelpUsuariosSAC().CodLocalSAC;
        item.sCodSacUsuario = f_txtSACID.Text;
        item.dFechaInicio = fechaInicio;
        item.sObservaciones = f_txtObservaciones.Text;
        item.SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario;
        item.SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario;
        item.SSIHost = Request.UserHostName;
        
        return item;
    }

    private UsuarioSala GetTablaUsuarioSalaSalida()
    {
        UsuarioSala item = new UsuarioSala();

        DateTime fechaInicio = Convert.ToDateTime(f_TextBoxFechaInicio.Text.Trim()).AddHours(Convert.ToInt32(f_DropDownListHoraInicio.Text.Trim())).AddMinutes(Convert.ToInt32(f_txtMinutoInicio.Text.Trim()));
        DateTime fechaFin = Convert.ToDateTime(f_TextBoxFechaFin.Text.Trim()).AddHours(Convert.ToInt32(f_DropDownListHoraFin.Text.Trim())).AddMinutes(Convert.ToInt32(f_txtMinutoFin.Text.Trim()));

        item.sCodRegistro = HF_CodRegistro.Value;
        item.dFechaInicio = fechaInicio;
        item.dFechaFin = fechaFin;
        item.sObservaciones = f_txtObservaciones.Text;
        item.SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario;

        return item;
    }

    private void LlenarDatosUsuarioSala(UsuarioSala item)
    {
        f_txtCodigoUsuarioSAC.Text = item.sCodUsuarioSAC;
        f_txtNombres.Text = item.sNombres;
        f_txtApellidos.Text = item.sApellidos;
        f_txtSAC.Text = item.sCodSacUsuarioNombre;
        f_txtSACID.Text = item.sCodSac;
        f_labelsCodLocalSACRegistro.Text = item.sCodSacNombre;
        f_TextBoxFechaInicio.Text = item.dFechaInicio.Value.Date.ToString();
        f_DropDownListHoraInicio.SelectedIndex = item.dFechaInicio.Value.Hour;
        f_txtMinutoInicio.Text = item.dFechaInicio.Value.Minute.ToString("00");
        
        MostrarFotografia(item.sCodUsuarioSAC);

        //Colocar fecha por defecto
        if (item.bSala == true)//Está en sala
        {
            if (HF_Proceso.Value == "01")//EDITAR
            {
                f_TextBoxFechaFin.Text = f_TextBoxFechaInicio.Text;
                f_DropDownListHoraFin.SelectedIndex = DateTime.Now.Hour;
                f_txtMinutoFin.Text = DateTime.Now.Minute.ToString("00");
            }
            else//VER
            {
                f_TextBoxFechaFin.Text = f_TextBoxFechaInicio.Text;
                f_DropDownListHoraFin.SelectedIndex = 0;
                f_txtMinutoFin.Text = "";
            }
            //f_TextBoxFechaInicio.Enabled = false;
            //f_DropDownListHoraInicio.Enabled = false;
            //f_txtMinutoInicio.Enabled = false;

        }
        else//No está en sala
        {
            f_TextBoxFechaFin.Text = item.dFechaFin.Value.Date.ToString();
            f_DropDownListHoraFin.SelectedIndex = item.dFechaFin.Value.Hour;
            f_txtMinutoFin.Text = item.dFechaFin.Value.Minute.ToString("00");
        }
    }

    private string Validar()
    {
        BuscarPersonaParaRegistro();
        string mensage = "";
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
            mensage = mensage + "¡ Usuario no puede registrar a usuario en sala, no esta asignado a un SAC. !" + "</br>";

        if (f_txtCodigoUsuarioSAC.Text == "" || f_txtApellidos.Text == "" || f_txtNombres.Text == "") mensage = mensage + " ¡ Ingresar código de usuario SAC ! " + "</br>";
        //ESALDARRIAGA 11/10/2011
        if (HF_Matricul.Value == "0") mensage = mensage + " ¡ Usuario de SAC no está matriculado !";
        //ESALDARRIAGA 11/10/2011

        if (HF_Evento.Value == HelpEvento.Registrar.ToString())//Registrar
        {
            UsuarioSalaLogic oUsuarioSalaLogic = new UsuarioSalaLogic();
            UsuarioSala itemUsuarioSala = new UsuarioSala();
            itemUsuarioSala = oUsuarioSalaLogic.BuscarRegistroUsuarioSala_x_Usuario(f_txtCodigoUsuarioSAC.Text);
            if (itemUsuarioSala.bSala != null)//ELVP:22-12-2011
                mensage = mensage + "¡ No se ha registrado salida de sala de Usuario !";
        }

        return mensage;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaRegistroUsuarioSala.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaRegistroUsuarioSala.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpcionesEditar = new RolesOpciones();
        RolesOpciones oRolesOpcionesNuevo = new RolesOpciones();
        bool editar = false;
        bool nuevo = false;

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtEditar.Rows.Count > 0)
            {
                editar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            if (dtNuevo.Rows.Count > 0)
            {
                nuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
            }
        }

        if (HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
        {
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
            {
                BotonesEdicionMantenimiento1.BotonGrabar = editar;//oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;// !oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = true;
            }
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = editar;// oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;// !oRolesOpcionesEditar.Flag_Editar;
                if (HF_Proceso.Value == "00")//Ver
                    EstadoDatosVER();
                if (HF_Proceso.Value == "01")//Editar
                {
                    if (HF_Evento.Value == HelpEvento.Registrar.ToString())
                    {
                        f_txtCodigoUsuarioSAC.ReadOnly = false;
                        f_txtCodigoUsuarioSAC.Enabled = true;
                    }
                    else
                    {
                        f_txtCodigoUsuarioSAC.ReadOnly = true;
                    }
                }
            }
            BotonesEdicionMantenimiento1.BotonRegresar = true;
            if (HF_Proceso.Value == "01")
            {
                BotonesEdicionMantenimiento1.BotonGrabarEnabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            }
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "")//Nuevo
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaRegistroUsuarioSala.aspx");
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;

            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
            {
                BotonesEdicionMantenimiento1.BotonGrabar = nuevo;//oRolesOpcionesNuevo.Flag_Nuevo;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;//!oRolesOpcionesEditar.Flag_Editar;
            }
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = nuevo;//oRolesOpcionesNuevo.Flag_Nuevo;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;// !oRolesOpcionesEditar.Flag_Editar;
            }
            BotonesEdicionMantenimiento1.BotonRegresar = true;
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void MostrarFotografia(string CodigoUsuarioSAC)
    {
        Random Num = new Random();
        Int32 NumI;

        NumI = Convert.ToInt32(Num.Next(100));

        string DirImagen = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenUsuarioSAC);
        if (CodigoUsuarioSAC == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario))
            f_ImageUsuarioSAC.ImageUrl = DirImagen + CodigoUsuarioSAC;
        else
        {
            string NombreArchivoGen = f_txtCodigoUsuarioSAC.Text + ".jpg?id=" + NumI;
            f_ImageUsuarioSAC.ImageUrl = DirImagen + NombreArchivoGen;
        }
    }
   
    #endregion

}
