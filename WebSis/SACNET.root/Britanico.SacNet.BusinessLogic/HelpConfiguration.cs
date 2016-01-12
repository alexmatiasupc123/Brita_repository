using System;
using System.Collections.Generic;
using System.Text;
using Oxinet.Maestros.BusinessLogic;
namespace Britanico.SacNet.BusinessLogic
{
    public class HelpConfiguration
    {
        public enum AppSett
        {
            Default_DIAS_ANTES,
            DefaultDiasPrestamoUsua,
            DefaultDiasPrestamoProf,
            DefaultDiasToleran,
            DefaultDiasSuspendido,
            DefaultDiasReservaVigen,
            Paginacion,
            DirImagenItem,
            DirImagenUsuarioSAC,
            DirImagenViewItem,
            Default_NameImagenUsuario,
            CodRolUsuarioSAC,
            CodArguTipoItemAudioVisual,
            CodArguEstadoItem_VXDF,
            CodArguEstadoTransferencia_VXDF,
            CodArguEstadoTransferencia_Retiro,
            CodArguEstadoTransferencia_Ingreso,
            CodArguEstadoDescartadoItem,
            CodArguEstadoDisponibleEjemplar,
            CodArguEstadoEnPrestamoEjemplar,
            CodArguEstadoEnReservaEjemplar,
            CodArguEstadoEnDeteriodoEjemplar,
            CodArguEstadoEnTransferenciaEjemplar,
            CodArguEstadoEnTransitoEjemplar,
            CodArguPrestamo_VXDF,
            CodArguEstadoCarneP01,
            CodArguEstadoCarneP02,
            CodArguEstadoCarneP03,
            CodArguEstadoCarneP04,
            CodArguEstadoCarneP05,
            CodArguEstadoEnStockItem,
            //***ELVP:19-09-2011****
            //CodArguTipoItemLibro,
            CodArguTipoItemLibroReader,
            CodArguTipoItemLibroGrammar,
            CodArguTipoItemLibroPaper,
            //**********************
            CodArguTipoItemRevista,
            CodArguTipoItemRecursoElectronico,
            TamanoMaximoImagen,
            CantidadMaxEjemplaresDocente,
            CodRolResponsableSAC,
            CodArguMovimientoPrestamos,
            CodArguMovimientoReservas,
            CodArguMovimientoDevoluciones,
            CodArguMovimientoPendientes,
            PrestamosA_NOMatriculados,
            CodArguPrestamoEnDomicilio,
            DefaultDiasAntesFinDeCurso,
        }

