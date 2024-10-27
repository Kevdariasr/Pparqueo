namespace Pparqueo.Parametros
{
    public class Vehiculo
    {
        public string marca { get; set; }
        public string color { get; set; }
        public string NumeroPlaca { get; set; }
        public string tipo { get; set; } // Vehículo/Moto
        public string dueño { get; set; } // Referencia al ID del usuario propietario
        public bool UsaEspacioLey7600 { get; set; }
    }
}
