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

    public class CursoDAO
    {
        private readonly AnyoDAO anyoDAO = new AnyoDAO();

        private readonly BimestreDAO bimestreDAO = new BimestreDAO();
        
        private readonly AsignaturaDAO asignaturaDAO = new AsignaturaDAO();

        private readonly ProfesorDAO profesorDAO = new ProfesorDAO();

        private readonly SalaDAO salaDAO = new SalaDAO();

        public List<Curso> getCursosByAnyoAndBimestre(Anyo anyo, Bimestre bimestre)
        {
            List<Curso> cursos = new List<Curso>();
            
            string queryString = "select * from curso where id_anyo = @id_anyo and id_bimestre = @id_bimestre order by codigo;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id_anyo", anyo.id);
                command.Parameters.AddWithValue("@id_bimestre", bimestre.id);
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cursos.Add(createCursoFromDataRecord((IDataRecord)reader));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }                
            }

            return cursos;
        }

        public Curso getCursoById(int id)
        {
            Curso curso = null;

            string queryString = "select * from curso where id = @id order by codigo;";

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
                        curso = createCursoFromDataRecord((IDataRecord)reader);
                        cont++;
                    }

                    if (cont == 0)
                    {
                        throw new Exception("No bimestre con id = " + id);
                    }

                    if (cont > 1)
                    {
                        throw new Exception("Existe más de un bimestre con id = " + id);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
                
            }

            return curso;
        }

        private Curso createCursoFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            int id_anyo = (int) record[1];
            int id_bimestre = (int) record[2];
            int id_asignatura = (int) record[3];
            int id_sala = (int)record[4];
            int id_profesor = (int) record[5];            
            string codigo = (string) record[6];
            string estado = (string)record[7];

            Anyo anyo = anyoDAO.getAnyoById(id_anyo);
            Bimestre bimestre = bimestreDAO.getBimestreById(id_bimestre);
            Asignatura asignatura = asignaturaDAO.getAsignaturaById(id_asignatura);
            Profesor profesor = profesorDAO.getProfesorById(id_profesor);
            Sala sala = salaDAO.getSalaById(id_sala);
                        
            return new Curso(id, anyo, bimestre, asignatura, profesor, sala, codigo, estado);
        }

    }
}