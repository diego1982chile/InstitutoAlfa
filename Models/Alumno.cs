using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Alumno
    {
        public int id { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public DateTime nacimiento { get; set; }
        public string genero { get; set; }

        public List<Matricula> matriculas { get; set; }

        public Alumno()
        {
        }

        public Alumno(int id, string rut, string nombre, DateTime nacimiento, string genero)
        {
            this.id = id;
            this.rut = rut;
            this.nombre = nombre;
            this.nacimiento = nacimiento;
            this.genero = genero;
            matriculas = new List<Matricula>();
        }
    }
}