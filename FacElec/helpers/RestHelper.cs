
using System;
using System.Xml.Linq;

namespace FacElec.helpers
{
    public static class RestHelper
    {
        private const string email = "rmorae@ice.co.cr";
        private const string password = "CtaGTI*2017";

        public static XDocument SendFacturaElectronica(XDocument docXml)
        {
            string respuesta = "";

            try
            {
                var servicio = new GTICargaFacturaSoapClient(GTICargaFacturaSoapClient.EndpointConfiguration.GTICargaFacturaSoap);
                var response = servicio.InsertarDocumentosAsync(docXml.ToString(), email, password);
                response.Wait();
                respuesta = response.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            XDocument resXml = XDocument.Parse(respuesta);
            return resXml;
        }
    }
}
