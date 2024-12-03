namespace LibraryAPI.DTOs;

public class CreateUserDto
{
    public string Name { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty; // "Student" or "Professor"
}
