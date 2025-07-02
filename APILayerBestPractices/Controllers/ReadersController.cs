using APILayerBestPractices.Models;
using APILayerBestPractices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayerBestPractices.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReadersController : ControllerBase
    {
        private readonly ReaderService _service;
        public ReadersController(ReaderService service) => _service = service;

        [HttpPost("register")]
        public IActionResult Register(Reader reader) => CreatedAtAction(nameof(GetById), new { id = reader.Id }, _service.Create(reader));

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => _service.GetById(id) is Reader reader ? Ok(reader) : NotFound();

        [HttpPost("{readerId}/borrow")]
        public IActionResult BorrowBook(int readerId, [FromQuery] int bookId) => _service.BorrowBook(readerId, bookId) ? Ok() : BadRequest();

        [HttpPatch("{readerId}/return")]
        public IActionResult ReturnBook(int readerId, [FromQuery] int bookId) => _service.ReturnBook(readerId, bookId) ? Ok() : BadRequest();
    }
}
