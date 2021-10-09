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

    public class BimestreDAO
    {

        public List<Bimestre> getAllBimestres()
        {
            List<Bimestre> anyos = new List<Bimestre>();

            string queryString = "select * from bimestre;";

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
                        anyos.Add(createBimestreFromDataRecord((IDataRecord)reader));
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            return anyos;
        }

        public Bimestre getBimestreById(long id)
        {
            Bimestre bimestre = null;

            string queryString = "select * from bimestre where id = @id;";

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
                        bimestre = createBimestreFromDataRecord((IDataRecord)reader);
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
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            return bimestre;
        }

        private Bimestre createBimestreFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            int bimestre = (int) record[1]; 
            string nombre = (string) record[2];

            return new Bimestre(id, bimestre, nombre);
        }

    }
}