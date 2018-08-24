using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using FacElec.model;
namespace FacElec.helpers
{
    public static class XmlHelper
    {
        
        public static XDocument generateXML(Factura factura)
        { 
            var cliente = factura.cliente[0];

            var xmlDoc = new XDocument(
                             new XDeclaration("1.0", "utf-8", ""),
                             
                             new XElement("TiqueteElectronico",
                                          //new XAttribute("xmlns","https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/tiqueteElectronico"),
                                          //new XAttribute($"{XNamespace.Xmlns}xsd","http://www.w3.org/2001/XMLSchema"),
                                          //new XAttribute($"{XNamespace.Xmlns}xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                                
                                          new XElement("Clave",factura.claveNumerica),
                                          new XElement("NumeroConsecutivo",factura.numConsecutivo),
                                          new XElement("FechaEmision", factura.fecha), 

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
                                                       new XElement("CondicionVenta", factura.condicionVenta),
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
                                                                    new XElement("TotalMercanciasGravadas", factura.totalGravado),
                                                                    new XElement("TotalMercanciasExentas", factura.totalExento),
                                                                     new XElement("TotalMercanciasGravadas", factura.totalGravado),
                                                                    new XElement("TotalGravado", factura.totalGravado),
                                                                    new XElement("TotalExento", factura.totalExento),
                                                                    new XElement("TotalVenta", factura.total),
                                                                    new XElement("TotalDescuentos", factura.totalDescuentos),
                                                                    new XElement("TotalVentaNeta", factura.totalVentaNeta),
                                                                    new XElement("TotalImpuesto", factura.totalImpuestos),
                                                                    new XElement("TotalComprobante", factura.totalComprobante)
                                                                     ),
                                                       new XElement("Normativa", 
                                                                    new XElement("NumeroResolucion","DGT-R-48-2016"),
                                                                    new XElement("FechaResolucion","2016-10-07 10:22:22"))
                                                       )
            );
            storeXml(xmlDoc, factura.id_factura);

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
                                     new XElement("MontoDescuento", detalle.montoDescuento),
                                     new XElement("NaturalezaDescuento", "Descuento"),
                                     new XElement("Impuesto",
                                                           new XElement("CodigoImpuesto", 1),
                                                           new XElement("PorcentajeImpuesto", (detalle.IV == true) ? "13.00" : "00.00"),
                                                  new XElement("MontoImpuesto", detalle.montoImpuesto),
                                                           new XElement("Exoneracion", null)
                                                 ),
                                     new XElement("MontoTotal",detalle.montoTotal),
                                     new XElement("Subtotal", detalle.subtotal),
                                     new XElement("MontoTotalLinea", detalle.montoTotalLinea)
                              
                                )
                       );
                i++;
            }

            return xml;

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
