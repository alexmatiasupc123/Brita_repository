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

public partial class Mantenimientos_frm_sede : System.Web.UI.Page
{

    BESede bSede = new BESede();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BLSedeTAD gSede = new BLSedeTAD();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvSede_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idSede = Convert.ToInt32(gvSede.SelectedValue);
        //llena registro
        pNuevo.Visible = true;
        btnAgregar.Visible = false;
        btnGuardar.Visible = true;
        lblNombreSeccion.Text = "Editar Sede";
        lblCodigo.Visible = true;
        lblECodigo.Visible = true;
        bSede = oSede.ListarRegistro(idSede);
        lblCodigo.Text = bSede.sede_codi.ToString();
        txtNombre.Text = bSede.sede_nomb;
        txtDireccion.Text = bSede.sede_dire;
        btnNuevo.Visible = false;
        gvSede.Visible = false;


    }
    protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
    {
        lblNombreSeccion.Text = "Agregar Sede";
        lblCodigo.Visible = false;
        lblECodigo.Visible = false;
        pNuevo.Visible = true;
        btnAgregar.Visible = true;
        btnGuardar.Visible = false;
        btnNuevo.Visible = false;
        gvSede.Visible = false;
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        limpiarInfo();
    }

    void limpiarInfo()
    {
        txtDireccion.Text = "";
        txtNombre.Text = "";
        lblCodigo.Text = "";
        pNuevo.Visible = false;
        btnNuevo.Visible = true;
        gvSede.Visible = true;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        bSede.sede_nomb = txtNombre.Text;
        bSede.sede_dire = txtDireccion.Text;
        gSede.Agregar(bSede);
        gvSede.DataBind();
        limpiarInfo();
    }
    protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btnEliminar = (ImageButton)sender;
        Int32 idSede = Convert.ToInt32(btnEliminar.CommandArgument);

        gSede.Eliminar(idSede);
        gvSede.DataBind();
    
    }
    protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
    {
        bSede.sede_codi = Convert.ToInt32(lblCodigo.Text);                                
        bSede.sede_nomb = txtNombre.Text;
        bSede.sede_dire = txtDireccion.Text;
        gSede.Modificar(bSede);                                   
        gvSede.DataBind();
        limpiarInfo();
    }
}
