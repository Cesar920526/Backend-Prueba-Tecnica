using System.ComponentModel.DataAnnotations;

namespace DirectorioAPI.Models.DTOs
{
    public class EmpleadoDTO
    {
        public string? Identificacion { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int? Edad { get; set; }
        public string? Cargo { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
