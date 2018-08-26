﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace FacElec.model
{
    public class Factura
    {
        public string id_factura;
        public int id_cliente;
        public int id_agente;
        public int plazo;
        public string fecha;
        public int id_usuario;
        public decimal PIV;
        public List<factura_Detalle> factura_Detalle;
        public List<cliente> cliente;
        public int sincronizada;
        public bool notaCredito;
        public string claveNumerica;
        public string numConsecutivo;
        public int condicionVenta;
        public decimal totalGravado;
        public decimal totalExento;
        public decimal total;
        public decimal totalDescuentos;
        public decimal totalVentaNeta;
        public decimal totalImpuestos;
        public decimal totalComprobante;

        public Factura(string id_factura, int id_cliente, int id_agente, int plazo, DateTime fecha, int id_usuario, decimal pIV, List<factura_Detalle> factura_Detalle, List<cliente> cliente, string ordenCompra, DateTime fechaOrden,
                       int sincronizada, string claveNumerica, string numConsecutivo,bool notaCredito = false)
        {
            this.id_factura = id_factura;
            this.id_cliente = id_cliente;
            this.id_agente = id_agente;
            this.plazo = plazo;
            this.fecha = fecha.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture);
            this.id_usuario = id_usuario;
            PIV = pIV;
            this.factura_Detalle = factura_Detalle;
            this.cliente = cliente;
            this.sincronizada = sincronizada;
            this.notaCredito = notaCredito;
            this.claveNumerica = claveNumerica;
            this.numConsecutivo = numConsecutivo;
            condicionVenta = (plazo == 0)? 1:2;

            calculateTotals();

            totalComprobante = totalVentaNeta + totalImpuestos;
        }

        private void calculateTotals()
        {

            var precioId = cliente[0].precio;

            foreach (factura_Detalle det in factura_Detalle)
            {
                var prod = det.producto[0];

                det.montoTotal = det.precio * det.cantidad;

                if (det.descuento > 0)
                    det.montoDescuento = getDescuento(det);

                if (det.IV)
                {
                    totalGravado += det.montoTotal;
                    det.montoImpuesto += getMontoImpuesto(det);
                }
                else
                {
                    totalExento += det.montoTotal;
                    det.montoImpuesto = 0;
                }


                det.subtotal = det.montoTotal - det.montoDescuento;
                det.montoTotalLinea = det.subtotal + det.montoImpuesto;
    
                var utilidad = getUtilidad(det, precioId);
                det.consumidor = Decimal.Round(prod.costo * (1 + utilidad) / prod.empaque / prod.sub_empaque * (1 + prod.detalle) * (1 + ((det.IV == true) ? new decimal(0.13) : 0)),2,MidpointRounding.AwayFromZero);


                total = totalExento + totalGravado;
                totalDescuentos += det.montoDescuento;
                totalImpuestos += det.montoImpuesto;
                totalVentaNeta = total - totalDescuentos;
                 
            }

        }

        decimal getUtilidad (factura_Detalle det,int precioId){
            
            switch (precioId)
            {
                case 1:
                    {
                        return det.producto[0].utilidad_1;
                    }
                case 2:
                    {
                        return det.producto[0].utilidad_2;
                    }
                case 3:
                    {
                        return det.producto[0].utilidad_3;
                    }
                case 4:
                    {
                        return det.producto[0].utilidad_4;
                    }
            }

            return new decimal(0);
        }

        private decimal getDescuento(factura_Detalle detalle)
        {
            return decimal.Round(detalle.montoTotal * detalle.descuento, 2, System.MidpointRounding.AwayFromZero);
        }

        private decimal getMontoImpuesto(factura_Detalle detalle)
        {   
            return decimal.Round((detalle.montoTotal - detalle.montoDescuento) * decimal.Parse("0.13"), 2, System.MidpointRounding.AwayFromZero);
        }
    }
}
