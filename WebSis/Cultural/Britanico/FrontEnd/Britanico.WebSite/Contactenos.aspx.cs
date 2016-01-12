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
using Britanico.Utilitario;

public partial class Contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
   

    private void EnviarMail()
    {
        String strAlumno = "";
        if (rblAlumno.SelectedValue == "1")
        {  strAlumno = "(Alumno)"; }
        string _srtcorreo = "";
        string mailto = strMail.Text;

        _srtcorreo = "Nuevo Mensaje de Contacto:<br>";
        _srtcorreo = _srtcorreo + "Area: " + ddlAreaEnvio.SelectedItem.Text + "<br>";
        _srtcorreo = _srtcorreo + "Nombres y Apellidos: " + strNombre.Text + " " + strApellidos.Text + strAlumno  + "<br>";
        _srtcorreo = _srtcorreo + "Telefono: " + strTelefono.Text + "<br>";
        _srtcorreo = _srtcorreo + "Direccion: " + strDireccion.Text + "<br>";
        _srtcorreo = _srtcorreo + "Email: " + mailto + "<br>";
        _srtcorreo = _srtcorreo + "Asunto: " + strAsunto.Text;


        sendMail(mailto, Constantes.CORREOENVIO, Constantes.MENSAJETITULO, _srtcorreo);
       
    }

    private void sendMail(string from, string to, string subject, string body)
    {
        // Mail initialization
        System.Net.Mail.MailMessage mailMsg = new System.Net.Mail.MailMessage();
        mailMsg.From = new System.Net.Mail.MailAddress(from);
        mailMsg.To.Add(to);
        mailMsg.CC.Add(from);

       // mailMsg.CC.Add(Constantes);
        //mailMsg.Bcc.Add(bcc);
        mailMsg.Subject = subject;
        mailMsg.IsBodyHtml = true;
        mailMsg.Body = body;
        mailMsg.Priority = System.Net.Mail.MailPriority.High;

        string pass = Constantes.correoPASSWORD;


        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = Constantes.HOST;
        // Usuario y contraseña con la que te logeas
        //smtp.Credentials = new System.Net.NetworkCredential(Constantes.correoUSUARIO, pass);
        //smtp.EnableSsl = Convert.ToBoolean(Constantes.ssl);
      //  smtp.Port = Int32.Parse(Constantes.PUERTO);


        try
        {
            smtp.Send(mailMsg);
            this._message.Text = "Mensaje fue enviado satisfactoriamente";
            this._message.Visible = true;
            strApellidos.Text = "";
            ddlAreaEnvio.SelectedIndex = 0;
            strAsunto.Text = "";
            strDireccion.Text = "";
            strMail.Text = "";
            strNombre.Text = "";
            strTelefono.Text = "";


        }
        catch (System.Net.Mail.SmtpException ex)
        {
            string msg = ex.Message;
            this._message.Text = msg;//"Correo no fue enviado debido a problemas con el servidor de correos.";
            this._message.Visible = true;
        }
    }
    protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
    {
        EnviarMail();
    }
}
