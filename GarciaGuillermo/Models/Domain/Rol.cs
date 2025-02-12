using System.ComponentModel.DataAnnotations;

namespace GarciaGuillermo.Models.Domain
{
    public class Rol
    {
        [Key] 
        public int IdRol { get; set; }

        [Required]
        [MaxLength(50)] 
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
