using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionDatos
{
    internal class ExcepcionDB
    {
        public Exception exception { get; set; }
        public string storedProcedure { get; set; }
        public Dictionary<string, object> parameters { get; set; }
        public static void Excepcion(Exception exception,string StoredProcedure,Dictionary<string,object>Parameters = null)
        {

        }

    }
}
