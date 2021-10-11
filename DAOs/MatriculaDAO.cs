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

        public Matricula getMatriculaById(long id)
        {
            Matricula matricula = null;

            string queryString = "select * from matricula where id = @id;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    int cont = 0;

                    while (reader.Read())
                    {
                        matricula = createMatriculaFromDataRecord((IDataRecord)reader);
                        cont++;
                    }

                    if (cont == 0)
                    {
                        throw new Exception("No existe matricula con id = " + id);
                    }

                    if (cont > 1)
                    {
                        throw new Exception("Existe más de una matricula con id = " + id);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return matricula;
        }

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
                    throw new Exception(ex.Message);
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
                    throw new Exception(ex.Message);
                }
            }

            return matriculas;
        }


        public Matricula createMatricula(Alumno alumno, Curso curso)
        {
            Matricula matricula = null;

            string queryString = "insert into matricula (id_alumno, id_curso, codigo) values (@id_alumno, @id_curso, @codigo) select cast(@@IDENTITY as int)";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                string codigo = "M" + alumno.id + curso.id;

                command.Parameters.AddWithValue("@id_alumno", alumno.id);
                command.Parameters.AddWithValue("@id_curso", curso.id);                
                command.Parameters.AddWithValue("@codigo", codigo);

                try
                {
                    connection.Open();

                    int id = (int) command.ExecuteScalar();                    

                    matricula = getMatriculaById(id);

                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return matricula;
        }


        private Matricula createMatriculaFromDataRecord(IDataRecord record, Alumno alumno)
        {
            int id = (int) record[0];
            int id_alumno = (int) record[1];
            int id_curso = (int) record[2];            
            string codigo = (string) record[4];            

            if(alumno == null)
            {
                alumno = alumnoDAO.getAlumnoById(id_alumno);
            }

            Curso curso = cursoDAO.getCursoById(id_curso);

            if (!record[3].ToString().Equals(""))
            {
                decimal nota = (decimal)record[3];
                return new Matricula(id, codigo, nota, curso, alumno);
            }
            else
            {
                return new Matricula(id, codigo, curso, alumno);
            }
        }

        private Matricula createMatriculaFromDataRecord(IDataRecord record, Curso curso)
        {
            int id = (int)record[0];
            int id_alumno = (int)record[1];
            int id_curso = (int)record[2];            
            string codigo = (string)record[4];

            if (curso == null)
            {
                curso = cursoDAO.getCursoById(id_curso);
            }

            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);
            
            if (!record[3].ToString().Equals(""))
            {
                decimal nota = (decimal)record[3];
                return new Matricula(id, codigo, nota, curso, alumno);
            }
            else
            {
                return new Matricula(id, codigo, curso, alumno);
            }
        }

        private Matricula createMatriculaFromDataRecord(IDataRecord record)
        {
            int id = (int)record[0];
            int id_alumno = (int)record[1];
            int id_curso = (int)record[2];
                       
            string codigo = (string)record[4];
            
            Curso curso = cursoDAO.getCursoById(id_curso);
            
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            if (!record[3].ToString().Equals(""))
            {
                decimal nota = (decimal)record[3];
                return new Matricula(id, codigo, nota, curso, alumno);
            }
            else
            {
                return new Matricula(id, codigo, curso, alumno);
            }
            
        }

    }
}