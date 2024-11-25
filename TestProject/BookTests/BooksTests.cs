using Application;
using Domain;
using Infrastructure.Database;
using Xunit;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class BooksTests
    {
        private FakeDatabase _fakeDatabase;

        [SetUp]
        public void Setup()
        {
            _fakeDatabase = new FakeDatabase();
        }

        [Test]
        public void AddNewBook_ShouldAddBook()
        {
            var newBook = new Book(6, "Test Book", "Test Description");

            var addedBook = _fakeDatabase.AddNewBook(newBook);

            Assert.IsTrue(_fakeDatabase.Books.Contains(newBook));
            Assert.AreEqual(newBook, addedBook);
        }

        [Test]
        public void DeleteBook_ShouldRemoveBook_WhenBookExists()
        {
            int bookId = 1;

            var result = _fakeDatabase.DeleteBook(bookId);

            Assert.IsTrue(result);
            Assert.IsFalse(_fakeDatabase.Books.Any(b => b.Id == bookId));
        }

        [Test]
        public void DeleteBook_ShouldReturnFalse_WhenBookDoesNotExist()
        {
            int nonExistentBookId = 999;

            var result = _fakeDatabase.DeleteBook(nonExistentBookId);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetBookById_ShouldReturnBook_WhenBookExists()
        {
            int bookId = 2;

            var book = _fakeDatabase.GetBookById(bookId);

            Assert.NotNull(book);
            Assert.AreEqual(bookId, book.Id);
        }

        [Test]
        public void GetBookById_ShouldReturnNull_WhenBookDoesNotExist()
        {
            int nonExistentBookId = 999;

            var book = _fakeDatabase.GetBookById(nonExistentBookId);

            Assert.IsNull(book);
        }

        [Test]
        public void UpdateBook_ShouldModifyBookDetails_WhenBookExists()
        {
            int bookId = 2;
            string newTitle = "Updated Title";
            string newDescription = "Updated Description";

            var updatedBook = _fakeDatabase.UpdateBook(bookId, newTitle, newDescription);

            Assert.NotNull(updatedBook);
            Assert.AreEqual(newTitle, updatedBook.Title);
            Assert.AreEqual(newDescription, updatedBook.Description);
        }

        [Test]
        public void UpdateBook_ShouldReturnNull_WhenBookDoesNotExist()
        {
            int nonExistentBookId = 999;

            var updatedBook = _fakeDatabase.UpdateBook(nonExistentBookId, "Title", "Description");

            Assert.IsNull(updatedBook);
        }
    }
}

