using System.ComponentModel.DataAnnotations;

namespace DirectorioAPI.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public required string Identificacion { get; set; }
        [Required]
        [StringLength(100)]
        public required string Nombres { get; set; }
        [Required]
        [StringLength(100)]
        public required string Apellidos { get; set; }
        public int? Edad {  get; set; }
        [Required]
        [StringLength(100)]
        public required string Cargo {  get; set; }
        [Required]
        [StringLength(10)]
        public required string Telefono {  get; set; }
        [Required]
        [StringLength(100)]
        public required string Email {  get; set; }
    }
}
