using InstitutoAlfa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace InstitutoAlfa.DAOs
{    

    public class MatriculaDAO
    {
        private readonly AlumnoDAO alumnoDAO = new AlumnoDAO();

        private readonly CursoDAO cursoDAO = new CursoDAO();                

        public List<Matricula> getMatriculasByAlumno(Alumno alumno)
        {
            List<Matricula> matriculas = new List<Matricula>();
            
            string queryString = "select * from matricula where id_alumno = @id_alumno order by codigo;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id_alumno", alumno.id);                
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        matriculas.Add(createMatriculaFromDataRecord((IDataRecord)reader, alumno));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            return matriculas;
        }

        public List<Matricula> getMatriculasByCurso(Curso curso)
        {
            List<Matricula> matriculas = new List<Matricula>();

            string queryString = "select * from matricula where id_curso = @id_curso order by codigo;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id_curso", curso.id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        matriculas.Add(createMatriculaFromDataRecord((IDataRecord)reader, curso));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return matriculas;
        }
        

        private Matricula createMatriculaFromDataRecord(IDataRecord record, Alumno alumno)
        {
            int id = (int) record[0];
            int id_alumno = (int) record[1];
            int id_curso = (int) record[2];
            decimal nota = (decimal) record[3];
            string codigo = (string) record[4];            

            if(alumno == null)
            {
                alumno = alumnoDAO.getAlumnoById(id_alumno);
            }

            Curso curso = cursoDAO.getCursoById(id_curso);            
                        
            return new Matricula(id, codigo, nota, curso, alumno);
        }

        private Matricula createMatriculaFromDataRecord(IDataRecord record, Curso curso)
        {
            int id = (int)record[0];
            int id_alumno = (int)record[1];
            int id_curso = (int)record[2];
            int nota = (int)record[3];
            string codigo = (string)record[4];

            if (curso == null)
            {
                curso = cursoDAO.getCursoById(id_curso);
            }

            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            return new Matricula(id, codigo, nota, curso, alumno);
        }

    }
}