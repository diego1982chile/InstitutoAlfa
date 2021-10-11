using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Matricula
    {
        public int id { get; set; }        
        public string codigo { get; set; }
        public decimal nota { get; set; }
        public Curso curso { get; set; }
        public Alumno alumno { get; set; }
        public Matricula(int id, string codigo, decimal nota, Curso curso, Alumno alumno)
        {
            this.id = id;
            this.codigo = codigo;
            this.nota = nota;
            this.curso = curso;
            this.alumno = alumno;
        }

        public Matricula(int id, string codigo, Curso curso, Alumno alumno)
        {
            this.id = id;
            this.codigo = codigo;
            this.curso = curso;
            this.alumno = alumno;
        }
    }
}