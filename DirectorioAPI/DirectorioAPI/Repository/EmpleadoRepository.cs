using DirectorioAPI.Context;
using DirectorioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectorioAPI.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DirectorioAPIContext _context;
        
        public EmpleadoRepository(DirectorioAPIContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ListarTodosLosEmpleados()
        {
            return _context.Empleados.ToList();
        }

        public Empleado BuscarPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> ListarEmpleadoPorIdentificacion(string identificacion)
        {
            var empleados = from e in _context.Empleados select e;
            var empleado = empleados.Where(e => e.Identificacion.Equals(identificacion));
            return empleado;
        }

        public void AdicionarEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void BorrarEmpleado(int id)
        {
            var empleado = BuscarPorId(id);
            if(empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
        }

    }
}
