using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Britanico.Web.BusinessEntities;


namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// This class is specifies the selection criteria
    /// for a Factory
    /// </summary>
    internal class uspMListarTodosArchivoXFiltrosIdentity
    {
        public uspMListarTodosArchivoXFiltrosIdentity(System.Int32 idPadre, System.Int32 tipoEvento, System.String tipoArchivo, System.Int32 numPag)
        {
            
            this.idPadreField =  idPadre;
            this.tipoEventoField = tipoEvento;
            this.tipoArchivoField = tipoArchivo;
            this.numPagField = numPag;

        }

        private System.Int32 idPadreField;

        public System.Int32 idPadre
        {
            get { return this.idPadreField; }
            set { this.idPadreField = value; }
        }


        private System.Int32 tipoEventoField;

        public System.Int32 tipoEvento
        {
            get { return this.tipoEventoField; }
            set { this.tipoEventoField = value; }
        }

        private System.String tipoArchivoField;

        public System.String tipoArchivo
        {
            get { return this.tipoArchivoField; }
            set { this.tipoArchivoField = value; }
        }

        private System.Int32 numPagField;

        public System.Int32 numPag
        {
            get { return this.numPagField; }
            set { this.numPagField = value; }
        }

    }
}

