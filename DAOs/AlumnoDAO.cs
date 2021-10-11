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

    public class AlumnoDAO
    {

        public List<Alumno> getAllAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();

            string queryString = "select * from alumno order by nombre;";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alumnos.Add(createAlumnoFromDataRecord((IDataRecord)reader));
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    //Console.WriteLine(ex.Message);
                }                
            }

            return alumnos;
        }

        public Alumno getAlumnoById(long id)
        {
            Alumno alumno = null;

            string queryString = "select * from alumno where id = @id;";

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
                        alumno = createAlumnoFromDataRecord((IDataRecord)reader);
                        cont++;
                    }

                    if (cont == 0)
                    {
                        throw new Exception("No existe alumno con id = " + id);
                    }

                    if (cont > 1)
                    {
                        throw new Exception("Existe más de un alumno con id = " + id);
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

            return alumno;
        }

        public Alumno createAlumno(Alumno alumno)
        {            
            string queryString = "insert into alumno values (@rut, @nombre, @nacimiento, @genero) select cast(scope_identity() as int)";            
            
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@rut", alumno.rut);
                command.Parameters.AddWithValue("@nombre", alumno.nombre);
                command.Parameters.AddWithValue("@nacimiento", alumno.nacimiento);
                command.Parameters.AddWithValue("@genero", alumno.genero);                

                try
                {
                    connection.Open();
                    
                    int id = (int) command.ExecuteScalar();

                    alumno.id = id;
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return alumno;
        }

        public Alumno updateAlumno(Alumno alumno)
        {
            string queryString = "update alumno set rut = @rut, nombre = @nombre, nacimiento = @nacimiento, genero = @genero where id = @id select cast(@@ROWCOUNT as int)";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@rut", alumno.rut);
                command.Parameters.AddWithValue("@nombre", alumno.nombre);
                command.Parameters.AddWithValue("@nacimiento", alumno.nacimiento);
                command.Parameters.AddWithValue("@genero", alumno.genero);
                command.Parameters.AddWithValue("@id", alumno.id);

                try
                {
                    connection.Open();

                    int modified = (int)command.ExecuteScalar();

                    if(modified == 0)
                    {
                        //Console.WriteLine("No se actualizó ningún dato del alumno!!");
                        throw new Exception("No se actualizó ningún dato del alumno!!");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return alumno;
        }

        public void deleteAlumno(int id_alumno)
        {
            string queryString = "delete from alumno where id = @id select cast(@@ROWCOUNT as int)";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["instituto_alfa"].ConnectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@id", id_alumno);                

                try
                {
                    connection.Open();

                    int modified = (int)command.ExecuteScalar();

                    if (modified == 0)
                    {
                        //Console.WriteLine("No se eliminó el alumno!!");
                        throw new Exception("No se eliminó el alumno!!");

                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            
        }

        private Alumno createAlumnoFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            string rut = (string) record[1];
            string nombre = (string) record[2];
            DateTime nacimiento = (DateTime) record[3];
            string genero = (string) record[4];

            return new Alumno(id, rut, nombre, nacimiento, genero);
        }

    }
}