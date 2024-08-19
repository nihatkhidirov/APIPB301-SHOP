namespace APIPB301.Dtos.AuthorDtos;

public class AuthorReturnDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<BookInAuthorReturnDto> Books { get; set; }
}

public class BookInAuthorReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
}
