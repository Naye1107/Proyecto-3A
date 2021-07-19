using System;

namespace kaninos.Models
{
    public class CruceDTO
    {
        public string nombre { get; set; }
        public int macho { get; set; }
        public int hembra { get; set; }
        public DateTime fecha_emp { get; set; }
        public DateTime fecha_nac { get; set; }
        public int ejemplares_nac { get; set; }
        public int cantidad_machos { get; set; }
        public int cantidad_hembras { get; set; }
        public int num_bajas { get; set; }
        public int criador { get; set; }
    }
}