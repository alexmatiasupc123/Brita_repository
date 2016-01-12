using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

//using Petranso.Atm.BusinessLogic;
//using Petranso.Atm.BusinessEntities;
//using Oxinet.Tools.Comun;

using Oxinet.Tools;

public partial class Controles_BuscarEntidad : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        if (!IsPostBack)
        {
            cargarPagina();
        }

    }
    protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        buscar();
    }
    protected void ddlTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoEntidad.SelectedIndex != 0)
        {
            string CodTipoEntidad = ddlTipoEntidad.SelectedValue.ToString();
            lblCodPersona.Visible = true;
            txtCodPersona.Visible = true;
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            if (CodTipoEntidad == "01") //persona
            {
                lblCodPersona.Text = "DNI:";
                lblNombre.Text = "Apellido:";
                gvBuscar.Columns[0].HeaderText = "DNI";
                gvBuscar.Columns[2].Visible = false;
                gvBuscar.Columns[3].Visible = true;
                gvBuscar.Columns[4].Visible = true;

            }
            else if (CodTipoEntidad == "02")//juridica
            {
                lblCodPersona.Text = "RUC:";
                lblNombre.Text = "Razon:";
                gvBuscar.Columns[0].HeaderText = "RUC";
                gvBuscar.Columns[2].Visible = true;
                gvBuscar.Columns[3].Visible = false;
                gvBuscar.Columns[4].Visible = false;
            }
            gvBuscar.DataBind();

        }
        else
        {
            lblCodPersona.Visible = false;
            txtCodPersona.Visible = false;
            lblNombre.Visible = false;
            txtNombre.Visible = false;
        }
    }
    private void cargarPagina()
    {
        //HelpMaestros.CargarListadoGenerico(ref ddlTipoEntidad, Helper.CodigoTabla(Helper.TablasMaestras.TipoEntidad), 1, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);

    }
    private void buscar()
    {


        if (ddlTipoEntidad.SelectedIndex != 0)
        {
            string CodTipoEntidad = ddlTipoEntidad.SelectedValue.ToString();
           


            //PersonasLogic oPersonasLogic = new PersonasLogic();
            //List<Personas> lista = oPersonasLogic.Listar(txtCodPersona.Text, txtNombre.Text, CodTipoEntidad, Util.ObtenerIdioma(),"");
            //gvBuscar.DataSource = lista;
            //gvBuscar.DataBind();
        }
        else
        {
            lblError.Text ="Seleccione un Tipo de Entidad";
            lblError.Visible = true;
        }

    }
    protected void gvBuscar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvBuscar.PageIndex = e.NewPageIndex;
        buscar();
    }
    protected void gvBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {

        StringBuilder Seleccionado = new StringBuilder();
        Seleccionado.Append("Entidad" + "&");  //....
        if (Request.QueryString.Get("Index") != null)
            Seleccionado.Append(Request.QueryString.Get("Index") + "&");  //Index
        Seleccionado.Append(gvBuscar.SelectedRow.Cells[0].Text + "&");  //Codigo
        Seleccionado.Append(gvBuscar.SelectedRow.Cells[2].Text + gvBuscar.SelectedRow.Cells[3].Text + " , " + gvBuscar.SelectedRow.Cells[4].Text );  //Nombre Completo
        //Aqui tenemos q cerrar el Popup y retornar el valor concatenado PERO recordemos que la funcion para cerrar esta en JavaScript..

        string script = String.Format("CerrarOK('{0}')", Seleccionado.ToString());
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerraOkScript"))
        {
            //Client Script CallBack.. la capacidad del servidor de ejecutar una funcion JavaScript desde el servidor.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerraOkScript", script, true);
        }

    }
   
}
