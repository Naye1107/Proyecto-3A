using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaninos.Entities
{
    public class Criador
    {
        [Key]
        public int id_criador { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string logotipo { get; set; }
        public string fotografia { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}