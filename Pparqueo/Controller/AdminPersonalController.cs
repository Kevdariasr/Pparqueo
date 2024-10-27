using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

[Authorize(Roles = "Administrativo")]
public class AdminPersonalController : Controller
{
    public IActionResult Dashboard()
    {
        // Página principal del personal administrativo
        // Mostrar los reportes relacionados al uso personal del parqueo
        return View();
    }

    public IActionResult VerEstatusVehiculos()
    {
        // Lógica para obtener y mostrar el estatus de los vehículos registrados del personal administrativo
        return View();

    }

    public IActionResult ReporteUsoMensual()
    {
        // Lógica para generar y mostrar el reporte de uso del parqueo del mes actual
        return View();
    }
}