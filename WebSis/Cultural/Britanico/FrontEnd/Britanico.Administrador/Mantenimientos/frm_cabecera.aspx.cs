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

public partial class Mantenimientos_frm_cabecera : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BECabecera bCabecera = new BECabecera();
    BLCabeceraNTAD oCabecera = new BLCabeceraNTAD();
    BLCabeceraTAD gCabecera = new BLCabeceraTAD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            cargarInfo();
        }
    }
    protected void cargarInfo() {

            bCabecera = oCabecera.ListarXTitulo(ddlTitulo.SelectedValue);
            if (bCabecera != null)
            {
                hidCodigo.Value = bCabecera.cabe_codi.ToString();
                imgCabe.ImageUrl = rutaUpload + bCabecera.cabe_imag.ToString();
            }
    
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
        Response.Redirect("~/Inicio.aspx");
    }

    void limpiarInfo()
    {
        hidCodigo.Value = "";
        imgCabe.ImageUrl = "";
        fuImagen.Dispose();

       
    }
    
    void guardaImagen(BECabecera bCabecera)
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
                    bCabecera.cabe_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bCabecera.cabe_imag);
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

        bCabecera.cabe_titu = ddlTitulo.SelectedValue;
        string nombreImagen = rutaUnload + bCabecera.cabe_imag;
        guardaImagen(bCabecera);
        eliminaImagen(nombreImagen);
        if (hidCodigo.Value=="")
        {
            gCabecera.Agregar(bCabecera);
        }
        else {
            bCabecera.cabe_codi = Convert.ToInt32(hidCodigo.Value);
            gCabecera.Modificar(bCabecera);
        }
        cargarInfo();
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

    protected void ddlTitulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        limpiarInfo();
        cargarInfo();
    }
}
