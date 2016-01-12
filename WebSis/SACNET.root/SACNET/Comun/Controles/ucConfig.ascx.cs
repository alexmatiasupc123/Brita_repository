using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;

public partial class Comun_Controles_ucConfig : System.Web.UI.UserControl
{


    public void Cargar()
    {

        ConfigLogic oConfigLogic = new ConfigLogic();
        string CodSistema = "0006";
        Repeater1.DataSource = oConfigLogic.Listar(CodSistema);
        Repeater1.DataBind();

    }
    public ReturnValor Guardar()
    {
        ReturnValor oReturn =new ReturnValor();
        oReturn.Exitosa = true;
        List<TConfig> lista = new List<TConfig>();
        try
        {

       
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            TConfig item = new TConfig();
            HiddenField hfCodConfig = ((HiddenField)Repeater1.Items[i].Controls[0].FindControl("hfCodConfig"));
            HiddenField hfCodTabla = ((HiddenField)Repeater1.Items[i].Controls[0].FindControl("hfCodTabla"));
            HiddenField hfTipoValor = ((HiddenField)Repeater1.Items[i].Controls[0].FindControl("hfTipoValor"));
            item.CodConfig = hfCodConfig.Value;
            if (hfCodTabla.Value.Trim() == "")
            {
                TextBox txtCodArgu = ((TextBox)Repeater1.Items[i].Controls[0].FindControl("txtCodArgu"));

                if (hfTipoValor.Value.ToString().ToLower() == "n")
                    if (txtCodArgu.Text == "0")
                    {
                        Label lblNombre = ((Label)Repeater1.Items[i].Controls[0].FindControl("lblNombre"));
                        oReturn.Exitosa = false;
                        oReturn.Message = "¡ El Parámetro: " + lblNombre.Text + " tiene que ser mayor que cero !";
                        break;
                    }
                item.Valor = txtCodArgu.Text;
            }
            else
            {
                DropDownList ddlCodArgu = ((DropDownList)Repeater1.Items[i].Controls[0].FindControl("ddlCodArgu"));
                item.Valor = ddlCodArgu.SelectedItem.Value;
            }

            item.SSIUsuario_Modificacion =  ((Usuarios)Session["Usuario"]).LoginUsuario;
            item.SSIHost = Context.Request.UserHostName;
            lista.Add(item);
        }
        if (oReturn.Exitosa)
        {
            ConfigLogic oConfigLogic = new ConfigLogic();
            oReturn = oConfigLogic.Actualizar(lista);
//            oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
        }
        }
        catch (Exception ex)
        {
            oReturn = HelpMessage.Message(ex);
        }
        return oReturn;
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HiddenField hfCodTabla = ((HiddenField)e.Item.Controls[0].FindControl("hfCodTabla"));
            HiddenField hfCodArgu = ((HiddenField)e.Item.Controls[0].FindControl("hfCodArgu"));
            HiddenField hfTipoValor = ((HiddenField)e.Item.Controls[0].FindControl("hfTipoValor"));
            TextBox txtCodArgu = ((TextBox)e.Item.Controls[0].FindControl("txtCodArgu"));
            DropDownList ddlCodArgu = ((DropDownList)e.Item.Controls[0].FindControl("ddlCodArgu"));
            Label lblSSIUsuario = ((Label)e.Item.Controls[0].FindControl("lblSSIUsuario"));
            Label lblAuditoria = ((Label)e.Item.Controls[0].FindControl("lblAuditoria"));
            if (hfCodTabla.Value.Trim() == "" )
            {
                ddlCodArgu.Visible = false;
                txtCodArgu.Visible = true;

                if (hfTipoValor.Value.Trim() == "n")
                {
                    txtCodArgu.Attributes.Add("onKeyPress", "return filterInput(1, event)");
                }
                txtCodArgu.Text = hfCodArgu.Value;

            }
            else
            {
                ddlCodArgu.Visible = true;
                txtCodArgu.Visible = false;
                HelpMaestros.CargarListadoGenerico(ref ddlCodArgu, hfCodTabla.Value,Convert.ToInt16(hfCodTabla.Value.Substring(5,1)), "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
                ddlCodArgu.SelectedValue = hfCodArgu.Value;
            }
            if (lblSSIUsuario.Text != string.Empty)
            {
                lblAuditoria.Visible = true;
            }
            else
            {
                lblAuditoria.Visible = false;
            }



        }
    }
   
}
