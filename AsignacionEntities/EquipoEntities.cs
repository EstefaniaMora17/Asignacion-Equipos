using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionEntities
{
   public class EquipoEntities
    {

        //objecto
        public string imei { get; set; }
        public string Referencia { get; set; }
        public string rom { get; set; }
        public string ram { get; set; }
        public string bateria { get; set; }
        public string accesorios { get; set; }
        public string observacion{ get; set; }
        public int idEstadoEquipo { get; set; }
        public string estadoEquipo { get; set; }
        public int idubicacionEquipo { get; set; }
        public string ubicacionEquipo { get; set; }
        public int idMarca { get; set; }
        public string marca { get; set; }
        public string Precio { get; set; }
        public DateTime FechaEquipo { get; set; }
    }
}
