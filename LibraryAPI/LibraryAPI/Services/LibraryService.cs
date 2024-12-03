using LibraryAPI.Models;
using LibraryAPI.DTOs;

namespace LibraryAPI.Services;

public class LibraryService : ILibraryService
{
    private readonly List<Book> _books = new();
    private readonly List<User> _users = new();
    private readonly ExcelDataService _excelDataService;
    private int _nextUserId = 1;

    public LibraryService(IConfiguration configuration)
    {
        var excelPath = configuration["ExcelSettings:Data\\BibliotecaBaseDatos.xlsx"]
            ?? throw new ArgumentNullException("Excel file path not configured");
        _excelDataService = new ExcelDataService(excelPath);
        InitializeBooksFromExcel().Wait(); 
    }

    private async Task InitializeBooksFromExcel()
    {
        var books = await _excelDataService.LoadBooksFromExcelAsync();
        _books.AddRange(books);
    }

    public async Task<Book> AddBookAsync(CreateBookDto bookDto)
    {
        var book = new Book
        {
            ISBN = bookDto.ISBN,
            Title = bookDto.Title,
            Author = bookDto.Author,
            IsAvailable = true
        };

        if (_books.Any(b => b.ISBN == book.ISBN))
            throw new InvalidOperationException("Book with this ISBN already exists");

        _books.Add(book);
        return book;
    }

    public async Task<User> RegisterUserAsync(CreateUserDto userDto)
    {
        User user = userDto.UserType.ToLower() switch
        {
            "student" => new Student { Id = _nextUserId, Name = userDto.Name },
            "professor" => new Professor { Id = _nextUserId, Name = userDto.Name },
            _ => throw new ArgumentException("Invalid user type")
        };

        _users.Add(user);
        _nextUserId++;
        return user;
    }

    public async Task<Book> BorrowBookAsync(string isbn, int userId)
    {
        var book = await GetBookByIsbnAsync(isbn);
        var user = await GetUserByIdAsync(userId);

        if (!book.IsAvailable)
            throw new InvalidOperationException("Book is not available");

        user.BorrowBook(book);
        book.IsAvailable = false;
        return book;
    }

    public async Task<Book> ReturnBookAsync(string isbn, int userId)
    {
        var book = await GetBookByIsbnAsync(isbn);
        var user = await GetUserByIdAsync(userId);

        user.ReturnBook(book);
        book.IsAvailable = true;
        return book;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return _books;
    }

    public async Task<IEnumerable<Book>> GetUserBorrowedBooksAsync(int userId)
    {
        var user = await GetUserByIdAsync(userId);
        return user.BorrowedBooks;
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        return _books.FirstOrDefault(b => b.ISBN == isbn)
            ?? throw new KeyNotFoundException("Book not found");
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId)
            ?? throw new KeyNotFoundException("User not found");
    }
}
