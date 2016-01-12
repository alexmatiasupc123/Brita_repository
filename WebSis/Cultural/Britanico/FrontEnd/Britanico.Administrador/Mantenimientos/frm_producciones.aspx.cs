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

public partial class Mantenimientos_frm_producciones : System.Web.UI.Page
{
    BEProducciones bProducciones = new BEProducciones();
    BLProduccionesNTAD oProducciones = new BLProduccionesNTAD();
    BLProduccionesTAD gProducciones = new BLProduccionesTAD();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
       lblNombreSeccion.Text = "Agregar Producción";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvProducciones.Visible = false;
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
        txtContenido.Text = "";
        txtAnio.Text = "";
        txtTitulo.Text = "";

        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvProducciones.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bProducciones.prod_desc = txtContenido.Text;
        bProducciones.prod_nomb = txtTitulo.Text;
        bProducciones.prod_anio = txtAnio.Text;
        gProducciones.Agregar(bProducciones);
        gvProducciones.DataBind();
        limpiarInfo();
    }

    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bProducciones.prod_codi = Convert.ToInt32(lblCodigo.Text);
        bProducciones.prod_desc = txtContenido.Text;
        bProducciones.prod_nomb = txtTitulo.Text;
        bProducciones.prod_anio = txtAnio.Text;
        gProducciones.Modificar(bProducciones);
        gvProducciones.DataBind();
        limpiarInfo();
    }

    protected void gvProducciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idProduccion = Convert.ToInt32(gvProducciones.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Producción";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bProducciones = oProducciones.ListarRegistro(idProduccion);

        lblCodigo.Text = bProducciones.prod_codi.ToString();
        txtTitulo.Text = bProducciones.prod_nomb;
        txtAnio.Text = bProducciones.prod_anio;
        txtContenido.Text = bProducciones.prod_desc;
        btnNuevo.Visible = false;
        gvProducciones.Visible = false;
    }


    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idProduccion = Convert.ToInt32(btnEliminar.CommandArgument);

        gProducciones.Eliminar(idProduccion);
        gvProducciones.DataBind();

    }
    protected void gvProducciones_RowDataBound(object sender, GridViewRowEventArgs e)
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


           
        }
    }
}