        public static string CodAppSett(AppSett valor)
        {
            string CodigoTabla = string.Empty; ;
            switch (valor)
            {
                case AppSett.Default_DIAS_ANTES:
                    CodigoTabla = "000601";
                    break;
                case AppSett.DefaultDiasPrestamoUsua:
                    CodigoTabla = "000602";
                    break;
                case AppSett.DefaultDiasPrestamoProf:
                    CodigoTabla = "000603";
                    break;
                case AppSett.DefaultDiasToleran:
                    CodigoTabla = "000605";
                    break;
                case AppSett.DefaultDiasSuspendido:
                    CodigoTabla = "000606";
                    break;
                case AppSett.DefaultDiasReservaVigen:
                    CodigoTabla = "000607";
                    break;
                case AppSett.Paginacion:
                    CodigoTabla = "000608";
                    break;
                case AppSett.DirImagenItem:
                    CodigoTabla = "000604";
                    break;
                case AppSett.DirImagenUsuarioSAC:
                    CodigoTabla = "000609";
                    break;
                case AppSett.DirImagenViewItem:
                    CodigoTabla = "000610";
                    break;
                case AppSett.Default_NameImagenUsuario:
                    CodigoTabla = "000611";
                    break;
                case AppSett.CodRolUsuarioSAC:
                    CodigoTabla = "000629";
                    break;
                case AppSett.CodArguTipoItemAudioVisual:
                    CodigoTabla = "000612";
                    break;
                case AppSett.CodArguEstadoItem_VXDF:
                    CodigoTabla = "000613";
                    break;
                case AppSett.CodArguEstadoTransferencia_VXDF:
                    CodigoTabla = "000614";
                    break;
                case AppSett.CodArguEstadoTransferencia_Retiro:
                    CodigoTabla = "000615";
                    break;
                case AppSett.CodArguEstadoTransferencia_Ingreso:
                    CodigoTabla = "000616";
                    break;
                case AppSett.CodArguEstadoDescartadoItem:
                    CodigoTabla = "000617";
                    break;
                case AppSett.CodArguEstadoDisponibleEjemplar:
                    CodigoTabla = "000618";
                    break;
                case AppSett.CodArguEstadoEnPrestamoEjemplar:
                    CodigoTabla = "000619";
                    break;
                case AppSett.CodArguEstadoEnReservaEjemplar:
                    CodigoTabla = "000620";
                    break;
                case AppSett.CodArguEstadoEnDeteriodoEjemplar:
                    CodigoTabla = "000621";
                    break;
                case AppSett.CodArguEstadoEnTransferenciaEjemplar:
                    CodigoTabla = "000622";
                    break;
                case AppSett.CodArguPrestamo_VXDF:
                    CodigoTabla = "000623";
                    break;
                case AppSett.CodArguEstadoCarneP01:
                    CodigoTabla = "000624";
                    break;
                case AppSett.CodArguEstadoCarneP02:
                    CodigoTabla = "000625";
                    break;
                case AppSett.CodArguEstadoCarneP03:
                    CodigoTabla = "000626";
                    break;
                case AppSett.CodArguEstadoCarneP04:
                    CodigoTabla = "000627";
                    break;
                case AppSett.CodArguEstadoCarneP05:
                    CodigoTabla = "000628";
                    break;
                case AppSett.CodArguEstadoEnStockItem:
                    CodigoTabla = "000630";
                    break;
                //***ELVP:19-09-2011*****
                case AppSett.CodArguTipoItemLibroReader:
                    CodigoTabla = "000631";
                    break;
                case AppSett.CodArguTipoItemLibroGrammar:
                    CodigoTabla = "000645";
                    break;
                case AppSett.CodArguTipoItemLibroPaper:
                    CodigoTabla = "000646";
                    break;
                //***********************
                case AppSett.CodArguTipoItemRevista:
                    CodigoTabla = "000632";
                    break;
                case AppSett.CodArguTipoItemRecursoElectronico:
                    CodigoTabla = "000633";
                    break;
                case AppSett.TamanoMaximoImagen:
                    CodigoTabla = "000634";
                    break;
                case AppSett.CantidadMaxEjemplaresDocente:
                    CodigoTabla = "000635";
                    break;
                case AppSett.CodRolResponsableSAC:
                    CodigoTabla = "000636";
                    break;
                case AppSett.CodArguEstadoEnTransitoEjemplar:
                    CodigoTabla = "000637";
                    break;
                case AppSett.CodArguMovimientoPrestamos:
                    CodigoTabla = "000638";
                    break;
                case AppSett.CodArguMovimientoReservas:
                    CodigoTabla = "000639";
                    break;
                case AppSett.CodArguMovimientoDevoluciones:
                    CodigoTabla = "000640";
                    break;
                case AppSett.CodArguMovimientoPendientes:
                    CodigoTabla = "000641";
                    break;
                case AppSett.PrestamosA_NOMatriculados:
                    CodigoTabla = "000642";
                    break;
                case AppSett.CodArguPrestamoEnDomicilio:
                    CodigoTabla = "000643";
                    break;
                case AppSett.DefaultDiasAntesFinDeCurso:
                    CodigoTabla = "000644";
                    break;
            }
            return CodigoTabla;
        }

        public static string AppSettings(AppSett AppSett)
        {
            ConfigLogic oConfigLogic = new ConfigLogic();
            return oConfigLogic.Buscar(CodAppSett(AppSett)).Valor;
        }
    }
    
}
