using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Services;
using LibraryAPI.DTOs;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly ILibraryService _libraryService;

    public LibraryController(ILibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    [HttpPost("books")]
    public async Task<IActionResult> AddBook(CreateBookDto bookDto)
    {
        var book = await _libraryService.AddBookAsync(bookDto);
        return CreatedAtAction(nameof(GetBook), new { isbn = book.ISBN }, book);
    }

    [HttpPost("users")]
    public async Task<IActionResult> RegisterUser(CreateUserDto userDto)
    {
        var user = await _libraryService.RegisterUserAsync(userDto);
        return CreatedAtAction(nameof(GetUserBooks), new { userId = user.Id }, user);
    }

    [HttpPost("books/{isbn}/borrow/{userId}")]
    public async Task<IActionResult> BorrowBook(string isbn, int userId)
    {
        var book = await _libraryService.BorrowBookAsync(isbn, userId);
        return Ok(book);
    }

    [HttpPost("books/{isbn}/return/{userId}")]
    public async Task<IActionResult> ReturnBook(string isbn, int userId)
    {
        var book = await _libraryService.ReturnBookAsync(isbn, userId);
        return Ok(book);
    }

    [HttpGet("books")]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _libraryService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("books/{isbn}")]
    public async Task<IActionResult> GetBook(string isbn)
    {
        var book = await _libraryService.GetBookByIsbnAsync(isbn);
        return Ok(book);
    }

    [HttpGet("users/{userId}/books")]
    public async Task<IActionResult> GetUserBooks(int userId)
    {
        var books = await _libraryService.GetUserBorrowedBooksAsync(userId);
        return Ok(books);
    }
}