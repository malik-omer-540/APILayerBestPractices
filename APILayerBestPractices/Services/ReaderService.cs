using APILayerBestPractices.Models;

namespace APILayerBestPractices.Services
{
    public class ReaderService
    {
        private readonly List<Reader> _readers = new();
        private readonly BookService _bookService;

        public ReaderService(BookService bookService) => _bookService = bookService;

        public List<Reader> GetAll() => _readers;
        public Reader? GetById(int id) => _readers.FirstOrDefault(r => r.Id == id);
        public Reader Create(Reader reader)
        {
            reader.Id = _readers.Count > 0 ? _readers.Max(r => r.Id) + 1 : 1;
            _readers.Add(reader);
            return reader;
        }
        public bool BorrowBook(int readerId, int bookId)
        {
            var reader = GetById(readerId);
            var book = _bookService.GetById(bookId);
            if (reader == null || book == null || !book.IsAvailable) return false;

            reader.BorrowedBookIds.Add(bookId);
            _bookService.SetAvailability(bookId, false);
            return true;
        }
        public bool ReturnBook(int readerId, int bookId)
        {
            var reader = GetById(readerId);
            if (reader == null || !reader.BorrowedBookIds.Contains(bookId)) return false;

            reader.BorrowedBookIds.Remove(bookId);
            _bookService.SetAvailability(bookId, true);
            return true;
        }
    }
}
