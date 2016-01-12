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
using System.Collections.Generic;

public partial class Mantenimientos_frm_eventos : System.Web.UI.Page
{
    BEEvento bEvento = new BEEvento();
    BLEventoNTAD oEvento = new BLEventoNTAD();
    List<BEEvento> listaEventos;
    BLActividadTeatroNTAD oActividad =  new BLActividadTeatroNTAD();
    BLProgramacionAuditorioNTAD oProgramacion = new BLProgramacionAuditorioNTAD();
    BLConcursoTemporadaNTAD oConcursoTemp = new BLConcursoTemporadaNTAD();
    BLConcursoTemporadaTAD gConcursoTemp = new BLConcursoTemporadaTAD();
    BLProgramacionAuditorioTAD gProgramacion = new BLProgramacionAuditorioTAD();
    BLActividadTeatroTAD gActividad = new BLActividadTeatroTAD();
    Int32 tipoEvento;
    Int32 idEvento;

    protected void Page_Load(object sender, EventArgs e)
    {
            listaEventos = oEvento.ListarTodos();
          
        
   }

     protected void gvEventos_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }



    protected void lnkDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkDestacar = (LinkButton)sender;
        Int32 even_codi = Convert.ToInt32(lnkDestacar.CommandArgument);

        foreach (BEEvento iEvento in listaEventos)
        {
            if (iEvento.even_codi == even_codi)
            {
                idEvento = iEvento.even_codr;
                tipoEvento = iEvento.even_tipo;
            }
        }

        //tipo de evento 1 = Auditorio,2 = Teatro, 3 = Concurso Temporada
        if (tipoEvento == 1)
        {
            BEProgramacionAuditorio bProgramacion = oProgramacion.ListarRegistro(idEvento);
            bProgramacion.prog_dest = true;
            gProgramacion.Modificar(bProgramacion);

        }
        else if (tipoEvento == 2)
        {
            BEActividadTeatro bActividad = oActividad.ListarRegistro(idEvento);
            bActividad.teat_dest = true;
            gActividad.Modificar(bActividad);
        }
        else if (tipoEvento == 3)
        {
            BEConcursoTemporada bConcursoTemp = oConcursoTemp.ListarRegistro(idEvento);
            bConcursoTemp.ctem_dest = true;
            gConcursoTemp.Modificar(bConcursoTemp);
        }

        //listaEventos = oEvento.ListarTodos();
        //gvEventos.DataSource = listaEventos;
        gvEventos.DataBind();
    }
    protected void lnkNoDestacar_Click(object sender, EventArgs e)
    {
        LinkButton lnkNoDestacar = (LinkButton)sender;
        Int32 even_codi = Convert.ToInt32(lnkNoDestacar.CommandArgument);
       
        foreach (BEEvento iEvento in listaEventos)
        {
            if (iEvento.even_codi == even_codi)
            {
                idEvento = iEvento.even_codr;
                tipoEvento = iEvento.even_tipo;
            }
        }

        //tipo de evento 1 = Auditorio,2 = Teatro, 3 = Concurso Temporada
        if (tipoEvento == 1)
        {
            BEProgramacionAuditorio bProgramacion = oProgramacion.ListarRegistro(idEvento);
            bProgramacion.prog_dest = false;
            gProgramacion.Modificar(bProgramacion);

        }
        else if (tipoEvento == 2)
        {
            BEActividadTeatro bActividad = oActividad.ListarRegistro(idEvento);
            bActividad.teat_dest = false;
            gActividad.Modificar(bActividad);
        }
        else if (tipoEvento == 3)
        {
            BEConcursoTemporada bConcursoTemp = oConcursoTemp.ListarRegistro(idEvento);
            bConcursoTemp.ctem_dest = false;
            gConcursoTemp.Modificar(bConcursoTemp);
        }

        //listaEventos = oEvento.ListarTodos();
        //gvEventos.DataSource = listaEventos;
        gvEventos.DataBind();
    }
}
