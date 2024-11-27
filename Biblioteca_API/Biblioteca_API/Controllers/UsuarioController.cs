using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return Ok(_usuarioService.ObtenerUsuarios());
        }

        [HttpPost]
        public ActionResult<Usuario> RegistrarUsuario(Usuario usuario)
        {
            _usuarioService.RegistrarUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.IdUsuario }, usuario);
        }
    }
}
