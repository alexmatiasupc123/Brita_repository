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
using Britanico.Utilitario.Funciones;

public partial class Muestra_Galeria : System.Web.UI.Page
{
    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BLGaleriaArteNTAD oGaleria = new BLGaleriaArteNTAD();
    BEGaleriaArte bGaleria = new BEGaleriaArte();
    BESede eSede = new BESede();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BEMuestraGaleria bMuestraGaleria = new BEMuestraGaleria();
    BLMuestraGaleriaNTAD oMuestraGaleria = new BLMuestraGaleriaNTAD();
    Funciones funciones = new Funciones();
    Int32 idGaleria;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarGalerias();
            llenarListaInicialDetalleMuestra();
        }
    }


    void llenarGalerias()
    {
        List<BEGaleriaArte> listaGalerias = oGaleria.ListarTodos();
        if (listaGalerias.Count > 0)
        {
            foreach (BEGaleriaArte iGaleria in listaGalerias)
            {
                iGaleria.gale_nomb = "> " + iGaleria.gale_nomb.ToUpper();
            }
        }
        dlGaleria.DataSource = listaGalerias;
        dlGaleria.DataBind();
    }


    void llenarListaInicialDetalleMuestra()
    {

    List<BEGaleriaArte> listaGaleria = oGaleria.ListarTodos();
    if (listaGaleria.Count > 0)
    {
        if (Session["idGaleria"] != null)
            idGaleria = Convert.ToInt32(Session["idGaleria"]);
        else
        {
            idGaleria = listaGaleria[0].gale_codi;
            Session["idGaleria"] = idGaleria.ToString();
        }

        llenarListaDetalleMuestra(idGaleria);
    }



        
    }

    void llenarListaDetalleMuestra(Int32 idGaleria)
    {

        bGaleria = oGaleria.ListarRegistro(idGaleria);
        eSede = oSede.ListarRegistro(bGaleria.sede_codi);
        lblTituloGaleria.Text = bGaleria.gale_nomb;

        lblDireccion.Text = eSede.sede_dire.ToUpper() + " - " + eSede.sede_nomb.ToUpper();

        List<BEMuestraGaleria> listaDetalle = oMuestraGaleria.ListarTodosXGaleria(idGaleria);
        foreach (BEMuestraGaleria iDetalle in listaDetalle)
        {
            if (iDetalle.mues_imag != null)
            {
                iDetalle.mues_imag = string.Format("{0}{1}", rutaUpload, iDetalle.mues_imag);

            }
            if (iDetalle.mues_desc.Length > 200)
                iDetalle.mues_desc = iDetalle.mues_desc.Substring(0, 200).ToString() + "...";
            else
                iDetalle.mues_desc = iDetalle.mues_desc + "...";
        }
        
        
        dlDetalleMuestra.DataSource = listaDetalle;
        dlDetalleMuestra.DataBind();
    }

  
    protected void dlDetalleMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 idDetalleMuestra = Convert.ToInt32(dlDetalleMuestra.SelectedValue);
        Session["idDetalleMuestra"] = idDetalleMuestra.ToString();
        Response.Redirect("MuestraGaleria_Detalle.aspx");
    }


    protected void dlGaleria_SelectedIndexChanged(object sender, EventArgs e)
    {
        idGaleria = Convert.ToInt32(dlGaleria.SelectedValue);
        llenarListaDetalleMuestra(idGaleria);
    

    }

  
    protected void dlDetalleMuestra_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image foto = (Image)e.Item.FindControl("imgFoto");
        Panel pDetalle = (Panel)e.Item.FindControl("pDetalle");
        if (foto.ImageUrl != "")
        {
            foto.Visible = true;
            pDetalle.Width = 334;
        }
        else
        {
            foto.Visible = false;
            pDetalle.Width =400;
        }
    }

}
