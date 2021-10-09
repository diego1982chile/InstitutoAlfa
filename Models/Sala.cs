using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Sala
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public int capacidad { get; set; }

        public Sala(int id, string codigo, int capacidad)
        {
            this.id = id;
            this.codigo = codigo;
            this.capacidad = capacidad;
        }
    }

                            
}