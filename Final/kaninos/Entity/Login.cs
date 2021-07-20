using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaninos.Entities
{
    [Table("log_reg")]
    public class Login
    {
        [Key]
        public int id_log { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}