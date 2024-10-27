using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

[Authorize(Roles = "Estudiante")]
public class EstudianteController : Controller
{
    public IActionResult Dashboard()
    {
        // Página principal del estudiante
        // Mostrar los reportes relacionados al uso personal del parqueo
        return View();
    }

    public IActionResult VerEstatusVehiculos()
    {
        // Lógica para obtener y mostrar el estatus de los vehículos registrados del estudiante
        return View();
    }

    public IActionResult ReporteUsoMensual()
    {
        // Lógica para generar y mostrar el reporte de uso del parqueo del mes actual
        return View();
    }
}
