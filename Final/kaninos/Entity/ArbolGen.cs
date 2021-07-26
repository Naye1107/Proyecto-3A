using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kaninos.Entities
{
    [Table("arbol_gen")]
    public class ArbolGen
    {
        [Key]
        public string ejemplar { get; set; }
        public int id_padre { get; set; }
        public int id_madre { get; set; }
    }
}