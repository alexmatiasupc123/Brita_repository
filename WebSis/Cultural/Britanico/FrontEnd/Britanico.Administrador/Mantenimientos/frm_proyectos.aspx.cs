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

public partial class Mantenimientos_frm_proyectos : System.Web.UI.Page
{
    BEProyecto bProyecto = new BEProyecto();
    BLProyectoNTAD oProyecto = new BLProyectoNTAD();
    BLProyectoTAD gProyecto = new BLProyectoTAD();
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    String rutaUnload = ConfigurationManager.AppSettings["eliminaUpload"].ToString();
    string bImagenURL;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Proyecto";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvProyecto.Visible = false;
        img.Visible = false;
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
        fuImagen.Dispose();
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvProyecto.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bProyecto.proy_desc = txtContenido.Text;
        bProyecto.proy_nomb = txtTitulo.Text;
        bProyecto.proy_subt = txtSubtitulo.Text;
       
        if (fuImagen.PostedFile.ContentLength > 0)
        {
            guardaImagen(bProyecto);
        }

        gProyecto.Agregar(bProyecto);
        gvProyecto.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bProyecto.proy_codi = Convert.ToInt32(lblCodigo.Text);
        bProyecto.proy_desc = txtContenido.Text;
        bProyecto.proy_nomb = txtTitulo.Text;
        bProyecto.proy_subt = txtSubtitulo.Text;
       
        if (fuImagen.PostedFile.ContentLength > 0)
        {
            guardaImagen(bProyecto);
        }
        else
        {
            if (Session["img"] != null)
            {
                bProyecto.proy_imag = Session["img"].ToString();

            }
        }

        gProyecto.Modificar(bProyecto);
        gvProyecto.DataBind();
        limpiarInfo();
    }


    void guardaImagen(BEProyecto bProyecto)
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
                bProyecto.proy_imag  = string.Format("{0}{1}", System.Guid.NewGuid().ToString(), System.IO.Path.GetExtension(fuImagen.PostedFile.FileName));
                fuImagen.SaveAs(Server.MapPath(rutaUpload) + bProyecto.proy_imag);
            }
            catch (Exception ex)
            {
                lblError.Text = "**ERROR: " + ex.Message.ToString();
            }

        }

        // }
    }

    protected void gvProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProyecto = Convert.ToInt32(gvProyecto.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Proyecto";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bProyecto = oProyecto.ListarRegistro(idProyecto);

        lblCodigo.Text = bProyecto.proy_codi.ToString();
        txtTitulo.Text = bProyecto.proy_nomb;
        txtSubtitulo.Text = bProyecto.proy_subt;
        txtContenido.Text = bProyecto.proy_desc;

        bImagenURL = rutaUpload + bProyecto.proy_imag;
        Session["img"] = bProyecto.proy_imag;

        img.Visible = true;
       
        img.ImageUrl = bImagenURL;
      

        btnNuevo.Visible = false;
        gvProyecto.Visible = false;
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idProyecto = Convert.ToInt32(btnEliminar.CommandArgument);

        gProyecto.Eliminar(idProyecto);
        gvProyecto.DataBind();

    }
    protected void gvProyecto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[3].Text;
            if (desc.Length < a)
            {
                a = desc.Length;
            }

            e.Row.Cells[3].Text = desc.Substring(0, a);


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
