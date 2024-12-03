using System.Text.Json.Serialization;

namespace LibraryAPI.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Book> BorrowedBooks { get; set; } = new();
    
    [JsonIgnore]
    public abstract int MaxBooksAllowed { get; }

    public virtual bool CanBorrowBook()
    {
        return BorrowedBooks.Count < MaxBooksAllowed;
    }

    public virtual void BorrowBook(Book book)
    {
        if (!CanBorrowBook())
            throw new InvalidOperationException($"User has reached maximum allowed books ({MaxBooksAllowed})");
            
        BorrowedBooks.Add(book);
    }

    public virtual void ReturnBook(Book book)
    {
        if (!BorrowedBooks.Contains(book))
            throw new InvalidOperationException("User does not have this book borrowed");
            
        BorrowedBooks.Remove(book);
    }
}