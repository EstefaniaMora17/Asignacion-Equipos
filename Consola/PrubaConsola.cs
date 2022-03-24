using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionEntities;
using AsignacionDatos;

namespace Consola
{
   public class PrubaConsola
    {

        static ConnectionBusiness OconnectionBusiness = new ConnectionBusiness();
        static void Main(string[] args)
        {
            //LLAMAMOS METODOS
            // InsertarSim();
            //InsertarEquipo();
             InsertarUsuario();
            // InsertarUsuarioEquipo();
            //ActualizarEquipo();
            //ActualizarSim();
            // ActualizarUsuarios();
            //ActualizarUsuarioEquipo();
            Console.ReadLine();
        }


        static void InsertarSim()
        {
            //INSTANCIAMOS LA CLASE ENTITIES 
            SimEntities OsimEntities = new SimEntities();
            //PREGUNTAMOS AL USUARIO
            Console.WriteLine("Ingrese iccid");
            //CAPTURAMOS
            OsimEntities.iccid = Console.ReadLine();
            Console.WriteLine("Ingrese min");
            OsimEntities.min = Console.ReadLine();
            Console.WriteLine("Ingrese plan de datos");
            OsimEntities.planDatos = Console.ReadLine();
            Console.WriteLine("Ingrese estado de la sim");
            OsimEntities.idEstadoSim = int.Parse(Console.ReadLine());

            //LLAMAMOS LA CLASE 
            TESTINGSIM.InsertarSim(OsimEntities);
        }

        static void InsertarEquipo()
        {
            EquipoEntities OequipoEntities = new EquipoEntities();
            Console.WriteLine("Ingrese imei");
            OequipoEntities.imei = Console.ReadLine();
            Console.WriteLine("Ingrese Referencia");
            OequipoEntities.Referencia = Console.ReadLine();
            Console.WriteLine("Ingrese rom");
            OequipoEntities.rom = Console.ReadLine();
            Console.WriteLine("Ingrese ram");
            OequipoEntities.ram = Console.ReadLine();
            Console.WriteLine("Ingrese bateria");
            OequipoEntities.bateria = Console.ReadLine();
            Console.WriteLine("Ingrese accesorios");
            OequipoEntities.accesorios = Console.ReadLine();
            Console.WriteLine("Ingrese observacion");
            OequipoEntities.observacion = Console.ReadLine();
            Console.WriteLine("Ingrese estadoequipo");
            OequipoEntities.idEstadoEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese ubicacion Equipo");
            OequipoEntities.idubicacionEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marca");
            OequipoEntities.idMarca = int.Parse(Console.ReadLine());
            TESTINGEquipo.InsertarEquipo(OequipoEntities);
           
        }

