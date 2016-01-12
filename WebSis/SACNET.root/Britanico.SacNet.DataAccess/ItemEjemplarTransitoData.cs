using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemEjemplarTransitoData
    {
        public string conexion = string.Empty;
        public ItemEjemplarTransitoData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla ItemEjemplar
        /// </summary>
        /// <param name="pItem"></param>
        public bool Registrar(ItemEjemplarTransito pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_mnt_RegistrarItemEjemplarTransito(
                        pItem.sCodPrestamo,
                        pItem.sCodEjemplar,
                        pItem.SSIUsuario_Creacion,
                        pItem.SSIHost
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
    
        #endregion

        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Lista todos los registros de la tabla ItemEjemplar
        /// <summary>
        /// <returns>List</returns>
        public List<ItemEjemplarTransito> Listar(string p_dFechaDevolucionRealINI,string p_dFechaDevolucionRealFIN,string p_sCodEjemplar, string pCodSac)
        {
            List<ItemEjemplarTransito> Lista = new List<ItemEjemplarTransito>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarEjemplaresEnTransito(p_dFechaDevolucionRealINI, p_dFechaDevolucionRealFIN, p_sCodEjemplar, pCodSac);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplarTransito()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            dFechaLlegadaSAC = item.dFechaLlegadaSAC,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,

                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodItem = item.sCodItem

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        #endregion

        #region " /* Funciones Modificar */ "

        /// <summary>
        /// Modificar los registros de la tabla ItemEjemplar que cumplan con los parametros de busqueda embiados
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public bool ActualizarLlegadaDeEjemplar(string p_sCodPrestamo, string p_sCodEjemplar, string p_SSIUsuario_Modificacion)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_pro_ActualizarLlegadaDeEjemplarEnTransito(
                        p_sCodPrestamo,
                        p_sCodEjemplar,
                        p_SSIUsuario_Modificacion
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }

        #endregion
      
    }
}
