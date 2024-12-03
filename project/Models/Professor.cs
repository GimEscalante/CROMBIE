namespace LibraryAPI.Models;

public class Professor : User
{
    public override int MaxBooksAllowed => 5;
    
    public override void BorrowBook(Book book)
    {
        base.BorrowBook(book);
        // Additional professor-specific logic can be added here
        // For example, extending the borrowing period
    }
}