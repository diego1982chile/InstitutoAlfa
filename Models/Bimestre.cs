using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Bimestre
    {
        public int id { get; set; }
        public int bimestre { get; set; }
        public string nombre { get; set; }

        public Bimestre(int id, int bimestre, string nombre)
        {
            this.id = id;
            this.bimestre = bimestre;
            this.nombre = nombre;
        }
    }
}