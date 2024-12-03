using System.Data;
using ExcelDataReader;
using LibraryAPI.Models;
using System.Text;

namespace LibraryAPI.Services;

public class ExcelDataService
{
    private readonly string _excelFilePath;

    public ExcelDataService(string excelFilePath)
    {
        _excelFilePath = excelFilePath;
        // Required for Excel encoding in .NET Core
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    }

    public async Task<List<Book>> LoadBooksFromExcelAsync()
    {
        var books = new List<Book>();

        using var stream = File.Open(_excelFilePath, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            {
                UseHeaderRow = true
            }
        });

        var dataTable = result.Tables[3]; // Assuming books are in the first sheet

        foreach (DataRow row in dataTable.Rows)
        {
            books.Add(new Book
            {
                ISBN = row["IdLibro"].ToString() ?? "",
                Title = row["Titulo"].ToString() ?? "",
                Author = row["Autor"].ToString() ?? "",
                IsAvailable = true
            });
        }

        return books;
    }

    public async Task SaveBooksToExcelAsync(IEnumerable<Book> books)
    {
        // Implementation for saving books back to Excel if needed
        // This would require a different library like EPPlus or ClosedXML
        // as ExcelDataReader is read-only
        throw new NotImplementedException("Saving to Excel is not implemented yet");
    }
}
