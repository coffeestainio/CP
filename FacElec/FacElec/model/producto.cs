namespace FacElec.model
{
    public class producto
    {
        public string id_producto;
        public string nombre;
        public decimal costo;

        public producto(string id_producto, string nombre, string costo)
        {
            this.id_producto = id_producto;
            this.nombre = nombre;
            this.costo = decimal.Parse(costo);
        }
    }
}