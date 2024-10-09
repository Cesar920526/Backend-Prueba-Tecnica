using DirectorioAPI.Models;
using DirectorioAPI.Models.DTOs;
using DirectorioAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        [HttpGet("ListaEmpleados")]
        public ActionResult<IEnumerable<Empleado>> MostrarTodos()
        {
            var empleados = empleadoService.ListaEmpleados();

            if(empleados == null || !empleados.Any())
            {
                return NotFound(new { message = "No se encontraron empleados." });
            }

            return Ok(empleados);
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var empleado = empleadoService.BuscarPorId(id);

            if (empleado == null)
            {
                return NotFound(new { message = "No se encontro el empleado con el ID dado." });
            }

            return Ok(empleado);
        }

        [HttpGet("EmpleadoPorIdentificacion/{identificacion}")]
        public IActionResult BuscarPorIdentificacion(string identificacion)
        {
            var empleado = empleadoService.BuscarPorIdentificacion(identificacion);

            if(empleado == null)
            {
                return NotFound(new { message = "No se encontro el empleado con la identificacion dada." });
            }

            return Ok(empleado);
        }

        [HttpPost("AdicionarEmpleado")]
        public IActionResult AdicionarEmpleado([FromBody] Empleado empleado)
        {
            var resultado = empleadoService.CrearEmpleado(empleado);

            if(resultado == null)
            {
                return BadRequest("Error al crear al empleado");
            }
            
            return CreatedAtAction(nameof(BuscarPorId), new { id = empleado.Id }, empleado);
        }

        [HttpPut("Actualizar/{id}")]
        public IActionResult ActualizarEmpleado(int id, [FromBody] EmpleadoDTO empleado)
        {
            if (empleado == null)
            {
                return BadRequest("Empleado no puede ser nulo.");
            }

            var resultado = empleadoService.ActualizarEmpleado(id, empleado);

            if(resultado == null)
            {
                return NotFound(new { message = "Empleado no encontrado o no se pudo actualizar." });
            }

            return Ok(resultado);
        }

        [HttpDelete("BorrarEmpleado/{id}")]
        public IActionResult BorrarEmpleado(string id)
        {
            var resultado = empleadoService.BuscarPorIdentificacion(id).FirstOrDefault();

            empleadoService.BorrarEmpleado(resultado.Id);
            return NoContent();
        }

    }
}
