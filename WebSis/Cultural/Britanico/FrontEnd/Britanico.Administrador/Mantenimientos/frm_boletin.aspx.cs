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
using System.IO;

public partial class Mantenimientos_frm_boletin : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEBoletin bBoletin = new BEBoletin();
    BLBoletinNTAD oBoletin = new BLBoletinNTAD();
    BLBoletinTAD gBoletin = new BLBoletinTAD();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiaInfo();
    }



 

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bBoletin.bole_publ = true;
        bBoletin.bole_fech = DateTime.Today.Date;
        bBoletin.bole_titu = txtTituto.Text;
        
        //guardar archivo
        if (fuArchivo.PostedFile.ContentLength > 0)
        {
            long maximo = 3072000;
            long tamanio = fuArchivo.FileContent.Length;
            if (tamanio > maximo)
            {
                lblError.Text = "**ERROR: Archivo excede el tamaño permitido";
            }
            else
            {
                try
                {
                    bBoletin.bole_nomb = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuArchivo.PostedFile.FileName));
                    fuArchivo.SaveAs(Server.MapPath(rutaUpload) + bBoletin.bole_nomb);
                    gBoletin.Agregar(bBoletin);
                    gvBoletines.DataBind();
                    limpiaInfo();
                }
                catch (Exception ex)
                {
                    lblError.Text = "**ERROR: " + ex.Message.ToString();
                }

            }

        }
       

    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        pNuevo.Visible = true;
        btnNuevo.Visible = false;
        gvBoletines.Visible = false;
    }

    void limpiaInfo()
    {
        txtTituto.Text = "";
        fuArchivo.Dispose();
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvBoletines.Visible = true;
    }
  
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idBoletin = Convert.ToInt32(btnEliminar.CommandArgument);
        bBoletin = oBoletin.ListarRegistro(idBoletin);
        string nombreArchivo = rutaUnload + bBoletin.bole_nomb;
        gBoletin.Eliminar(idBoletin);

        if (nombreArchivo.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(nombreArchivo);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }

        gvBoletines.DataBind();
    }
}
