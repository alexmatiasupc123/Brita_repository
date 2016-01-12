using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using Britanico.SacNet.BusinessEntities;

public partial class ParametrosSistema : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            ucConfig1.Cargar();
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.BotonNuevo = false;
        this.BotonesEdicionMantenimiento1.BotonEditar = false;
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);
    }

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ReturnValor oReturn = ucConfig1.Guardar();
            if (oReturn.Exitosa)
            {
                MessageBox1.ShowSuccess(oReturn.Message);
                ucConfig1.Cargar();
            }
            else
            {
                MessageBox1.ShowWarning(oReturn.Message);
            }
        }
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        MessageBox1.ShowConfirm("¿ Confirma guardar los parámetros de configuración ?", HelpEvento.Guardar.ToString());  
    }
    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        
         Response.Redirect("Default.aspx");
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ParametrosSistema.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ParametrosSistema.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();
        if (lstRolesOpciones != null)
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            if (dtEditar.Rows.Count > 0)
            {
                BotonesEdicionMantenimiento1.BotonGrabar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                Panel1Contenido.Enabled = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
            }
            BotonesEdicionMantenimiento1.LoadComplete();
            
            //BotonesEdicionMantenimiento1.BotonGrabar = oRolesOpciones.Flag_Editar;
            //Panel1Contenido.Enabled = oRolesOpciones.Flag_Editar;
            //BotonesEdicionMantenimiento1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

}
