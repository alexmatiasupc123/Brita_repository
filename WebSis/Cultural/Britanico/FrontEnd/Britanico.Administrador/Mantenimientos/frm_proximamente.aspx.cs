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

public partial class Mantenimientos_frm_proximamente : System.Web.UI.Page
{
    BEInformacion bInformacion = new BEInformacion();
    BLInformacionNTAD oInformacion = new BLInformacionNTAD();
    BLInformacionTAD gInformacion = new BLInformacionTAD();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        gvInformacion.Visible = false;
        btnNuevo.Visible = false;
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
        //txtConductor.Text = "";
        txtContenido.Text = "";
        txtNombre.Text = "";
        // txtProgramacion.Text = "";
        // txtRadio.Text = "";
       
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        gvInformacion.Visible = true;
        btnNuevo.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bInformacion.info_fech = "";
        bInformacion.info_desc = txtContenido.Text;
        bInformacion.info_titu = txtNombre.Text;
        bInformacion.even_tipo = Convert.ToInt32(ddlTipoEvento.SelectedValue);
        gInformacion.Agregar(bInformacion);
        gvInformacion.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bInformacion.info_codi = Convert.ToInt32(lblCodigo.Text);
        bInformacion.info_fech = "";
        bInformacion.info_desc = txtContenido.Text;
        bInformacion.info_titu = txtNombre.Text;
        bInformacion.even_tipo = Convert.ToInt32(ddlTipoEvento.SelectedValue);
        gInformacion.Modificar(bInformacion);
        gvInformacion.DataBind();
        limpiarInfo();
    }

    protected void gvInformacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idInformacion = Convert.ToInt32(gvInformacion.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bInformacion = oInformacion.ListarRegistro(idInformacion);
        ddlTipoEvento.SelectedValue = bInformacion.even_tipo.ToString();
        lblCodigo.Text = bInformacion.info_codi.ToString();
        /// txtRadio.Text = bInformacion.brad_radio;
        // txtProgramacion.Text = bInformacion.brad_hora;
        txtNombre.Text = bInformacion.info_titu;
        // txtConductor.Text = bInformacion.brad_cond;
        txtContenido.Text = bInformacion.info_desc;
        btnNuevo.Visible = false;
        gvInformacion.Visible = false;


    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idInformacion = Convert.ToInt32(btnEliminar.CommandArgument);

        gInformacion.Eliminar(idInformacion);
        gvInformacion.DataBind();

    }
    protected void gvInformacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Int32 a = 100;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String desc = e.Row.Cells[2].Text;
            if (desc.Length < a)
            {
                a = desc.Length;
            }

            e.Row.Cells[2].Text = desc.Substring(0, a);


        }
    }
   
}
