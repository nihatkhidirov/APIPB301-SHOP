using FluentValidation;

namespace APIPB301.Dtos.AuthorDtos;

public class AuthorCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
{
    public AuthorCreateDtoValidator()
    {
        RuleFor(a => a.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(a => a.LastName).NotEmpty().MaximumLength(50);
    }
}