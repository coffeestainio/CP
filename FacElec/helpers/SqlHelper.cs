using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using FacElec.model;
using Newtonsoft.Json;

namespace FacElec.helpers
{
    public static class SqlHelper
    {
        private const string sqlConnection = "Server=tcp:cp2.database.windows.net,1433;Initial Catalog = cp2_test2; Persist Security Info=False;User ID = CPSQL; Password=SQLCP12345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public static List<Factura> GetFacturas()
        {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            //facturas = validarFacturas(facturas);

            return facturas;
        }


        static List<Factura> validarFacturas(List<Factura> facturas)
        {

            var errores = new List<Error>();
            var facturasvalidas = new List<Factura>();

            foreach (Factura fac in facturas)
            {
                var cliente = fac.cliente[0];

                //validate email
                try
                {
                    MailAddress mail = new MailAddress(cliente.email);
                }
                catch (FormatException)
                {
                    errores.Add(new Error(fac.id_factura, fac.claveNumerica, fac.numConsecutivo, "Error:001", "Formato del correo incorrecto"));
                    facturas.Remove(fac);
                    break;
                }

                Regex regex = new Regex(@"^[0-9]{8}$");

                //validate phone
                if (regex.Match(cliente.telefono.Trim().Replace("-","")) == Match.Empty)
                {
                    errores.Add(new Error(fac.id_factura, fac.claveNumerica, fac.numConsecutivo, "Error:002", "Formato del numero de correo"));
                    facturas.Remove(fac);
                    break;
                }

                regex = new Regex(@"^[0-9]{17}$");
                //validate identificacion
                if (cliente.tipoIdentificacion == 3 && 
                    regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
                {
                    errores.Add(new Error(fac.id_factura, fac.claveNumerica, fac.numConsecutivo, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
                    facturas.Remove(fac);
                    break;
                }

                regex = new Regex(@"^[0-9]{10}$");
                //validate identificacion
                if (cliente.tipoIdentificacion == 2 &&
                    regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
                {
                    errores.Add(new Error(fac.id_factura, fac.claveNumerica, fac.numConsecutivo, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
                    facturas.Remove(fac);
                    break;
                }

                regex = new Regex(@"^[0-9]{9}$");
                //validate identificacion
                if (cliente.tipoIdentificacion == 1 &&
                    regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
                {
                    errores.Add(new Error(fac.id_factura, fac.claveNumerica, fac.numConsecutivo, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
                    facturas.Remove(fac);
                    break;
                }
               
            }

            return facturas;
        }
    }
}
