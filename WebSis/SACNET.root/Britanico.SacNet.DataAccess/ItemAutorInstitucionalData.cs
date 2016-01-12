using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class ItemAutorInstitucionalData
	{
		public string conexion = string.Empty;
        public ItemAutorInstitucionalData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla ItemAutor
		/// </summary>
		/// <param name="pItem"></param>
		public  bool Registrar(ItemAutor  pItem)
		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					SQLDC.pa_mnt_RegistrarItemAutorInstitucional(
						pItem.sCodItem,
						pItem.sCodArguAutor,
						pItem.bEstado,
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
		/// Lista todos los registros de la tabla ItemAutor
		/// <summary>
		/// <returns>List</returns>
        public List<ItemAutor> Listar(string sCodItem)
        {
            List<ItemAutor> Lista = new List<ItemAutor>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_ItemAutorInstitucional(sCodItem);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemAutor()
                        {
                            sCodItem = item.sCodItem,
                            sCodArguAutor = item.sCodArguAutorInstitucional,
                            sCodArguNombreAutor = item.CodArguNombreAutorInstitucional,
                            bEstado = false,//Valor que indica que viene de BD
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost

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

	

	#region " /* Funciones Eliminar */ "

		/// <summary>
		/// Eliminar
		/// </summary>
		public  bool Eliminar(string sCodItem, string sCodArguAutor)
		{
			int lnAfectados = -1;
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{

					lnAfectados = SQLDC.pa_mnt_EliminarItemAutorInstitucional(sCodItem, sCodArguAutor);
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
