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

    public class ProfesorDAO
    {
        
        public Profesor getProfesorById(long id)
        {
            Profesor profesor = null;

            string queryString = "select * from profesor where id = @id;";

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
                        profesor = createProfesorFromDataRecord((IDataRecord)reader);
                    }

                    if (cont == 0)
                    {
                        throw new Exception("No existe sala con id = " + id);
                    }

                    if (cont > 1)
                    {
                        throw new Exception("Existe más de una sala con id = " + id);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            return profesor;
        }

        private Profesor createProfesorFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            string rut = (string) record[1];
            string nombre = (string) record[2];            

            return new Profesor(id, rut, nombre);
        }

    }
}