using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class ItemActorData
	{
		public string conexion = string.Empty;
		public ItemActorData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla ItemActor
		/// </summary>
		/// <param name="pItem"></param>
		public  bool Registrar(ItemActor  pItem)
		{
            int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    lnAfectados=SQLDC.pa_mnt_RegistrarItemActor(
						pItem.sCodItem,
						pItem.sCodArguActor,
						pItem.bActivo,
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
		/// Lista todos los registros de la tabla ItemActor
		/// <summary>
		/// <returns>List</returns>
        public List<ItemActor> Listar(string sCodItem)
		{
			List<ItemActor> Lista = new List<ItemActor>();
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    var resul = SQLDC.pa_mnt_Listar_ItemActor(sCodItem);
					foreach (var item in resul)
					{
						Lista.Add(new ItemActor()
						{
							sCodItem = item.sCodItem,
							sCodArguActor = item.sCodArguActor,
                            sCodArguNombreActor=item.CodArguNombreActor,
                            bActivo = false,//Valor que indica que viene de BD
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

	#region " /* Funciones Modificar */ "

		/// <summary>
		/// Modificar los registros de la tabla ItemActor que cumplan con los parametros de busqueda embiados
		/// </summary>
		/// <param name="pItem"></param>
		/// <returns></returns>
		public  bool Actualizar(ItemActor  pItem)
		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					lnAfectados = SQLDC.pa_mnt_ActualizarItemActor(
						pItem.sCodItem,
						pItem.sCodArguActor,
						pItem.bActivo,						
						pItem.SSIUsuario_Modificacion,						
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

	#region " /* Funciones Eliminar */ "

		/// <summary>
		/// Eliminar
		/// </summary>
		public  bool Eliminar(string sCodItem, string sCodArguActor)
		{
			int lnAfectados = -1;
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{

					lnAfectados = SQLDC.pa_mnt_EliminarItemActor(sCodItem, sCodArguActor);
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
