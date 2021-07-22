using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaninos.Entities
{
    public class Ejemplar
    {
        [Key]
        public int id_ejemplar { get; set;}
        public string nombre { get; set; }
        public int edad { get; set;}
        public int id_raza { get; set;}
        public int id_criador { get; set;}
        public int id_variedad { get; set;}
        public int id_color { get; set; }
        public string descripcion { get; set; }
        public string foto_ejemplar { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? modified_date { get; set; }
    }
}