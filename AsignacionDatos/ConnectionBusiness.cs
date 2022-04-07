using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
                ExcepcionDB(ex);
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
                ExcepcionDB(ex);
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
                ExcepcionDB(ex);
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
                    query = connection.Query<dynamic>(StoredProcedure, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                ExcepcionDB(ex);
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
                ExcepcionDB(ex);
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
                return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            }
            catch
            {
                throw new Exception("Connection not configured ");
            }
        }

        private void ExcepcionDB(Exception ex)
        {
            try
            {

                //SqlConnection VALIDA LA CONEXION A LA BASE DE DATOS
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    // DAPPER EJECUTA EL PROCEDIMINETO ALMACENADO
                    int count = connection.Execute("insertarExcepciones", new DynamicParameters(new Dictionary<string, object>
                        {
                                { "@excepciones", string.Concat(ex.Message,ex.InnerException,ex.StackTrace) }
                            }), commandType: System.Data.CommandType.StoredProcedure);

                   
                }

            }
            catch (Exception)
            {

                TextWriter mensaje = new StreamWriter("C:\\Users\\Estefania Mora\\Desktop\\nia\\Asignacion-Equipos\\AsignacionDatos\\log\\Test.txt");
                mensaje.WriteLine(string.Concat(ex.Message, ex.InnerException, ex.StackTrace));
                mensaje.Close();

            }   
        }
    }   
}
