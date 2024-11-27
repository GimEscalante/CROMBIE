using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly LibroService _libroService;
        private readonly UsuarioService _usuarioService;

        public BibliotecaController(LibroService libroService, UsuarioService usuarioService)
        {
            _libroService = libroService;
            _usuarioService = usuarioService;
        }

        // Obtener el estado de todos los libros (disponibles o prestados)
        [HttpGet("estado")]
        public ActionResult<List<Libro>> GetEstadoBiblioteca()
        {
            var libros = _libroService.ObtenerLibros();
            return Ok(libros);
        }

        // Ver todos los libros prestados por un usuario específico
        [HttpGet("usuario/{idUsuario}/prestados")]
        public ActionResult<List<Libro>> GetLibrosPrestadosDeUsuario(string idUsuario)
        {
            var usuario = _usuarioService.ObtenerUsuarioPorId(idUsuario);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok(usuario.LibrosPrestados);
        }

        // Ver todos los libros prestados (por cualquier usuario)
        [HttpGet("prestados")]
        public ActionResult<List<Libro>> GetLibrosPrestados()
        {
            var librosPrestados = _libroService.ObtenerLibros().Where(l => !l.Disponible).ToList();
            return Ok(librosPrestados);
        }

        // Prestar un libro a un usuario
        [HttpPost("prestar")]
        public ActionResult PrestarLibro(string isbn, string idUsuario)
        {
            var libro = _libroService.ObtenerLibroPorISBN(isbn);
            var usuario = _usuarioService.ObtenerUsuarioPorId(idUsuario);

            if (libro == null)
            {
                return NotFound("Libro no encontrado");
            }

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Se puede delegar la lógica de préstamo al servicio correspondiente
            usuario.PrestarMaterial(libro);
            return Ok($"Libro '{libro.Titulo}' prestado a {usuario.Nombre}");
        }

        // Devolver un libro
        [HttpPost("devolver")]
        public ActionResult DevolverLibro(string isbn, string idUsuario)
        {
            var libro = _libroService.ObtenerLibroPorISBN(isbn);
            var usuario = _usuarioService.ObtenerUsuarioPorId(idUsuario);

            if (libro == null)
            {
                return NotFound("Libro no encontrado");
            }

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            usuario.DevolverMaterial(libro);
            return Ok($"Libro '{libro.Titulo}' devuelto por {usuario.Nombre}");
        }

        // Ver un resumen general de la biblioteca
        [HttpGet("resumen")]
        public ActionResult<string> GetResumenBiblioteca()
        {
            var totalLibros = _libroService.ObtenerLibros().Count;
            var totalPrestados = _libroService.ObtenerLibros().Count(l => !l.Disponible);
            var totalUsuarios = _usuarioService.ObtenerUsuarios().Count;

            var resumen = $"Total de libros: {totalLibros}, Libros prestados: {totalPrestados}, Usuarios registrados: {totalUsuarios}";
            return Ok(resumen);
        }
    }
}
