using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : vwLocalesSAC.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Orlando Carril 08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class vwCursosUsuarioSAC
    {
        #region Entidadest

        public string CodUsuarioSAC { get; set; }
        public string Ciclo { get; set; }
        public string Cursos { get; set; }
        public string Horario{ get; set; }
        public string FechaInicioCiclo { get; set; }
        public string FechaFinalCiclo { get; set; }
        public string SubSistema{ get; set; }
        public string EstadoDeCurso { get; set; }
        public string Sabado { get; set; }
        #endregion

    }
}
