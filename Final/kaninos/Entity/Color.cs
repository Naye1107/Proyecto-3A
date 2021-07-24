using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaninos.Entities
{
    [Table("colores")]
    public class Color
    {
        [Key]
        public int id_color { get; set; }
        public string nombre { get; set; }
        public int is_deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}