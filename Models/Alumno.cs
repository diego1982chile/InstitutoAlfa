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

        public override bool Equals(object obj)
        {
            return obj is Alumno alumno &&
                   id == alumno.id &&
                   rut == alumno.rut &&
                   nombre == alumno.nombre &&
                   nacimiento == alumno.nacimiento &&
                   genero == alumno.genero;                   
        }

        public override int GetHashCode()
        {
            int hashCode = 1729070767;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rut);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombre);
            hashCode = hashCode * -1521134295 + nacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(genero);
            return hashCode;
        }
    }
}