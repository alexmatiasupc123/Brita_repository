using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Oxinet.Tools;
using Oxinet.Maestros.BusinessLogic;

/// <summary>
/// Summary description for HelpMaestros
/// </summary>
public class HelpMaestros : Oxinet.Maestros.Interface.HelpMaestros
{
    public HelpMaestros()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /// <summary>
    /// Describen el nombre de las tablas Maestras
    /// </summary>
    public enum TablasMaestras
    {
  
        TiposDeCargos,
        ActoresDeObras,	        //PACTR	Actores
        AutoresDeItems,	        //PAUTR	Autores y/o escritores de libros, revistas, musicales, etc
        AutoresDeItemsInstitucionales,	        //PAUTI	Autores Institucionales
        TablaDeProveedores,	    //PRVDR	Se describen los a los proveedores del SAC
        TiposDeItem,	        //TARTI	Clasificación de Ítem
        TiposDeAudiencia,	    //TAUDI	Describe los Tipos de Audiencia
        TiposDeGeneros,	        //TGENR	Se describen los tipos de Géneros
        MotivoDeEnvioDeEmail,	//TMTVC	Describe los Motivos de Envio de Email a las personas asignadas
        TiposDeProcedencia,	    //TPRCD	Se describen los tipos de Procedencia de los Ítems
        EstadosDeCarne,	        //TSTDC	Se describe los tipos de estado para los Carnés
        EstadosDeEjemplares,    //TSTDE	Se describen los Tipo de Estado para los Ejemplares
        EstadosDeLosItems,	    //TSTDI	Se describen los ESTADOS de los Ítems en el sac
        EstadosDeTransferencias,//TSTDT	Se describen los Estados para las Transferencia de Ítems
        EstadosDeMovimientos,   //TSTDM	Se describen los Estados para las Movimeintos de Ítems
        TiposDeTemas,	        //TTEMA	Se describen los tipos de temas para los Ítems                
        TiposDePrestamos,	    //TPRTM	Se describen los tipos de prestamos de los Items, Sala - Domicilio                
    }

   
    /// <summary>
    /// OBTIENE EL CODIGO DE LA TABLA MAESTRA
    /// </summary>
    /// <param name="valor"></param>
    /// <returns></returns>
    public static string CodigoTabla(TablasMaestras valor)
    {
        string CodigoTabla = string.Empty; ;
        switch (valor)
        {
          
            case TablasMaestras.TiposDeCargos:
                CodigoTabla = "PCARG";
                break;
            case TablasMaestras.ActoresDeObras:	           //PACTR	Actores
                CodigoTabla = "PACTR";
                break;
            case TablasMaestras.AutoresDeItems:	           //PAUTR	Autores y/o escritores de libros, revistas, musicales, etc
                CodigoTabla = "PAUTR";
                break;
            case TablasMaestras.AutoresDeItemsInstitucionales:	           //PAUTR	Autores y/o escritores de libros, revistas, musicales, etc
                CodigoTabla = "PAUTI";
                break;
            case TablasMaestras.TablaDeProveedores:	       //PRVDR	Se describen los a los proveedores del SAC
                CodigoTabla = "PRVDR";
                break;
            case TablasMaestras.TiposDeItem:	           //TARTI	Clasificación de Ítem
                CodigoTabla = "TARTI";
                break;
            case TablasMaestras.TiposDeAudiencia:	       //TAUDI	Describe los Tipos de Audiencia
                CodigoTabla = "TAUDI";
                break;
            case TablasMaestras.TiposDeGeneros:	           //TGENR	Se describen los tipos de Géneros
                CodigoTabla = "TGENR";
                break;
            case TablasMaestras.MotivoDeEnvioDeEmail:	   //TMTVC	Describe los Motivos de Envio de Email a las personas asignadas
                CodigoTabla = "TMTVC";
                break;
            case TablasMaestras.TiposDeProcedencia:	       //TPRCD	Se describen los tipos de Procedencia de los Ítems
                CodigoTabla = "TPRCD";
                break;
            case TablasMaestras.EstadosDeCarne:	           //TSTDC	Se describe los tipos de estado para los Carnés
                CodigoTabla = "TSTDC";
                break;
            case TablasMaestras.EstadosDeEjemplares:       //TSTDE	Se describen los Tipo de Estado para los Ejemplares
                CodigoTabla = "TSTDE";
                break;
            case TablasMaestras.EstadosDeLosItems:	       //TSTDI	Se describen los ESTADOS de los Ítems en el sac
                CodigoTabla = "TSTDI";
                break;
            case TablasMaestras.EstadosDeTransferencias:   //TSTDT	Se describen los Estados para las Transferencia de Ítems
                CodigoTabla = "TSTDT";
                break;
            case TablasMaestras.EstadosDeMovimientos:      //TSTDM	Se describen los Estados para las Movimeintos de Ítems
                CodigoTabla = "TSTDM";
                break;
            case TablasMaestras.TiposDeTemas:	           //TTEMA	Se describen los tipos de temas para los Ítems
                CodigoTabla = "TTEMA";
                break;
            case TablasMaestras.TiposDePrestamos:	           //TPRTM	Se describen los tipos de prestamos para los Ítems.
                CodigoTabla = "TPRTM";
                break;
        }
        return CodigoTabla;
    }
    public static int NivelTabla(TablasMaestras valor)
    {
        int NivTabla = 0;
        switch (valor)
        {
            //case TablasMaestras.Departamento:
            //    NivTabla = 2;
            //    break;
            //case TablasMaestras.Provincia:
            //    NivTabla = 3;
            //    break;
            //case TablasMaestras.Distrito:
            //    NivTabla = 4;
            //    break;

            default:
                NivTabla = 1;
                break;
        }
        return NivTabla;
    }
    public static void CargarListadoGenerico(ref DropDownList pComboBox, TablasMaestras Tabla, string pCodArgu, MaestroLogic.EstadoDetalle pEstado, HelpComboBox.Texto pTexto)
    {
        CargarListadoGenerico(ref pComboBox, CodigoTabla(Tabla), NivelTabla(Tabla), pCodArgu, pEstado, pTexto);
    }
    public static void CargarListadoGenerico(ref ListBox pComboBox, TablasMaestras Tabla, string pCodArgu, MaestroLogic.EstadoDetalle pEstado, string pTexto)
    {
        CargarListadoGenerico(ref pComboBox, CodigoTabla(Tabla), NivelTabla(Tabla), pCodArgu, pEstado, pTexto);
    }
}
