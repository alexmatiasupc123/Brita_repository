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
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using System.Configuration;
public partial class ListaEjemplares_VerificarRetiro : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        if (!Page.IsPostBack)
        {
            
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                hfParameters.Value = querystringDESENCRYP;
                txtCodTransferencia.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "tId");
                this.PintarDatosTransferencia(txtCodTransferencia.Text);
            }
        }
        Seguridad();
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {       
            
            Page.Title = lblTituloPagina.Text;
    }
    #endregion
    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaEjemplares_VerificarRetiro.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            if (oRolesOpciones.Flag_Editar)
            {
                gvItemsTransferencia_Retiro.Enabled = true;
                btnGenerarRetiro.Visible = true;
            }
            else
            {
                gvItemsTransferencia_Retiro.Enabled = false;
                btnGenerarRetiro.Visible = false;
            }

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    private void PintarDatosTransferencia(string pCodTransferencia)
    {
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        SolicitudTransferencia itemSolicitudTransferencia = new SolicitudTransferencia();
        itemSolicitudTransferencia = oSolicitudTransferenciaLogic.Buscar(pCodTransferencia,"R");
        txtSacOrigen.Text = itemSolicitudTransferencia.sNombreLocalOrigen;
        txtSacDestino.Text = itemSolicitudTransferencia.sNombreLocalDestino;
        txtSolicitadoPor.Text = itemSolicitudTransferencia.sUsuarioSolicitante;        
        txtFechaProcesoSolicitud.Text = itemSolicitudTransferencia.dFechaProcesoSolicitud.ToShortDateString();
        txtEstadoTransferencia.Text = itemSolicitudTransferencia.sCodArguNombreEstadoTransferencia;
        txtFechaProcesoRetiro.Text = DateTime.Today.ToShortDateString();
        gvItemsTransferencia_Retiro.DataSource = itemSolicitudTransferencia.ListaDetalleTransferencia;
        gvItemsTransferencia_Retiro.DataBind();
        HelpGridView.Caption(ref gvItemsTransferencia_Retiro, "Lista de ejemplares a retirar.", itemSolicitudTransferencia.ListaDetalleTransferencia.Count.ToString());
        
        
    }
    private SolicitudTransferencia GetItemTransferenciaRetiro()
    {
        SolicitudTransferencia oSolicitudTransferencia = new SolicitudTransferencia();
        List<SolicitudTransferenciaDetalle> ListaDetalleTransferencia = new List<SolicitudTransferenciaDetalle>();
        string pEstadoRetiroVerificado = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoTransferencia_Retiro);
        oSolicitudTransferencia.sCodTransferencia = txtCodTransferencia.Text;
        oSolicitudTransferencia.sUsuarioSacOrigen = Master.HelpUsuario().LoginUsuario;                
        oSolicitudTransferencia.dFechaProcesoRetiro = DateTime.Now;
        oSolicitudTransferencia.sCodArguEstadoTransferencia = pEstadoRetiroVerificado;
        oSolicitudTransferencia.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;        
        for (int i = 0; i < gvItemsTransferencia_Retiro.Rows.Count; i++)
        {
            CheckBox chkBaja = (CheckBox)gvItemsTransferencia_Retiro.Rows[i].Cells[5].FindControl("chkRetiro");
            if (chkBaja.Checked)
            {
                SolicitudTransferenciaDetalle oItemTransferenciaDetalle = new SolicitudTransferenciaDetalle();
                string CodEjemplar = gvItemsTransferencia_Retiro.Rows[i].Cells[1].Text;
                oItemTransferenciaDetalle.sCodEjemplar = CodEjemplar;
                oItemTransferenciaDetalle.sCodTransferencia = txtCodTransferencia.Text;
                oItemTransferenciaDetalle.bAprobacionRetiro = true;
                oItemTransferenciaDetalle.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
                ListaDetalleTransferencia.Add(oItemTransferenciaDetalle);
            }

        }
        oSolicitudTransferencia.ListaDetalleTransferencia = ListaDetalleTransferencia;
        return oSolicitudTransferencia;
    }
    #endregion
    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmarRetiro(); ;
        }
    }

    protected void btnGenerarRetiro_Click(object sender, ImageClickEventArgs e)
    {
        int CantReg = 0;
        string mensaje = string.Empty;
        for (int i = 0; i < gvItemsTransferencia_Retiro.Rows.Count; i++)
        {
            CheckBox chkBaja = (CheckBox)gvItemsTransferencia_Retiro.Rows[i].Cells[5].FindControl("chkRetiro");
            if (chkBaja.Checked)
            {
                CantReg++;
            }
        }
        if (CantReg == 0)
        {
            mensaje = "Seleccionar el ejemplar a retirar.";
        }

        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma el retiro del ejemplar ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    private void ConfirmarRetiro()
    {
        ReturnValor oReturnValor = new ReturnValor();
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        SolicitudTransferencia itemTransferencia = new SolicitudTransferencia();

        itemTransferencia = GetItemTransferenciaRetiro();
        oReturnValor = oSolicitudTransferenciaLogic.Actualizar_Retiro(itemTransferencia);
        if (oReturnValor.Exitosa)
        {   
            MessageBox1.ShowSuccess(oReturnValor.Message);
            btnGenerarRetiro.Visible = false;
            gvItemsTransferencia_Retiro.Enabled = false;
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }
    protected void gvItemsTransferencia_Retiro_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemsTransferencia_Retiro.PageIndex = e.NewPageIndex;
        this.PintarDatosTransferencia(txtCodTransferencia.Text);
    }
    #endregion

 
    protected void btnRegreso_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListaTransferenciaEjemplares_Retiro.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
    }
}
