using Microsoft.AspNetCore.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public class OficialController : Controller
{
    public IActionResult Dashboard()
    {
        // Mostrar la interfaz principal del oficial de seguridad
        return View();
    }

    [HttpPost]
    public IActionResult IngresarVehiculo(string placa)
    {
        // Lógica para ingresar un vehículo al parqueo
        return View("IngresoExitoso");
    }

    [HttpPost]
    public IActionResult EgresarVehiculo(string placa)
    {
        // Lógica para registrar la salida de un vehículo
        return View("EgresoExitoso");
    }
}

