using System;
using System.ComponentModel.DataAnnotations;

namespace kaninos.Models
{
    public class LoginDTO
    {
        [Required]
        public int id_log { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string pass { get; set; }
    }
}
