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
using Britanico.SacNet.BusinessEntities;
using Oxinet.Tools;
using System.Collections.Generic;

public partial class ProPrestamo : System.Web.UI.Page
{
    #region --- EVENTOS DE FORMULARIO ---

    protected void Page_Load(object sender, EventArgs e)
    {
        Auditoria1.CargarSeguridadInicio();
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        if (!IsPostBack)
        {
            labelFechaPrestamoDato.Text = DateTime.Now.ToLongDateString();
            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            ButtonPrestamo.Enabled = false;
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

    }

    #endregion

    #region --- EVENTOS DE LOS CONTROLES ---

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmarPrestamoA_Usuario();
        }
    }

    protected void TextBoxCodigoUsuarioSAC_TextChanged(object sender, EventArgs e)
    {
        UsuarioParaPrestamo();
    }

    protected void TextBoxCodigoEjemplar_TextChanged(object sender, EventArgs e)
    {
        EjemplarParaPrestamo();
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "")
            {
                //txtBuscar.Text = Valores[2].ToString();
            }

        }
    }

    protected void ButtonPrestamo_Click(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma registrar el préstamo del usuario  ?", HelpEvento.Guardar.ToString());

        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    #endregion

    #region --- MÉTODOS DEL PROGRAMADOR ---

    private string Validar()
    {
        string mensage = "";
        Label lblCodEjemp = null;
        lblCodEjemp = ucItem1.FindControl("LabelEstadoEjemplarCOD") as Label;
        Label lblNomUsuarioSAC = null;
        lblNomUsuarioSAC = ucUsuario1.FindControl("TextBoxNombresApellidos") as Label;

        if (TextBoxCodigoEjemplar.Text.Trim().Length == 0 || TextBoxCodigoEjemplar.Text == "") mensage = mensage + "¡ Código de ejemplar no existe !" + "</br>";
        if (lblNomUsuarioSAC.Text.Trim().Length == 0 || TextBoxCodigoUsuarioSAC.Text == "") mensage = mensage + "¡ Código de usuario SAC no existe !" + "</br>";

        if (HF_EsUsuarioAL.Value == "1")
            if (HF_CodPrestamo.Value.Length > 0)
                mensage = mensage + "¡ El usuario tiene pendiente la entrega de un ejemplar de ítem !" + "</br>";
        if (HF_EjemplarRESV.Value.ToString().Length > 0)
            mensage = mensage + HF_EjemplarRESV.Value.ToString();
        if (mensage.Length > 0)
            mensage = mensage.Substring(2);
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
            mensage = mensage + "¡ Usuario no puede realizar la operación de préstamo, no esta asignado a un SAC. !" + "</br>";
        return mensage;
    }

    private void UsuarioParaPrestamo()
    {
        string PRESTAMO_A_NO_MATRICULADOS = "S";
        HF_FechaFinalClase.Value = string.Empty;
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        {
            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de préstamo !");
            Auditoria1.CargarSeguridadInicio();
            TextBoxCodigoEjemplar.Enabled = false;
            ButtonPrestamo.Enabled = false;
            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            pnlUsuario.Visible = true;
            LimpiarDatosDelUsuario(false, string.Empty);
            pnlUsuario.Visible = false;
        }
        else if (TextBoxCodigoUsuarioSAC.Text.Trim().Length > 0)
        {
            vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
            vwUsuariosSAC xkvwUsuariosSAC = new vwUsuariosSAC();
            xkvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(TextBoxCodigoUsuarioSAC.Text.Trim());



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
                        //UsuariosBloqueadosLogic oUsuariosBloqueadosLogic = new UsuariosBloqueadosLogic();
                        //UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados();
                        //itemUsuariosBloqueados = oUsuariosBloqueadosLogic.Buscar(TextBoxCodigoUsuarioSAC.Text.Trim(), true);

                        //if (itemUsuariosBloqueados.sCodUsuarioSAC != null)
                        //{
                            //if (DateTime.Now.Date <= itemUsuariosBloqueados.dFechaBloqueoOFF.Date)
                            //{
                            //    MessageBox1.ShowInfo("¡ El usuario esta bloqueado para préstamos, se habilitará el : " + itemUsuariosBloqueados.dFechaBloqueoOFF.AddDays(1).ToShortDateString() + " !");
                            //    ucUsuario1.prm_CodUsuarioSAC = itemUsuariosBloqueados.sCodUsuarioSAC;
                            //    ucUsuario1.CargarDatosDeUsuarioSAC();
                            //    Auditoria1.CargarSeguridad(itemUsuariosBloqueados.SSIUsuario_Creacion, itemUsuariosBloqueados.SSIUsuario_Modificacion, itemUsuariosBloqueados.SSIFechaHora_Creacion, itemUsuariosBloqueados.SSIFechaHora_Modificacion, itemUsuariosBloqueados.SSIHost);
                            //    TextBoxCodigoEjemplar.Enabled = false;
                            //    ButtonPrestamo.Enabled = false;
                            //    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            //    pnlUsuario.Visible = true;
                            //}
                            //else
                            //{
                            //    TextBoxCodigoEjemplar.Enabled = true;
                            //    pnlUsuario.Visible = true;
                            //    ButtonPrestamo.Enabled = false;
                            //    HF_CodPrestamo.Value = string.Empty;
                            //    ucUsuario1.prm_CodUsuarioSAC = TextBoxCodigoUsuarioSAC.Text;
                            //    ucUsuario1.CargarDatosDeUsuarioSAC();
                                
                            //    HF_FechaFinalClase.Value = ucUsuario1.prm_FechaFinalClases.ToShortDateString();//ELVP:26-09-2011
                            //    //ValidarFechaDeFinDeCursos(xkvwUsuariosSAC);//ELVP: 26-09-2011 

                            //    Auditoria1.CargarSeguridadInicio();
                            //}
                        //}
                        //else if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
                        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
                        {
                            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de préstamo, no esta asignado a un SAC. !");
                            TextBoxCodigoEjemplar.Enabled = false;
                            ButtonPrestamo.Enabled = false;
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            LimpiarDatosDelUsuario(false, string.Empty);
                            pnlUsuario.Visible = false;
                        }
                        else
                        {
                            TextBoxCodigoEjemplar.Enabled = true;
                            ButtonPrestamo.Enabled = false;
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            pnlUsuario.Visible = true;
                            HF_CodPrestamo.Value = string.Empty;
                            ucUsuario1.prm_CodUsuarioSAC = TextBoxCodigoUsuarioSAC.Text;
                            ucUsuario1.CargarDatosDeUsuarioSAC();

                            HF_FechaFinalClase.Value = ucUsuario1.prm_FechaFinalClases.ToShortDateString();//ELVP:26-09-2011
                            //ValidarFechaDeFinDeCursos(xkvwUsuariosSAC);//ELVP: 26-09-2011

                            Auditoria1.CargarSeguridadInicio();
                        }
                        //ESALDARRIAGA 04/10/2011
                        
                        if (xkvwUsuariosSAC.EsAlumno == "A")
                        {
                            DIAS_DE_ENTREGA = Util.DiasDePrestamo(DateTime.Now, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasPrestamoUsua)), 0, false,ucUsuario1.prm_Sabado);
                            HF_EsUsuarioAL.Value = "1";
                        }
                        else
                        {
                            DIAS_DE_ENTREGA = Util.DiasDePrestamo(DateTime.Now, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasPrestamoProf)), 0, false,ucUsuario1.prm_Sabado);
                            HF_EsUsuarioAL.Value = "0";

                        }

                        //Descomentar
                        labelDevolucionDato.Text = DateTime.Now.AddDays(DIAS_DE_ENTREGA).ToLongDateString();
                        HF_FechaEntrega.Value = DateTime.Now.AddDays(DIAS_DE_ENTREGA).ToShortDateString();
                        //ESALDARRIAGA 04/10/2011

                        //ESALDARRIAGA 12/09/2011
                        if (xkvwUsuariosSAC.EsAlumno == "A")
                            ucUsuario1.MostrarFotografia(xkvwUsuariosSAC.CodUsuarioSAC);
                        else
                            ucUsuario1.OcultaFotografia();
                        //ESALDARRIAGA 12/09/2011                       
                    }
                    else
                    {
                        MessageBox1.ShowWarning("¡ Usuario SAC no puede realizar préstamo, no esta matriculado a un SAC. !");
                        TextBoxCodigoEjemplar.Enabled = false;
                        ButtonPrestamo.Enabled = false;
                        ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                        LimpiarDatosDelUsuario(false, string.Empty);
                        pnlUsuario.Visible = false;
                    }
                }
                else
                {

                    MessageBox1.ShowWarning("¡ Código de usuario SAC no pertenece a ningún SAC. !");
                    HF_EsUsuarioAL.Value = "";

                    labelDevolucionDato.Text = string.Empty;
                    HF_FechaEntrega.Value = string.Empty;

                    TextBoxCodigoEjemplar.Enabled = false;
                    ButtonPrestamo.Enabled = false;
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    LimpiarDatosDelUsuario(false, string.Empty);
                    pnlUsuario.Visible = false;


                }
            }
            else
            {
                MessageBox1.ShowWarning("¡ Código de usuario SAC no esta registrado en el sistema. !");
                HF_EsUsuarioAL.Value = "";

                labelDevolucionDato.Text = string.Empty;
                HF_FechaEntrega.Value = string.Empty;

                TextBoxCodigoEjemplar.Enabled = false;
                ButtonPrestamo.Enabled = false;
                ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                LimpiarDatosDelUsuario(false, string.Empty);
                pnlUsuario.Visible = false;
            }
        }
        else
        {
            LimpiarDatosDelUsuario(false, string.Empty);
        }

    }

    //private void ValidarFechaDeFinDeCursos(vwUsuariosSAC xkvwUsuariosSAC)
    bool ValidarFechaDeFinDeCursos(vwUsuariosSAC xkvwUsuariosSAC, string prmCodArguTipoPrestamo)//ELVP:26-09-2011
    {
        bool result = true;
        if (xkvwUsuariosSAC.EsAlumno == "A")
        {
            try
            {
                //HF_FechaFinalClase.Value = ucUsuario1.prm_FechaFinalClases.ToShortDateString();//ELVP:26-09-2011
                DateTime dFechaFinalClase = Convert.ToDateTime(HF_FechaFinalClase.Value);//20/08/2011
                DateTime dFechaEntrega = Convert.ToDateTime(HF_FechaEntrega.Value);
                DateTime dFechaPosibleDev;

                if (prmCodArguTipoPrestamo == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamoEnDomicilio))
                {
                    dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true, ucUsuario1.prm_Sabado);
                    //dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true);
                    //DateTime dFechaPosibleDev = Util.DiasDeDevolucionNuevo(dFechaFinalClase, dFechaEntrega, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasAntesFinDeCurso)), 0, true);

                    if (dFechaPosibleDev <= dFechaFinalClase)
                    {
                        if (dFechaPosibleDev < DateTime.Today)
                        {
                            MessageBox1.ShowWarning("¡ El alumno ya esta fuera de sus fechas de fin de curso matriculados ! - ");
                            TextBoxCodigoEjemplar.Enabled = false;
                            labelDevolucionDato.Text = dFechaFinalClase.ToLongDateString();
                            HF_FechaEntrega.Value = dFechaFinalClase.ToShortDateString();

                            LimpiarDatosDelEjemplar(false, string.Empty);
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            TextBoxCodigoEjemplar.Text = string.Empty;

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
                        }
                    }

                }
                else//En sala
                {
                    //ELVP: 27-12-2011 Se cambio fecha de devolución hasta 1 día antes a EL MISMO DÍA DE FIN DE CLASES
                    //dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, 1, 0, true);
                    dFechaPosibleDev = Util.DiasDeDevolucion(dFechaFinalClase, dFechaEntrega, 0, 0, true, ucUsuario1.prm_Sabado);
                    if (dFechaPosibleDev <= dFechaFinalClase)
                    {
                        if (dFechaPosibleDev < DateTime.Today)
                        {
                            MessageBox1.ShowWarning("¡ El alumno ya esta fuera de sus fechas de fin de curso matriculados ! - ");
                            TextBoxCodigoEjemplar.Enabled = false;
                            labelDevolucionDato.Text = dFechaFinalClase.ToLongDateString();
                            HF_FechaEntrega.Value = dFechaFinalClase.ToShortDateString();

                            LimpiarDatosDelEjemplar(false, string.Empty);
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            TextBoxCodigoEjemplar.Text = string.Empty;

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
                        }
                    }
                }


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
            result = true;
        }
        return result;
    }

    private bool ValidaPrestamoADomicilio(string prmCodArguTipoPrestamo)
    {
        List<Prestamo> listaPrestamoDomi = new List<Prestamo>();
        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
        listaPrestamoDomi = oItemEjemplarLogic.DetectarUsuarioEnDevolucionPendienteV2(TextBoxCodigoUsuarioSAC.Text, prmCodArguTipoPrestamo);

        bool VALIDA_PREST_DOMICILIO = true;
        if (prmCodArguTipoPrestamo == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamoEnDomicilio))
        {
            if (HF_EsUsuarioAL.Value == "1") // Alumno
                if (listaPrestamoDomi.Count == 0)
                    VALIDA_PREST_DOMICILIO = true;
                else
                    VALIDA_PREST_DOMICILIO = false;
            else if (HF_EsUsuarioAL.Value == "0") // Docente
                if (listaPrestamoDomi.Count < Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CantidadMaxEjemplaresDocente)))
                    VALIDA_PREST_DOMICILIO = true;
                else
                    VALIDA_PREST_DOMICILIO = false;
        }
        return VALIDA_PREST_DOMICILIO;
    }

    private bool ValidaDesbloqueoUsuario(string prmCodArguTipoPrestamo)
    {
        bool result = true;
        UsuariosBloqueadosLogic oUsuariosBloqueadosLogic = new UsuariosBloqueadosLogic();
        UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados();
        itemUsuariosBloqueados = oUsuariosBloqueadosLogic.Buscar(TextBoxCodigoUsuarioSAC.Text.Trim(), true);

        if (itemUsuariosBloqueados.sCodUsuarioSAC != null)
        {
            if (DateTime.Now.Date <= itemUsuariosBloqueados.dFechaBloqueoOFF.Date)
            {
                //Si está dentro de los días de bloqueo y es préstamo a domicilio devuelve false
                if (prmCodArguTipoPrestamo == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamoEnDomicilio))
                {
                    MessageBox1.ShowInfo("¡ El usuario esta bloqueado para préstamos a domicilio, se habilitará el : " + itemUsuariosBloqueados.dFechaBloqueoOFF.AddDays(1).ToShortDateString() + " !");
                    ucUsuario1.prm_CodUsuarioSAC = itemUsuariosBloqueados.sCodUsuarioSAC;
                    ucUsuario1.CargarDatosDeUsuarioSAC();
                    Auditoria1.CargarSeguridad(itemUsuariosBloqueados.SSIUsuario_Creacion, itemUsuariosBloqueados.SSIUsuario_Modificacion, itemUsuariosBloqueados.SSIFechaHora_Creacion, itemUsuariosBloqueados.SSIFechaHora_Modificacion, itemUsuariosBloqueados.SSIHost);
                    TextBoxCodigoEjemplar.Enabled = false;
                    ButtonPrestamo.Enabled = false;
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    pnlUsuario.Visible = true;

                    result = false;
                }
            }
        }

        return result;
    }

    private void EjemplarParaPrestamo()
    {
        if (TextBoxCodigoEjemplar.Text.Trim().Length > 0)
        {
            ItemLogic oItemLogic = new ItemLogic();
            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            ReturnValor oReturnValor = new ReturnValor();
            ItemEjemplar itemItemEjemplar = new ItemEjemplar();
            vwUsuariosSAC ovwUsuariosSAC = (vwUsuariosSAC)Session["UsuarioSAC"];
            itemItemEjemplar = oItemEjemplarLogic.Buscar(TextBoxCodigoEjemplar.Text.Trim(), ovwUsuariosSAC.CodLocalSAC);

            List<Prestamo> listaPrestamo = new List<Prestamo>();
            listaPrestamo = new PrestamoLogic().Listar(string.Empty, null, null, TextBoxCodigoUsuarioSAC.Text.Trim(), string.Empty, TextBoxCodigoEjemplar.Text.Trim(), string.Empty, true, string.Empty, null, PrestamoLogic.TipoDeOperacion.OperReserva);

            Prestamo itemReservado = new Prestamo();
            oReturnValor = new ItemEjemplarLogic().DetectarEjemplarEnReserva(TextBoxCodigoEjemplar.Text, ref itemReservado);

            if (itemItemEjemplar.sCodEjemplar != null)
            {
                if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar))
                {
                    LimpiarDatosDelEjemplar(false, string.Empty);
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    MessageBox1.ShowInfo("¡ El ejemplar se encuentra en préstamo !");
                    TextBoxCodigoEjemplar.Text = string.Empty;

                }
                else if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnDeteriodoEjemplar))
                {
                    LimpiarDatosDelEjemplar(false, string.Empty);
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    MessageBox1.ShowInfo("¡ El ejemplar se encuentra en estado descartado !");
                    TextBoxCodigoEjemplar.Text = string.Empty;
                }
                else if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransferenciaEjemplar))
                {
                    LimpiarDatosDelEjemplar(false, string.Empty);
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    MessageBox1.ShowInfo("¡ El ejemplar se encuentra en transferencia de SAC !");

                }
                else if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransitoEjemplar))
                {
                    LimpiarDatosDelEjemplar(false, string.Empty);
                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    MessageBox1.ShowInfo("¡ El ejemplar se encuentra en tránsito de devolución al SAC !");

                }
                else
                {
                    if (listaPrestamo.Count == 1)
                    {
                        if (listaPrestamo[0].dFechaInicioReserva != null)
                        {
                            
                            double xDIAS_RSV = Util.DiasDePrestamo(listaPrestamo[0].dFechaInicioReserva.Value, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasReservaVigen)), 0, false,ucUsuario1.prm_Sabado);
                            DateTime FechaVencReservado = Convert.ToDateTime(listaPrestamo[0].dFechaInicioReserva.Value.AddDays(xDIAS_RSV).ToShortDateString());
                            DateTime FechaInicReservado = Convert.ToDateTime(listaPrestamo[0].dFechaInicioReserva.Value.ToShortDateString());
                            if (FechaVencReservado <= DateTime.Today || FechaVencReservado >= FechaInicReservado)
                            {
                                HF_CodPrestamoRSV.Value = listaPrestamo[0].sCodPrestamo;
                                HF_EjemplarRESV.Value = string.Empty;
                            }
                            else
                                HF_CodPrestamoRSV.Value = string.Empty;
                        }
                    }
                    if (itemReservado.sCodEjemplar != null)
                    {
                        if (itemReservado.sCodUsuarioSAC != TextBoxCodigoUsuarioSAC.Text)
                        {
                            if (itemReservado.dFechaInicioReserva != null)
                            {
                                double dDIAS_VIGENCIA = (double)Util.DiasDePrestamo(itemReservado.dFechaInicioReserva.Value,
                                                                Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasReservaVigen)),
                                                                0, true,ucUsuario1.prm_Sabado);
                                DateTime FechaVencReservado = Convert.ToDateTime(itemReservado.dFechaInicioReserva.Value.AddDays(dDIAS_VIGENCIA).ToShortDateString());
                                if (FechaVencReservado >= DateTime.Today)
                                {
                                    LimpiarDatosDelEjemplar(false, string.Empty);
                                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                                    MessageBox1.ShowInfo("¡ Ejemplar está reservado por el usuario SAC: ( " + itemReservado.sCodUsuarioSAC + " ) " + itemReservado.sCodUsuarioSACNombres + " !" + "</br>" +
                                                         " Activado el: ( " + itemReservado.dFechaInicioReserva.Value.ToLongDateString() + "</br>" +
                                                         " Vence el: ( " + FechaVencReservado.ToLongDateString() + " )");
                                }
                                else
                                {
                                    LimpiarDatosDelEjemplar(true, TextBoxCodigoEjemplar.Text);
                                    pnlItem.Visible = true;
                                    ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
                                }
                            }
                            else
                            {
                                LimpiarDatosDelEjemplar(false, string.Empty);
                                ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                                MessageBox1.ShowInfo("¡ Ejemplar está reservado por el usuario SAC: ( " + itemReservado.sCodUsuarioSAC + " ) " + itemReservado.sCodUsuarioSACNombres + " !" + "</br>" +
                                                    " Solicitado el: ( " + itemReservado.dFechaSolicitudReserva.Value.ToLongDateString() + " )");
                            }
                        }
                        else
                        {
                            HF_CodPrestamoRSV.Value = itemReservado.sCodPrestamo;
                            HF_EjemplarRESV.Value = "";
                            pnlItem.Visible = true;
                            LimpiarDatosDelEjemplar(true, TextBoxCodigoEjemplar.Text);
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
                        }
                    }
                    else if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar))
                    {
                        LimpiarDatosDelEjemplar(false, TextBoxCodigoEjemplar.Text);
                        Label lblTipoPrestamoCOD = null;
                        lblTipoPrestamoCOD = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;
                        pnlItem.Visible = true;

                        //*************************************************
                        //ELVP: 26-09-2011 Validación de fecha límite de préstamo sólo para Préstamos a Domicilio
                        vwUsuariosSAC xkvwUsuariosSAC = new vwUsuariosSAC();
                        xkvwUsuariosSAC = new vwDatosVistaLogic().Buscarvw_UsuariosSAC(TextBoxCodigoUsuarioSAC.Text.Trim());
                        if (ValidarFechaDeFinDeCursos(xkvwUsuariosSAC, lblTipoPrestamoCOD.Text))
                        {
                            //Valida cantidad de ejemplares límite para préstamos a domicilio
                            if (!ValidaPrestamoADomicilio(lblTipoPrestamoCOD.Text))
                            {
                                ButtonPrestamo.Enabled = false;
                                MessageBox1.ShowWarning("¡ Usuario SAC tiene ocupado la cantidad límite de ejemplares para prestamo a domicilio. !");
                            }
                            else
                            {
                                //Validar que usuario NO esté bloqueado sólo para Préstamos a Domicilio
                                if (ValidaDesbloqueoUsuario(lblTipoPrestamoCOD.Text))
                                    LimpiarDatosDelEjemplar(true, TextBoxCodigoEjemplar.Text);
                            }
                        }
                        //*************************************************


                    }
                    else
                    {
                        LimpiarDatosDelEjemplar(false, TextBoxCodigoEjemplar.Text);
                        Label lblTipoPrestamoCOD = null;
                        lblTipoPrestamoCOD = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;
                        pnlItem.Visible = true;
                        if (!ValidaPrestamoADomicilio(lblTipoPrestamoCOD.Text))
                        {
                            ButtonPrestamo.Enabled = false;
                            MessageBox1.ShowWarning("¡ Usuario SAC tiene ocupado la cantidad límite de ejemplares para prestamo a domicilio. !");
                        }
                        else
                        {
                            HF_EjemplarRESV.Value = "";
                            LimpiarDatosDelEjemplar(true, TextBoxCodigoEjemplar.Text);
                            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
                        }
                    }
                }
            }
            else
            {
                ButtonPrestamo.Enabled = false;
                pnlItem.Visible = false;
                string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                MessageBox1.ShowWarning("¡ Código de ejemplar no existe en el SAC " + LOCAL_SAC + " !");
                ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                TextBoxCodigoEjemplar.Text = string.Empty;
            }
        }
        else
        {
            ButtonPrestamo.Enabled = false;
            pnlItem.Visible = false;
            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
        }
    }

    private void LimpiarDatosDelUsuario(bool TEXTBOX, string p_CodUsuarioSAC)
    {
        TextBoxCodigoEjemplar.Enabled = TEXTBOX;
        ButtonPrestamo.Enabled = TEXTBOX;
        ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
        ucUsuario1.prm_CodUsuarioSAC = p_CodUsuarioSAC;
        ucUsuario1.CargarDatosDeUsuarioSAC();
        if (TEXTBOX)
            pnlUsuario.Visible = true;
        else
            pnlUsuario.Visible = false;
    }

    private void LimpiarDatosDelEjemplar(bool BOTON, string p_CodigoEjemplar)
    {
        ButtonPrestamo.Enabled = BOTON;
        ucItem1.CargarDatosDeItemEjemplar(p_CodigoEjemplar);
        if (BOTON)
        {
            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
            pnlItem.Visible = true;
        }
        else
        {
            ButtonPrestamo.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            pnlItem.Visible = false;
        }
    }

    private void ConfirmarPrestamoA_Usuario()
    {
        Prestamo itemPrestamo;
        Label lblCodSAC = null;
        Label lblCodPres = null;
        lblCodSAC = ucUsuario1.FindControl("TextBoxCodSAC") as Label;
        lblCodPres = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;

        itemPrestamo = new Prestamo
        {
            sCodUsuarioSAC = TextBoxCodigoUsuarioSAC.Text,
            sCodEjemplar = TextBoxCodigoEjemplar.Text,
            sCodSac = this.Master.HelpUsuariosSAC().CodLocalSAC,
            sCodSacUsuario = lblCodSAC.Text,
            sCodArguPrestamoEn = lblCodPres.Text,
            bCarnet = CheckBoxConCarne.Checked,
            dFechaDevolucionEstimada = Convert.ToDateTime(HF_FechaEntrega.Value + " " + DateTime.Now.ToShortTimeString()),
            SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName,
            sCodPrestamoOrigen = null,
            bRenovacion = false,
        };

        ReturnValor oReturnValor = new ReturnValor();
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        if (HF_CodPrestamoRSV.Value == string.Empty)
            oReturnValor = oPrestamoLogic.RegistrarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperPrestamo);
        else
        {
            itemPrestamo.sCodPrestamo = HF_CodPrestamoRSV.Value;
            oReturnValor = oPrestamoLogic.ActualizarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperPrestamo, DateTime.Now);
        }
        if (oReturnValor.Exitosa)
        {
            LimpiarDatos(oReturnValor);
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    private void LimpiarDatos(ReturnValor oReturnValor)
    {
        TextBoxCodigoEjemplar.Text = string.Empty;
        TextBoxCodigoUsuarioSAC.Text = string.Empty;
        EjemplarParaPrestamo();
        MessageBox1.ShowSuccess(oReturnValor.Message);
        HF_UsuarioLOCK.Value = string.Empty;
        HF_FechaEntrega.Value = string.Empty;
        HF_EsUsuarioAL.Value = string.Empty;
        HF_EjemplarRESV.Value = string.Empty;
        HF_CodPrestamoRSV.Value = string.Empty;
        HF_CodPrestamo.Value = string.Empty;
        labelDevolucionDato.Text = string.Empty;
        LimpiarDatosDelUsuario(false, string.Empty);
        LimpiarDatosDelEjemplar(false, string.Empty);
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ProPrestamo.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ProPrestamo.aspx");//ELVP:11-10-2011
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
                ButtonPrestamo.Visible = Convert.ToBoolean(dt1.Rows[0]["Flag_Nuevo"]);//oRolesOpciones.Flag_Nuevo;
            }

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //Page.Title = lblTituloPagina.Text;
            //ButtonPrestamo.Visible = oRolesOpciones.Flag_Nuevo;

            dt = null;
            dt1 = null;
            dr = null;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    #endregion

    protected void CheckBoxEnSala_CheckedChanged(object sender, EventArgs e)
    {
        UsuarioParaPrestamo();
    }
}
