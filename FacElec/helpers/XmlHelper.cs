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

            var periodo = 0;
            if (System.DateTime.Today.Month < 10)
                periodo = System.DateTime.Today.Year;
            else
                periodo = System.DateTime.Today.Year + 1;

            var xmlDoc = new XDocument(
                             new XDeclaration("1.0", "utf-8", ""),
                             
                             new XElement("TiqueteElectronico",
                                          //new XAttribute("xmlns","https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/tiqueteElectronico"),
                                          //new XAttribute($"{XNamespace.Xmlns}xsd","http://www.w3.org/2001/XMLSchema"),
                                          //new XAttribute($"{XNamespace.Xmlns}xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                                
                                          new XElement("Clave",factura.claveNumerica),
                                          new XElement("NumeroConsecutivo",factura.numConsecutivo),
                                          new XElement("FechaEmision", factura.fecha.ToString("yyyy-MM-dd")), 

                                          new XElement("Emisor",
                                                             new XElement("Nombre", "Comercial Pozos S.A"),
                                                             new XElement("Identificacion",
                                                                          new XElement("Tipo","02"),
                                                                          new XElement("Numero","3101159911")
                                                                         ),
                                                       new XElement("NombreComercial", "Comercial Pozos S.A"),
                                                       new XElement("Ubicacion",
                                                                    new XElement("Provincia",1),
                                                                    new XElement("Canton",9),
                                                                    new XElement("Distrito",3),
                                                                    new XElement("Barrio",1),
                                                                    new XElement("OtrasSenas","100 Sur Iglesia Pozos, Santa Ana")
                                                                   ),
                                                       new XElement("Telefono",
                                                                    new XElement("CodigoPais","506"),
                                                                    new XElement("NumTelefono","2282-6030")
                                                                   ),
                                                       new XElement("CorreoElectronico","comercialpozos2@hotmail.com"),
                                                       new XElement("CondicionVenta", (factura.plazo == 0 ) ? "1":"2"),
                                                       new XElement("PlazoCredito", factura.plazo),
                                                       new XElement("MedioPago", 1)
                                                      ),
                                          new XElement("Receptor",
                                                             new XElement("Nombre", cliente.nombre),
                                                             new XElement("Identificacion",
                                                                          new XElement("Tipo", cliente.tipoIdentificacion),
                                                                          new XElement("Numero", cliente.identificacion)
                                                                         ),
                                                       new XElement("NombreComercial", cliente.nombre),
                                                       new XElement("Ubicacion",
                                                                    new XElement("Provincia", cliente.provincia),
                                                                    new XElement("Canton", cliente.canton),
                                                                    new XElement("Distrito", cliente.distrito),
                                                                    new XElement("Barrio", 1),
                                                                    new XElement("OtrasSenas", cliente.direccion)
                                                                   ),
                                                       new XElement("Telefono",
                                                                    new XElement("CodigoPais", "506"),
                                                                    new XElement("NumTelefono", cliente.telefono)
                                                                   ),
                                                       new XElement("CorreoElectronico", cliente.email)
                                                      ),
                                                       generateDetailsXml(factura.factura_Detalle),
              
                                                       new XElement("ResumenFactura",
                                                                    new XElement("CodigoMoneda","CRC"),
                                                                    new XElement("TipoCambio",1),
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
                                                       new XElement("Normativa", 
                                                                    new XElement("NumeroResolucion","DGT-R-48-2016"),
                                                                    new XElement("FechaResolucion","2016-10-07 10:22:22"))
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
                var xml = new XElement("DetalleServicio");
            var i = 1;

            foreach (factura_Detalle detalle in detalles)
            {
                var montoImpuesto = getMontoImpuesto(detalle);
                var montoDescuento = getDescuento(detalle);

                xml.Add(new XElement("LineaDetalle",
                                     new XElement("NumeroLinea", i),
                                     new XElement("Codigo",
                                                  new XElement("Tipo", 4),
                                                  new XElement("Codigo", 3)
                                                 ),

                                     new XElement("Cantidad", detalle.cantidad),
                                     new XElement("UnidadMedida", "Unid"),
                                     new XElement("UnidadMedidaComercial", null),
                                     new XElement("Detalle", detalle.producto[0].nombre),
                                     new XElement("PrecioUnitario", detalle.precio),
                                     new XElement("MontoDescuento", montoDescuento),
                                     new XElement("NaturalezaDescuento", "Descuento"),
                                     new XElement("Impuesto",
                                                           new XElement("CodigoImpuesto", 1),
                                                           new XElement("PorcentajeImpuesto", (detalle.IV == true) ? "13.00" : "00.00"),
                                                           new XElement("MontoImpuesto", montoImpuesto),
                                                           new XElement("Exoneracion", null)
                                                 ),
                                     new XElement("MontoTotal",detalle.precio * detalle.cantidad),
                                     new XElement("Subtotal", detalle.precio * detalle.cantidad - montoDescuento),
                                     new XElement("MontoTotalLinea", detalle.precio * detalle.cantidad + montoImpuesto)
                              
                                )
                       );
                i++;
            }

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
