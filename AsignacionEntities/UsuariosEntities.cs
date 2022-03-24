using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionEntities
{
    public class UsuariosEntities
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public int idcargo { get; set; }
        public string cargo { get; set; }
        public int idArea { get; set; }
        public string area { get; set; }
        public DateTime FechaUsuario { get; set; }
    }
}
