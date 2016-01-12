using System;

namespace Britanico.SacNet.BusinessEntities
{
    public class Reportes
    {

        public string CodSAC { get; set; }
        public string SAC { get; set; }
        public string CodItem { get; set; }
        public string Item { get; set; }
        public string CodTipoMaterial { get; set; }
        public string TipoMaterial { get; set; }
        public string CodTipoPrestamo { get; set; }
        public string TipoPrestamo { get; set; }
        public string TipoUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string CodUsuarioSAC { get; set; }
        public string CodEjemplar { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int CantMovXSac { get; set; }
        public string Usuario { get; set; }       
        public int? EnSala { get; set; }
        public int? EnDomicilio { get; set; }
        public int? Prestamos { get; set; }

        public int? CantEjemplar { get; set; }
        public int? CantMovimiento { get; set; }
        public int? Retrasos { get; set; }
        public int? DiasRetrasos { get; set; }

        public int? Prestados { get; set; }
        public int? Reservados { get; set; }
        public int? Disponibles { get; set; }
        public int? Asignados { get; set; }

        public string EstadoCarnet { get; set; }
        public string FormatoAdicional { get; set; }
        public string Ejemplar { get; set; }
        public string sCodArguTema { get; set; }
        public string Tema { get; set; }

        public string Curso { get; set; }
        public string Horario { get; set; }
        public string Aula { get; set; }
        public string Subsistema { get; set; }

    }
}
