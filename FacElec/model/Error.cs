using System;
namespace FacElec.model
{
    public class Error
    {
        public string NumFacturaInterno;
        public string ClaveNumerica;
        public string NumConsecutivoCompr;
        public string CodigoError;
        public string DescripcionError;

        public Error() { }

        public Error(string numFacturaInterno, string claveNumerica, string numConsecutivoCompr, string codigoError, string descripcionError)
        {
            NumFacturaInterno = numFacturaInterno;
            ClaveNumerica = claveNumerica;
            NumConsecutivoCompr = numConsecutivoCompr;
            CodigoError = codigoError;
            DescripcionError = descripcionError;
 
        }
    }
}
