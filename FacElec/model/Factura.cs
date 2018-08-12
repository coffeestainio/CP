using System;
using System.Collections.Generic;

namespace FacElec.model
{
    public class Factura
    {
        public string id_factura;
        public int id_cliente;
        public int id_agente;
        public int plazo;
        public DateTime fecha;
        public int id_usuario;
        public decimal PIV;
        public List<factura_Detalle> factura_Detalle;
        public List<cliente> cliente;
        public string ordenCompra;
        public DateTime fechaOrden;
        public int sincronizada;
        public bool notaCredito;

        public Factura(string id_factura, int id_cliente, int id_agente, int plazo, DateTime fecha, int id_usuario, decimal pIV, List<factura_Detalle> factura_Detalle, List<cliente> cliente, string ordenCompra, DateTime fechaOrden,
                      int sincronizada, bool notaCredito)
        {
            this.id_factura = id_factura;
            this.id_cliente = id_cliente;
            this.id_agente = id_agente;
            this.plazo = plazo;
            this.fecha = fecha;
            this.id_usuario = id_usuario;
            PIV = pIV;
            this.factura_Detalle = factura_Detalle;
            this.cliente = cliente;
            this.ordenCompra = ordenCompra;
            this.fechaOrden = fechaOrden;
            this.sincronizada = sincronizada;
            this.notaCredito = notaCredito;
        }
    }
}
