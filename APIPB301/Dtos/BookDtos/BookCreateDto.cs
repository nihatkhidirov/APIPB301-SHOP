using FluentValidation;
using APIPB301.Data.Data;

namespace ShopApp.Dtos.BookDtos;

public class BookCreateDto
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public List<int> AuthorIds { get; set; }
}


public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
{
    private readonly IServiceProvider _serviceProvider;

    public BookCreateDtoValidator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        RuleFor(b => b.Name).NotEmpty().MaximumLength(50);
        RuleFor(b => b.PageCount).NotEmpty().InclusiveBetween(10, 1000);
        RuleFor(b => b.AuthorIds).NotEmpty();
        RuleForEach(b => b.AuthorIds).Custom((id, context) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            if (!dbContext.Authors.Any(a => a.Id == id))
            {
                context.AddFailure("Invalid author id");
            }
        });
    }
}
