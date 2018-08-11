using System;
using System.Collections.Generic;
using FacElec.model;
using FacElec.helpers;
namespace FacElec.sync
{
    public static class Sincronizador
    {

        public static void SincronizarFacturas(){
            var facturas = new List<Factura>();
            facturas = ObtenerFacturasPendientes();
            if (facturas.Count > 0){
                foreach(Factura fac in facturas){
                    EnviarFacturaElectronica(fac);
                }
            }
        } 


        private static List<Factura> ObtenerFacturasPendientes(){
            return SqlHelper.GetFacturas();
        }

        private static void EnviarFacturaElectronica(Factura factura){
            RestHelper.DoSomething();
        }
    }
}
