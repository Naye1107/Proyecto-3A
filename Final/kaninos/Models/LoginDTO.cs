using System;

namespace kaninos.Models
{
    public class LoginDTO
    {
        public int id_log { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
    }
}