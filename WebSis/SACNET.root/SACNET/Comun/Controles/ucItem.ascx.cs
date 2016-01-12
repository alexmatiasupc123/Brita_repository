using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Comun_Controles_ucItem : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void CargarDatosDeItemEjemplar(string prm_sCodEjemplar)
    {
        if (prm_sCodEjemplar != null)
        {
            if (prm_sCodEjemplar.Length > 0)
            {
                ItemLogic oItemLogic = new ItemLogic();
                ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
                ReturnValor oReturnValor = new ReturnValor();
                ItemEjemplar itemItemEjemplar = new ItemEjemplar();
                Item itemItem = new Item();

                vwUsuariosSAC ovwUsuariosSAC = (vwUsuariosSAC)Session["UsuarioSAC"];
                itemItemEjemplar = oItemEjemplarLogic.Buscar(prm_sCodEjemplar, ovwUsuariosSAC.CodLocalSAC);

                itemItem = oItemLogic.BuscarPorCodEjemplar(prm_sCodEjemplar);


                LabelTipoPrestamoCOD.Text = itemItem.sCodArguPrestamoEn;
                LabelTipoPrestamo.Text = itemItem.sCodArguPrestamoEnNombre;
                TextBoxCodigoItem.Text = itemItem.sCodItem;
                TextBoxTitulo.Text = itemItem.sTitulo;
                txtNotas.Text = itemItem.sFormatoAdicional;

                ListBoxActores.DataSource = itemItem.ListaActores;
                ListBoxActores.DataTextField = "sCodArguNombreActor";
                ListBoxActores.DataValueField = "sCodArguActor";
                ListBoxActores.DataBind();

                ListBoxAutores.DataSource = itemItem.ListaAutores;
                ListBoxAutores.DataTextField = "sCodArguNombreAutor";
                ListBoxAutores.DataValueField = "sCodArguAutor";
                ListBoxAutores.DataBind();


                if (itemItemEjemplar.sCodEjemplar != null)
                {
                    LabelEstadoEjemplar.Text = itemItemEjemplar.sCodArguNombreEstadoEjemplar;
                    LabelEstadoEjemplarCOD.Text = itemItemEjemplar.sCodArguEstadoEjemplar;

                }
                else
                {
                    LabelEstadoEjemplar.Text = string.Empty;
                    LabelEstadoEjemplarCOD.Text = string.Empty;
                    string LOCAL_SAC = ovwUsuariosSAC.CodLocalSACNombre == null ? string.Empty : ovwUsuariosSAC.CodLocalSACNombre;
                }
            }
            else
            {
                LabelEstadoEjemplar.Text = string.Empty;
                LabelEstadoEjemplarCOD.Text = string.Empty;
                LabelTipoPrestamo.Text = string.Empty;
                TextBoxCodigoItem.Text = string.Empty;
                TextBoxTitulo.Text = string.Empty;
                ListBoxActores.Items.Clear();
                ListBoxAutores.Items.Clear();
            }
        }
    }
}

