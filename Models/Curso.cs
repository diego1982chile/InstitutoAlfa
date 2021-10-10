using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.Models
{
    public class Curso
    {
        public int id { get; set; }        
        public Anyo anyo { get; set; }
        public Bimestre bimestre { get; set; }
        public Asignatura asignatura { get; set; }
        public Profesor profesor { get; set; }
        public Sala sala { get; set; }
        public string codigo { get; set; }
        public string estado { get; set; }

        public List<Matricula> matriculas { get; set; }

        public Curso(int id, Anyo anyo, Bimestre bimestre, Asignatura asignatura, Profesor profesor, Sala sala, string codigo, string estado)
        {
            this.id = id;
            this.anyo = anyo;
            this.bimestre = bimestre;
            this.asignatura = asignatura;
            this.profesor = profesor;
            this.sala = sala;
            this.codigo = codigo;
            this.estado = estado;
            matriculas = new List<Matricula>();
        }
    }
}