using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using FacElec.model;
using log4net;
using Newtonsoft.Json;

namespace FacElec.helpers
{
    public static class SqlHelper
    {

        public static string sqlConnection;
        internal static ILog log;

        public static List<Factura> GetFacturas()
        {
            log.Info("Obteniendo facturas pendientes");

            List<Factura> facturas = new List<Factura>();
            try
            {
                var sqlQuery = "SELECT *, " +
                    "factura_Detalle = ( " +
                                       "select *, " +
                                       "producto = (select * from producto p where p.id_producto = fd.id_producto for JSON PATH) " +
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
                    var jsonResult = new StringBuilder();
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader[0].ToString());
                        }
                    }

                    facturas = JsonConvert.DeserializeObject<List<Factura>>(jsonResult.ToString());
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;

            }


            return facturas;
        }


        public static void updateNoInternet (Factura fac){
            log.Info("Guardando nueva ClaveNumerica (Sin internet)");
            try
            {

                var sqlQuery = $"update factura set " +
                    $"claveNumerica = '{fac.claveNumerica}' " +
                    $"where id_factura = {fac.id_factura}";

                using (var connection = new SqlConnection(sqlConnection))
                {
                    var command = new SqlCommand(sqlQuery, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static void updateWithError(Error error){

            log.Info("Guardando error en la base de datos");

            try
            {

                var sqlQuery = $"update factura set " +
                    $"actualizada = getDate(), " +
                    $"sincronizada = 1 ," +
                    $"coderror = '{error.CodigoError}' ," +
                    $"DESCRIPCIONERROR = '{ error.DescripcionError}' " +
                    $"where id_factura = {error.NumFacturaInterno}";

                using (var connection = new SqlConnection(sqlConnection))
                {
                    var command = new SqlCommand(sqlQuery, connection);
                    connection.Open();
                    var cantidadError = command.ExecuteNonQuery();
                    if (cantidadError > 0)
                        log.Error("Error loguedo satisfactoriamente : "+
                                          $"Factura : {error.NumFacturaInterno}. " +
                                          $"Codigo : {error.CodigoError}. " +
                                          $"Descipcion : {error.DescripcionError} ");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static bool UpdateSuccessful(string idFactura)
        {
            log.Info($"Actualizando el estado de la factura");

            try
            {

                var sqlQuery = $"update factura set " +
                    $"sincronizada = 1 ," +
                    $"coderror = 'Error:00' ," +
                    $"DESCRIPCIONERROR = 'No error', " +
                    $"actualizada = getDate() " +
                    $"where id_factura = {idFactura}";

                using (var connection = new SqlConnection(sqlConnection))
                {
                    var command = new SqlCommand(sqlQuery, connection);
                    connection.Open();
                    var cantidadError = command.ExecuteNonQuery();
                    if (cantidadError > 0)
                        Console.WriteLine("Factura enviada satisfactoriamente : " +
                                          $"Factura : {idFactura}.");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }

            return true;
        }
      
    }
}
