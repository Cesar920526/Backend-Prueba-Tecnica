using DirectorioAPI.Models;
using DirectorioAPI.Models.DTOs;

namespace DirectorioAPI.Services
{
    public interface IEmpleadoService
    {
        IEnumerable<Empleado> ListaEmpleados();
        IEnumerable<Empleado> BuscarPorIdentificacion(string identificacion);
        Empleado BuscarPorId(int id);
        Empleado CrearEmpleado(Empleado empleado);
        Empleado ActualizarEmpleado(int id, EmpleadoDTO empleado);
        void BorrarEmpleado(int id);
    }
}
