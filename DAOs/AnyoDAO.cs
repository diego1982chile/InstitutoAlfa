using InstitutoAlfa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InstitutoAlfa.DAOs
{    

    public class AnyoDAO
    {
        
        public List<Anyo> getAllAnyos()
        {
            List<Anyo> anyos = new List<Anyo>();            

            string queryString = "select * from anyo;";

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
                        anyos.Add(createAnyoFromDataRecord((IDataRecord)reader));
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }                
            }

            return anyos;
        }

        public Anyo getAnyoById(long id)
        {
            Anyo anyo = null;

            string queryString = "select * from anyo where id = @id;";

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
                        anyo = createAnyoFromDataRecord((IDataRecord)reader);
                        cont++;
                    }

                    if(cont == 0)
                    {
                        throw new Exception("No existe año con id = " + id);
                    }

                    if(cont > 1)
                    {
                        throw new Exception("Existe más de un año con id = " + id);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }                
            }

            return anyo;
        }

        private Anyo createAnyoFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            int anyo = (int) record[1];            

            return new Anyo(id, anyo);
        }

    }
}