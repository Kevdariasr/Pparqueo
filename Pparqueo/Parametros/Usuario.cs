namespace Pparqueo.Parametros
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string identificacion { get; set; }
        public string numeroCarne { get; set; }
        public string rol { get; set; }

        public string cambioClaveObligatorio { get; set; }
        public string claveDefault { get; set; }
        public string vehiculo { get; set; }
    }
}
