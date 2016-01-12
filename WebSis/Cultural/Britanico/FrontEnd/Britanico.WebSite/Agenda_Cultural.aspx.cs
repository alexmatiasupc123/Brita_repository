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

public partial class Agenda_Cultural : System.Web.UI.Page
{

    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEAgendaCultural bAgendaCultural = new BEAgendaCultural();
    BLAgendaCulturalNTAD oAgendaCultural = new BLAgendaCulturalNTAD();
    BEEvento bEvento = new BEEvento();
    BLEventoNTAD oEvento = new BLEventoNTAD();
    Int32 sede;
    String criterio;
    List<BEEvento> listaEventos;
    String tipoCriterio;
    Int32 tipoEvento;
    Int32 idEvento;
    Funciones funciones = new Funciones();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            cargarInfo();
        }

        if (Session["tipoCriterio"] != null)
        {
            tipoCriterio = Session["tipoCriterio"].ToString();

            if (Session["idSede"] != null)
            {
                sede = Convert.ToInt32(Session["idSede"]);
            }

            if (Session["criterio"] != null)
            {
                criterio = Session["criterio"].ToString();
            }
            if (tipoCriterio == "0")
            {
                listaEventos = oEvento.ListarTodos(sede);
                lblCriterio.Text = "** Agenda Cultural por Sede";
                BESede bSede = new BESede();
                BLSedeNTAD oSede = new BLSedeNTAD();
                bSede = oSede.ListarRegistro(sede);
                lblClave.Text = bSede.sede_dire + " - " + bSede.sede_nomb;

            }
            else if (tipoCriterio == "1")
            {
                listaEventos = oEvento.ListarTodos(criterio);
                lblCriterio.Text = "** Agenda Cultural por Criterios de Busqueda";
                lblClave.Text = criterio;
            }

           

            foreach (BEEvento iEvento in listaEventos)
            {

                if (iEvento.even_imag != null)
                {
                    iEvento.even_imag = string.Format("{0}{1}", rutaUpload, iEvento.even_imag);
                }

                iEvento.even_desc = iEvento.even_desc + "...";

             }
            dlAgenda.DataSource = listaEventos;
            dlAgenda.DataBind();
        }
        else
        {
            lblCriterio.Text = "** No hay Criterios de Busqueda Activo";
            lblClave.Text = "";
        }
       

       
    }

    protected void cargarInfo()
    {

        List<BEAgendaCultural> bAgendaCulturalList = new List<BEAgendaCultural>();
        bAgendaCulturalList = oAgendaCultural.ListarTodos();
        if (bAgendaCulturalList.Count > 0)
        {
            bAgendaCultural = bAgendaCulturalList[0];
            lblContenido.Text = bAgendaCultural.agen_desc;
            if (bAgendaCultural.agen_imag != null && bAgendaCultural.agen_imag != "" && bAgendaCultural.agen_desc!="")
            {
                imgFoto.ImageUrl = string.Format("{0}{1}", rutaUpload, bAgendaCultural.agen_imag);
                imgFoto.Visible = true;
            }
            else
            {
                imgFoto.Visible = false;
            }

    
        }

    }

    protected void dlAgenda_SelectedIndexChanged(object sender, EventArgs e)
    {
      Int32 even_codi  = Convert.ToInt32(dlAgenda.SelectedValue);
    
        foreach (BEEvento iEvento in listaEventos)
        {
            if (iEvento.even_codi == even_codi)
            {
                idEvento = iEvento.even_codr;
                tipoEvento = iEvento.even_tipo;
            }

        }
        //tipo de evento 1 = Auditorio,2 = Teatro, 3 = Concurso Temporada, 4 = cursos y talleres, 0= galeria arte detalle
        if (tipoEvento == 0)
        {
            Session["idDetalleGaleria"] = idEvento.ToString();
            Response.Redirect("GaleriaArte_Detalle.aspx");
        }
        
        if (tipoEvento == 1)
        {
            Session["idProgramacion"] = idEvento.ToString();
            Response.Redirect("Auditorio_Detalle.aspx");
        }
        else if (tipoEvento == 2)
        {
            Session["idActividad"] = idEvento.ToString();
            Response.Redirect("Teatro_Detalle.aspx");
        }
        else if (tipoEvento == 3)
        {
            Session["idConcursoTemporada"] = idEvento.ToString();
            Response.Redirect("Concursos.aspx");
        }

        else if (tipoEvento == 4)
        {
            Session["idCurso"] = idEvento.ToString();
            Response.Redirect("CursoTaller_Detalle.aspx");
        }


    }
    protected void dlAgenda_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image foto = (Image)e.Item.FindControl("imgFoto");
        Panel pDetalle = (Panel)e.Item.FindControl("pDetalle");
        if (foto.ImageUrl != null)
        {
            foto.Visible = true;
            pDetalle.Width = 336;
        }
        else
        {
            foto.Visible = false;
            pDetalle.Width = 400;
        }
    }
}
