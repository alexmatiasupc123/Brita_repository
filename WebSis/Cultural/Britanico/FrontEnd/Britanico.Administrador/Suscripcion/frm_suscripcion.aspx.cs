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
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.Web.BusinessEntities;
using System.Collections.Generic;
using System.Text;
using System.IO;


public partial class Suscripcion_frm_suscripcion : System.Web.UI.Page
{
    BLSuscriptorNTAD oSuscriptores = new BLSuscriptorNTAD();


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void gvSuscriptores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        DateTime inicio = Convert.ToDateTime(txt_fechainicio.Text);
        DateTime fin = Convert.ToDateTime(txt_fechafin.Text);
        Int32 estado = Convert.ToInt32(rblEstado.SelectedValue);

        List<BESuscriptor> listaSuscriptores = oSuscriptores.ListarTodosXValores(inicio,fin,estado);
        if (listaSuscriptores.Count > 0)
        { 
        
        btnImprimir.Visible = true;
        btnExportar.Visible = true;
        gvSuscriptores.DataSource = listaSuscriptores;
        gvSuscriptores.DataBind();

        StringBuilder SB = new StringBuilder();
        StringWriter SW = new StringWriter(SB);
        HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
        gvSuscriptores.RenderControl(htmlTW);

        string strHTML = SB.ToString();
        Session["strData"] = strHTML;
       // Response.Redirect("DataExcel.aspx",false);
        //mime type
       // string strHTML = Session["strData"].ToString();
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        this.EnableViewState = false;
        Response.Write(strHTML);
        Response.End();
        }
        
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.
        // No code required here.
    }
}
