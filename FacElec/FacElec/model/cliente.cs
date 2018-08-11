namespace FacElec.model
{
    public class cliente
    {
        private int id_Cliente;
        private string nombre_encargado;
        private string telefono;
        private string nombre;
        private string email;
        private string direccion;

        public cliente(int id_Cliente, string nombre_encargado, string telefono, string nombre, string email, string direccion)
        {
            this.id_Cliente = id_Cliente;
            this.nombre_encargado = nombre_encargado;
            this.telefono = telefono;
            this.nombre = nombre;
            this.email = email;
            this.direccion = direccion;
        }
    }
}