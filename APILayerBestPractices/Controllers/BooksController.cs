using APILayerBestPractices.Models;
using APILayerBestPractices.Services;
using Microsoft.AspNetCore.Mvc;

namespace APILayerBestPractices.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;
        public BooksController(BookService service) => _service = service;

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => _service.GetById(id) is Book book ? Ok(book) : NotFound();

        [HttpPost]
        public IActionResult Create(Book book) => CreatedAtAction(nameof(GetById), new { id = book.Id }, _service.Create(book));

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book) => _service.Update(id, book) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _service.Delete(id) ? NoContent() : NotFound();
    }

}
