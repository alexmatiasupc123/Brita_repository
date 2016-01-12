using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using System.Collections.Generic;
using System.IO;

public partial class ProDevolucionV1 : System.Web.UI.Page
{
    #region --- EVENTOS DE FORMULARIO ---
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Auditoria1.CargarSeguridadInicio();
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        if (!IsPostBack)
        {
            labelFechaDevolucionDato.Text = DateTime.Now.ToLongDateString();
            labelFechaDevEstimada.Text = string.Empty;
            ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            ButtonDevolucion.Enabled = false;

            //ELVP: 28-09-2011
            ButtonRenovacion.Enabled = false;
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }
    
    #endregion

    #region --- EVENTOS DE LOS CONTROLES ---

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmarDevolucionDe_Usuario();
        }
    }

    protected void TextBoxCodigoEjemplar_TextChanged(object sender, EventArgs e)
    {
        EjemplarParaDevolucion();
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "")
            {

            }
        }
    }

    protected void ButtonDevolucion_Click(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma la devolución del ejemplar  ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    #endregion

    #region --- MÉTODOS DEL PROGRAMADOR ---

    private void EjemplarParaDevolucion()
    {
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        {
            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de devolución, no esta asignado a un SAC. !");
            Auditoria1.CargarSeguridadInicio();
            TextBoxCodigoEjemplar.Enabled = false;
            ButtonDevolucion.Enabled = false;
            ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            pnlUsuario.Visible = true;
            pnlUsuario.Visible = false;
        }
        else
        {
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            ReturnValor oReturnValor = new ReturnValor();

            Prestamo itemPrestamo = new Prestamo();
            oReturnValor = oItemEjemplarLogic.DetectarEjemplarEnPrestamo(TextBoxCodigoEjemplar.Text, ref itemPrestamo);

            if (itemPrestamo.sCodPrestamo != null)
            {
                ucItem1.CargarDatosDeItemEjemplar(TextBoxCodigoEjemplar.Text);
                HF_FechaDevEstimada.Value = itemPrestamo.dFechaDevolucionEstimada.Value.ToShortDateString();
                HF_CodPrestamo.Value = itemPrestamo.sCodPrestamo;
                HF_CodUsuario.Value = itemPrestamo.sCodUsuarioSAC;
                HF_CentroPrestamo.Value = itemPrestamo.sCodSac.Trim();
                labelFechaDevEstimada.Text = itemPrestamo.dFechaDevolucionEstimada.Value.ToLongDateString();

                ucUsuario1.prm_CodUsuarioSAC = itemPrestamo.sCodUsuarioSAC;
                ucUsuario1.CargarDatosDeUsuarioSAC();
                Auditoria1.CargarSeguridad(itemPrestamo.SSIUsuario_Creacion, itemPrestamo.SSIUsuario_Modificacion, itemPrestamo.SSIFechaHora_Creacion, itemPrestamo.SSIFechaHora_Modificacion, itemPrestamo.SSIHost);
                pnlItem.Visible = true;
                pnlUsuario.Visible = true;
                ButtonDevolucion.Enabled = true;
                ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";

                //ELVP: 28-09-2011
                ButtonRenovacion.Enabled = true;
                ButtonRenovacion.CommandArgument = "Renovacion";
                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_A.jpg";

                //ELVP: 09-08-2011
                if(DateTime.Now.Date > Convert.ToDateTime(HF_FechaDevEstimada.Value))
                    MessageBox1.ShowWarning("¡ Usuario está devolviendo el ejemplar fuera de fecha. !");
            }
            else
            {
                MessageBox1.ShowInfo("¡ El código de ejemplar ingresado no está como préstamo! ");
                HF_FechaDevEstimada.Value = string.Empty;
                HF_CodPrestamo.Value = string.Empty;
                HF_CodUsuario.Value = string.Empty;
                ucUsuario1.prm_CodUsuarioSAC = itemPrestamo.sCodUsuarioSAC;
                ucUsuario1.CargarDatosDeUsuarioSAC();
                pnlItem.Visible = false;
                pnlUsuario.Visible = false;
                ButtonDevolucion.Enabled = false;
                ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                labelFechaDevEstimada.Text = string.Empty;

                //ELVP: 28-09-2011
                ButtonRenovacion.Enabled = false;
                ButtonRenovacion.CommandArgument = "";
                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
            }
        }
    }
    
    private string Validar()
    {
        string mensage = "";
        Label lblCodEjemp = null;
        lblCodEjemp = ucItem1.FindControl("LabelEstadoEjemplarCOD") as Label;

        if (HF_CodPrestamo.Value == "") mensage = mensage + "¡ No se ha encontrado el registro de préstamo !" + "</br>";
        if (HF_CodUsuario.Value == "") mensage = mensage + "¡ No se ha encontrado el código de usuario !" + "</br>";
        if (HF_FechaDevEstimada.Value == "") mensage = mensage + "¡ No se ha encontrado la fecha de devolución estimada !" + "</br>";
        if (TextBoxCodigoEjemplar.Text == "") mensage = mensage + "¡ Ingresar código de ejemplar a devolver !" + "</br>";
        //ESALDARRIAGA  11/10/2011
        //if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        //    mensage = mensage + "¡ Usuario no puede realizar la operación de devolución, no esta asignado a un SAC !" + "</br>";
        //ESALDARRIAGA  11/10/2011
        if (mensage.Length > 0)
            mensage = mensage.Substring(2);
        return mensage;
    }

    private void ConfirmarDevolucionDe_Usuario()
    {
        Prestamo itemPrestamo;
        Label lblCodSAC = null;
        lblCodSAC = ucUsuario1.FindControl("TextBoxCodSAC") as Label;
        itemPrestamo = new Prestamo
        {
            sCodPrestamo = HF_CodPrestamo.Value,
            sCodUsuarioSAC = HF_CodUsuario.Value,
            sCodEjemplar = TextBoxCodigoEjemplar.Text,
            sCodSacDevuelto = this.Master.HelpUsuariosSAC().CodLocalSAC.Trim(),
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName,
            dFechaDevolucionEstimada = Convert.ToDateTime(HF_FechaDevEstimada.Value),
            dFechaDevolucionReal = DateTime.Now,
            sCodSac = HF_CentroPrestamo.Value,
        };

        ReturnValor oReturnValor = new ReturnValor();
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        DateTime FechaFinSuspension = itemPrestamo.dFechaDevolucionReal.Value.AddDays(Util.DiasDePrestamo(itemPrestamo.dFechaDevolucionReal.Value, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasSuspendido)), Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)),false,ucUsuario1.prm_Sabado));
       
        // Actualiza el registro de prestamo en la Devolución REAL
        oReturnValor = oPrestamoLogic.ActualizarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperDevolucion, FechaFinSuspension);
        string OTRO_SAC = string.Empty;
        
        if (oReturnValor.Exitosa)
        {
            bool ESTA_RESERVADO = false;
            if (itemPrestamo.sCodSac == itemPrestamo.sCodSacDevuelto)
            {
                ESTA_RESERVADO = AvisarPorEmailSiEstaReservado(itemPrestamo, oReturnValor, oPrestamoLogic, ESTA_RESERVADO);
            }
            else
                OTRO_SAC = "¡ El ejemplar no se esta devolviendo en su SAC de orígen !";

            if (oReturnValor.Exitosa)
            {
                TextBoxCodigoEjemplar.Text = string.Empty;
                ucItem1.CargarDatosDeItemEjemplar(TextBoxCodigoEjemplar.Text);
                EjemplarParaDevolucion();
                if (ESTA_RESERVADO)
                    MessageBox1.ShowWarning(oReturnValor.Message + "</br>" + OTRO_SAC);
                else
                    MessageBox1.ShowSuccess(oReturnValor.Message + "</br>" + OTRO_SAC);
            }
            else
                MessageBox1.ShowWarning(oReturnValor.Message);

        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);

    }

    private bool AvisarPorEmailSiEstaReservado(Prestamo itemPrestamo, ReturnValor oReturnValor, PrestamoLogic oPrestamoLogic, bool ESTA_RESERVADO)
    {
        labelFechaDevEstimada.Text = string.Empty;
        Prestamo miReservaDeEjemplar = new Prestamo();
        miReservaDeEjemplar = oPrestamoLogic.BuscarReservasSolicitadas(string.Empty, TextBoxCodigoEjemplar.Text, PrestamoLogic.TipoDeOperacion.OperReserva);

        if (miReservaDeEjemplar.sCodPrestamo != null)
        {
            if (miReservaDeEjemplar.sCodPrestamo != HF_CodPrestamo.Value)
            {
                bool SUCEDIDO = oPrestamoLogic.ActivarReservaDePrestamo(miReservaDeEjemplar.sCodPrestamo).Exitosa;
                oReturnValor.Message = oReturnValor.Message + "¡ El ejemplar que se está devolviendo está en reserva !";
                ESTA_RESERVADO = true;
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
                vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
                itemvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(itemPrestamo.sCodUsuarioSAC);

                List<HelpMailDatos> listaHelpMailDatos = new List<HelpMailDatos>();
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Código de reserva: ", descripcion = itemPrestamo.sCodPrestamo });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Código de ejemplar: ", descripcion = itemPrestamo.sCodEjemplar });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Titulo : ", descripcion = miReservaDeEjemplar.sCodEjemplarNombreTitulo });
                listaHelpMailDatos.Add(new HelpMailDatos { titulo = "Fecha solicitada : ", descripcion = miReservaDeEjemplar.dFechaSolicitudReserva.Value.ToLongDateString() });
                string EMAIL = HelpMail.CrearBody("Reserva de ejemplar disponible", listaHelpMailDatos, "Ya puede acercarse a realizar su préstamo de ejemplar", "BRITANICO");

                HelpMail.Enviar("SACNET: Ejemplar reservado", EMAIL, itemvwUsuariosSAC.CorreoElectronico);
            }
        }
        return ESTA_RESERVADO;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ProDevolucion.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ProDevolucion.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] dr = dt.Select("Tipo =5");
            DataTable dt1 = dr.Length > 0 ? dr.CopyToDataTable() : new DataTable();

            if (dt1.Rows.Count > 0)
            {
                lblTituloPagina.Text = dt1.Rows[0]["CodigoOpcionNombre"].ToString();//oRolesOpciones.CodigoOpcionNombre;
                Page.Title = lblTituloPagina.Text;
                ButtonDevolucion.Visible = Convert.ToBoolean(dt1.Rows[0]["Flag_Nuevo"]);//oRolesOpciones.Flag_Nuevo;
            }

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = lblTituloPagina.Text;
            //ButtonDevolucion.Visible = oRolesOpciones.Flag_Nuevo;
            dt = null;
            dt1 = null;

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    #endregion

    //***ELVP: 27-09-2011 Renovación de Préstamos**********
    protected void ButtonRenovacion_Click(object sender, ImageClickEventArgs e)
    {
        if (ButtonRenovacion.CommandArgument == "Renovacion")
        {
            bool validaEjemplar = EjemplarParaRenovacion();
            bool validaUsuario = UsuarioParaRenovacion();

            if (validaEjemplar)
            {
                if (validaUsuario)
                {
                    HabilitarControlesRenovacion("R");
                    ButtonRenovacion.CommandArgument = "Confirmacion";
                }
            }
            if (!validaUsuario || !validaEjemplar)
            {
                ButtonRenovacion.Enabled = false;
                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                ButtonDevolucion.Enabled = false;
                ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                LimpiarDatosDelUsuario(false, string.Empty);
                pnlUsuario.Visible = false;
                pnlItem.Visible = false;
                TextBoxCodigoEjemplar.Enabled = true;
                LimpiarDatosDelEjemplar(false, TextBoxCodigoEjemplar.Text);

                labelFechaDevEstimada.Text = "";
                labelDevolucionDato.Text = "";
                TextBoxCodigoEjemplar.Focus();
            }
        }
        else//Confirmacion
        {
            //System.Threading.Thread.Sleep(4000);
            ConfirmarRenovacionA_Usuario();
        }
    }

    protected void ButtonCancelar_Click(object sender, ImageClickEventArgs e)
    {
        HabilitarControlesRenovacion("D");
        ButtonRenovacion.CommandArgument = "Renovacion";
    }

    protected void HabilitarControlesRenovacion(string operacion)
    {
        labelFechaPrestamoDato.Text = DateTime.Now.ToLongDateString();

        if (operacion == "R")//Renovación
        {
            ButtonDevolucion.Enabled = false;
            ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Confirmar_I.jpg";

            ButtonCancelar.Enabled = true;
            labelFechaDevolucionDato.Visible = false;
            labelFechaDevEstimada.Visible = false;

            labelFechaPrestamoDato.Visible = true;
            labelDevolucionDato.Visible = true;

            lblFechaOperacion.Text = "Fecha de Préstamo: ";
            lblFechaDevolucionEstimada.Text = "Fecha de Devolución: ";

            MessageBox1.ShowWarning("¡ Las fechas han sido recalculadas por favor verifique antes de Confirmar !");
        }
        else//Devolución
        {
            ButtonDevolucion.Enabled = true;
            ButtonDevolucion.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Confirmar_I.jpg";

            ButtonCancelar.Enabled = false;
            labelFechaDevolucionDato.Visible = true;
            labelFechaDevEstimada.Visible = true;

            labelFechaPrestamoDato.Visible = false;
            labelDevolucionDato.Visible = false;

            lblFechaOperacion.Text = "Fecha de devolución: ";
            lblFechaDevolucionEstimada.Text = "Devolución estimada: ";
        }
    }

    bool UsuarioParaRenovacion()
    {
        bool result = false;
        string PRESTAMO_A_NO_MATRICULADOS = "S";
        HF_FechaFinalClase.Value = string.Empty;
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        {
            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de renovación de préstamo !");
            Auditoria1.CargarSeguridadInicio();
            TextBoxCodigoEjemplar.Enabled = false;
            ButtonRenovacion.Enabled = false;
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
            pnlUsuario.Visible = true;
            LimpiarDatosDelUsuario(false, string.Empty);
            pnlUsuario.Visible = false;
            result = false;
        }
        else if (HF_CodUsuario.Value.Length > 0)
        {
            vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
            vwUsuariosSAC xkvwUsuariosSAC = new vwUsuariosSAC();
            xkvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(HF_CodUsuario.Value);

            int DIAS_DE_ENTREGA = 0;

            if (xkvwUsuariosSAC.CodUsuarioSAC != null)
            {
                if (xkvwUsuariosSAC.CodLocalSACNombre != null)
                {
                    //*Modificado ultimo**************|| !xkvwUsuariosSAC.EsMatriculado****// 20110201
                    if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.PrestamosA_NOMatriculados) == PRESTAMO_A_NO_MATRICULADOS)
                        xkvwUsuariosSAC.EsMatriculado = true;
                    //*Modificado ultimo**************|| !xkvwUsuariosSAC.EsMatriculado****//
                    //if (xkvwUsuariosSAC.EsMatriculado || !xkvwUsuariosSAC.EsMatriculado)
                    if (xkvwUsuariosSAC.EsMatriculado) //|| !xkvwUsuariosSAC.EsMatriculado
                    {
                        if (xkvwUsuariosSAC.EsAlumno == "A")
                        {
                            DIAS_DE_ENTREGA = Util.DiasDePrestamo(DateTime.Now, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasPrestamoUsua)), 0, false,ucUsuario1.prm_Sabado);
                            //HF_EsUsuarioAL.Value = "1";
                        }
                        else
                        {
                            DIAS_DE_ENTREGA = Util.DiasDePrestamo(DateTime.Now, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasPrestamoProf)), 0, false,ucUsuario1.prm_Sabado);
                            //HF_EsUsuarioAL.Value = "0";

                        }


                        labelDevolucionDato.Text = DateTime.Now.AddDays(DIAS_DE_ENTREGA).ToLongDateString();
                        HF_FechaEntrega.Value = DateTime.Now.AddDays(DIAS_DE_ENTREGA).ToShortDateString();


                        UsuariosBloqueadosLogic oUsuariosBloqueadosLogic = new UsuariosBloqueadosLogic();
                        UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados();
                        itemUsuariosBloqueados = oUsuariosBloqueadosLogic.Buscar(HF_CodUsuario.Value, true);

                        if (itemUsuariosBloqueados.sCodUsuarioSAC != null)
                        {
                            if (DateTime.Now < itemUsuariosBloqueados.dFechaBloqueoOFF)
                            {
                                MessageBox1.ShowInfo("¡ El usuario esta bloqueado para renovación de préstamos, se habilitará el : " + itemUsuariosBloqueados.dFechaBloqueoOFF.ToShortDateString() + " !");
                                ucUsuario1.prm_CodUsuarioSAC = itemUsuariosBloqueados.sCodUsuarioSAC;
                                ucUsuario1.CargarDatosDeUsuarioSAC();
                                Auditoria1.CargarSeguridad(itemUsuariosBloqueados.SSIUsuario_Creacion, itemUsuariosBloqueados.SSIUsuario_Modificacion, itemUsuariosBloqueados.SSIFechaHora_Creacion, itemUsuariosBloqueados.SSIFechaHora_Modificacion, itemUsuariosBloqueados.SSIHost);
                                TextBoxCodigoEjemplar.Enabled = false;
                                ButtonRenovacion.Enabled = false;
                                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                                pnlUsuario.Visible = true;
                                result = false;
                            }
                            else
                            {
                                TextBoxCodigoEjemplar.Enabled = true;
                                pnlUsuario.Visible = true;
                                ButtonRenovacion.Enabled = true;
                                //HF_CodPrestamo.Value = string.Empty;
                                ucUsuario1.prm_CodUsuarioSAC = HF_CodUsuario.Value;
                                ucUsuario1.CargarDatosDeUsuarioSAC();

                                //ValidarFechaDeFinDeCursos(xkvwUsuariosSAC);

                                if (ValidarFechaDeFinDeCursos(xkvwUsuariosSAC, HF_TipoPrestamoCOD.Value))
                                {
                                    Auditoria1.CargarSeguridadInicio();
                                    result = true;
                                }
                                else
                                    result = false;
                            }
                        }
                        else if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
                        {
                            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de renovación de préstamo, no esta asignado a un SAC. !");
                            TextBoxCodigoEjemplar.Enabled = false;
                            ButtonRenovacion.Enabled = false;
                            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                            LimpiarDatosDelUsuario(false, string.Empty);
                            pnlUsuario.Visible = false;
                            result = false;
                        }
                        else
                        {
                            TextBoxCodigoEjemplar.Enabled = true;
                            ButtonRenovacion.Enabled = true;
                            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                            pnlUsuario.Visible = true;
                            //HF_CodPrestamo.Value = string.Empty;
                            ucUsuario1.prm_CodUsuarioSAC = HF_CodUsuario.Value;
                            ucUsuario1.CargarDatosDeUsuarioSAC();

                            //ValidarFechaDeFinDeCursos(xkvwUsuariosSAC);

                            if (ValidarFechaDeFinDeCursos(xkvwUsuariosSAC, HF_TipoPrestamoCOD.Value))
                            {
                                Auditoria1.CargarSeguridadInicio();
                                result = true;
                            }
                            else
                                result = false;
                        }
                        //ESALDARRIAGA 12/09/2011
                        if (xkvwUsuariosSAC.EsAlumno == "A")
                            ucUsuario1.MostrarFotografia(xkvwUsuariosSAC.CodUsuarioSAC);
                        else
                            ucUsuario1.OcultaFotografia();
                        //ESALDARRIAGA 12/09/2011                       
                    }
                    else
                    {
                        MessageBox1.ShowWarning("¡ Usuario SAC no puede realizar renovación de préstamo, no esta matriculado a un SAC. !");
                        TextBoxCodigoEjemplar.Enabled = false;
                        ButtonRenovacion.Enabled = false;
                        ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                        LimpiarDatosDelUsuario(false, string.Empty);
                        pnlUsuario.Visible = false;
                        result = false;
                    }
                }
                else
                {

                    MessageBox1.ShowWarning("¡ Código de usuario SAC no pertenece a ningún SAC. !");
                    //HF_EsUsuarioAL.Value = "";

                    labelDevolucionDato.Text = string.Empty;
                    HF_FechaEntrega.Value = string.Empty;

                    TextBoxCodigoEjemplar.Enabled = false;
                    ButtonRenovacion.Enabled = false;
                    ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                    LimpiarDatosDelUsuario(false, string.Empty);
                    pnlUsuario.Visible = false;
                    result = false;

                }
            }
            else
            {
                MessageBox1.ShowWarning("¡ Código de usuario SAC no está registrado en el sistema. !");
                //HF_EsUsuarioAL.Value = "";

                labelDevolucionDato.Text = string.Empty;
                HF_FechaEntrega.Value = string.Empty;

                TextBoxCodigoEjemplar.Enabled = false;
                ButtonRenovacion.Enabled = false;
                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                LimpiarDatosDelUsuario(false, string.Empty);
                pnlUsuario.Visible = false;
                result = false;
            }
        }
        else
        {
            LimpiarDatosDelUsuario(false, string.Empty);
            result = false;
        }
        return result;
    }

    bool EjemplarParaRenovacion()
    {
        bool result = false;
        if (TextBoxCodigoEjemplar.Text.Trim().Length > 0)
        {
            ItemLogic oItemLogic = new ItemLogic();
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            ReturnValor oReturnValor = new ReturnValor();

            Label lblTipoPrestamoCOD = null;
            //lblTipoPrestamoCOD = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;

            ItemEjemplar itemItemEjemplar = new ItemEjemplar();
            vwUsuariosSAC ovwUsuariosSAC = (vwUsuariosSAC)Session["UsuarioSAC"];
            itemItemEjemplar = oItemEjemplarLogic.Buscar(TextBoxCodigoEjemplar.Text.Trim(), ovwUsuariosSAC.CodLocalSAC);

            List<Prestamo> listaPrestamo = new List<Prestamo>();
            listaPrestamo = new PrestamoLogic().Listar(string.Empty, null, null, HF_CodUsuario.Value, string.Empty, TextBoxCodigoEjemplar.Text.Trim(), string.Empty, true, string.Empty, null, PrestamoLogic.TipoDeOperacion.OperReserva);

            Prestamo itemReservado = new Prestamo();
            oReturnValor = new ItemEjemplarLogic().DetectarEjemplarEnReserva(TextBoxCodigoEjemplar.Text, ref itemReservado);

            if (itemItemEjemplar.sCodEjemplar != null)
            {
                if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar))//EN PRÉSTAMO
                {
                    //Verificar que sea el mismo usuario que realizó el préstamo
                    Prestamo itemPrestamo = new Prestamo();
                    oReturnValor = oItemEjemplarLogic.DetectarEjemplarEnPrestamo(TextBoxCodigoEjemplar.Text, ref itemPrestamo);

                    if (itemPrestamo.sCodPrestamo != null)//ESTA EN PRESTAMO
                    {

                        //Verificar que el SAC donde hizo el PRESTAMO sea el mismo que el SAC donde se desea hacer la renovación
                        if (itemPrestamo.sCodSac == this.Master.HelpUsuariosSAC().CodLocalSAC)
                        {
                            //Verificar que sea el mismo usuario
                            if (itemPrestamo.sCodUsuarioSAC == HF_CodUsuario.Value)//Es el mismo usuario
                            {
                                DateTime FechaDevolucion = itemPrestamo.dFechaDevolucionEstimada.Value.AddDays(Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)));
                                if (DateTime.Today > FechaDevolucion)//Se ha excedido la fecha de devolución del ejemplar
                                {
                                    ButtonRenovacion.Enabled = false;
                                    pnlItem.Visible = false;
                                    string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                                    MessageBox1.ShowWarning("¡ Préstamo ha excedido la fecha de devolución límite, debe registrar la devolución del ejemplar " + LOCAL_SAC + " !");
                                    ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                                    TextBoxCodigoEjemplar.Text = string.Empty;
                                    result = false;
                                }
                                else
                                {
                                    //SE ACTIVA PARA RENOVACIÓN
                                    HF_CodPrestamo.Value = itemPrestamo.sCodPrestamo;
                                    HF_CentroPrestamo.Value = itemPrestamo.sCodSac;
                                    HF_FecDevEstimadaPrestamoOrigen.Value = itemPrestamo.dFechaDevolucionEstimada.ToString();
                                    HF_FecDevRealPrestamoOrigen.Value = DateTime.Now.ToShortDateString();
                                    LimpiarDatosDelEjemplar(false, TextBoxCodigoEjemplar.Text);
                                    lblTipoPrestamoCOD = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;
                                    HF_TipoPrestamoCOD.Value = lblTipoPrestamoCOD.Text;//ELVP: 20-12-2011

                                    //Verificar que el tipo de préstamo sea a DOMICILIO
                                    if (lblTipoPrestamoCOD.Text == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamoEnDomicilio))
                                    {
                                        pnlItem.Visible = true;
                                        LimpiarDatosDelEjemplar(true, TextBoxCodigoEjemplar.Text);
                                        result = true;
                                    }
                                    else//Préstamo en SALA
                                    {
                                        ButtonRenovacion.Enabled = false;
                                        pnlItem.Visible = false;
                                        string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                                        MessageBox1.ShowWarning("¡ Renovación no es válida para préstamos en sala " + LOCAL_SAC + " !");
                                        ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                                        TextBoxCodigoEjemplar.Text = string.Empty;
                                        result = false;
                                    }


                                }

                            }
                            else//Es otro usuario
                            {
                                ButtonRenovacion.Enabled = false;
                                pnlItem.Visible = false;
                                string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                                MessageBox1.ShowWarning("¡ Préstamo no corresponde al usuario ingresado " + LOCAL_SAC + " !");
                                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                                TextBoxCodigoEjemplar.Text = string.Empty;
                                result = false;
                            }
                        }
                        else//Es OTRO SAC
                        {
                            ButtonRenovacion.Enabled = false;
                            pnlItem.Visible = false;
                            string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                            MessageBox1.ShowWarning("¡ SAC de Préstamo no corresponde al SAC de renovación " + LOCAL_SAC + " !");
                            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                            TextBoxCodigoEjemplar.Text = string.Empty;
                            result = false;
                        }

                    }
                    else//No está en préstamo
                    {
                        ButtonRenovacion.Enabled = false;
                        pnlItem.Visible = false;
                        string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                        MessageBox1.ShowWarning("¡ Código de ejemplar no está en préstamo " + LOCAL_SAC + " !");
                        ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                        TextBoxCodigoEjemplar.Text = string.Empty;
                        result = false;
                    }

                    //LimpiarDatosDelEjemplar(false, string.Empty);
                    //ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    //MessageBox1.ShowInfo("¡ El ejemplar se encuentra en préstamo !");
                    //TextBoxCodigoEjemplar.Text = string.Empty;
                }
                else//No está en préstamo
                {
                    ButtonRenovacion.Enabled = false;
                    pnlItem.Visible = false;
                    string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                    MessageBox1.ShowWarning("¡ Código de ejemplar no está en préstamo " + LOCAL_SAC + " !");
                    ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                    TextBoxCodigoEjemplar.Text = string.Empty;
                    result = false;
                }
            }
            else
            {
                ButtonRenovacion.Enabled = false;
                pnlItem.Visible = false;
                string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                MessageBox1.ShowWarning("¡ Código de ejemplar no existe en el SAC " + LOCAL_SAC + " !");
                ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
                TextBoxCodigoEjemplar.Text = string.Empty;
                result = false;
            }
        }
        else
        {
            ButtonRenovacion.Enabled = false;
            pnlItem.Visible = false;
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
            result = false;
        }
        return result;
    }

    private string ValidarRenovacion()
    {
        string mensage = "";
        Label lblCodEjemp = null;
        lblCodEjemp = ucItem1.FindControl("LabelEstadoEjemplarCOD") as Label;
        Label lblNomUsuarioSAC = null;
        lblNomUsuarioSAC = ucUsuario1.FindControl("TextBoxNombresApellidos") as Label;

        if (TextBoxCodigoEjemplar.Text.Trim().Length == 0 || TextBoxCodigoEjemplar.Text == "") mensage = mensage + "¡ Código de ejemplar no existe !" + "</br>";
        if (lblNomUsuarioSAC.Text.Trim().Length == 0 || HF_CodUsuario.Value == "") mensage = mensage + "¡ Código de usuario SAC no existe !" + "</br>";

        //if (HF_EsUsuarioAL.Value == "1")
            //if (HF_CodPrestamo.Value.Length > 0)
            //    mensage = mensage + "¡ El usuario tiene pendiente la entrega de un ejemplar de ítem !" + "</br>";
            //if (HF_EjemplarRESV.Value.ToString().Length > 0)
            //    mensage = mensage + HF_EjemplarRESV.Value.ToString();
        if (mensage.Length > 0)
            mensage = mensage.Substring(2);
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
            mensage = mensage + "¡ Usuario no puede realizar la operación de renovación de préstamo, no esta asignado a un SAC. !" + "</br>";
        return mensage;
    }

    bool ValidarFechaDeFinDeCursos(vwUsuariosSAC xkvwUsuariosSAC, string prmCodArguTipoPrestamo)//ELVP: 20-12-2011
    {
        bool result = false;
        if (xkvwUsuariosSAC.EsAlumno == "A")
        {
            try
            {
                HF_FechaFinalClase.Value = ucUsuario1.prm_FechaFinalClases.ToShortDateString();
                DateTime dFechaFinalClase = Convert.ToDateTime(HF_FechaFinalClase.Value);//20/08/2011
                DateTime dFechaEntrega = Convert.ToDateTime(HF_FechaEntrega.Value);

                DateTime dFechaPosibleDev; //= Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true);
                //DateTime dFechaPosibleDev = Util.DiasDeDevolucionNuevo(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true);

                if (prmCodArguTipoPrestamo == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamoEnDomicilio))
                {
                    dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true, ucUsuario1.prm_Sabado);
                    
                    if (dFechaPosibleDev <= dFechaFinalClase)
                    {
                        if (dFechaPosibleDev < DateTime.Today)
                        {
                            MessageBox1.ShowWarning("¡ El alumno no puedo realizar esta transacción, debido a que la fecha excede a las fechas de fin de curso matriculados !");
                            TextBoxCodigoEjemplar.Enabled = false;
                            labelDevolucionDato.Text = dFechaFinalClase.ToLongDateString();
                            HF_FechaEntrega.Value = dFechaFinalClase.ToShortDateString();
                            result = false;
                        }
                        else
                        {
                            if (dFechaEntrega >= dFechaPosibleDev)
                            {
                                dFechaEntrega = dFechaPosibleDev;
                            }
                            labelDevolucionDato.Text = dFechaEntrega.ToLongDateString();
                            //labelDevolucionDato.Text = dFechaPosibleDev.ToLongDateString();

                            HF_FechaEntrega.Value = dFechaEntrega.ToShortDateString();
                            result = true;
                        }
                    }
                }
                else//En sala. No existe renovación para préstamos en sala
                {
                    ////ELVP: 27-12-2011 Se cambio fecha de devolución hasta 1 día antes a EL MISMO DÍA DE FIN DE CLASES
                    ////dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, 1, 0, true);
                    //dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, 0, 0, true);
                    //if (dFechaPosibleDev <= dFechaFinalClase)
                    //{
                    //    if (dFechaPosibleDev < DateTime.Today)
                    //    {
                    //        MessageBox1.ShowWarning("¡ El alumno ya esta fuera de sus fechas de fin de curso matriculados ! - ");
                    //        TextBoxCodigoEjemplar.Enabled = false;
                    //        labelDevolucionDato.Text = dFechaFinalClase.ToLongDateString();
                    //        HF_FechaEntrega.Value = dFechaFinalClase.ToShortDateString();

                    //        result = false;
                    //    }
                    //    else
                    //    {
                    //        if (dFechaEntrega >= dFechaPosibleDev)
                    //        {
                    //            dFechaEntrega = dFechaPosibleDev;
                    //        }
                    //        labelDevolucionDato.Text = dFechaEntrega.ToLongDateString();
                    //        //labelDevolucionDato.Text = dFechaPosibleDev.ToLongDateString();

                    //        HF_FechaEntrega.Value = dFechaEntrega.ToShortDateString();
                    //    }
                    //}

                }//Fin sala


            }
            catch (Exception ex)
            {
                MessageBox1.ShowWarning("¡ Alumno no tiene cursos matriculados, no se puede encontrar fecha de fin de curso ! ");
                labelDevolucionDato.Text = string.Empty;
                HF_FechaEntrega.Value = string.Empty;
                TextBoxCodigoEjemplar.Enabled = false;
                result = false;
            }
        }
        else
        {
            HF_FechaFinalClase.Value = string.Empty;
            result = false;
        }
        return result;
    }

    private void LimpiarDatosDelUsuario(bool TEXTBOX, string p_CodUsuarioSAC)
    {
        TextBoxCodigoEjemplar.Enabled = TEXTBOX;
        ButtonRenovacion.Enabled = TEXTBOX;
        ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
        ucUsuario1.prm_CodUsuarioSAC = p_CodUsuarioSAC;
        ucUsuario1.CargarDatosDeUsuarioSAC();
        if (TEXTBOX)
            pnlUsuario.Visible = true;
        else
            pnlUsuario.Visible = false;
    }

    private void LimpiarDatosDelEjemplar(bool BOTON, string p_CodigoEjemplar)
    {
        ButtonRenovacion.Enabled = BOTON;
        ucItem1.CargarDatosDeItemEjemplar(p_CodigoEjemplar);
        if (BOTON)
        {
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_A.jpg";
            pnlItem.Visible = true;
        }
        else
        {
            ButtonRenovacion.ImageUrl = "~/Comun/Imagenes/Botones/Renovar_I.jpg";
            pnlItem.Visible = false;
        }
    }

    private void ConfirmarRenovacionA_Usuario()
    {
        Prestamo itemPrestamo_Prestamo;
        Prestamo itemPrestamo_Devolucion;
        Label lblCodSAC = null;
        Label lblCodPres = null;
        HiddenField hfCodUsuarioSac = null;
        lblCodSAC = ucUsuario1.FindControl("TextBoxCodSAC") as Label;
        lblCodPres = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;
        hfCodUsuarioSac = ucUsuario1.FindControl("HF_CodUsuarioSAC") as HiddenField;

        //Actualiza el registro de prestamo en la DEVOLUCION REAL
        itemPrestamo_Devolucion = new Prestamo
        {
            sCodPrestamo = HF_CodPrestamo.Value,
            sCodUsuarioSAC = hfCodUsuarioSac.Value,
            sCodEjemplar = TextBoxCodigoEjemplar.Text,
            sCodSacDevuelto = this.Master.HelpUsuariosSAC().CodLocalSAC.Trim(),
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName,
            dFechaDevolucionEstimada = Convert.ToDateTime(HF_FecDevEstimadaPrestamoOrigen.Value),
            dFechaDevolucionReal = DateTime.Now,
            sCodSac = HF_CentroPrestamo.Value,
        };

        ReturnValor oReturnValor = new ReturnValor();
        DateTime FechaFinSuspension = Convert.ToDateTime(HF_FecDevEstimadaPrestamoOrigen.Value).AddDays(Util.DiasDePrestamo(Convert.ToDateTime(HF_FecDevRealPrestamoOrigen.Value), Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasSuspendido)), Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)), false,ucUsuario1.prm_Sabado));

        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        //oReturnValor = oPrestamoLogic.ActualizarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperDevolucion, FechaFinSuspension);

        //Registrar PRÉSTAMO
        itemPrestamo_Prestamo = new Prestamo
        {
            sCodUsuarioSAC = HF_CodUsuario.Value,
            sCodEjemplar = TextBoxCodigoEjemplar.Text,
            sCodSac = this.Master.HelpUsuariosSAC().CodLocalSAC,
            sCodSacUsuario = lblCodSAC.Text,
            sCodArguPrestamoEn = lblCodPres.Text,
            bCarnet = false,
            dFechaDevolucionEstimada = Convert.ToDateTime(HF_FechaEntrega.Value + " " + DateTime.Now.ToShortTimeString()),
            SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName,
            sCodPrestamoOrigen = HF_CodPrestamo.Value,
            bRenovacion = true,
        };

        //if (HF_CodPrestamoRSV.Value == string.Empty)
        oReturnValor = oPrestamoLogic.ActualizarOperacionesRenovacion(itemPrestamo_Prestamo, PrestamoLogic.TipoDeOperacion.OperRenovacion, FechaFinSuspension, itemPrestamo_Devolucion);
        //else
        //{
        //    itemPrestamo.sCodPrestamo = HF_CodPrestamoRSV.Value;
        //    oReturnValor = oPrestamoLogic.ActualizarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperPrestamo, DateTime.Now);
        //}

        if (oReturnValor.Exitosa)
        {
            LimpiarDatos(oReturnValor);
            //EjemplarParaDevolucion();
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    private void LimpiarDatos(ReturnValor oReturnValor)
    {
        TextBoxCodigoEjemplar.Text = string.Empty;
        HF_CodUsuario.Value = string.Empty;
        //EjemplarParaRenovacion();
        MessageBox1.ShowSuccess(oReturnValor.Message);
        HF_FechaEntrega.Value = string.Empty;
        HF_CodPrestamo.Value = string.Empty;
        labelDevolucionDato.Text = string.Empty;
        LimpiarDatosDelUsuario(false, string.Empty);
        LimpiarDatosDelEjemplar(false, string.Empty);
        TextBoxCodigoEjemplar.Enabled = true;

        ucItem1.CargarDatosDeItemEjemplar(TextBoxCodigoEjemplar.Text);
            
        lblFechaOperacion.Text = "Fecha de devolución: ";
        lblFechaDevolucionEstimada.Text = "Devolución estimada: ";
        labelFechaDevolucionDato.Visible = true;
        labelFechaDevEstimada.Visible = true;
        labelFechaDevEstimada.Text = "";
        labelFechaPrestamoDato.Visible = false;
        labelDevolucionDato.Visible = false;
        labelDevolucionDato.Text = "";
    }
    //*****************************************************

}
