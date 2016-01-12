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

public partial class Mantenimientos_frm_britanicoRadio : System.Web.UI.Page
{
    BEBritanicoRadio bBritanicoRadio = new BEBritanicoRadio();
    BLBritanicoRadioNTAD oBritanicoRadio = new BLBritanicoRadioNTAD();
    BLBritanicoRadioTAD gBritanicoRadio = new BLBritanicoRadioTAD();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text= "Agregar";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        gvBritanicoRadio.Visible = false;
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
        gvBritanicoRadio.Visible = true;
        btnNuevo.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bBritanicoRadio.brad_cond = "";
       bBritanicoRadio.brad_desc = txtContenido.Text;
       bBritanicoRadio.brad_hora = "";
        bBritanicoRadio.brad_nomb = txtNombre.Text;
        bBritanicoRadio.brad_radio = "";
        gBritanicoRadio.Agregar(bBritanicoRadio);
        gvBritanicoRadio.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bBritanicoRadio.brad_codi = Convert.ToInt32(lblCodigo.Text);
       bBritanicoRadio.brad_cond = "";
        bBritanicoRadio.brad_desc = txtContenido.Text;
        bBritanicoRadio.brad_hora = "";
       bBritanicoRadio.brad_nomb = txtNombre.Text;
       bBritanicoRadio.brad_radio = "";
        gBritanicoRadio.Modificar(bBritanicoRadio);
        gvBritanicoRadio.DataBind();
        limpiarInfo();
    }

    protected void gvBritanicoRadio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idBritanicoRadio = Convert.ToInt32(gvBritanicoRadio.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text= "Editar";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bBritanicoRadio = oBritanicoRadio.ListarRegistro(idBritanicoRadio);

        lblCodigo.Text = bBritanicoRadio.brad_codi.ToString();
       /// txtRadio.Text = bBritanicoRadio.brad_radio;
       // txtProgramacion.Text = bBritanicoRadio.brad_hora;
        txtNombre.Text = bBritanicoRadio.brad_nomb;
       // txtConductor.Text = bBritanicoRadio.brad_cond;
        txtContenido.Text = bBritanicoRadio.brad_desc;
        btnNuevo.Visible = false;
        gvBritanicoRadio.Visible = false;


    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idBritanicoRadio = Convert.ToInt32(btnEliminar.CommandArgument);

        gBritanicoRadio.Eliminar(idBritanicoRadio);
        gvBritanicoRadio.DataBind();

    }
    protected void gvBritanicoRadio_RowDataBound(object sender, GridViewRowEventArgs e)
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