        static void InsertarUsuario()
        {
            UsuariosEntities OusuariosEntities = new UsuariosEntities();
            Console.WriteLine("Ingrese cedula");
            OusuariosEntities.cedula = Console.ReadLine();
            Console.WriteLine("Ingrese nombre");
            OusuariosEntities.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido");
            OusuariosEntities.apellido = Console.ReadLine();
            Console.WriteLine("Ingrese telefono");
            OusuariosEntities.telefono = Console.ReadLine();
            Console.WriteLine("Ingrese idcargo");
            OusuariosEntities.idcargo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese idArea");
            OusuariosEntities.idArea = int.Parse(Console.ReadLine());

            TESTINGUsuario.InsertarUsuarios(OusuariosEntities);
        }
        static void InsertarUsuarioEquipo()
        {
            UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
            Console.WriteLine("Ingrese cedula");
            OusuarioEquipoEntities.cedula = Console.ReadLine();
            Console.WriteLine("Ingrese imei");
            OusuarioEquipoEntities.imei = Console.ReadLine();
            Console.WriteLine("Ingrese iccid");
            OusuarioEquipoEntities.iccid = Console.ReadLine();
            Console.WriteLine("Ingrese observacion");
            OusuarioEquipoEntities.observacion = Console.ReadLine();
            Console.WriteLine("Ingrese idEstadoEquipo");
            OusuarioEquipoEntities.idEstadoEquipo =int.Parse( Console.ReadLine());
            Console.WriteLine("Ingrese idEstadoSim");
            OusuarioEquipoEntities.idEstadoSim = int.Parse(Console.ReadLine());
            TESTINGUsuarioEquipo.InsertarUsuarioEquipo(OusuarioEquipoEntities);

        }
        static void ActualizarEquipo()
        {
            EquipoEntities OequipoEntities = new EquipoEntities();
            Console.WriteLine("Ingrese imei");
            OequipoEntities.imei = Console.ReadLine();
            Console.WriteLine("Ingrese Referencia");
            OequipoEntities.Referencia = Console.ReadLine();
            Console.WriteLine("Ingrese rom");
            OequipoEntities.rom = Console.ReadLine();
            Console.WriteLine("Ingrese ram");
            OequipoEntities.ram = Console.ReadLine();
            Console.WriteLine("Ingrese bateria");
            OequipoEntities.bateria = Console.ReadLine();
            Console.WriteLine("Ingrese accesorios");
            OequipoEntities.accesorios = Console.ReadLine();
            Console.WriteLine("Ingrese observacion");
            OequipoEntities.observacion = Console.ReadLine();
            Console.WriteLine("Ingrese estadoequipo");
            OequipoEntities.idEstadoEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese ubicacion Equipo");
            OequipoEntities.idubicacionEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese marca");
            OequipoEntities.idMarca = int.Parse(Console.ReadLine());
            TESTINGEquipo.ActualizarEquipo(OequipoEntities);

        }
        static void ActualizarSim()
        {
            //INSTANCIAMOS LA CLASE ENTITIES 
            SimEntities OsimEntities = new SimEntities();
            //PREGUNTAMOS AL USUARIO
            Console.WriteLine("Ingrese iccid");
            //CAPTURAMOS
            OsimEntities.iccid = Console.ReadLine();
            Console.WriteLine("Ingrese min");
            OsimEntities.min = Console.ReadLine();
            Console.WriteLine("Ingrese plan de datos");
            OsimEntities.planDatos = Console.ReadLine();
            Console.WriteLine("Ingrese estado de la sim");
            OsimEntities.idEstadoSim = int.Parse(Console.ReadLine());

            //LLAMAMOS LA CLASE 
            TESTINGSIM.ActualizarSim(OsimEntities);
        }
        static void ActualizarUsuarios()
        {
            UsuariosEntities OusuariosEntities = new UsuariosEntities();
            Console.WriteLine("Ingrese cedula");
         //   OusuariosEntities.Cedula = Console.ReadLine();
            Console.WriteLine("Ingrese nombre");
            OusuariosEntities.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido");
            OusuariosEntities.apellido = Console.ReadLine();
            Console.WriteLine("Ingrese telefono");
            OusuariosEntities.telefono = Console.ReadLine();
            Console.WriteLine("Ingrese idcargo");
            OusuariosEntities.idcargo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese idArea");
            OusuariosEntities.idArea = int.Parse(Console.ReadLine());

            TESTINGUsuario.ActualizarUsuarios(OusuariosEntities);
        }
        static void ActualizarUsuarioEquipo()
        {
            UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
            Console.WriteLine("Ingrese id");
            OusuarioEquipoEntities.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cedula");
            OusuarioEquipoEntities.cedula = Console.ReadLine();
            Console.WriteLine("Ingrese imei");
            OusuarioEquipoEntities.imei = Console.ReadLine();
            Console.WriteLine("Ingrese iccid");
            OusuarioEquipoEntities.iccid = Console.ReadLine();
            Console.WriteLine("Ingrese observacion");
            OusuarioEquipoEntities.observacion = Console.ReadLine();
            Console.WriteLine("Ingrese idEstadoEquipo");
            OusuarioEquipoEntities.idEstadoEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese idEstadoSim");
            OusuarioEquipoEntities.idEstadoSim = int.Parse(Console.ReadLine());
            TESTINGUsuarioEquipo.ActualizarUsuarioEquipo(OusuarioEquipoEntities);

        }
         static void ConsultarEquipoIndv(string imei)
        {
            UsuarioEquipoEntities OusuarioEquipoEntities = new UsuarioEquipoEntities();
            Console.WriteLine("Ingrese id");
            OusuarioEquipoEntities.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cedula");
            OusuarioEquipoEntities.cedula = Console.ReadLine();
            Console.WriteLine("Ingrese imei");
            OusuarioEquipoEntities.imei = Console.ReadLine();
            Console.WriteLine("Ingrese iccid");
            OusuarioEquipoEntities.iccid = Console.ReadLine();
            Console.WriteLine("Ingrese observacion");
            OusuarioEquipoEntities.observacion = Console.ReadLine();
            Console.WriteLine("Ingrese idEstadoEquipo");
            OusuarioEquipoEntities.idEstadoEquipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese idEstadoSim");
            OusuarioEquipoEntities.idEstadoSim = int.Parse(Console.ReadLine());
          //  TESTINGEquipo.ConsultarEquipoIndv(imei);

        }
    }
}
