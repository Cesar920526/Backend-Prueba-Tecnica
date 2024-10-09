using DirectorioAPI.Models;
using DirectorioAPI.Models.DTOs;
using DirectorioAPI.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;

namespace DirectorioAPI.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this._empleadoRepository = empleadoRepository;
        }

        public IEnumerable<Empleado> ListaEmpleados()
        {
            return _empleadoRepository.ListarTodosLosEmpleados();
        }

        public IEnumerable<Empleado> BuscarPorIdentificacion(string identificacion)
        {
            return _empleadoRepository.ListarEmpleadoPorIdentificacion(identificacion);
        }

        public Empleado BuscarPorId(int id)
        {
            return _empleadoRepository.BuscarPorId(id);
        }

        public Empleado CrearEmpleado(Empleado empleado)
        {
            try
            {
                _empleadoRepository.AdicionarEmpleado(empleado);
                return empleado;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Empleado ActualizarEmpleado(int id, EmpleadoDTO empleadoActualizado)
        {
            var empleadoExistente = _empleadoRepository.BuscarPorId(id);

            empleadoExistente.Nombres = empleadoActualizado.Nombres ?? empleadoExistente.Nombres;
            empleadoExistente.Apellidos = empleadoActualizado.Apellidos ?? empleadoExistente.Apellidos;
            empleadoExistente.Telefono = empleadoActualizado.Telefono ?? empleadoExistente.Telefono;
            empleadoExistente.Cargo = empleadoActualizado.Cargo ?? empleadoExistente.Cargo;
            empleadoExistente.Email = empleadoActualizado.Email ?? empleadoExistente.Email;
            if (empleadoActualizado.Edad.HasValue)
            {
                empleadoExistente.Edad = empleadoActualizado.Edad.Value;
            }

            try
            {
                _empleadoRepository.ActualizarEmpleado(empleadoExistente);
                return empleadoExistente;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void BorrarEmpleado(int id)
        {
            _empleadoRepository.BorrarEmpleado(id);
        }
    }
}
