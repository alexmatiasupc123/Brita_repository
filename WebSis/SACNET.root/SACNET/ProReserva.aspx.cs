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

public partial class ProReservaV1 : System.Web.UI.Page
{
    #region --- EVENTOS DE LA PÁGINA ---

    protected void Page_Load(object sender, EventArgs e)
    {
        Auditoria1.CargarSeguridadInicio();
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        if (!IsPostBack)
        {
            labelFechaReservaDato.Text = DateTime.Now.ToLongDateString();
            ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            ButtonReservar.Enabled = false;
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
            ConfirmarReservaA_Usuario();
        }
    }

    protected void TextBoxCodEjemplar_TextChanged(object sender, EventArgs e)
    {
        EjemplarParaReserva();
    }

    protected void TextBoxCodUsuario_TextChanged(object sender, EventArgs e)
    {
        UsuarioParaReserva();
    }

    protected void CheckBoxReserva_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox TieneReserva = ((CheckBox)sender);
        foreach (GridViewRow item in gvItems.Rows)
        {
            CheckBox TieneReserva2;
            TieneReserva2 = ((CheckBox)item.Cells[6].FindControl("CheckBoxReserva"));
            if (Convert.ToInt32(TieneReserva.ValidationGroup) != item.RowIndex)
            {
                TieneReserva2.Checked = false;
            }
            else
            {
                ucItem1.CargarDatosDeItemEjemplar(item.Cells[1].Text);
                ButtonReservar.Enabled = true;
                ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
                pnlItem.Visible = false;
            }
        }
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView IOK = (DataRowView)e.Row.DataItem;

