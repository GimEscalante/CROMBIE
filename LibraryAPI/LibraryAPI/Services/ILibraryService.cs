using LibraryAPI.Models;
using LibraryAPI.DTOs;

namespace LibraryAPI.Services;

public interface ILibraryService
{
    Task<Book> AddBookAsync(CreateBookDto bookDto);
    Task<User> RegisterUserAsync(CreateUserDto userDto);
    Task<Book> BorrowBookAsync(string isbn, int userId);
    Task<Book> ReturnBookAsync(string isbn, int userId);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<IEnumerable<Book>> GetUserBorrowedBooksAsync(int userId);
    Task<Book> GetBookByIsbnAsync(string isbn);
    Task<User> GetUserByIdAsync(int userId);
}
