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
using System.IO;

public partial class Mantenimientos_frm_noticias : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();

    BENoticia bNoticia = new BENoticia();
    BLNoticiaNTAD oNoticia = new BLNoticiaNTAD();
    BLNoticiaTAD gNoticia = new BLNoticiaTAD();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Noticia";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvNoticias.Visible = false;
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
        txtContenido.Text = "";
        txtSubtitulo.Text = "";
        txtTitulo.Text = "";
        txtFecha.Text = "";
        fuImagen.Dispose();

        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvNoticias.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bNoticia.noti_desc = txtContenido.Text;
        bNoticia.noti_titu = txtTitulo.Text;
        bNoticia.noti_subt = txtSubtitulo.Text;
        bNoticia.noti_fech = Convert.ToDateTime(txtFecha.Text);
        guardaImagen(bNoticia);
        gNoticia.Agregar(bNoticia);
        gvNoticias.DataBind();
        limpiarInfo();
    }

    void guardaImagen(BENoticia bNoticia)
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
                    bNoticia.noti_imag = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                    fuImagen.SaveAs(Server.MapPath(rutaUpload) + bNoticia.noti_imag);
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
        bNoticia.noti_codi = Convert.ToInt32(lblCodigo.Text);
        bNoticia.noti_desc = txtContenido.Text;
        bNoticia.noti_titu = txtTitulo.Text;
        bNoticia.noti_subt = txtSubtitulo.Text;
        bNoticia.noti_fech = Convert.ToDateTime(txtFecha.Text);
        BENoticia eNoticia = oNoticia.ListarRegistro(bNoticia.noti_codi);
        string nombreImagen = rutaUnload + eNoticia.noti_imag;
        guardaImagen(bNoticia);
        eliminaImagen(nombreImagen);
        gNoticia.Modificar(bNoticia);
        gvNoticias.DataBind();
        limpiarInfo();
    }

    protected void gvNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idNoticia = Convert.ToInt32(gvNoticias.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Noticia";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bNoticia = oNoticia.ListarRegistro(idNoticia);

        lblCodigo.Text = bNoticia.noti_codi.ToString();
        txtTitulo.Text = bNoticia.noti_titu;
        txtSubtitulo.Text = bNoticia.noti_subt;
        txtContenido.Text = bNoticia.noti_desc;
        txtFecha.Text = bNoticia.noti_fech.ToShortDateString();
        btnNuevo.Visible = false;
        gvNoticias.Visible = false;
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idNoticia = Convert.ToInt32(btnEliminar.CommandArgument);
        bNoticia = oNoticia.ListarRegistro(idNoticia);
        string nombreImagen = rutaUnload + bNoticia.noti_imag;
        gNoticia.Eliminar(idNoticia);
        eliminaImagen(nombreImagen);
        gvNoticias.DataBind();

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
    protected void gvNoticias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[4].Text;
            if (desc.Length < a)
            {
                a = desc.Length;
            }

            e.Row.Cells[4].Text = desc.Substring(0, a);


            //
            String subt = e.Row.Cells[2].Text;
            if (subt.Length < a)
            {
                a = subt.Length;
            }

            e.Row.Cells[2].Text = subt.Substring(0, a);

        }
    }
}
