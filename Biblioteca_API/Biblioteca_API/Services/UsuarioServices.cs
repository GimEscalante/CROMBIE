using Biblioteca_API.Models;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Services
{
    public class UsuarioService
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public List<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        public Usuario ObtenerUsuarioPorId(string idUsuario)
        {
            return _usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }
    }
}