            if (IOK.Row[4].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar) || 
                IOK.Row[4].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar) || 
                IOK.Row[4].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransferenciaEjemplar) ||
                IOK.Row[4].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnDeteriodoEjemplar)||
                IOK.Row[4].ToString() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransitoEjemplar))
            {
                string dato = IOK.Row[5].ToString();
                if (dato == "True")
                {
                    ((CheckBox)e.Row.Cells[7].FindControl("CheckBoxReserva")).Visible = false;
                }
                else
                {
                    if (IOK.Row[4].ToString() != HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransferenciaEjemplar))
                        ((CheckBox)e.Row.Cells[7].FindControl("CheckBoxReserva")).Visible = true;
                    else
                        ((CheckBox)e.Row.Cells[7].FindControl("CheckBoxReserva")).Visible = false;
                }
            }
            else
                ((CheckBox)e.Row.Cells[7].FindControl("CheckBoxReserva")).Visible = false;

            CheckBox TieneReserva;
            TieneReserva = ((CheckBox)e.Row.Cells[7].FindControl("CheckBoxReserva"));
            TieneReserva.ValidationGroup = e.Row.RowIndex.ToString();

            //Label EstaReservado = ((Label)e.Row.Cells[5].FindControl("LabelReser"));
            //if (EstaReservado.Text == "True")
            //    EstaReservado.Text = "Si";
            //else
            //    EstaReservado.Text = "No";
        }

    }

    protected void ButtonReservar_Click(object sender, ImageClickEventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma guardar la reserva del ejemplar para el usuario  ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    protected void ButtonNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProReserva.aspx");
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

    #endregion

    #region --- MÉTODOS DEL PROGRAMADOR ---

    public string PintarEstado(bool pEstado)//string pCodigoTabla, 
    {
        string estado = string.Empty;
        if (pEstado)
            estado = "Si";
        else
            estado = "No";
        return estado;
    }

    private string Validar()
    {
        string mensage = "";
        Label lblCodEjempESTADO = null;
        lblCodEjempESTADO = ucItem1.FindControl("LabelEstadoEjemplarCOD") as Label;
        Label lblNomUsuarioSAC = null;
        lblNomUsuarioSAC = ucUsuario1.FindControl("TextBoxNombresApellidos") as Label;

        if (lblNomUsuarioSAC.Text.Trim().Length == 0 || TextBoxCodUsuario.Text == "") mensage = mensage + "¡ Código de Usuario no EXISTE !" + "</br>";
        if (TextBoxCodItem.Text == "") mensage = mensage + "¡ Ingresar código de ítem 1" + "</br>";
        if (lblCodEjempESTADO.Text == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar))
            mensage = mensage + "¡ El ejemplar se encuentra en reservado !" + "</br>";
        if (lblCodEjempESTADO.Text == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnDeteriodoEjemplar))
            mensage = mensage + "¡ El ejemplar se encuentra en deteriodo !" + "</br>";
        HF_CodEjemplar.Value = string.Empty;
        foreach (GridViewRow item in gvItems.Rows)
        {
            if (item.RowType == DataControlRowType.DataRow)
            {
                CheckBox TieneReserva = ((CheckBox)item.Cells[6].FindControl("CheckBoxReserva"));
                if (TieneReserva.Checked)
                    HF_CodEjemplar.Value = item.Cells[1].Text;
            }
        }
        if (HF_CodEjemplar.Value == "") mensage = mensage + "¡ No ha seleccionado código de ejemplar !" + "</br>";
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
            mensage = mensage + "¡ Usuario que no puede realizar la operación de reserva, no esta asignado a un SAC !" + "</br>";
        if (mensage.Length > 0)
            mensage = mensage.Substring(2);
        return mensage;
    }

    private void ConfirmarReservaA_Usuario()
    {
        Prestamo itemPrestamo;
        Label lblCodSAC = null;
        Label lblCodPres = null;
        lblCodSAC = ucUsuario1.FindControl("TextBoxCodSAC") as Label;
        lblCodPres = ucItem1.FindControl("LabelTipoPrestamoCOD") as Label;
        itemPrestamo = new Prestamo
        {
            sCodUsuarioSAC = TextBoxCodUsuario.Text,
            sCodEjemplar = HF_CodEjemplar.Value,
            sCodSac = this.Master.HelpUsuariosSAC().CodLocalSAC,
            sCodSacUsuario = lblCodSAC.Text,
            SSIUsuario_Creacion = this.Master.HelpUsuario().LoginUsuario,
            SSIUsuario_Modificacion = this.Master.HelpUsuario().LoginUsuario,
            SSIHost = Context.Request.UserHostName,
            sCodArguPrestamoEn = lblCodPres.Text
        };

        ReturnValor oReturnValor = new ReturnValor();
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();

        oReturnValor = oPrestamoLogic.RegistrarOperaciones(itemPrestamo, PrestamoLogic.TipoDeOperacion.OperReserva);

        if (oReturnValor.Exitosa)
        {
            UsuarioParaReserva();
            TextBoxCodItem.Text = string.Empty;
            EjemplarParaReserva();
            MessageBox1.ShowSuccess(oReturnValor.Message);
            Auditoria1.CargarSeguridadInicio();
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }

    private void EjemplarParaReserva()
    {
        ItemLogic oItemLogic = new ItemLogic();
        Item xItem = new Item();
        string CodEjemplarDisponible = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
        string CodEjemplarEnPrestamo = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar);
        string CodEjemplarEnReserva = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar);
        xItem = oItemLogic.BuscarDetalleItem(TextBoxCodItem.Text, this.Master.HelpUsuariosSAC().CodLocalSAC, CodEjemplarDisponible, CodEjemplarEnPrestamo, CodEjemplarEnReserva);
        List<ItemEjemplar> listaItemEjemplar = new List<ItemEjemplar>();
        if (xItem.sCodItem != null)
        {

            listaItemEjemplar = xItem.ListaEjemplares;
            gvItems.DataSource = HelpConvert<ItemEjemplar>.ConvertList(listaItemEjemplar);
            gvItems.DataBind();
            if (xItem.ListaEjemplares.Count > 0)
                ucItem1.CargarDatosDeItemEjemplar(xItem.ListaEjemplares[0].sCodEjemplar);
        }
        else
        {
            MessageBox1.ShowInfo("¡ Código de ítem no existe, no se puede encontrar ejemplares !");
            gvItems.DataSource = HelpConvert<ItemEjemplar>.ConvertList(listaItemEjemplar);
            gvItems.DataBind();
        }
    }

    private void UsuarioParaReserva()
    {
        if (this.Master.HelpUsuariosSAC().CodLocalSAC == null || this.Master.HelpUsuariosSAC().CodLocalSAC.Trim() == string.Empty)
        {
            MessageBox1.ShowWarning("¡ Usuario del sistema no puede realizar la operación de reserva !");
            TextBoxCodItem.Enabled = false;
            ButtonReservar.Enabled = false;
            ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
            LimpiarDatosDelUsuario(false, string.Empty);
            pnlUsuario.Visible = false;
        }
        else if (TextBoxCodUsuario.Text.Trim().Length > 0)
        {
            vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
            vwUsuariosSAC xkvwUsuariosSAC = new vwUsuariosSAC();
            xkvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(TextBoxCodUsuario.Text.Trim());
            if (xkvwUsuariosSAC.CodUsuarioSAC != null)
            {
                if (xkvwUsuariosSAC.CodLocalSACNombre != null)
                {
                    if (xkvwUsuariosSAC.EsMatriculado)
                    {
                        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
                        ReturnValor oReturnValor = new ReturnValor();
                        Prestamo itemPrestamo = new Prestamo();
                        oReturnValor = oItemEjemplarLogic.DetectarUsuarioEnDevolucionPendiente(TextBoxCodUsuario.Text, ref itemPrestamo);
                        if (itemPrestamo.sCodPrestamo != null)
                        {
                            MessageBox1.ShowInfo("¡ El usuario tiene pendiente la entrega de ejemplares de ítem o ya tiene una reserva !");
                            HF_CodPrestamo.Value = itemPrestamo.sCodPrestamo;
                            ucUsuario1.prm_CodUsuarioSAC = itemPrestamo.sCodUsuarioSAC;
                            ucUsuario1.CargarDatosDeUsuarioSAC();
                            Auditoria1.CargarSeguridad(itemPrestamo.SSIUsuario_Creacion, itemPrestamo.SSIUsuario_Modificacion, itemPrestamo.SSIFechaHora_Creacion, itemPrestamo.SSIFechaHora_Modificacion, itemPrestamo.SSIHost);
                            TextBoxCodItem.Enabled = false;
                            ButtonReservar.Enabled = false;
                            ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                            pnlUsuario.Visible = true;
                            return;
                        }
                        else
                        { HF_CodPrestamo.Value = string.Empty; }
                        Prestamo itemPrestamoRSV = new Prestamo();
                        oReturnValor = oItemEjemplarLogic.DetectarUsuarioEnReservaPendiente(TextBoxCodUsuario.Text.Trim(), ref itemPrestamoRSV);
                        if (itemPrestamoRSV.sCodPrestamo != null)
                        {
                            if (itemPrestamoRSV.dFechaInicioReserva == null)
                            {
                                MessageBox1.ShowInfo("¡ El usuario ya tiene registrado la reserva de un ejemplar de ítem !");
                                HF_CodPrestamoRSV.Value = itemPrestamoRSV.sCodPrestamo;
                                ucUsuario1.prm_CodUsuarioSAC = itemPrestamoRSV.sCodUsuarioSAC;
                                ucUsuario1.CargarDatosDeUsuarioSAC();
                                Auditoria1.CargarSeguridad(itemPrestamo.SSIUsuario_Creacion, itemPrestamo.SSIUsuario_Modificacion, itemPrestamo.SSIFechaHora_Creacion, itemPrestamo.SSIFechaHora_Modificacion, itemPrestamo.SSIHost);
                                TextBoxCodItem.Enabled = false;
                                ButtonReservar.Enabled = false;
                                ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                                pnlUsuario.Visible = true;
                                return;
                            }
                            else
                            {
                                DateTime FechaVencReservado = Convert.ToDateTime(itemPrestamoRSV.dFechaInicioReserva.Value.AddDays((double)Util.DiasDePrestamo(itemPrestamoRSV.dFechaInicioReserva.Value, Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasReservaVigen)),0, false,ucUsuario1.prm_Sabado )).ToShortDateString());
                                DateTime FechaInicReservado = Convert.ToDateTime(itemPrestamoRSV.dFechaInicioReserva.Value.ToShortDateString());
                                if (FechaVencReservado >= DateTime.Today || FechaVencReservado <= FechaInicReservado)
                                {
                                    MessageBox1.ShowInfo("¡ El usuario SAC tiene activado una reserva de un ejemplar de ítem !");
                                    HF_CodPrestamoRSV.Value = itemPrestamoRSV.sCodPrestamo;
                                    ucUsuario1.prm_CodUsuarioSAC = itemPrestamoRSV.sCodUsuarioSAC;
                                    ucUsuario1.CargarDatosDeUsuarioSAC();
                                    Auditoria1.CargarSeguridad(itemPrestamo.SSIUsuario_Creacion, itemPrestamo.SSIUsuario_Modificacion, itemPrestamo.SSIFechaHora_Creacion, itemPrestamo.SSIFechaHora_Modificacion, itemPrestamo.SSIHost);
                                    TextBoxCodItem.Enabled = false;
                                    ButtonReservar.Enabled = false;
                                    ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                                    pnlUsuario.Visible = true;
                                    return;
                                }
                                else
                                    HF_CodPrestamoRSV.Value = string.Empty;
                            }
                        }
                        else
                        { HF_CodPrestamoRSV.Value = string.Empty; }
                        UsuariosBloqueadosLogic oUsuariosBloqueadosLogic = new UsuariosBloqueadosLogic();
                        UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados();
                        itemUsuariosBloqueados = oUsuariosBloqueadosLogic.Buscar(TextBoxCodUsuario.Text.Trim(), true);
                        if (itemUsuariosBloqueados.sCodUsuarioSAC != null)
                        {
                            if (DateTime.Now < itemUsuariosBloqueados.dFechaBloqueoOFF)
                            {
                                HF_UsuarioLOCK.Value = itemUsuariosBloqueados.dFechaBloqueoOFF.ToShortDateString();
                                MessageBox1.ShowInfo("¡ El usuario está bloqueado para hacer reservas; se habilitará el [ " + HF_UsuarioLOCK.Value + " ] !");
                                TextBoxCodItem.Enabled = false;
                                ButtonReservar.Enabled = false;
                                ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                                LimpiarDatosDelUsuario(false, string.Empty);
                                pnlUsuario.Visible = false;
                                return;
                            }
                            else
                                HF_UsuarioLOCK.Value = "N";
                        }
                        else
                            HF_UsuarioLOCK.Value = "N";
                        ucUsuario1.prm_CodUsuarioSAC = TextBoxCodUsuario.Text;
                        ucUsuario1.CargarDatosDeUsuarioSAC();
                        Auditoria1.CargarSeguridadInicio();
                        TextBoxCodItem.Enabled = true;
                        pnlUsuario.Visible = true;
                    }
                    else
                    {

                        MessageBox1.ShowWarning("¡ Usuario SAC no puede realizar reserva, no esta matriculado a un SAC. !");
                        TextBoxCodItem.Enabled = false;
                        ButtonReservar.Enabled = false;
                        ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                        LimpiarDatosDelUsuario(false, string.Empty);
                        pnlUsuario.Visible = false;
                    }
                }
                else
                {

                    MessageBox1.ShowWarning("¡ Código de usuario SAC no pertenece a ningún SAC. !");
                    TextBoxCodItem.Enabled = false;
                    ButtonReservar.Enabled = false;
                    ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                    LimpiarDatosDelUsuario(false, string.Empty);
                    pnlUsuario.Visible = false;
                    return;


                }

            }
            else
            {
                MessageBox1.ShowWarning("¡ Código de usuario SAC no esta registrado en el sistema. !");

                TextBoxCodItem.Enabled = false;
                ButtonReservar.Enabled = false;
                ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                LimpiarDatosDelUsuario(false, string.Empty);
                pnlUsuario.Visible = false;
                return;
            }
        }
        else
        {
            LimpiarDatosDelUsuario(false, string.Empty);
        }
    }

    private void LimpiarDatosDelUsuario(bool TEXTBOX, string p_CodUsuarioSAC)
    {
        TextBoxCodItem.Enabled = TEXTBOX;
        ButtonReservar.Enabled = TEXTBOX;
        ButtonReservar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
        ucUsuario1.prm_CodUsuarioSAC = p_CodUsuarioSAC;
        ucUsuario1.CargarDatosDeUsuarioSAC();
        if (TEXTBOX)
            pnlUsuario.Visible = true;
        else
            pnlUsuario.Visible = false;
    }

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ProReserva.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
            ButtonReservar.Visible = oRolesOpciones.Flag_Nuevo;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    
    #endregion

}
