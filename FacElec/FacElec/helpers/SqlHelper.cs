using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FacElec.model;
using Newtonsoft.Json;

namespace FacElec.helpers
{
    public static class SqlHelper
    {
        private const string sqlConnection = "Server=tcp:cp2.database.windows.net,1433;Initial Catalog = CP2_Test; Persist Security Info=False;User ID = CPSQL; Password=SQLCP12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public static List<Factura> GetFacturas()
        {
            List<Factura> factura = new List<Factura>();
            try
            {
                var sqlQuery = "SELECT TOP 1 *, " +
                    "factura_Detalle = ( " +
                                       "select top 1 *, " +
                                       "producto = (select id_producto, nombre, costo from producto p where p.id_producto = fd.id_producto for JSON PATH) " +
                                       "from Factura_Detalle fd where f.id_factura = fd.id_factura " +
                    "FOR JSON PATH ) ,    " +
                    " cliente = ( " +
                    "select * from cliente where cliente.id_cliente = f.id_cliente " +
                    "FOR JSON AUTO " +
                    ") " +
                    " from Factura f " +
                                            "For JSON PATH  ";

                using (var connection = new SqlConnection(sqlConnection))
                {
                    var command = new SqlCommand(sqlQuery, connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            factura = JsonConvert.DeserializeObject<List<Factura>>(reader[0].ToString());

                        }
                    }
                }
            }
            catch (Exception){
                return null;
            }

            return factura;

        }
    }
}
