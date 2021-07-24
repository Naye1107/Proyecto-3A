using System;

namespace kaninos.Models
{
    public class EjemplarDTO
    {
        public int id_ejemplar { get; set; }
        public string nombre { get; set; }
        public int padre { get; set; }
        public int madre { get; set;}
        public int edad { get; set;}
        public int id_raza { get; set;}
        public int id_criador { get; set;}
        public string criador { get; set; }
        public int id_variedad { get; set;}
        public int id_color { get; set; }
        public string descripcion { get; set; }
        public string foto_ejemplar { get; set; }
        public string btn_reg { get; set; }
        public string btn_bus { get; set; }
    }
}