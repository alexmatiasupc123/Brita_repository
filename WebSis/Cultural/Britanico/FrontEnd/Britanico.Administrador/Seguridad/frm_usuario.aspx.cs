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

public partial class Seguridad_frm_usuario : System.Web.UI.Page
{
    BLUsuarioNTAD rUsuario = new BLUsuarioNTAD();
    BLUsuarioTAD gUsuario = new BLUsuarioTAD();



    protected void Page_Load(object sender, EventArgs e)
    {
        pClave.Visible = true;
        pEmail.Visible = true;
        pUsuario.Visible = true;
        lblMensaje.Text = "";
    }
    protected void txtLogin_TextChanged(object sender, EventArgs e)
    {
        string usuario = txtLogin.Text;
        Int32 codigo = Convert.ToInt32(Session["uCodigo"]);


        if (rUsuario.VerificaModificaLogin(codigo, usuario) == 1)
        {
            lblVerificaLogin.Text = "usuario no esta disponible";
            btnUGuardar.Visible = false;

        }
        else
        {
            lblVerificaLogin.Text = "";
            btnUGuardar.Visible = true;

        }
    }


    protected void btnEGuardar_Click(object sender, ImageClickEventArgs e)
    {
        BEUsuario nUsuario = rUsuario.ListarRegistro(Convert.ToInt32(Session["uCodigo"]));
        nUsuario.usua_mail = txtEmail.Text;
        gUsuario.GuardaEmail(nUsuario);


        txtEmail.Text = "";
        lblMensaje.Text = "Email Guardado Exitosamente";
    }
    protected void btnUGuardar_Click(object sender, ImageClickEventArgs e)
    {
        BEUsuario nUsuario = rUsuario.ListarRegistro(Convert.ToInt32(Session["uCodigo"]));
        nUsuario.usua_login = txtLogin.Text;
        gUsuario.GuardaLogin(nUsuario);


        txtLogin.Text = "";
        lblMensaje.Text = "Login Guardado Exitosamente";


    }
    protected void btnCGuardar_Click(object sender, ImageClickEventArgs e)
    {
        BEUsuario nUsuario = rUsuario.ListarRegistro(Convert.ToInt32(Session["uCodigo"]));
        nUsuario.usua_pass = txtClave.Text;
        gUsuario.GuardaClave(nUsuario);

        txtClave.Text = "";
        txtConfirmaClave.Text = "";
        lblMensaje.Text = "Clave de Acceso Guardado Exitosamente";


    }
    protected void tcUsuario_ActiveTabChanged(object sender, EventArgs e)
    {
        txtClave.Dispose();
        lblMensaje.Dispose();
        txtConfirmaClave.Dispose();
        txtEmail.Dispose();
        txtLogin.Dispose();


    }
    protected void tcUsuario_Load(object sender, EventArgs e)
    {

    }
}
