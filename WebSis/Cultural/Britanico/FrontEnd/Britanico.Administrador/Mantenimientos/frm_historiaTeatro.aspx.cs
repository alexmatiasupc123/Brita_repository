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

public partial class Mantenimientos_frm_historiaTeatro : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BEHistoriaTeatro bHistoriaTeatro = new BEHistoriaTeatro();
    BLHistoriaTeatroNTAD oHistoriaTeatro = new BLHistoriaTeatroNTAD();
    BLHistoriaTeatroTAD gHistoriaTeatro = new BLHistoriaTeatroTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            cargarInfo();
        }
    }
    protected void cargarInfo() {

        List<BEHistoriaTeatro> bHistoriaTeatroList = new List<BEHistoriaTeatro>();
        bHistoriaTeatroList=oHistoriaTeatro.ListarTodos();
        if (bHistoriaTeatroList.Count  > 0) {
            bHistoriaTeatro = bHistoriaTeatroList[0];
            hidCodigo.Value = bHistoriaTeatro.histo_codi.ToString();
            txtContenido.Text = bHistoriaTeatro.histo_desc;
            txtFecha.Text = bHistoriaTeatro.histo_fech.ToShortDateString();
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
    
    void guardaImagen(BEHistoriaTeatro bHistoriaTeatro)
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
                    bHistoriaTeatro.histo_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bHistoriaTeatro.histo_imag);
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
        
        bHistoriaTeatro.histo_desc = txtContenido.Text;
        bHistoriaTeatro.histo_fech = Convert.ToDateTime(txtFecha.Text);
        bHistoriaTeatro.histo_titu = "Historia del Teatro";
        string nombreImagen = rutaUnload + bHistoriaTeatro.histo_imag;
        guardaImagen(bHistoriaTeatro);
        eliminaImagen(nombreImagen);
        if (hidCodigo.Value=="")
        {
            gHistoriaTeatro.Agregar(bHistoriaTeatro);
        }
        else {
            bHistoriaTeatro.histo_codi = Convert.ToInt32(hidCodigo.Value);
            gHistoriaTeatro.Modificar(bHistoriaTeatro);
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
