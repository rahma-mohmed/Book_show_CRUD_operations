using TaskIT.Models;

namespace TaskIT.Services
{
    public class BookRepository
    {
        ProgContext context = new ProgContext();

        public List<Book> getAll()
        {
            return context.Books.ToList();
        }
        public Book getById(int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public int Create(Book book)
        {
            context.Books.Add(book);
            int raw = context.SaveChanges();
            return raw;
        }

        public int Update(int id , Book book)
        {
            Book oldBook = context.Books.FirstOrDefault(x => x.Id == id);
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.Author = book.Author;
            oldBook.BookUrl = book.BookUrl;
            oldBook.Image = book.Image;
            int raw = context.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            Book oldBook = context.Books.FirstOrDefault(x => x.Id == id);
            context.Books.Remove(oldBook);
            int raw = context.SaveChanges();
            return raw;
        }
    }
}
