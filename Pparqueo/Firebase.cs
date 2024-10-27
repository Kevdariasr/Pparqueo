using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pparqueo.Parametros;
using System.IO;
using System.Net;

public class FirebaseService
{
    private readonly IFirebaseClient _firebaseClient;

    public FirebaseService()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "46eb999a859d406079231519cb5f40ae19c10ec4", // Clave de autenticación de tu base de datos.
            BasePath = "https://accounts.google.com/o/oauth2/auth" // URL de tu base de datos.
        };

        _firebaseClient = new FireSharp.FirebaseClient(config);

        if (_firebaseClient == null)
        {
            throw new System.Exception("No se pudo conectar a la base de datos de Firebase.");
        }
    }

    public async Task AgregarUsuario(Usuario usuario)
    {
        SetResponse response = await _firebaseClient.SetAsync("Usuarios/" + usuario.identificacion, usuario);
    }

    public async Task<Usuario> ObtenerUsuarioPorId(string id)
    {
        FirebaseResponse response = await _firebaseClient.GetAsync("Usuarios/" + id);
        return response.ResultAs<Usuario>();
    }

    public async Task<List<Usuario>> ObtenerTodosLosUsuarios()
    {
        FirebaseResponse response = await _firebaseClient.GetAsync("Usuarios");
        Dictionary<string, Usuario> usuarios = response.ResultAs<Dictionary<string, Usuario>>();

        return new List<Usuario>(usuarios.Values);
    }
}

