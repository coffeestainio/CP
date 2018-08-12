using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using FacElec.model;
namespace FacElec.helpers
{
    public static class XmlHelper
    {
        private static decimal totalGravado;
        private static decimal totalExento;
        private static decimal total;
        private static decimal totalDescuentos;
        private static decimal totalVentaNeta;
        private static decimal totalImpuestos;

        public static XDocument generateXML(Factura factura)
        {

            calculateTotals(factura);

            var cliente = factura.cliente[0];

            var numCuenta = "4445";
            var periodo = 0;
            if (System.DateTime.Today.Month < 10)
                periodo = System.DateTime.Today.Year;
            else
                periodo = System.DateTime.Today.Year + 1;

            var xmlDoc = new XDocument(
                             new XDeclaration("1.0", "utf-8", ""),
                             new XElement("root",
                             new XElement("FacturaElectronicaXML",
                                   new XElement("Encabezado",
                                                new XElement("NumeroFactura", factura.id_factura),
                                                new XElement("FechaFactura", factura.fecha.ToString("yyyy-MM-dd")),
                                                new XElement("Emisor", new XElement("NumCuenta", numCuenta)),
                                                new XElement("TipoCambio", "1.00"),
                                                new XElement("TipoDoc", (!factura.notaCredito) ? "1" : "3"),
                                                new XElement("CondicionVenta", 1),
                                                new XElement("NumOrdenCompra", factura.ordenCompra),
                                                new XElement("Moneda", 1),
                                                new XElement("idMedioPago", 1),
                                                new XElement("DiasCredito", factura.plazo),
                                                new XElement("Sucursal", 1),
                                                new XElement("Terminal", 1),
                                                new XElement("FechaVencimiento", ""),
                                                new XElement("SituacionEnvio", 1),
                                                new XElement("Periodo", periodo),
                                                new XElement("Receptor",
                                                             new XElement("TipoIdentificacion", cliente.tipoIdentificacion),
                                                             new XElement("IdentificacionReceptor", cliente.identificacion.Replace("-", "")),
                                                             new XElement("NombreReceptor", cliente.nombre_sociedad),
                                                             new XElement("idProvincia", cliente.provincia),
                                                             new XElement("idCanton", cliente.canton),
                                                             new XElement("idDistrito", cliente.distrito),
                                                             new XElement("idBarrio", 1),
                                                             new XElement("DireccionReceptor", cliente.direccion),
                                                             new XElement("NumeroAreaTelReceptor", "506"),
                                                             new XElement("NumeroTelReceptor", cliente.telefono.Replace("-", "")),
                                                             new XElement("CorreoElectronicoReceptor", cliente.email),
                                                             new XElement("CopiaCortesia", "rmorae@ice.co.cr;pcalvo@coffeestain.io")
                                                            )

                                               ),
                                                generateDetailsXml(factura.factura_Detalle),
                                                generarNotaCredito(factura),
                                                new XElement("Totales",
                                                             new XElement("TotalServGravados", 0),
                                                             new XElement("TotalServExentos", 0),
                                                             new XElement("TotalMercanciasGravadas", totalGravado),
                                                             new XElement("TotalMercanciasExentas", totalExento),
                                                             new XElement("TotalMercanciasGravadas", totalGravado),
                                                             new XElement("TotalGravado", totalGravado),
                                                             new XElement("TotalExento", totalExento),
                                                             new XElement("TotalVenta", total),
                                                             new XElement("TotalDescuentos", totalDescuentos),
                                                             new XElement("TotalVentaNeta", totalVentaNeta),
                                                             new XElement("TotalImpuesto", totalImpuestos),
                                                             new XElement("TotalComprobante", totalVentaNeta + totalImpuestos)
                                                             ),
                                                new XElement("Otros", "")
                                               )
                                         )
            );
            return xmlDoc;
        }


