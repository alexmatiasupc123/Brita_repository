using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class ItemTemaData
	{
		public string conexion = string.Empty;
		public ItemTemaData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla ItemTema
		/// </summary>
		/// <param name="pItem"></param>
		public  bool Registrar(ItemTema  pItem)

		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					lnAfectados=SQLDC.pa_mnt_RegistrarItemTema(
						pItem.sCodItem,
						pItem.sCodArguTema,
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
		/// Buscar un regitro de la tabla ItemTema segun su pk enviado por parametro
		/// </summary>
		/// <returns>Item</returns>
        //public  ItemTema Buscar(string sCodItem, string sCodArguTema)
        //{
        //    ItemTema Item = new ItemTema();
        //    try
        //    {
        //        using (SQLDataContext SQLDC = new SQLDataContext(conexion))
        //        {
        //            var resul = SQLDC.pa_mnt_BuscarItemTema(sCodItem, sCodArguTema);
        //            foreach (var item in resul)
        //            {
        //                Item = new ItemTema()
        //                {
        //                    sCodItem = item.sCodItem,
        //                    sCodArguTema = item.sCodArguTema,
        //                    bEstado = item.bEstado,
        //                    SSIUsuario_Creacion = item.SSIUsuario_Creacion,
        //                    SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
        //                    SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
        //                    SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
        //                    SSIHost = item.SSIHost

        //                };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Item;
        //}

		/// <summary>
		/// Lista todos los registros de la tabla ItemTema
		/// <summary>
		/// <returns>List</returns>
		public  List<ItemTema> Listar(string sCodItem)
		{
			List<ItemTema> Lista = new List<ItemTema>();
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    var resul = SQLDC.pa_mnt_Listar_ItemTema(sCodItem);
					foreach (var item in resul)
					{
						Lista.Add(new ItemTema()
						{
							sCodItem = item.sCodItem,
							sCodArguTema = item.sCodArguTema,
                            sCodArguNombreTema=item.CodArguNombreTema,
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

	#region " /* Funciones Modificar */ "

		/// <summary>
		/// Modificar los registros de la tabla ItemTema que cumplan con los parametros de busqueda embiados
		/// </summary>
		/// <param name="pItem"></param>
		/// <returns></returns>
		public  bool Actualizar(ItemTema  pItem)
		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					lnAfectados = SQLDC.pa_mnt_ActualizarItemTema(
						pItem.sCodItem,
						pItem.sCodArguTema,
						pItem.bEstado,					
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
		public  bool Eliminar(string sCodItem, string sCodArguTema)
		{
			int lnAfectados = -1;
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{

					lnAfectados = SQLDC.pa_mnt_EliminarItemTema(sCodItem, sCodArguTema);
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
