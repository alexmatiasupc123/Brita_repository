using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;

using Oxinet.Tools;
using System.Data;

public partial class PopupDocumentosDePago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = lblTituloPagina.Text;
            CargarPagina();
        }
        Page.Title = lblTituloPagina.Text;
    }

    protected void CheckBoxSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox TieneCheckBoxSelect = ((CheckBox)sender);
        foreach (GridViewRow item in gvPagosUsuarios.Rows)
        {
            CheckBox TieneReserva2;
            TieneReserva2 = ((CheckBox)item.Cells[5].FindControl("CheckBoxSelect"));
            if (Convert.ToInt32(TieneCheckBoxSelect.ValidationGroup) != item.RowIndex)
            {
                TieneReserva2.Checked = false;
            }
        }
    }

    protected void imgbtnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        string strdatos1 = null;

        strdatos1 = string.Empty;

        foreach (GridViewRow item in gvPagosUsuarios.Rows)
        {
            if (item.RowType == DataControlRowType.DataRow)
            {
                CheckBox TieneSelect = ((CheckBox)item.Cells[5].FindControl("CheckBoxSelect"));
                if (TieneSelect.Checked)
                {
                    string[] docsX = item.Cells[1].Text.Split('-');
                    string[] sacsX = item.Cells[3].Text.Split('-');
                    strdatos1 = strdatos1 + Server.UrlEncode(item.Cells[2].Text) + "&";   //    USUARIO
                    strdatos1 = strdatos1 + docsX[0] + "&";             //    TIPO DE DOCUMENTO
                    //strdatos1 = strdatos1 + docsX[1] + "&";             //    NUMERO DE DOCUMENTO
                    strdatos1 = strdatos1 + docsX[1] + "-";
                    strdatos1 = strdatos1 + docsX[2] + "&";

                    strdatos1 = strdatos1 + sacsX[0] + "&";             //    ESTABLECIMIENTO CODIGO
                    strdatos1 = strdatos1 + sacsX[1] + "&";             //    ESTABLECIMIENTO NOMBRE
                    strdatos1 = strdatos1 + item.Cells[1].Text + "&";   //    TIPO Y NUMERO DE DOCUMENTO
                }
            }
        }

        int intValor = 1;
        if (strdatos1.Length > 0)
        {
            strdatos1 = strdatos1 + Convert.ToString(intValor);

            //Aqui tenemos q cerrar el Popup y retornar el valor concatenado PERO recordemos 
            //que la funcion para cerrar esta en JavaScript..

            string script = String.Format("CerrarOK('{0}')", strdatos1);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CerrarOK", script, true);
        }
        else
            MessageBox1.ShowInfo("¡ Seleccionar documento de pago de duplicado de carné del usuario SAC !");
    }

    protected void imgbtnCancelar_Click(object sender, ImageClickEventArgs e)
    {

        ////  Aqui tenemos q cerrar el Popup y retornar el valor concatenado PERO recordemos que la funcion 
        ////  para cerrar esta en JavaScript..


        string script = String.Format("CerrarCancel()", "");
        if (!this.Page.ClientScript.IsStartupScriptRegistered("CerrarCancelScript"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarCancelScript", script, true);
        }

    }

    private void CargarPagina()
    {
        String querystringDESENCRYP = string.Empty;
        if (Request.QueryString.Get("pm") != null)
            querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
        HF_CodUsuarioSAC.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "id");

        ListarDatos();


    }

    private void ListarDatos()
    {
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        List<vwPagosUsuarioSAC> miLista = new List<vwPagosUsuarioSAC>();

        miLista = ovwDatosVistaLogic.Listarvw_PagosUsuarioSAC(HF_CodUsuarioSAC.Value);
        gvPagosUsuarios.DataSource = HelpConvert<vwPagosUsuarioSAC>.ConvertList(miLista);
        gvPagosUsuarios.DataBind();
    }

    protected void gvPagosUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView IOK = (DataRowView)e.Row.DataItem;

            CheckBox TieneReserva;
            TieneReserva = ((CheckBox)e.Row.Cells[5].FindControl("CheckBoxSelect"));
            TieneReserva.ValidationGroup = e.Row.RowIndex.ToString();

        }
    }

    protected void gvPagosUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPagosUsuarios.PageIndex = e.NewPageIndex;
        ListarDatos();
    }
}
