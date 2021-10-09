using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Profesor
    {
        public int id { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public Profesor(int id, string rut, string nombre)
        {
            this.id = id;
            this.rut = rut;
            this.nombre = nombre;
        }
    }
}