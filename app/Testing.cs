using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Libreria;


namespace TestingApp
{
    public class Testing
    {
        public static void Main(string[] args)
        {
            // Configura la construcción de la configuración
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtén la cadena de conexión
            var conn = configuration.GetConnectionString("dbMercurio");

            // Prueba la conexión
            try
            {
                using (var sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    Console.WriteLine("Conexión exitosa.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }
    }
}
