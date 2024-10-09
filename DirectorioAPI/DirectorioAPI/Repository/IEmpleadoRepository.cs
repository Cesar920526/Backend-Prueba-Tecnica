using DirectorioAPI.Models;

namespace DirectorioAPI.Repository
{
    public interface IEmpleadoRepository
    {
        IEnumerable<Empleado> ListarTodosLosEmpleados();
        Empleado BuscarPorId(int id);
        void AdicionarEmpleado(Empleado empleado);
        void ActualizarEmpleado(Empleado empleado);
        void BorrarEmpleado(int id);
        IEnumerable<Empleado> ListarEmpleadoPorIdentificacion(string identificacion);
    }
}
