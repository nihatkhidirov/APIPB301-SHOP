using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPB301.Data.Data;
using APIPB301.Data.Entities;
using APIPB301.Dtos.BookDtos;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Book> books = await _context.Books.Include(b => b.BookAuthors).ThenInclude(ba => ba.Author).ToListAsync();
            return Ok(_mapper.Map<List<BookReturnDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Book? book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(_mapper.Map<BookReturnDto>(book));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(BookCreateDto bookCreateDto)
        {
            Book book = _mapper.Map<Book>(bookCreateDto);
            List<BookAuthor> bookAuthors = new();
            foreach (int authorId in bookCreateDto.AuthorIds)
            {
                bookAuthors.Add(new()
                {
                    BookId = book.Id,
                    AuthorId = authorId
                });
            }
            book.BookAuthors = bookAuthors;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(BookCreateDto bookCreateDto, int id)
        {
            Book? book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return NotFound();
            _mapper.Map(book, bookCreateDto);
            List<BookAuthor> bookAuthors = new();
            foreach (int authorId in bookCreateDto.AuthorIds)
            {
                bookAuthors.Add(new()
                {
                    BookId = book.Id,
                    AuthorId = authorId
                });
            }
            book.BookAuthors = bookAuthors;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book? book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
