namespace APIPB301.Data.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
}
