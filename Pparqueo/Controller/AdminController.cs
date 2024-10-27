using Microsoft.AspNetCore.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;



public class AdminController : Controller
{
    public IActionResult Index()
    {
        // Página principal del administrador
        return View();
    }

    public IActionResult RegistrarUsuario()
    {
        // Lógica para registrar un nuevo usuario
        return View();
    }

    public IActionResult VerReportes()
    {
        // Mostrar reportes del parqueo
        return View();
    }
}

