using System;
using System.Collections.Generic;
using FacElec.model;
using FacElec.helpers;
using System.Xml.Linq;
using log4net;

namespace FacElec.sync
{
    public static class Sincronizador
    {

        public static ILog log;

        public static void SincronizarFacturas()
        {

            var facturas = new List<Factura>();

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
    }
}
