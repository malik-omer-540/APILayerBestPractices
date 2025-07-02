using APILayerBestPractices.Models;
using System.Xml.Linq;

namespace APILayerBestPractices.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "The Hobbit" },
        new Book { Id = 2, Title = "1984" },
        new Book { Id = 3, Title = "The Alchemist" }
    };

        public List<Book> GetAll() => _books;
        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
        public Book Create(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return book;
        }
        public bool Update(int id, Book updated)
        {
            var book = GetById(id);
            if (book == null) return false;
            book.Title = updated.Title;
            book.IsAvailable = updated.IsAvailable;
            return true;
        }
        public bool Delete(int id)
        {
            var book = GetById(id);
            if (book == null) return false;
            _books.Remove(book);
            return true;
        }
        public void SetAvailability(int bookId, bool available)
        {
            var book = GetById(bookId);
            if (book != null) book.IsAvailable = available;
        }
    }

}
