using Microsoft.AspNetCore.Mvc;
using BibliotecaAPI.Models;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;

        public LibroController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public ActionResult<List<Libro>> GetLibros()
        {
            return Ok(_libroService.ObtenerLibros());
        }

        [HttpGet("{isbn}")]
        public ActionResult<Libro> GetLibro(string isbn)
        {
            var libro = _libroService.ObtenerLibroPorISBN(isbn);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public ActionResult<Libro> AgregarLibro(Libro libro)
        {
            _libroService.AgregarLibro(libro);
            return CreatedAtAction(nameof(GetLibro), new { isbn = libro.ISBN }, libro);
        }
    }
}
