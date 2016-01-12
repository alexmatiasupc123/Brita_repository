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

public partial class MantSolicitudImpresionCarnet : System.Web.UI.Page
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
                UpdatePanel_cpms(parameter);
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
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            GuardarSolicitudCarne();
        }
        else if (MessageBox1.Evento() == HelpEvento.Imprimir.ToString())
        {
            SeSolicitaLaImpresionDelCarne();
        }
        else if (MessageBox1.Evento() == HelpEvento.CerrarSolicitud.ToString())
        {
            CarnetEntregarAUsurio();
        }
        else if (MessageBox1.Evento() == HelpEvento.Enviar.ToString())
        {
            SeCambiaEstadoDeLaSolicitud();
        }
    }

    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        //ButtonBuscarUsuarioSAC.Visible = true;
        //f_txtCodigoUsuarioSAC.ReadOnly = false;
        //f_CheckBoxTieneFoto.Checked = false;
        //f_TextBoxFechaSolicitud.Text = string.Empty;
        //f_CheckBoxbDuplicado.Checked = false;
        //LimpiarControles();
        //NuevoRegistroDeSolicitud();
    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        HF_Evento.Value = HelpEvento.Editar.ToString();
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        ViewState["operacion"] = "G";
        if (HF_Ver.Value == "5")
        {
            MessageBox1.ShowConfirm("¿ Confirma la entrega del carné al usuario SAC ?", HelpEvento.CerrarSolicitud.ToString());
        }
        else if (HF_Ver.Value == "6")
        {
            string mensaje = ValidarCambiarEstado();
            if (mensaje == "")
                MessageBox1.ShowConfirm("¿ Confirma cambiar el estado actual de la solicitud de carné ?", HelpEvento.Enviar.ToString());
            else
                MessageBox1.ShowInfo(mensaje);
        }
        else
        {
            string mensaje = Validar();
            if (mensaje == "")
            {
                MessageBox1.ShowConfirm("¿ Confirma guardar la solicitud de carné ?", HelpEvento.Guardar.ToString());
            }
            else
            {
                MessageBox1.ShowInfo(mensaje);
            }
        }
    }

    private void GuardarSolicitudCarne()
    {
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
        SolicitudCarnet item = GetTablaSolicitudCarnet();

        if (HF_Evento.Value == HelpEvento.Registrar.ToString())
        {
            ReturnValor oReturnValor = new ReturnValor();
            item.sCorreoElectronico = f_txtCorreoElectronico.Text;//ELVP:19-07-2011

            oReturnValor = oSolicitudCarnetLogic.Registrar(item);
            if (oReturnValor.Exitosa)
            {
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                MessageBox1.ShowSuccess(oReturnValor.Message);
                EstadoDatosVER();

                ViewState["correoElectronico"] = "R";//19-07-2011
            }
            else
            {
                MessageBox1.ShowWarning(oReturnValor.Message);
            }
        }
        else if (HF_Evento.Value == HelpEvento.Editar.ToString())
        {
            ReturnValor oReturnValor = new ReturnValor();
            item.sCodSolicitud = f_labelsCodSolicitud.Text;
            item.sCorreoElectronico = f_txtCorreoElectronico.Text;//ELVP:19-07-2011

            oReturnValor = oSolicitudCarnetLogic.ActualizarSolicitudCarnet(item, Convert.ToInt32(HF_Proceso.Value));

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

    private void CarnetEntregarAUsurio()
    {
        ReturnValor oReturnValor = new ReturnValor();
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();

        SolicitudCarnet itemx = new SolicitudCarnet()
        {
            sCodSolicitud = HF_CodSolicitud.Value,
            sCodArguEstado = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP05),
            sUsuarioEntregaUsuario = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
        };

        oReturnValor = oSolicitudCarnetLogic.ActualizarSolicitudCarnet(itemx, 4);

        if (oReturnValor.Exitosa)
        {
            Response.Redirect("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx");
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        if (HF_Proceso.Value == "" || HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
            Response.Redirect("ListaSolicitudCarnetSolictaImpresion.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
        else if (HF_Proceso.Value == "02")
            Response.Redirect("ListaSolicitudCarnetImpresiones.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
        else if (HF_Proceso.Value == "03")
            Response.Redirect("ListaSolicitudCarnetRecibidoSAC.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
        else if (HF_Proceso.Value == "04")
            Response.Redirect("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
        else if (HF_Proceso.Value == "05")
            Response.Redirect("ListaSolicitudCarnetCambiarEstado.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
    }

    #endregion

    protected void ButtonBuscarUsuarioSAC_Click(object sender, EventArgs e)
    {
        ViewState["operacion"] = "B";
        BuscarPersonaParaSolicitud();
    }

    private void BuscarPersonaParaSolicitud()
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
                    f_CheckBoxTieneFoto.Checked = itemvwUsuariosSAC.TieneFotografia;
                    f_labelsCodLocalSACSolicita.Text = this.Master.HelpUsuariosSAC().CodLocalSACNombre;

                    if (ViewState["operacion"].ToString() == "B")
                    {
                        if ((ViewState["correoElectronico"] == null && f_txtCorreoElectronico.Text.Trim() == "") ||
                           Convert.ToString(ViewState["correoElectronico"]) == "R")//ELVP: 19-07-2011
                            f_txtCorreoElectronico.Text = itemvwUsuariosSAC.CorreoElectronico;
                    }

                    if (itemvwUsuariosSAC.EsAlumno == "A")
                    {
                        if (!itemvwUsuariosSAC.EsMatriculado)
                            HF_Matricul.Value = "0";
                        else
                            HF_Matricul.Value = "1";
                        // else
                        //{ HF_Matricul.Value = "1"; }   


                        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
                        SolicitudCarnet xitemSolicitudCarnet = new SolicitudCarnet();
                        xitemSolicitudCarnet = oSolicitudCarnetLogic.BuscarPorCodUsuarioSAC(f_txtCodigoUsuarioSAC.Text);
                        if (xitemSolicitudCarnet.sCodUsuarioSAC != null)
                        {
                            if (xitemSolicitudCarnet.sCodArguEstado == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP05))
                            {
                                f_CheckBoxbDuplicado.Checked = true;
                                HF_Proceso.Value = "01";
                                String querystringENCRYP = string.Empty;
                                querystringENCRYP = HelpEncrypt.Encriptar("id=" + xitemSolicitudCarnet.sCodUsuarioSAC.Trim());
                                ButtonBuscarPago.Attributes.Add("Onclick", "OpenPopup('PopupDocumentosDePago.aspx?pm=" + querystringENCRYP + "',800,500)");
                                DatosDePago(true);
                            }
                            else
                            {
                                MessageBox1.ShowInfo("¡ Usuario SAC ya tiene en trámite su carné !");
                                f_labelsCodSolicitud.Text = xitemSolicitudCarnet.sCodSolicitud;
                            }
                            f_labelnTotalEmitidas.Text = " " + xitemSolicitudCarnet.nTotalEmitidos.ToString().PadLeft(3, '0') + " ";


                        }
                        else
                        {
                            f_labelsCodSolicitud.Text = string.Empty;
                            f_CheckBoxbDuplicado.Checked = false;
                            f_labelnTotalEmitidas.Text = " 000 ";
                            DatosDePago(false);
                        }
                        MostrarFotografia(itemvwUsuariosSAC.CodUsuarioSAC);
                    }
                    else //ESALDARRIAGA 12/09/2011
                    {
                        string codixusu = f_txtCodigoUsuarioSAC.Text;
                        MessageBox1.ShowWarning("¡ Código de usuario SAC no permitido para la solicitud de carnet !");
                        LimpiarControles();
                        f_txtCodigoUsuarioSAC.Text = codixusu;

                    }
                    //ESALDARRIAGA 12/09/2011

                }
                else
                {
                    string codixusu = f_txtCodigoUsuarioSAC.Text;
                    MessageBox1.ShowWarning("¡ Código de usuario SAC no pertenece a ningún SAC. !");
                    LimpiarControles();
                    f_txtCodigoUsuarioSAC.Text = codixusu;
                }
            }
            else
            {
                string codixusu = f_txtCodigoUsuarioSAC.Text;
                MessageBox1.ShowWarning("¡ Código de usuario SAC ingresado no existe !");
                LimpiarControles();
                f_txtCodigoUsuarioSAC.Text = codixusu;
            }
        }
        else
        {
            MessageBox1.ShowInfo("¡ Ingresar código de usuario SAC para buscar sus datos !");
            LimpiarControles();
        }
    }

    protected void ButtonParaImprimir_Click(object sender, EventArgs e)
    {
        string messages = ValidarSolicitud();
        if (messages == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma solicitud de impresión de carné ?", HelpEvento.Imprimir.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(messages);
        }
    }

    //protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    //{
    //    if (parameter.Trim() != "")
    //    {
    //        string[] Valores = parameter.Split(new char[] { '&' });

    //        if (Valores.Length > 0)
    //        {
    //            f_labelsTipoDocumento.Text = Valores[1].ToString();
    //            f_labelsNumeroDocumento.Text = Valores[2].ToString();
    //            f_labelsTipoDocNumero.Text = Valores[5].ToString();
    //            f_LabelsUsuario.Text = Valores[0].ToString();
    //            f_LabelsEstablecimientoCodigo.Text = Valores[3].ToString();
    //            f_LabelsEstablecimientoCodigoNombre.Text = Valores[4].ToString();
    //        }
    //    }
    //}
    public void UpdatePanel_cpms(string parameter)
    {


        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });

            if (Valores.Length > 0)
            {
                f_labelsTipoDocumento.Text = Valores[1].ToString();
                f_labelsNumeroDocumento.Text = Valores[2].ToString();
                f_labelsTipoDocNumero.Text = Valores[5].ToString();
                f_LabelsUsuario.Text = Server.UrlDecode(Valores[0].ToString());
                f_LabelsEstablecimientoCodigo.Text = Valores[3].ToString();
                f_LabelsEstablecimientoCodigoNombre.Text = Valores[4].ToString();
            }
        }
    }


    #endregion

    #region "/--- Metodos del Desarrollador  ---/"

    private void SeSolicitaLaImpresionDelCarne()
    {
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
        SolicitudCarnet itemSolicitudCarnet = new SolicitudCarnet();
        itemSolicitudCarnet = oSolicitudCarnetLogic.Buscar(HF_CodSolicitud.Value);
        itemSolicitudCarnet.sCodArguEstado = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP02);
        itemSolicitudCarnet.sUsuarioSolicitaImpresion = this.Master.HelpUsuario().LoginUsuario;
        itemSolicitudCarnet.dFechaSolicitaImpresion = DateTime.Now;
        itemSolicitudCarnet.bFotografia = f_CheckBoxTieneFoto.Checked;
        if (f_CheckBoxbDuplicado.Checked)
        {
            itemSolicitudCarnet.sNumeroDocumento = f_labelsNumeroDocumento.Text;
            itemSolicitudCarnet.sTipoDocumento = f_labelsTipoDocumento.Text;
            itemSolicitudCarnet.sUsuario = f_LabelsUsuario.Text;
            itemSolicitudCarnet.sEstablecimientoCodigo = f_LabelsEstablecimientoCodigo.Text;
        }
        ReturnValor oReturnValor = new ReturnValor();
        oReturnValor = oSolicitudCarnetLogic.ActualizarSolicitudCarnet(itemSolicitudCarnet, 1);
        if (oReturnValor.Exitosa)
        {
            Response.Redirect("ListaSolicitudCarnetSolictaImpresion.aspx");
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    private void SeCambiaEstadoDeLaSolicitud()
    {
        SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
        SolicitudCarnet itemSolicitudCarnet = new SolicitudCarnet();
        itemSolicitudCarnet = oSolicitudCarnetLogic.Buscar(HF_CodSolicitud.Value);

        itemSolicitudCarnet.sCodArguEstado = f_DropDownListEstadoSolicitud.SelectedValue.ToString();
        itemSolicitudCarnet.SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario;
        ReturnValor oReturnValor = new ReturnValor();
        oReturnValor = oSolicitudCarnetLogic.ActualizarSolicitudCarnet(itemSolicitudCarnet, 5);
        if (oReturnValor.Exitosa)
        {
            Response.Redirect("ListaSolicitudCarnetCambiarEstado.aspx");
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    private void LimpiarControles()
    {
        f_labelsCodSolicitud.Text = "";
        f_txtCodigoUsuarioSAC.Text = "";
        f_txtSAC.Text = "";
        f_txtNombres.Text = "";
        f_txtApellidos.Text = "";
        f_labelsUsuarioSolicitaImpresion.Text = "";
        f_labelsUsuarioImpresion.Text = "";
        f_labelsUsuarioEntregaUsuario.Text = "";
        f_labelsUsuarioEntregaSAC.Text = "";
        f_labelsTipoDocumento.Text = "";
        f_labelsTipoDocumento.Text = "";
        f_labeldFechaSolicitaImpresion.Text = "";
        f_labeldFechaImpresion.Text = "";
        f_labeldFechaEntregaSAC.Text = "";
        f_labeldFechaEntregaUsuario.Text = "";
        f_labelsCodLocalSACSolicita.Text = "";
        f_labelnTotalEmitidas.Text = "";
        f_CheckBoxTieneFoto.Checked = false;
        f_txtCorreoElectronico.Text = "";//ESALDARRIAGA 12/09/2011
        MostrarFotografia(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario));
    }

    private void CargarPagina()
    {
        HelpMaestros.CargarListadoGenerico(ref f_DropDownListEstadoSolicitud, HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.EstadosDeCarne), HelpMaestros.NivelTabla(HelpMaestros.TablasMaestras.EstadosDeCarne), "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        f_DropDownListEstadoSolicitud.DataBind();
        String querystringDESENCRYP = string.Empty;
        if (Request.QueryString.Get("pm") != null)
            querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
        hfParameters.Value = querystringDESENCRYP;
        HF_CodSolicitud.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");
        HF_Proceso.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "nv");
        HF_Ver.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "ver");
        if (HF_Proceso.Value == "")
        {
            NuevoRegistroDeSolicitud();
            ViewState["correoElectronico"] = "R";
        }
        else
        {
            //btif_TextBoxFechaSolicitud.Enabled = false;
            SolicitudCarnetLogic oSolicitudCarnetLogic = new SolicitudCarnetLogic();
            SolicitudCarnet itemSolicitudCarnet = new SolicitudCarnet();
            itemSolicitudCarnet = oSolicitudCarnetLogic.Buscar(HF_CodSolicitud.Value);
            HF_CodUsuarioSAC.Value = itemSolicitudCarnet.sCodUsuarioSAC;
            SetSolicitudCarnet(itemSolicitudCarnet);
            ButtonBuscarUsuarioSAC.Visible = false;
            ButtonBuscarPago.Visible = false;
            if (itemSolicitudCarnet.bDuplicado)
                pnlPagoDuplicado.Visible = true;
            if (HF_Ver.Value == string.Empty)
            {
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
                HF_Evento.Value = HelpEvento.Editar.ToString();
                f_DropDownListEstadoSolicitud.Enabled = false;
                if (itemSolicitudCarnet.sCodArguEstado == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP01))
                {
                    ButtonParaImprimir.Visible = true;
                    if (f_CheckBoxbDuplicado.Checked)
                    {
                        String querystringENCRYP = string.Empty;
                        querystringENCRYP = HelpEncrypt.Encriptar("id=" + HF_CodUsuarioSAC.Value.ToString().Trim());
                        ButtonBuscarPago.Attributes.Add("Onclick", "OpenPopup('PopupDocumentosDePago.aspx?pm=" + querystringENCRYP + "',800,400)");
                        ButtonBuscarPago.Visible = true;
                        pnlPagoDuplicado.Visible = true;
                    }
                    else
                        ButtonBuscarPago.Visible = false;
                    BotonesEdicionMantenimiento1.BotonNuevo = false;
                    BotonesEdicionMantenimiento1.BotonEditar = false;
                }
                if (HF_Proceso.Value == "" || HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
                {
                    BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarEditar);
                    lblTituloPagina.Text = HelpEvento.Editar.ToString().ToUpper() + "- Registro de " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetSolictaImpresion.aspx").CodigoOpcionNombre;
                    f_txtCodigoUsuarioSAC.ReadOnly = true;
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                    BotonesEdicionMantenimiento1.LoadComplete();
                }
            }
            else
            {
                if (HF_Proceso.Value == "" || HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
                    lblTituloPagina.Text = "Ver - Registro de " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetSolictaImpresion.aspx").CodigoOpcionNombre;
                else if (HF_Proceso.Value == "02")
                    lblTituloPagina.Text = "Ver - Registro de " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetImpresiones.aspx").CodigoOpcionNombre;
                else if (HF_Proceso.Value == "03")
                    lblTituloPagina.Text = "Ver - Registro de " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoSAC.aspx").CodigoOpcionNombre;
                else if (HF_Proceso.Value == "04")
                {
                    if (HF_Ver.Value == "1")
                        lblTituloPagina.Text = "Ver - Registro de " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx").CodigoOpcionNombre;
                    else
                        lblTituloPagina.Text = "Registro : " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx").CodigoOpcionNombre;
                }
                else if (HF_Proceso.Value == "05")
                    lblTituloPagina.Text = "Registro : " + this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetCambiarEstado.aspx").CodigoOpcionNombre;

                EstadoDatosVER();
                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Ver);
            }
            Auditoria1.CargarSeguridad(itemSolicitudCarnet.SSIUsuario_Creacion, itemSolicitudCarnet.SSIUsuario_Modificacion, itemSolicitudCarnet.SSIFechaHora_Creacion, itemSolicitudCarnet.SSIFechaHora_Modificacion, itemSolicitudCarnet.SSIHost);
        }
        Page.Title = lblTituloPagina.Text;
    }

    private void NuevoRegistroDeSolicitud()
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
        HF_Evento.Value = HelpEvento.Registrar.ToString();
        //btif_TextBoxFechaSolicitud.Enabled = true;
        f_TextBoxFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        f_DropDownListEstadoSolicitud.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP01);
        f_DropDownListEstadoSolicitud.Enabled = false;
        HF_EstadoCarnet.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP01);
        Auditoria1.CargarSeguridadInicio();
        BotonesEdicionMantenimiento1.BotonNuevoEnabled = false;
        BotonesEdicionMantenimiento1.BotonEditarEnabled = false;
    }

    private void EstadoDatosVER()
    {
        f_txtSACID.ReadOnly = true;
        f_DropDownListEstadoSolicitud.Enabled = false;
        f_txtCodigoUsuarioSAC.ReadOnly = true;
        f_CheckBoxbDuplicado.Enabled = false;
        //f_CheckBoxTieneFoto.Enabled = false;//ELVP:29-05-2012
        //btif_TextBoxFechaSolicitud.Visible = false;
        f_TextBoxFechaSolicitud.Enabled = false;
    }

    private SolicitudCarnet GetTablaSolicitudCarnet()
    {
        SolicitudCarnet item = new SolicitudCarnet();
        string horaX = DateTime.Now.ToLongTimeString();
        item.dFechaProceso = Convert.ToDateTime(f_TextBoxFechaSolicitud.Text + " " + horaX);
        item.sCodLocalSACSolicita = this.Master.HelpUsuariosSAC().CodLocalSAC;
        item.sCodArguEstado = f_DropDownListEstadoSolicitud.SelectedValue.ToString();

        item.sCodUsuarioSAC = f_txtCodigoUsuarioSAC.Text;
        item.sCodLocalSACUsuario = f_txtSACID.Text;
        item.sNombresUsuarioSAC = f_txtNombres.Text;
        item.sApellidosUsuarioSAC = f_txtApellidos.Text;
        item.bDuplicado = f_CheckBoxbDuplicado.Checked;
        item.bFotografia = f_CheckBoxTieneFoto.Checked;

        item.sNumeroDocumento = f_labelsNumeroDocumento.Text.Trim();
        item.sTipoDocumento = f_labelsTipoDocumento.Text;

        item.sUsuario = f_LabelsUsuario.Text;
        item.sEstablecimientoCodigo = f_LabelsEstablecimientoCodigo.Text;

        item.SSIHost = Request.UserHostName;
        item.SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario;
        item.SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario;

        return item;
    }

    private void SetSolicitudCarnet(SolicitudCarnet item)
    {
        f_txtCodigoUsuarioSAC.Text = item.sCodUsuarioSAC;
        f_labelsCodSolicitud.Text = item.sCodSolicitud;
        f_TextBoxFechaSolicitud.Text = item.dFechaProceso.ToShortDateString() + " " + item.dFechaProceso.ToShortTimeString();
        f_DropDownListEstadoSolicitud.SelectedValue = item.sCodArguEstado;
        f_labelsCodLocalSACSolicita.Text = item.sCodLocalSACSolicitaNombre;

        f_txtApellidos.Text = item.sApellidosUsuarioSAC;
        f_txtNombres.Text = item.sNombresUsuarioSAC;
        f_CheckBoxbDuplicado.Checked = item.bDuplicado;
        f_CheckBoxTieneFoto.Checked = item.bFotografia;
        f_txtCorreoElectronico.Text = item.sCorreoElectronico;//ELVP: 15-07-2011
        ViewState["correoElectronico"] = item.sCorreoElectronico;//ELVP: 15-07-2011

        f_txtSAC.Text = item.sCodLocalSACUsuarioNombre;
        f_txtSACID.Text = item.sCodLocalSACUsuario;

        if (!item.bDuplicado)
            DatosDePago(false);
        f_LabelsEstablecimientoCodigo.Text = item.sEstablecimientoCodigo;
        f_LabelsEstablecimientoCodigoNombre.Text = item.sEstablecimientoCodigoNombre;
        f_labelsNumeroDocumento.Text = item.sNumeroDocumento;
        f_labelsTipoDocumento.Text = item.sTipoDocumento;
        f_LabelsUsuario.Text = Server.UrlDecode(item.sUsuario);
        f_labelsTipoDocNumero.Text = item.TipoDocuNumero;

        f_labelsUsuarioEntregaSAC.Text = item.sUsuarioEntregaSAC;
        f_labelsUsuarioEntregaUsuario.Text = item.sUsuarioEntregaUsuario;
        f_labelsUsuarioImpresion.Text = item.sUsuarioImpresion;
        f_labelsUsuarioSolicitaImpresion.Text = item.sUsuarioSolicitaImpresion;
        f_labeldFechaEntregaSAC.Text = item.dFechaEntregaSAC == null ? "" : Convert.ToDateTime(item.dFechaEntregaSAC.Value).ToShortDateString() + " " + Convert.ToDateTime(item.dFechaEntregaSAC.Value).ToShortTimeString();
        f_labeldFechaEntregaUsuario.Text = item.dFechaEntregaUsuario != null ? item.dFechaEntregaUsuario.Value.ToShortDateString() + " " + item.dFechaEntregaUsuario.Value.ToShortTimeString() : "";
        f_labeldFechaImpresion.Text = item.dFechaImpresion != null ? item.dFechaImpresion.Value.ToShortDateString() + " " + item.dFechaImpresion.Value.ToShortTimeString() : "";
        f_labeldFechaSolicitaImpresion.Text = item.dFechaSolicitaImpresion != null ? item.dFechaSolicitaImpresion.Value.ToShortDateString() + " " + item.dFechaSolicitaImpresion.Value.ToShortTimeString() : "";
        f_labelnTotalEmitidas.Text = " " + item.nTotalEmitidos.ToString().PadLeft(3, '0') + " ";
        MostrarFotografia(item.sCodUsuarioSAC);
    }

    private string ValidarSolicitud()
    {
        string messages = string.Empty;
        if (!f_CheckBoxTieneFoto.Checked)
            messages = messages + "¡ Usuario de SAC no tiene fotografía !" + "</br>";
        if (f_CheckBoxbDuplicado.Checked)
        {
            if (f_labelsTipoDocumento.Text.Length == 0 || f_labelsNumeroDocumento.Text.Length == 0)
                messages = messages + " ¡ Usuario de SAC no ha realizado pago de carné por duplicado !" + "</br>";
        }
        return messages;
    }

    private string ValidarCambiarEstado()
    {
        string messages = string.Empty;
        if (f_DropDownListEstadoSolicitud.SelectedValue.ToString().Trim() == string.Empty)
            messages = messages + "¡ Seleccionar estado de la solicitud a cambiar !" + "</br>";
        return messages;
    }


    private string Validar()
    {
        BuscarPersonaParaSolicitud();
        string mensage = "";
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
            mensage = mensage + "¡ Usuario no puede registrar la solicitud de carné, no esta asignado a un SAC. !" + "</br>";

        if (f_txtCodigoUsuarioSAC.Text == "" || f_txtApellidos.Text == "" || f_txtNombres.Text == "") mensage = mensage + " ¡ Ingresar código de usuario SAC ! " + "</br>";
        //---ELVP: 29-05-2012-----------
        if (!f_CheckBoxTieneFoto.Checked)
            mensage = mensage + "¡ Usuario de SAC no tiene fotografía !" + "</br>" + "  /1  " + f_ImageUsuarioSAC.ImageUrl;
        //------------------------------
        if (HF_Proceso.Value != "01")
        {
            if (f_labelsCodSolicitud.Text.Length > 0)
                mensage = mensage + "¡ Usuario SAC ya esta en trámite su carné !" + "</br>";
        }

        if (f_TextBoxFechaSolicitud.Text == "")
            mensage = mensage + " ¡ Ingresar la fecha de solicitud ! " + "</br>";
        else
        {
            if (Convert.ToDateTime(f_TextBoxFechaSolicitud.Text) > DateTime.Today)
                mensage = mensage + " ¡ La fecha de solicitud es mayor a la fecha actual ! " + "</br>";
        }

        if (HF_Matricul.Value == "0") mensage = mensage + " ¡ Usuario de SAC no esta matriculado !";
        if (f_CheckBoxbDuplicado.Checked)
        {
            if (f_labelsTipoDocumento.Text.Length == 0 || f_labelsNumeroDocumento.Text.Length == 0)
                mensage = mensage + " ¡ Usuario de SAC no ha realizado pago de carné por duplicado ! " + "</br>";
        }
        return mensage;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones;
        List<RolesOpciones> lstRolesOpciones;//ELVP:11-10-2011
        RolesOpciones oRolesOpcionesEditar = new RolesOpciones();
        RolesOpciones oRolesOpcionesNuevo = new RolesOpciones();
        DataTable dt;
        bool editar = false;
        bool nuevo = false;

        if (HF_Proceso.Value == "00" || HF_Proceso.Value == "01")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetSolictaImpresion.aspx");
            lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaSolicitudCarnetSolictaImpresion.aspx");//ELVP:11-10-2011

            //ELVP:11-10-2011**********************************
            if (lstRolesOpciones != null)
            {
                dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
                DataRow[] drEditar = dt.Select("Tipo=4");
                DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

                if (dtEditar.Rows.Count > 0)
                {
                    editar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                }
            }
            //*************************************************

            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            ButtonBuscarPago.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            ButtonParaImprimir.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
            {
                BotonesEdicionMantenimiento1.BotonGrabar = editar;//oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;//!oRolesOpcionesEditar.Flag_Editar;
                //f_CheckBoxTieneFoto.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar; //ELVP: 29-05-2012
                f_TextBoxFechaSolicitud.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = true;
            }
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = editar;//oRolesOpcionesEditar.Flag_Editar;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;//!oRolesOpcionesEditar.Flag_Editar;
                //f_CheckBoxTieneFoto.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar; //ELVP: 29-05-2012
                f_TextBoxFechaSolicitud.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
                if (HF_Proceso.Value == "00")
                    EstadoDatosVER();
                if (HF_Proceso.Value == "01")
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
                if (HF_Evento.Value == HelpEvento.Registrar.ToString())
                    f_TextBoxFechaSolicitud.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
                else
                    f_TextBoxFechaSolicitud.Enabled = !editar;//!oRolesOpcionesEditar.Flag_Editar;
                BotonesEdicionMantenimiento1.BotonGrabarEnabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            }
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetSolictaImpresion.aspx");
            lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaSolicitudCarnetSolictaImpresion.aspx");//ELVP:11-10-2011

            //ELVP:11-10-2011**********************************
            if (lstRolesOpciones != null)
            {
                dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
 
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
            //*************************************************

            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            ButtonBuscarPago.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            ButtonParaImprimir.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
            {
                BotonesEdicionMantenimiento1.BotonGrabar = nuevo;//oRolesOpcionesNuevo.Flag_Nuevo;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;//!oRolesOpcionesEditar.Flag_Editar;
                //f_CheckBoxTieneFoto.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar; //ELVP: 29-05-2012
                f_TextBoxFechaSolicitud.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            }
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = nuevo;//oRolesOpcionesNuevo.Flag_Nuevo;
                f_txtCodigoUsuarioSAC.ReadOnly = !editar;//!oRolesOpcionesEditar.Flag_Editar;
                //f_CheckBoxTieneFoto.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar; //ELVP: 29-05-2012
                f_TextBoxFechaSolicitud.Enabled = editar;// oRolesOpcionesEditar.Flag_Editar;
            }
            BotonesEdicionMantenimiento1.BotonRegresar = true;
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "02")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetImpresiones.aspx");
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                BotonesEdicionMantenimiento1.BotonGrabar = true;
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = false;
                EstadoDatosVER();
            }
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "03")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoSAC.aspx");
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                BotonesEdicionMantenimiento1.BotonGrabar = true;
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = false;
                EstadoDatosVER();
            }
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "04")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx");
            lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaSolicitudCarnetRecibidoUsuarioSAC.aspx");//ELVP:11-10-2011

            //ELVP:11-10-2011**********************************
            if (lstRolesOpciones != null)
            {
                dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

                DataRow[] drEditar = dt.Select("Tipo=4");
                DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

                if (dtEditar.Rows.Count > 0)
                {
                    editar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                }

            }
            //*************************************************

            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            if (HF_Ver.Value == "1")
            {
                BotonesEdicionMantenimiento1.BotonGrabar = false;
            }
            else
            {
                if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                    BotonesEdicionMantenimiento1.BotonGrabar = true;
                else
                {
                    BotonesEdicionMantenimiento1.BotonGrabar = editar;//oRolesOpcionesEditar.Flag_Editar;
                    EstadoDatosVER();
                }
            }
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else if (HF_Proceso.Value == "05")
        {
            //oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaSolicitudCarnetCambiarEstado.aspx");
            lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaSolicitudCarnetCambiarEstado.aspx");//ELVP:11-10-2011

            //ELVP:11-10-2011**********************************
            if (lstRolesOpciones != null)
            {
                dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

                DataRow[] drEditar = dt.Select("Tipo=4");
                DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

                if (dtEditar.Rows.Count > 0)
                {
                    editar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                }
            }
            //*************************************************

            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
            BotonesEdicionMantenimiento1.BotonNuevo = false;
            BotonesEdicionMantenimiento1.BotonEditar = false;
            if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                BotonesEdicionMantenimiento1.BotonGrabar = true;
            else
            {
                BotonesEdicionMantenimiento1.BotonGrabar = editar;//oRolesOpcionesEditar.Flag_Editar;
                EstadoDatosVER();
                f_DropDownListEstadoSolicitud.Enabled = editar;//oRolesOpcionesEditar.Flag_Editar;
            }
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

    private void DatosDePago(bool VISIBLE)
    {
        pnlPagoDuplicado.Visible = VISIBLE;
        ButtonBuscarPago.Visible = VISIBLE;
    }

    private bool ValidaTieneFoto()
    {
        bool tieneFoto = false;

        return tieneFoto;
    }

    #endregion

}
