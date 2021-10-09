using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Asignatura
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }

        public Asignatura(int id, string nombre, string codigo)
        {
            this.id = id;
            this.nombre = nombre;
            this.codigo = codigo;
        }
    }
}