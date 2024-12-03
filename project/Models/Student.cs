namespace LibraryAPI.Models;

public class Student : User
{
    public override int MaxBooksAllowed => 3;
}