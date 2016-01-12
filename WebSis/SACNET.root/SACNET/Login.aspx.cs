using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Configuration;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Login : System.Web.UI.Page
{
    #region // EVENTOS DE LA PÁGINA //

    string intraCod = "";
    string intraPass = "";
    string intraIndCambio = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       // Button1.Attributes.Add("onclick", BusyBox1.ShowFunctionCall);

        //ELVP: 19-10-2011 Cuando ingresa desde la Intranet
        intraCod = Request.QueryString["cod"];
        intraPass = Request.QueryString["pass"];
        intraIndCambio = Request.QueryString["ind"];

        if (!IsPostBack)
        {

            //lblTituloPagina.Text = "INICIO DE SESIÓN";
            Session["Usuario"] = null;
            txtUsuarioLogin.Focus();

            if (intraCod != null)
            {
                //Si se envio el password encriptado:
                if (intraIndCambio.Equals("1"))
                {
                    intraPass = Util.SRT_DesEncripta(intraPass);
                }
                this.txtUsuarioLogin.Text = intraCod;
                this.txtPasswordLogin.Text = intraPass;
                txtUsuarioLogin_TextChanged(null, null);
                btnAceptar_Click(null, null);
            }
        }
        lblDatosIncorrectos.Visible = false;
    }

    #endregion

    #region // EVENTOS DE LOS CONTROLES //
    protected void btnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        AccederAlSistema();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    //BusyBox1.ShowTimeout = 10;
    //    System.Threading.Thread.Sleep(4000);
    //    AccederAlSistema();
        
    //}
    protected void txtUsuarioLogin_TextChanged(object sender, EventArgs e)
    {
        try
        {
            EncontrarLoginUsuario();
        }
        catch (Exception ex)
        {
            lblDatosIncorrectos.Text = ex.Message;
            lblDatosIncorrectos.Visible = true;
        }
    }

    #endregion

    #region // METODOS DEL PROGRAMADOR //
    //private void Permisos(string User)
    //{

    //    List<Usuarios> UsuariosRoles = new List<Usuarios>();

    //    UsuariosRolesLogic UsuariosRolesLogic = new UsuariosRolesLogic();

    //    string CodSistema = ConfigurationManager.AppSettings.Get("Sistema");

    //    UsuariosRoles = UsuariosRolesLogic.DetectarLogin(User).ToList<Usuarios>();

    //    if (UsuariosRoles.Count > 0)
    //    {
    //        List<RolesOpciones> listaRol = UsuariosRolesLogic.mListarPorSistemaYRol(UsuariosRoles[0].CodigoRol).ToList<RolesOpciones>();
    //        Session["Usuario"] = UsuariosRoles[0];
    //        Session["Rol_Opcion"] = listaRol;
    //        vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
    //        itemvwUsuariosSAC = new vwDatosVistaLogic().Buscarvw_UsuariosSAC(UsuariosRoles[0].CodPersona);
    //        Session["UsuarioSAC"] = itemvwUsuariosSAC;
    //        if (listaRol.Count == 1)
    //        {
    //            Response.Redirect(listaRol[0].CodigoOpcionEnlace, true);
    //        }
    //        else
    //        {
    //            Response.Redirect("Default.aspx", true);
    //        }
    //    }
    //}
    private void AccederAlSistema()
    {
        try
        {
            string usuario, pass;
            int idusuario, idsistema;

            ServicioSeguridad.IService1 SerSeg = new ServicioSeguridad.Service1Client();
            List<ServicioSeguridad.UsuarioSis> lstUsuario;

            //if (intraCod == null)
            //{
                usuario = this.txtUsuarioLogin.Text;
                pass = this.txtPasswordLogin.Text;
            //}
            //else
            //{
                //usuario = intraCod;
                //pass = intraPass;
            //}
            

            lstUsuario = SerSeg.GetUsuarioSistema(usuario, "SIS_SACNET");


            if (lstUsuario.Count > 0)
            {
                //Evaluando si tiene Perfiles 
                List<ServicioSeguridad.PERFIL> lstPerfil;

                idusuario = lstUsuario.ElementAt<ServicioSeguridad.UsuarioSis>(0).USUAI_ID;
                idsistema = lstUsuario.ElementAt<ServicioSeguridad.UsuarioSis>(0).SISTI_ID;

                lstPerfil = SerSeg.GetPerfilUsuario(idusuario, idsistema);
               

                if (lstPerfil.Count == 0)
                {
                    this.lblDatosIncorrectos.Text = "Usuario no cuenta con  Perfiles";
                }
                else
                {
                    if (lstUsuario.ElementAt<ServicioSeguridad.UsuarioSis>(0).USUAV_PASS != pass.ToUpper())
                    {
                        this.lblDatosIncorrectos.Text = "Clave incorrecta";
                    }
                    else
                    {
                        //Session.Add("usuarioCode", usuario);
                        //Session.Add("usuarioid", idusuario);
                        //Session.Add("sistemaid", idsistema);

                        //SetearPerfilPaginaInicio(lstPerfil);

                        SetearPerfil();
                        


                    }
                }
            }
            else
            {
                this.lblDatosIncorrectos.Text = "Usuario incorrecto";
            }

            //Usuarios oUsuariosRoles = new Usuarios();
            //UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();

            //if (ddlRoles.SelectedIndex >= 0)
            //{
            //    if (oUsuariosRolesLogic.DetectarLoginPassword(txtUsuarioLogin.Text, txtPasswordLogin.Text))
            //    {
            //        oUsuariosRoles = oUsuariosRolesLogic.DetectarUsuario(txtUsuarioLogin.Text, ddlRoles.SelectedValue.ToString());
            //        oUsuariosRoles.CodigoRolNombre = ddlRoles.SelectedItem.Text;
            //        Session["Usuario"] = oUsuariosRoles;

            //        vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
            //        //oUsuariosRoles.LoginUsuario anterior mente  en este caso seria oUsuariosRoles.CodPersona
            //        //itemvwUsuariosSAC = new vwDatosVistaLogic().Buscarvw_UsuariosSAC(oUsuariosRoles.CodPersona);
            //        itemvwUsuariosSAC = new vwDatosVistaLogic().Buscarvw_UsuariosSAC(oUsuariosRoles.LoginUsuario);                    
            //        Roles itemRol = new Roles();
            //        itemRol = new RolesLogic().Buscar(oUsuariosRoles.CodigoRol);
                    

            //        if (oUsuariosRoles.CodigoRol == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolResponsableSAC) || 
            //            oUsuariosRoles.CodigoRol == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolUsuarioSAC))
            //        {
            //            if (itemvwUsuariosSAC.CodLocalSACNombre != null)
            //            {
            //                Session["UsuarioSAC"] = itemvwUsuariosSAC;
            //                Response.Redirect("Default.aspx", true);
            //            }
            //            else
            //            {
            //                txtUsuarioLogin.Focus();
            //                lblDatosIncorrectos.Visible = true;
            //                lblDatosIncorrectos.Text = "Usuario no está asignado a un SAC.";
            //            }


            //        }
            //        else
            //        {
            //            if (itemRol.TodosLosCentros)
            //                itemvwUsuariosSAC.CodLocalSAC = null;
            //            Session["UsuarioSAC"] = itemvwUsuariosSAC;
            //            Response.Redirect("Default.aspx", true);
            //        }
            //    }
            //    else
            //    {
            //        txtUsuarioLogin.Focus();
            //        lblDatosIncorrectos.Visible = true;
            //        lblDatosIncorrectos.Text = "La contraseña es incorrecta, verificar.";
            //    }
            //}
            //else
            //{
            //    txtUsuarioLogin.Focus();
            //    lblDatosIncorrectos.Text = "Ud. no tiene roles asignados, no puede ingresar";
            //}
        }
        catch (Exception ex)
        {
            lblDatosIncorrectos.Text = ex.Message;
        }
    }

    private void SetearPerfil()
    {
        ServicioSeguridad.IService1 SerSeg = new ServicioSeguridad.Service1Client();

        Usuarios oUsuariosRoles = new Usuarios();
        UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();

        if (ddlRoles.SelectedIndex >= 0)
        {

            oUsuariosRoles = oUsuariosRolesLogic.DetectarUsuario(txtUsuarioLogin.Text, ddlRoles.SelectedValue.ToString());
            oUsuariosRoles.CodigoRolNombre = ddlRoles.SelectedItem.Text;
            Session["Usuario"] = oUsuariosRoles;

            vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
            itemvwUsuariosSAC = new vwDatosVistaLogic().Buscarvw_UsuariosSAC(oUsuariosRoles.LoginUsuario);
            
            Roles itemRol = new Roles();
            itemRol = new RolesLogic().Buscar(oUsuariosRoles.CodigoRol);

            //if (oUsuariosRoles.CodigoRol == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolResponsableSAC) ||
            //    oUsuariosRoles.CodigoRol == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolUsuarioSAC))
            if (oUsuariosRoles.CodigoRol == "27" ||
                oUsuariosRoles.CodigoRol == "28")
            {
                if (itemvwUsuariosSAC.CodLocalSACNombre != null)
                {
                    Session["UsuarioSAC"] = itemvwUsuariosSAC;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    txtUsuarioLogin.Focus();
                    lblDatosIncorrectos.Visible = true;
                    lblDatosIncorrectos.Text = "Usuario no está asignado a un SAC.";
                }


            }
            else
            {
                if (itemRol.TodosLosCentros)
                    itemvwUsuariosSAC.CodLocalSAC = null;
                Session["UsuarioSAC"] = itemvwUsuariosSAC;
                Response.Redirect("Default.aspx", true);
            }

        }
        else
        {
            txtUsuarioLogin.Focus();
            lblDatosIncorrectos.Text = "Ud. no tiene roles asignados, no puede ingresar";
        }
    }

    private void EncontrarLoginUsuario()
    {
        ServicioSeguridad.IService1 SerSeg = new ServicioSeguridad.Service1Client();
        List<ServicioSeguridad.UsuarioSis> lstUsuario;
        int idusuario, idsistema;
        
        lstUsuario = SerSeg.GetUsuarioSistema(txtUsuarioLogin.Text.Trim(), "SIS_SACNET");

        if (lstUsuario.Count > 0)
        {
            //Evaluando si tiene Perfiles 
            List<ServicioSeguridad.PERFIL> lstPerfil;

            idusuario = lstUsuario.ElementAt<ServicioSeguridad.UsuarioSis>(0).USUAI_ID;
            idsistema = lstUsuario.ElementAt<ServicioSeguridad.UsuarioSis>(0).SISTI_ID;

            lstPerfil = SerSeg.GetPerfilUsuario(idusuario, idsistema);

            if (lstPerfil.Count == 0)
            {
                ddlRoles.Items.Clear();
                ddlRoles.DataBind();
                ddlRoles.Visible = false;
                lblRol.Visible = false;
                txtUsuarioLogin.Focus();
                this.lblDatosIncorrectos.Text = "Usuario no cuenta con perfiles asignados";
            }
            else
            {
                ddlRoles.DataSource = lstPerfil;
                ddlRoles.DataTextField = "PERFV_NOMBRE";
                ddlRoles.DataValueField = "PERFI_ID";
                ddlRoles.DataBind();
                ddlRoles.Visible = true;
                lblRol.Visible = true;

                string CodPerfilUsuarioSac = "28";
                if (lstPerfil.Exists(x => x.PERFI_ID.ToString() == CodPerfilUsuarioSac) && lstPerfil.Count == 1)
                {
                    ddlRoles.SelectedValue = CodPerfilUsuarioSac;
                    ddlRoles.Enabled = false;
                }
                else { ddlRoles.Enabled = true; }
                lblDatosIncorrectos.Text = string.Empty;
                txtPasswordLogin.Focus();
            }
        }
        else
        {
            ddlRoles.Items.Clear();
            ddlRoles.DataBind();
            ddlRoles.Visible = false;
            lblRol.Visible = false;
            txtUsuarioLogin.Focus();
            lblDatosIncorrectos.Text = "Usted no tiene acceso al sistema";
            lblDatosIncorrectos.Visible = true;
        }

        //List<Usuarios> UsuariosRoles = new List<Usuarios>();
        //UsuariosRolesLogic oUsuariosRolesLogic = new UsuariosRolesLogic();
        //UsuariosRoles = oUsuariosRolesLogic.DetectarLogin(txtUsuarioLogin.Text);
        //if (UsuariosRoles.Count > 0)
        //{
        //    UsuariosLogic oUsuariosLogic = new UsuariosLogic();
        //    Usuarios itemUsuario = new Usuarios();
        //    itemUsuario = oUsuariosLogic.Buscar(txtUsuarioLogin.Text);
        //    ddlRoles.DataSource = UsuariosRoles;
        //    ddlRoles.DataTextField = "CodigoRolNombre";
        //    ddlRoles.DataValueField = "CodigoRol";
        //    ddlRoles.DataBind();

        //    ddlRoles.Visible = true;
        //    lblRol.Visible = true;
        //    if (itemUsuario.TipoUsuario == "A" || itemUsuario.TipoUsuario == "P")
        //    {
        //        string CodRolUsuarioSac = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolUsuarioSAC);
        //        if (UsuariosRoles.Exists(x => x.CodigoRol == CodRolUsuarioSac))
        //        {
        //            ddlRoles.SelectedValue = CodRolUsuarioSac;
        //            ddlRoles.Enabled = false;
        //        }
        //    }
        //    else { ddlRoles.Enabled = true; }
        //    lblDatosIncorrectos.Text = string.Empty;
        //    txtPasswordLogin.Focus();
        //}
        //else
        //{


        //    ddlRoles.Items.Clear();
        //    ddlRoles.DataBind();
        //    ddlRoles.Visible = false;
        //    lblRol.Visible = false;
        //    txtUsuarioLogin.Focus();
        //    lblDatosIncorrectos.Text = "Ud. no tiene roles asignados, no puede ingresar";
        //    lblDatosIncorrectos.Visible = true;
        //}



    }

    #endregion

    
}

