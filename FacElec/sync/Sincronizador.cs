using System;
using System.Collections.Generic;
using FacElec.model;
using FacElec.helpers;
using System.Xml.Linq;
using log4net;
using System.Net;
using System.Text;

namespace FacElec.sync
{
    public static class Sincronizador
    {

        public static ILog log;

        public static void SincronizarFacturas()
        {

            var facturas = new List<Factura>();

            var hayConexion = verificarInternet();

            facturas = SqlHelper.GetFacturas();

            if (facturas != null && facturas.Count > 0)
            {
                foreach (Factura fac in facturas)
                {
                    log.Info($"** Procesando la factura: {fac.id_factura} **");
                    var error = ValidatorHelper.validarFacturas(fac);

                    if (error != null)
                    {
                        SqlHelper.updateWithError(error);
                    }
                    else
                    {
                        //si no hay internet se cambia la situacion de envio a 3
                        if (!hayConexion)
                        {
                            fac.claveNumerica = newClaveNumerica(fac.claveNumerica);
                            SqlHelper.updateNoInternet(fac);

                        }

                        //se genera el xml el pdf se llama el proceso y se guarda la factura
                        XmlHelper.GenerateXML(fac);
                        PdfHelper.GeneratePDF(fac);
                        AdemarHelper.CallBatchProcess(fac.claveNumerica);
                        SqlHelper.UpdateSuccessful(fac.id_factura);
                    }

                }
            }
            else{
                log.Info("No se encontraron facturas pendientes");
            }

        }

        private static string newClaveNumerica(string oldClaveNumerica){
            var sb = new StringBuilder(oldClaveNumerica);
            sb[41] = '3';
            return sb.ToString();
        }

        private static bool verificarInternet()
        {
            log.Info("Verificando conexion a intenet");

            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    log.Info("Conexion exitosa");
                    return true;
                }
            }
            catch
            {
                log.Warn("No se pudo conectar a internet");
                return false;
            }
        }

    }
}
