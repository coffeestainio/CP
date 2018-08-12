using System;
namespace FacElec.model
{
    public class GTIResponse
    {
        public string NumDocumento;
        public string IdCarga;
        public string NumFacturaInterno;
        public string ClaveNumerica;
        public string NumConsecutivoCompr;
        public string CodigoError;
        public string DescripcionError;
        public int Sincronizada;
        public bool NotaCredito;

        public GTIResponse() { }
    }
}
