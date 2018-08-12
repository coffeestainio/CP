using System;
using System.Collections.Generic;
using FacElec.model;
using FacElec.helpers;
using System.Xml.Linq;

namespace FacElec.sync
{
    public static class Sincronizador
    {

        public static void SincronizarFacturas()
        {
            var facturas = new List<Factura>();
            var resultados = new List<GTIResponse>();
            facturas = SqlHelper.GetFacturas();
            if (facturas != null && facturas.Count > 0)
            {
                foreach (Factura fac in facturas)
                {
                    var xmlFac = XmlHelper.generateXML(fac);

                    XmlHelper.storeXml(xmlFac, fac.id_factura);
                    var resultado = RestHelper.SendFacturaElectronica(xmlFac);

                    resultados.Add(XmlHelper.validateResponse(resultado, fac.notaCredito));

                }
            }
            else{
                Console.WriteLine("Nothing to sync.");
            }

            SqlHelper.GuardarEstado(resultados);

        }
    }
}
