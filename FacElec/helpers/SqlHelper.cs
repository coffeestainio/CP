using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using FacElec.model;
using Newtonsoft.Json;

namespace FacElec.helpers
{
    public static class SqlHelper
    {
        private const string sqlConnection = "Server=tcp:pt2.database.windows.net,1433;Initial Catalog = pt2_test; Persist Security Info=False;User ID = PTSQL; Password=SQLPT12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public static List<Factura> GetFacturas()
        {
            List<Factura> facturas = new List<Factura>();
            try
            {
                var sqlQuery = "SELECT *, " +
                    "factura_Detalle = ( " +
                                       "select *, " +
                                       "producto = (select id_producto, nombre from producto p where p.id_producto = fd.id_producto for JSON PATH) " +
                                       "from Factura_Detalle fd where f.id_factura = fd.id_factura " +
                    "FOR JSON PATH ) ,    " +
                    " cliente = ( " +
                    "select * from cliente where cliente.id_cliente = f.id_cliente " +
                    "FOR JSON AUTO " +
                    ") " +
                    " from Factura f where sincronizada = 0 " +
                                            "For JSON PATH  ";

                using (var connection = new SqlConnection(sqlConnection))
                {
                    var command = new SqlCommand(sqlQuery, connection);
                    var jsonResult =  new StringBuilder();
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader[0].ToString());
                        }
                    }

                    facturas = JsonConvert.DeserializeObject<List<Factura>>(jsonResult.ToString());
                }
            }
            catch (Exception ex ){
                Console.WriteLine(ex);
                return null;
            }

            return facturas;

        }

        public static void GuardarEstado(List<GTIResponse> resultados)
        {
            var sqlCommando = "";
            if (resultados.Count > 0)
            {
                foreach (GTIResponse res in resultados)
                {
                    if (!res.NotaCredito)
                        sqlCommando +=
                            $"update dbo.factura set idCarga={res.IdCarga}, " +
                            $"ClaveNumerica='{res.ClaveNumerica}', " +
                            $"NumConsecutivo='{res.NumConsecutivoCompr}', " +
                            $"CodError='{res.CodigoError}', " +
                            $"DescripcionError='{res.DescripcionError}', " +
                            $"sincronizada=1, " +
                            $"Actualizada='{DateTime.Today}'" +
                            $" where id_factura = {res.NumFacturaInterno};";
                    else
                        sqlCommando +=
                            "insert into dbo.notacreditoelec (idfactura, idCarga,ClaveNumerica,NumConsecutivo,CodError,DescripcionError,Actualizada) " +
                            $" values ({res.NumFacturaInterno}, {res.IdCarga}, '{res.ClaveNumerica}','{res.NumConsecutivoCompr}','{res.CodigoError}', " +
                            $" '{res.DescripcionError}', '{DateTime.Today}'); " +
                            $"update dbo.factura set Sincronizada = 1 where id_factura = {res.NumFacturaInterno};";
                }

                try
                {
                    using (var connection = new SqlConnection(sqlConnection))
                    {
                        var command = new SqlCommand(sqlCommando, connection);
                        connection.Open();

                        var updatedRows = command.ExecuteNonQuery();
                        Console.WriteLine($"Number of processed rows {updatedRows}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
