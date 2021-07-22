using System;

namespace kaninos.Models
{
    public class EjemplarDTO
    {
        public string nombre { get; set; }
        public int padre { get; set; }
        public int madre { get; set;}
        public int edad { get; set;}
        public int id_raza { get; set;}
        public int id_criador { get; set;}
        public int id_variedad { get; set;}
        public int id_color { get; set; }
        public string descripcion { get; set; }
        public string foto_ejemplar { get; set; }
    }
}