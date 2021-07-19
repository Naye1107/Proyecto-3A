using System;
using System.ComponentModel.DataAnnotations;

namespace kaninos.Entities
{
    public class Cruce
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int id_macho { get; set; }
        public int id_hembra { get; set; }
        public DateTime fecha_emp { get; set; }
        public DateTime fecha_nac { get; set; }
        public int ejemplares_nac { get; set; }
        public int cantidad_machos { get; set; }
        public int cantidad_hembras { get; set; }
        public int num_bajas { get; set; }
        public int id_criador { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}