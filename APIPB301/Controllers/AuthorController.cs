using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPB301.Data.Data;
using APIPB301.Data.Entities;
using APIPB301.Dtos.AuthorDtos;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthorController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Author> authors = await _context.Authors.Include(a => a.BookAuthors).ThenInclude(ba => ba.Book).ToListAsync();
            return Ok(_mapper.Map<List<AuthorReturnDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Author? author = await _context.Authors.Include(a => a.BookAuthors).ThenInclude(ba => ba.Book).FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return NotFound();
            return Ok(_mapper.Map<AuthorReturnDto>(author));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(AuthorCreateDto authorCreateDto)
        {
            Author author = _mapper.Map<Author>(authorCreateDto);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(AuthorCreateDto authorCreateDto, int id)
        {
            Author? author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return NotFound();
            _mapper.Map(authorCreateDto, author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Author? author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return NotFound();
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
