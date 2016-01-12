using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.BusinessLogic.Transaccionales;
using System.Collections.Generic;

public partial class Seguridad_frm_usuarios : System.Web.UI.Page
{
    BLUsuarioNTAD oUsuarios = new BLUsuarioNTAD();
    BLUsuarioTAD gUsuarios = new BLUsuarioTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            cargar_grilla();
        }
    }
   
    void cargar_grilla()
    {
        List<BEUsuario> rUsuario = oUsuarios.ListarTodos();
        gvUsuario.DataSource = rUsuario;
        gvUsuario.DataBind();
    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblVerificaLogin.Text = "";
        pNuevo.Visible = true;
        btnNuevo.Visible = false;
        btnNuevo.Visible = false;
        gvUsuario.Visible = false;
    }
  
    protected void btnCancela_Click(object sender, ImageClickEventArgs e)
    {

        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        limpia_textos();
    }

    void limpia_textos()
    {
        txtNombre.Text = "";
        txtApellidoMat.Text = "";
        txtApellidoPat.Text = "";
        txtClave.Text = "";
        txtConfirmaClave.Text = "";
        txtEmail.Text = "";
        txtLogin.Text = "";
        btnNuevo.Visible = true;
        gvUsuario.Visible = true;
    }
    protected void btnAgrega_Click(object sender, ImageClickEventArgs e)
    {
        BEUsuario rUsuario = new BEUsuario();
        rUsuario.usua_amat = txtApellidoMat.Text;
        rUsuario.usua_apat = txtApellidoPat.Text;
        rUsuario.usua_mail = txtEmail.Text;
        rUsuario.usua_login = txtLogin.Text;
        rUsuario.usua_pass = txtClave.Text;
        rUsuario.usua_nomb = txtNombre.Text;
        rUsuario.rol_codi = 1;
        rUsuario.usua_esta = 1;
        BLUsuarioTAD gUsuario = new BLUsuarioTAD();
        gUsuario.Agregar(rUsuario);
        //aqui agregamos
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        limpia_textos();
        cargar_grilla();
        gvUsuario.DataBind();

    }
    protected void txtLogin_TextChanged(object sender, EventArgs e)
    {
        //verificamos usuario
        string usuario = txtLogin.Text;

        if (oUsuarios.VerificaLogin(usuario) == 1)
        {
            lblVerificaLogin.Text = "usuario no esta disponible";
            btnAgrega.Visible = false;

        }
        else
        {
            lblVerificaLogin.Text = "";
            btnAgrega.Visible = true;

        }
    }
    protected void btnBaja_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnBaja = (ImageButton)sender;
        Int32 id = Convert.ToInt32(btnBaja.CommandArgument);
        BEUsuario bUsuario = oUsuarios.ListarRegistro(id);
        bUsuario.usua_esta = 0;

        gUsuarios.GuardaEstado(bUsuario);
        //dar de baja eliminar los usuarios de este canal comercial
        cargar_grilla();
        gvUsuario.DataBind();
    }
}
