using AutoMapper;
using APIPB301.Data.Entities;
using APIPB301.Dtos.AuthorDtos;
using APIPB301.Dtos.BookDtos;

namespace APIPB301.Profiles;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Author, AuthorInBookReturnDto>();
        CreateMap<Book, BookReturnDto>()
        .ForMember(b => b.Authors, map => map.MapFrom(b => b.BookAuthors.Select(ba => ba.Author)));

        CreateMap<Book, BookInAuthorReturnDto>();
        CreateMap<Author, AuthorReturnDto>()
        .ForMember(a => a.Books, map => map.MapFrom(b => b.BookAuthors.Select(ba => ba.Book)));

        CreateMap<BookCreateDto, Book>();
        CreateMap<AuthorCreateDto, Author>();
    }
}
