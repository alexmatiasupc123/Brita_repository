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
using System.Collections.Generic;

public partial class Britanico_Radio : System.Web.UI.Page
{
    BEBritanicoRadio bBritanicoRadio = new BEBritanicoRadio();
    BLBritanicoRadioNTAD oBritanicoRadio = new BLBritanicoRadioNTAD();
    protected void Page_Load(object sender, EventArgs e)
    {   
        llenarBritanicoRadio();
        if (!IsPostBack)
        {
            llenarRegistroInicialBritanicoRadio();
        }
    }

    void llenarRegistroInicialBritanicoRadio()
    {
        List<BEBritanicoRadio> listaBritanicoRadio = oBritanicoRadio.ListarTodos();
        Int32 idBritanicoRadio = listaBritanicoRadio[0].brad_codi;
        llenarRegistroBritanicoRadio(idBritanicoRadio);
    }

    void llenarRegistroBritanicoRadio(Int32 idBritanicoRadio)
    {
        BEBritanicoRadio RegistroBritanicoRadio = oBritanicoRadio.ListarRegistro(idBritanicoRadio);


        lblTitulo.Text = RegistroBritanicoRadio.brad_nomb;

        lblContenido.Text = RegistroBritanicoRadio.brad_desc;
        //lblRadio.Text = RegistroBritanicoRadio.brad_radio;
       /// lblConductor.Text = RegistroBritanicoRadio.brad_cond;
     //   lblProgramacion.Text = RegistroBritanicoRadio.brad_hora;
    }


    void llenarBritanicoRadio()
    {
        List<BEBritanicoRadio> listaBritanicoRadio = oBritanicoRadio.ListarTodos();
        foreach (BEBritanicoRadio iBritanico in listaBritanicoRadio)
        {
            iBritanico.brad_nomb = "> " + iBritanico.brad_nomb.ToUpper();
        }
        dlRadio.DataSource = listaBritanicoRadio;
        dlRadio.DataBind();

    }

    protected void dlRadio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idBritanicoRadio = Convert.ToInt32(dlRadio.SelectedValue);
        llenarRegistroBritanicoRadio(idBritanicoRadio);
    }
}
