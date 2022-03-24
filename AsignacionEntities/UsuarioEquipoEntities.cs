using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionEntities
{
    public class UsuarioEquipoEntities
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string iccid   { get; set; }
        public string imei { get; set; }
        public string observacion { get; set; }
        public int idEstadoSim { get; set; }
        public string estadoSim { get; set; }
        public int idEstadoEquipo { get; set; }
        public string   estadoEquipo { get; set; }
        public Byte[] imagen { get; set; }
        public string nombreImagen { get; set; }
        public string ContentType { get; set; }
        public DateTime fechaUsuarioEquipo { get; set; }
    }



}
