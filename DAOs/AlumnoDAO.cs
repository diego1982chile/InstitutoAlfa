﻿using InstitutoAlfa.Models;
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

            string queryString = "select * from alumno;";

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
                    Console.WriteLine(ex.Message);
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
                    Console.WriteLine(ex.Message);
                }                
            }

            return alumno;
        }

        private Alumno createAlumnoFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            string rut = (string) record[1];
            string nombre = (string) record[2];            

            return new Alumno(id, rut, nombre);
        }

    }
}