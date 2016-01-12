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

public partial class Agenda_Fecha : System.Web.UI.Page
{

    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    BEEvento bEvento = new BEEvento();
    BLEventoNTAD oEvento = new BLEventoNTAD();
    DateTime fecha;
    List<BEEvento> listaEventos;
    String tipoCriterio;
    Int32 tipoEvento;
    Int32 idEvento;
    String nombreMes;
    DateTime fechaAnterior;
    DateTime fechaSiguiente;
    DateTime fechaAAnterior;
    DateTime fechaSSiguiente;
    String DiaSemana;
    Funciones funciones = new Funciones();

    protected void Page_Load(object sender, EventArgs e)
    {
            cargaInfo();
    }

    void cargaInfo()

    {
        if (Session["tipoCriterio"] != null)
        {
            tipoCriterio = Session["tipoCriterio"].ToString();

            if (Session["dtFecha"] != null)
            {
                    fecha = Convert.ToDateTime(Session["dtFecha"]);
            }


            lblCriterio.Text = funciones.determinaMes(fecha) + " " + fecha.Year.ToString();
            string diaActual = fecha.DayOfWeek.ToString();
            lblNombreDia.Text = funciones.determinaDiaSemana(diaActual) + " " + fecha.Day.ToString();
            GeneraBarraFechas(fecha);

            listaEventos = oEvento.ListarTodosXstrFecha(Session["dtFecha"].ToString());

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
    
    }

    void GeneraBarraFechas(DateTime fecha)
    {

        //barra de fechas
        fechaSiguiente = fecha.AddDays(1);
        fechaAnterior = fecha.AddDays(-1);
        fechaSSiguiente = fechaSiguiente.AddDays(1);
        fechaAAnterior = fechaAnterior.AddDays(-1);

        string diaAnterior = fechaAnterior.DayOfWeek.ToString();
        string diaSiguiente = fechaSiguiente.DayOfWeek.ToString();
       
        lnkAnterior.Text = funciones.determinaDiaSemana(diaAnterior) + " " + fechaAnterior.Day.ToString();//fechaAnterior.ToShortDateString();
        lnkSiguiente.Text = funciones.determinaDiaSemana(diaSiguiente) + " " + fechaSiguiente.Day.ToString();//fechaSiguiente.ToShortDateString();
       //
    
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

 
   
    protected void lnkAnterior_Click(object sender, EventArgs e)
    {
        fecha = fechaAnterior;
        tipoCriterio = "2";
        Session["tipoCriterio"] = tipoCriterio;
        Session["dtFecha"] = fecha.ToString();
        cargaInfo();
    }
    protected void lnkSiguiente_Click(object sender, EventArgs e)
    {
        fecha = fechaSiguiente;
        tipoCriterio = "2";
        Session["tipoCriterio"] = tipoCriterio;
        Session["dtFecha"] = fecha.ToString();
        cargaInfo();
    }
    protected void lnkAAnterior_Click(object sender, EventArgs e)
    {
        fecha = fechaAAnterior;
        tipoCriterio = "2";
        Session["tipoCriterio"] = tipoCriterio;
        Session["dtFecha"] = fecha.ToString();
        cargaInfo();
    }
    protected void lnkSSiguiente_Click(object sender, EventArgs e)
    {
        fecha = fechaSSiguiente;
        tipoCriterio = "2";
        Session["tipoCriterio"] = tipoCriterio;
        Session["dtFecha"] = fecha.ToString();
        cargaInfo();
    }
    protected void lnkMesAnterior_Click(object sender, EventArgs e)
    {
        fecha = fecha.AddMonths(-1);
        tipoCriterio = "2";
        Session["tipoCriterio"] = tipoCriterio;
        Session["dtFecha"] = fecha.ToString();
        cargaInfo();
    }
    protected void dlAgenda_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image foto = (Image)e.Item.FindControl("imgFoto");
        Panel pDetalle = (Panel)e.Item.FindControl("pDetalle");
        if (foto.ImageUrl != null)
        {
            foto.Visible = true;
            pDetalle.Width = 326;
        }
        else
        {
            foto.Visible = false;
            pDetalle.Width = 390;
        }
    }
}
