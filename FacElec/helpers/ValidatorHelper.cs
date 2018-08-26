using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FacElec.model;

namespace FacElec.helpers
{
    public static class ValidatorHelper
    {
        public static Error validarFacturas(Factura factura)
        {

            var cliente = factura.cliente[0];

            //validate email
            try
            {
                MailAddress mail = new MailAddress(cliente.email);
            }
            catch (FormatException)
            {
                return new Error(factura.id_factura, "Error:001", "Formato del correo incorrecto");
            }

            Regex regex = new Regex(@"^[0-9]{8}$");

            //validate phone
            if (regex.Match(cliente.telefono.Trim().Replace("-", "")) == Match.Empty)
            {
                return (new Error(factura.id_factura, "Error:002", "Formato del numero incorrecto"));
            }

            regex = new Regex(@"^[0-9]{17}$");
            //validate identificacion
            if (cliente.tipoIdentificacion == 3 &&
                regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
            {
                return (new Error(factura.id_factura, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
            }

            regex = new Regex(@"^[0-9]{10}$");
            //validate identificacion
            if (cliente.tipoIdentificacion == 2 &&
                regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
            {
                return (new Error(factura.id_factura, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
            }

            regex = new Regex(@"^[0-9]{9}$");
            //validate identificacion
            if (cliente.tipoIdentificacion == 1 &&
                regex.Match(cliente.identificacion.Trim().Replace("-", "")) == Match.Empty)
            {
                return (new Error(factura.id_factura, "Error:003", "El formato de la cedula no corresponde al tipo de identificacion"));
            }


            return null;
        }
    }
}
