using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Oxinet.Tools;
using System.Configuration;
public partial class PopupDarBajaEjemplares : System.Web.UI.Page
{
    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Usuarios oUsuario = new Usuarios();            
            oUsuario = (Usuarios)Session["Usuario"];
            if (oUsuario != null)
            {
                CargarPagina();
                CargarConfiguraciones();
            }
            else
                Response.Redirect("Login.aspx");
        }
        Seguridad();
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {        
            

    }
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaDarBajaEjemplares.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaDarBajaEjemplares.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            if (dtEditar.Rows.Count > 0)
            {
                gvEjemplares.Enabled = true;
                imgbtnAceptar.Visible = true;
            }
            else
            {
                gvEjemplares.Enabled = false;
                imgbtnAceptar.Visible = false;
            }

            //if (oRolesOpciones.Flag_Editar)
            //{
            //    gvEjemplares.Enabled = true;
            //    //btnGrabar.Visible = true;
            //    imgbtnAceptar.Visible = true;
            //}
            //else
            //{
            //    gvEjemplares.Enabled = false;
            //    //btnGrabar.Visible = false;
            //    imgbtnAceptar.Visible = false;
            //}
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    private void CargarConfiguraciones()
    {
        //this.btnSalir.Attributes.Add("OnClick", "CerrarClose()");
        ImageCancelar.Attributes.Add("OnClick", "CerrarClose()");
    }

    private void CargarPagina()
    {
        if (Request.QueryString["pm"] != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            txtCodItem.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "iId");
            txtTitulo.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "Tit");
            hfCodSAC.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "Sac");
            CargarEjemplares(txtCodItem.Text);

        }
    }
    private void CargarEjemplares(string pCodItem)
    {
        string pEstadoDisponible = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
        ItemLogic oItemLogic = new ItemLogic();
        List<ItemEjemplar> ListaEjemplar = new List<ItemEjemplar>();
        ListaEjemplar = oItemEjemplarLogic.Listar_A_Dar_Baja(pCodItem, hfCodSAC.Value.ToString(), pEstadoDisponible);
        gvEjemplares.DataSource = ListaEjemplar;
        gvEjemplares.DataBind();
        //HelpGridView.Caption(ref gvEjemplares, "Lista de ejemplares disponibles del ítem.", ListaEjemplar.Count.ToString());
        /***CGA: 17/12/2012 Altiris #***/
        HelpGridView.Caption(ref gvEjemplares, "Lista de ejemplares disponibles y en préstamo del ítem.", ListaEjemplar.Count.ToString());
        if (gvEjemplares.Rows.Count > 0)
            //btnGrabar.Enabled = true;
            imgbtnAceptar.Enabled = true;
        else
            //btnGrabar.Enabled = false;
            imgbtnAceptar.Visible = false;

    }
   
    #endregion
   
    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    protected void gvEjemplares_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
    }
    protected void gvEjemplares_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEjemplares.PageIndex = e.NewPageIndex;
        CargarEjemplares(txtCodItem.Text);
    }

    protected void imgbtnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        List<ItemEjemplar> ListaADarBaja = new List<ItemEjemplar>();
        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
        ReturnValor oReturnValor = new ReturnValor();
        string pEstadoDisponible = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnDeteriodoEjemplar);
        int CantReg = 0;
        for (int i = 0; i < gvEjemplares.Rows.Count; i++)
        {
            CheckBox chkBaja = (CheckBox)gvEjemplares.Rows[i].Cells[2].FindControl("chkDarBaja");
            if (chkBaja.Checked)
            {
                CantReg++;
            }

        }
        if (CantReg == 0)
        {
            MessageBox1.ShowInfo("' Seleccionar el ejemplar a dar de baja. !");
            return;
        }
        for (int i = 0; i < gvEjemplares.Rows.Count; i++)
        {
            CheckBox chkBaja = (CheckBox)gvEjemplares.Rows[i].Cells[2].FindControl("chkDarBaja");
            if (chkBaja.Checked)
            {
                ItemEjemplar oItemEjemplar = new ItemEjemplar();
                string CodEjemplar = gvEjemplares.Rows[i].Cells[1].Text;
                oItemEjemplar.sCodEjemplar = CodEjemplar;
                oItemEjemplar.sCodArguEstadoEjemplar = pEstadoDisponible;
                oItemEjemplar.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
                ListaADarBaja.Add(oItemEjemplar);
            }

        }
        oReturnValor = oItemEjemplarLogic.ActualizarEjemplares_DarBaja(ListaADarBaja);
        if (oReturnValor.Exitosa)
        {
            CargarEjemplares(txtCodItem.Text);
            MessageBox1.ShowSuccess(oReturnValor.Message);
            //string script = String.Format("CerrarOK('{0}')", "0");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CerrarOK", script, true);
        }

    }
    protected void imgbtnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        ////  Aqui tenemos q cerrar el Popup y retornar el valor concatenado PERO recordemos que la funcion 
        ////  para cerrar esta en JavaScript..


        string script = String.Format("CerrarOK('{0}')", "");
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerrarCancelScript"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarCancelScript", script, true);
        }
    }

    #endregion
}
