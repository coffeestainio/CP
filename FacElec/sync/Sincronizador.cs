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

            facturas = SqlHelper.GetFacturas();

            if (facturas != null && facturas.Count > 0)
            {
                foreach (Factura fac in facturas)
                {

                    var error = ValidatorHelper.validarFacturas(fac);
                    if (error != null)
                        SqlHelper.updateWithError(error);
                    else {
                        XmlHelper.generateXML(fac);
                        PdfHelper.generatePDF(fac);
                        SqlHelper.updateSuccessful(fac.id_factura);
                    }

                }
            }
            else{
                Console.WriteLine("Nothing to sync.");
            }

        }
    }
}
