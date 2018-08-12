namespace FacElec.model
{
    public class cliente
    {
        public int id_Cliente;
        public string identificacion;
        public int tipoIdentificacion;
        public string nombre_encargado;
        public string telefono;
        public string nombre_sociedad;
        public string email;
        public string direccion;
        public int provincia;
        public int canton;
        public int distrito;
        public string idautomercado;

        public cliente(int id_Cliente, string identificacion, int tipoIdentificacion, string nombre_encargado, string telefono, string nombreSociedad, string email, string direccion,
                       int provincia, int canton, int distrito, string idautomercado)
        {
            this.id_Cliente = id_Cliente;
            this.identificacion = identificacion;
            if (tipoIdentificacion == 5) tipoIdentificacion = 10;
            this.tipoIdentificacion = tipoIdentificacion;
            this.nombre_encargado = nombre_encargado;
            this.telefono = telefono;
            this.nombre_sociedad = nombreSociedad;
            this.email = email;
            this.direccion = direccion;
            this.provincia = provincia;
            this.canton = canton;
            this.distrito = distrito;
            this.idautomercado = idautomercado;
        }
    }
}