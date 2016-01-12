using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities;
using System.Data.SqlClient;
namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuariosData
    {
        public string conexion = string.Empty;

        public UsuariosData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        


        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public Usuarios Buscar(string p_LoginUsuario)
        {
            Usuarios itemUsuario=null;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarUsuarios(p_LoginUsuario);
                    foreach (var item in resul)
                    {
                        itemUsuario = new Usuarios()
                        {
                            LoginUsuario = item.LoginUsuario,
                            PasswordUsuario = item.PasswordUsuario,
                            ApellidosUsuario = item.ApellidosUsuario,
                            NombresUsuario = item.NombresUsuario,
                            ApellidosyNombres = item.ApellidosUsuario + ", " + item.NombresUsuario,
                            CodPersona = item.CodPersona,
                            TipoUsuario = item.TipoUsuario

                        };
                    }
                }
                // using (SqlConnection cnSQL=new SqlConnection(conexion))
                //{
                //    cnSQL.Open();
                //    SqlCommand cmdSQL = new SqlCommand("Ssi.pa_mnt_BuscarUsuarios", cnSQL);                    
                //    cmdSQL.CommandType = System.Data.CommandType.StoredProcedure;                    
                //    cmdSQL.Parameters.Add("@p_LoginUsuario", System.Data.SqlDbType.VarChar, 15).Value = p_LoginUsuario;
                //    SqlDataReader drSQL = cmdSQL.ExecuteReader();                    
                //    while (drSQL.Read())
                //    {
                //        itemUsuario = new Usuarios();
                //        if(!drSQL.IsDBNull(0))
                //            itemUsuario.LoginUsuario = Convert.ToString(drSQL["LoginUsuario"]);
                //        if (!drSQL.IsDBNull(1))
                //            itemUsuario.PasswordUsuario = Convert.ToString(drSQL["PasswordUsuario"]);
                //        if (!drSQL.IsDBNull(2))
                //            itemUsuario.ApellidosUsuario = Convert.ToString(drSQL["ApellidosUsuario"]);
                //        if (!drSQL.IsDBNull(3))
                //            itemUsuario.NombresUsuario = Convert.ToString(drSQL["NombresUsuario"]);
                //        if (!drSQL.IsDBNull(3))
                //            itemUsuario.ApellidosyNombres = Convert.ToString(drSQL["ApellidosUsuario"]).Trim() + " " + Convert.ToString(drSQL["NombresUsuario"]).Trim();
                //        if(!drSQL.IsDBNull(4))
                //            itemUsuario.CodPersona = Convert.ToString(drSQL["CodPersona"]);
                //        if (!drSQL.IsDBNull(5))
                //            itemUsuario.TipoUsuario = Convert.ToString(drSQL["TipoUsuario"]);

   
                //    }
                    
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuario;
        }
        public Usuarios UsuarioOpciones(string p_LoginUsuario,string p_RolOpcion)
        {
            Usuarios itemUsuario = new Usuarios();
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
            return itemUsuario;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<Usuarios> Listar(string p_NombresUsuario, string p_ApellidosUsuario, string p_LoginUsuario)
        {
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarUsuarios(p_NombresUsuario, p_ApellidosUsuario, p_LoginUsuario);
                    foreach (var item in resul)
                    {
                        lista.Add(new Usuarios()
                        {
                            LoginUsuario = item.LoginUsuario,

                            PasswordUsuario = item.PasswordUsuario,
                            ApellidosUsuario = item.ApellidosUsuario,
                            NombresUsuario = item.NombresUsuario,

                            ApellidosyNombres = item.ApellidosUsuario.Trim() + ", " + item.NombresUsuario.Trim()

                        });
                    }
                }
                //using (SqlConnection cnSQL = new SqlConnection(conexion))
                //{
                //    cnSQL.Open();
                //    SqlCommand cmdSQL = new SqlCommand("Ssi.pa_mnt_ListarUsuarios", cnSQL);
                //    cmdSQL.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmdSQL.Parameters.Add("@p_NombresUsuario", System.Data.SqlDbType.VarChar, 15).Value = p_NombresUsuario;
                //    cmdSQL.Parameters.Add("@p_ApellidosUsuario", System.Data.SqlDbType.VarChar, 15).Value = p_ApellidosUsuario;
                //    cmdSQL.Parameters.Add("@p_LoginUsuario", System.Data.SqlDbType.VarChar, 15).Value = p_LoginUsuario;
                //    SqlDataReader drSQL = cmdSQL.ExecuteReader();
                //    Usuarios itemUsuario;
                //    while (drSQL.Read())
                //    {
                //        itemUsuario = new Usuarios();
                //        if (!drSQL.IsDBNull(0))
                //            itemUsuario.LoginUsuario = Convert.ToString(drSQL["LoginUsuario"]);
                //        if (!drSQL.IsDBNull(1))
                //            itemUsuario.PasswordUsuario = Convert.ToString(drSQL["PasswordUsuario"]);
                //        if (!drSQL.IsDBNull(2))
                //            itemUsuario.ApellidosUsuario = Convert.ToString(drSQL["ApellidosUsuario"]);
                //        if (!drSQL.IsDBNull(3))
                //            itemUsuario.NombresUsuario = Convert.ToString(drSQL["NombresUsuario"]);
                //        if (!drSQL.IsDBNull(3))
                //            itemUsuario.ApellidosyNombres = Convert.ToString(drSQL["ApellidosUsuario"]).Trim() + " " + Convert.ToString(drSQL["NombresUsuario"]).Trim();
                //        if (!drSQL.IsDBNull(6))
                //            itemUsuario.TipoUsuario = Convert.ToString(drSQL["TipoUsuario"]);
                //        lista.Add(itemUsuario);

                //    }

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        #endregion

      

      
    }
}
