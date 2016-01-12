using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.BusinessLogic.Transaccionales;
using System.IO;

public partial class Mantenimientos_frm_agendaCultural : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEAgendaCultural bAgendaCultural = new BEAgendaCultural();
    BLAgendaCulturalNTAD oAgendaCultural = new BLAgendaCulturalNTAD();
    BLAgendaCulturalTAD gAgendaCultural = new BLAgendaCulturalTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            cargarInfo();
        }
    }
    protected void cargarInfo() {

        List<BEAgendaCultural> bAgendaCulturalList = new List<BEAgendaCultural>();
        bAgendaCulturalList=oAgendaCultural.ListarTodos();
        if (bAgendaCulturalList.Count  > 0) {
            bAgendaCultural = bAgendaCulturalList[0];
            hidCodigo.Value = bAgendaCultural.agen_codi.ToString();
            txtContenido.Text = bAgendaCultural.agen_desc;
            txtFecha.Text = bAgendaCultural.agen_fech.ToShortDateString();
       }
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
        Response.Redirect("~/Inicio.aspx");
    }

    void limpiarInfo()
    {
        txtContenido.Text = "";
        txtFecha.Text = "";
        fuImagen.Dispose();

       
    }
    
    void guardaImagen(BEAgendaCultural bAgendaCultural)
    {

        //guardar imagen
        if (fuImagen.PostedFile.ContentLength > 0)
        {
            long maximo = 204800;
            long tamanio = fuImagen.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Imagen excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bAgendaCultural.agen_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bAgendaCultural.agen_imag);
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        }
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        
        bAgendaCultural.agen_desc = txtContenido.Text;
        bAgendaCultural.agen_fech = Convert.ToDateTime(txtFecha.Text);
        bAgendaCultural.agen_titu = "agenria del Teatro";
        string nombreImagen = rutaUnload + bAgendaCultural.agen_imag;
        guardaImagen(bAgendaCultural);
        eliminaImagen(nombreImagen);
        if (hidCodigo.Value=="")
        {
            gAgendaCultural.Agregar(bAgendaCultural);
        }
        else {
            bAgendaCultural.agen_codi = Convert.ToInt32(hidCodigo.Value);
            gAgendaCultural.Modificar(bAgendaCultural);
        }
        //cargarInfo();
        Response.Redirect("~/Inicio.aspx");
    }

    

    
    void eliminaImagen(String nombreImagen)
    {
       
       if (nombreImagen.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(nombreImagen);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    
}
