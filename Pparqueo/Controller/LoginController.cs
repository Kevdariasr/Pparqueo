using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin.Auth;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;



public class AuthController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        // Devuelve la vista de Login
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        try
        {
            // Autentica al usuario con Firebase Authentication
            var userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
            // En este punto, FirebaseAuth no verifica la contraseña, necesitamos hacerlo manualmente
            // Vamos a simular la autenticación usando Firebase SDK y el token de ID (en un caso real, usarías Firebase SDK de cliente)
            // Aquí debes validar la contraseña con Firebase (esto generalmente se hace en el cliente con Firebase Authentication)
            // Por simplicidad, aquí solo verificamos si el usuario existe.

            // Si la autenticación es exitosa, creamos las claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userRecord.Email),
                new Claim(ClaimTypes.Email, userRecord.Email),
            };

            // Agregamos el rol basado en las Custom Claims en Firebase
            if (userRecord.CustomClaims.TryGetValue("role", out object role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                // Configuraciones adicionales de autenticación (si es necesario)
            };

            // Inicia la sesión del usuario
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            // Redirige según el rol del usuario
            switch (role.ToString())
            {
                case "Administrador":
                    return RedirectToAction("Index", "Admin");
                case "Oficial":
                    return RedirectToAction("Dashboard", "Oficial");
                case "Administrativo":
                    return RedirectToAction("Dashboard", "AdminPersonal");
                case "Estudiante":
                    return RedirectToAction("Dashboard", "Estudiante");
                default:
                    return RedirectToAction("Login");
            }
        }
        catch (FirebaseAuthException ex)
        {
            ModelState.AddModelError(string.Empty, "Correo o clave incorrecta.");
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        // Cierra la sesión del usuario
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}

