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

public partial class Mantenimientos_frm_publicaciones : System.Web.UI.Page
{
    BEPublicaciones bPublicacion =  new BEPublicaciones();
    BLPublicacionesNTAD oPublicacion = new BLPublicacionesNTAD();
    BLPublicacionesTAD gPublicacion = new BLPublicacionesTAD();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
       lblNombreSeccion.Text = "Agregar Publicación";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvPublicacion.Visible = false;
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

        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvPublicacion.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bPublicacion.publ_desc = txtContenido.Text;
        bPublicacion.publ_nomb = txtTitulo.Text;
        bPublicacion.publ_subt = txtSubtitulo.Text;
        gPublicacion.Agregar(bPublicacion);
        gvPublicacion.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bPublicacion.publ_codi = Convert.ToInt32(lblCodigo.Text);
        bPublicacion.publ_desc = txtContenido.Text;
        bPublicacion.publ_nomb = txtTitulo.Text;
        bPublicacion.publ_subt = txtSubtitulo.Text;
        gPublicacion.Modificar(bPublicacion);
        gvPublicacion.DataBind();
        limpiarInfo();
    }

    protected void gvPublicacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idPublicacion = Convert.ToInt32(gvPublicacion.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
       lblNombreSeccion.Text= "Editar Publicación";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bPublicacion = oPublicacion.ListarRegistro(idPublicacion);
       
        lblCodigo.Text = bPublicacion.publ_codi.ToString();
        txtTitulo.Text = bPublicacion.publ_nomb;
        txtSubtitulo.Text = bPublicacion.publ_subt;
        txtContenido.Text = bPublicacion.publ_desc;
        btnNuevo.Visible = false;
        gvPublicacion.Visible = false;
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idPublicacion = Convert.ToInt32(btnEliminar.CommandArgument);

        gPublicacion.Eliminar(idPublicacion);
        gvPublicacion.DataBind();

    }
    protected void gvPublicacion_RowDataBound(object sender, GridViewRowEventArgs e)
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
