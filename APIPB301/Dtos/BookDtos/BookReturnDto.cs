namespace APIPB301.Dtos.BookDtos;

public class BookReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public List<AuthorInBookReturnDto> Authors { get; set; }
}

public class AuthorInBookReturnDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}