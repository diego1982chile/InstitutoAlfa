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

    public class AsignaturaDAO
    {

        private readonly AnyoDAO anyoDAO = new AnyoDAO();
        
        public Asignatura getAsignaturaById(long id)
        {
            Asignatura asignatura = null;

            string queryString = "select * from asignatura where id = @id;";

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
                        asignatura = createAsignaturaFromDataRecord((IDataRecord)reader);
                    }

                    if (cont == 0)
                    {
                        throw new Exception("No existe asignatura con id = " + id);
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
                }                
            }

            return asignatura;
        }

        private Asignatura createAsignaturaFromDataRecord(IDataRecord record)
        {
            int id = (int) record[0];
            string codigo = (string) record[1];
            string nombre = (string) record[2];            

            return new Asignatura(id, nombre, codigo);
        }

    }
}