        private static XElement generarNotaCredito(Factura factura){
            if (factura.notaCredito)
                return new XElement("InformacionDeReferencia",
                                    new XElement("Referencia",
                                                 new XElement("TipoDocRef", 3),
                                                 new XElement("NumeroDeReferencia", 1),
                                                 new XElement("CodigoReferencia", 1)
                                                )
                                   );
            return new XElement("InformacionDeReferencia", null);
        }

        private static XElement generateDetailsXml(List<factura_Detalle> detalles){
            var xml = new XElement("Detalle");

               foreach(factura_Detalle detalle in detalles)
                xml.Add(new XElement("Linea",
                                new XElement("Tipo", "M"),
                               new XElement("CodigoProducto", detalle.producto[0].id_producto),
                                     new XElement("Cantidad",detalle.cantidad),
                               new XElement("UnidadMedida", 40),
                               new XElement("DetalleMerc", detalle.producto[0].nombre),
                               new XElement("PrecioUnitario", detalle.precio),
                               new XElement("MontoDescuento", getDescuento(detalle)),
                                     new XElement("NaturalezaDescuento","Descuento"),
                               new XElement("Impuestos",
                                           new XElement("Impuesto",
                                                           new XElement("CodigoImpuesto",1),
                                                           new XElement("PorcentajeImpuesto",(detalle.IV == true) ? "13.00":"00.00"),
                                                        new XElement("MontoImpuesto",getMontoImpuesto(detalle)),
                                                           new XElement("Exoneracion",null)
                                                          )
                                             )
                                ) 
                       );

            return xml;


        }

        private static decimal getDescuento(factura_Detalle detalle)
        {
            return decimal.Round(detalle.cantidad * detalle.precio * detalle.descuento,2);
        }

        private static decimal getMontoImpuesto(factura_Detalle detalle){
            if (!detalle.IV)
                return 0;
            return (
                decimal.Round(((detalle.precio * detalle.cantidad) - getDescuento(detalle)) * decimal.Parse("0.13"),2)
            );
        }

        private static void calculateTotals(Factura factura)
        {
            totalExento = 0;
            totalGravado = 0;
            totalImpuestos = 0;
            totalVentaNeta = 0;
            totalDescuentos = 0;
            total = 0;

            foreach (factura_Detalle det in factura.factura_Detalle)
            {

                if (det.IV == true)
                    totalGravado += det.cantidad * det.precio;
                else
                    totalExento += det.cantidad * det.precio;

                if (det.descuento > 0)
                    totalDescuentos += getDescuento(det);

                if (det.IV)
                    totalImpuestos += getMontoImpuesto(det);

                total = totalExento + totalGravado;
                totalVentaNeta = total - totalDescuentos;
            }
        }


        public static void storeXml(XDocument xmlDoc, string facId){
            var fileName = $"facturasEnviadas/facturaElectronica_{facId}.xml";
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            file.Directory.Create();
            xmlDoc.Save(fileName);
        }

        public static GTIResponse validateResponse(XDocument xResponse, bool notaCredito)
        {
            var res = xResponse.Element("root").Element("FacturaElectronicaXML");

            var response  = new GTIResponse();

            if (res.Element("ClaveNumerica") != null)
            {
                response.ClaveNumerica = res.Element("ClaveNumerica").Value;
                response.NumConsecutivoCompr = res.Element("NumConsecutivoCompr").Value;
                response.Sincronizada = 1;
            }
            else{
                response.ClaveNumerica = "";
                response.NumConsecutivoCompr = "";
                response.Sincronizada = 0;
            }
            response.NumDocumento = res.Element("NumDocumento").Value;
            response.IdCarga = res.Element("IdCarga").Value;
            response.NumFacturaInterno = res.Element("NumFacturaInterno").Value;
            response.CodigoError = res.Element("CodigoError").Value;
            response.DescripcionError = res.Element("DescripcionError").Value;
            response.NotaCredito = notaCredito;

            return response;

        }

    }
}
