using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionDatos
{
    public class ConnectionBusiness
    {
        Exception Exception = new Exception();

        //CAMPOS
        public dynamic query { get; set; }
        public bool status { get; set; }

        //SIRVE PARA INSERTAR,ACTUALIZAR Y ELIMINAR
        public bool Execute(string StoredProcedure, Dictionary<string, object> Parameters)
        {
            try
            {
                //SqlConnection VALIDA LA CONEXION A LA BASE DE DATOS
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    int count = connection.Execute(StoredProcedure, new DynamicParameters(Parameters), commandType: System.Data.CommandType.StoredProcedure);

                    if (count > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB.Excepcion(ex, StoredProcedure, Parameters);
            }

            return status;
        }
        //CONSULTAR UN LISTA
        public dynamic QueryToList(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    query = connection.Query<dynamic>(StoredProcedure, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB.Excepcion(ex, StoredProcedure);
            }

            return query;
        }

        //CONSULTRA UNA LISTA CON PARAMETROS
        public dynamic QueryToList(string StoredProcedure, Dictionary<string, object> Parameters)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    query = connection.Query<dynamic>(StoredProcedure, new DynamicParameters(Parameters), commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB.Excepcion(ex, StoredProcedure, Parameters);
            }

            return query;
        }

        //CONSULTAR SOLO UN OBJETO
        public dynamic QueryFirstOrDefault(string StoredProcedure)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    query = connection.Query<dynamic>(StoredProcedure,  commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB.Excepcion(ex, StoredProcedure);
            }

            return query;
        }

        //CONSULTAR UN SOLO OBJETO CON PARAMETROS
        public dynamic QueryFirstOrDefault(string StoredProcedure, Dictionary<string, object> Parameters)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    query = connection.Query<dynamic>(StoredProcedure, new DynamicParameters(Parameters), commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB.Excepcion(ex, StoredProcedure, Parameters);
            }

            return query;
        }

        public enum Connection
        {
            oCnx,
            oCnxAP,
            oCnxTCR
        }
        private string GetConnectionString()
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            }
            catch
            {
                throw new Exception("Connection not configured ");
            }
        }
    }
}
