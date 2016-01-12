using System;
using System.Collections.Generic;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : Item.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class Item
    {

        public Item()
        {
            ListaActores = new  List<ItemActor>();
            ListaAutores = new  List<ItemAutor>();
            ListaAutoresInstitucionales = new List<ItemAutor>();
            ListaEjemplares = new List<ItemEjemplar>();
            ListaTemas = new List<ItemTema>();
        }

        #region Entidadest

        public string sCodItem { get; set; }
        public string sTitulo { get; set; }
        public string sEdicion { get; set; }
        public string sISBN { get; set; }
        public string sISSN { get; set; }
        public string sPieImprenta { get; set; }
        public int? nPaginas { get; set; }
        public string sDuracion { get; set; }
        public string sResumen { get; set; }
        public string sCodArguTipoItem { get; set; }
        public string sCodArguAudiencia { get; set; }
        public string sCodArguGenero { get; set; }
        public string sCodArguEstadoItem { get; set; }
        public string sCodArguPrestamoEn { get; set; }
        public string sFormatoAdicional { get; set; }
        public string sIdioma { get; set; }
        public decimal? fPrecioUnitario { get; set; }
        public string sCodArguProveedor { get; set; }
        public string sRequerimientoTecnico { get; set; }
        public string sFotografia { get; set; }
        public string sNotas { get; set; }
        public string sCodArguProcedencia { get; set; }
        public string sConferencia { get; set; }
        public string sPeriocidad { get; set; }
        public string sSerie { get; set; }
        public string sFuenteEn { get; set; }
        public List<ItemAutor> ListaAutores { get; set; }
        public List<ItemAutor> ListaAutoresInstitucionales { get; set; }
        public List<ItemActor> ListaActores { get; set; }
        public List<ItemEjemplar> ListaEjemplares { get; set; }
        public List<ItemTema> ListaTemas { get; set; }


        public string sCodSac { get; set; }
        public string sCodSacNombre { get; set; }
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCantidadDisponibles { get; set; }
        public string sCantidadEnPrestamo{ get; set; }
        public string sCantidadEnReserva { get; set; }
        public string sNombreAutores { get; set; }
        public string sNombreTemas { get; set; }

        public string sCodArguNombreEstadoItem { get; set; }

        public string sCodArguTipoItemNombre { get; set; }
        public string sCodArguAudienciaNombre { get; set; }
        public string sCodArguGeneroNombre { get; set; }
        public string sCodArguPrestamoEnNombre { get; set; }
        public string sCodArguProveedorNombre { get; set; }
        public string sCodArguProcedenciaNombre { get; set; }

        public int TotalEjemplares { get; set; }

        public string sCodItemsCodSac { get; set; }
        #endregion

    }
}
