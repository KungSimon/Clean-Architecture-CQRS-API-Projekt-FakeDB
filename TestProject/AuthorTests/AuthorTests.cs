//using Application.Authors.Commands_Authors.CreateAuthor;
//using Application.Interfaces.RepositoryInterfaces;
//using Domain;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.AuthorTests
//{
//    [TestFixture]
//    public class AuthorTests
//    {

//        private IMediator _mediator;
//        private IAuthorRepository _authorRepository;

//        [SetUp]
//        public void Setup()
//        {
//            _authorRepository = A.Fake<IAuthorRepository>();
//            var services = new ServiceCollection();
//            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAuthorCommandHandler).Assembly));
//            services.AddSingleton(_authorRepository);
//            var provider = services.BuildServiceProvider();
//            _mediator = provider.GetRequiredService<IMediator>();
//        }

//        [Test]
//        public void AddNewAuthor_ShouldAddAuthor()
//        {
//            // Arrange
//            //var database = new FakeDatabase();
//            var newAuthor = new Author(3, "Test Author", "Test Bio");

//            // Act
//            var addedAuthor = _database.AddNewAuthor(newAuthor);

//            // Assert
//            Assert.IsTrue(_database.Authors.Contains(newAuthor));
//            Assert.AreEqual(newAuthor, addedAuthor);
//        }

//        [Test]
//        public void DeleteAuthor_ShouldRemoveAuthor_WhenAuthorExists()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int authorId = 1;

//            // Act
//            var result = _database.DeleteAuthor(authorId);

//            // Assert
//            Assert.IsTrue(result);
//            Assert.IsFalse(_database.Authors.Any(a => a.Id == authorId));
//        }

//        [Test]
//        public void DeleteAuthor_ShouldReturnFalse_WhenAuthorDoesNotExist()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int nonExistentAuthorId = 999;

//            // Act
//            var result = _database.DeleteAuthor(nonExistentAuthorId);

//            // Assert
//            Assert.IsFalse(result);
//        }

//        [Test]
//        public void GetAuthorById_ShouldReturnAuthor_WhenAuthorExists()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int authorId = 1;

//            // Act
//            var author = _database.GetAuthorById(authorId);

//            // Assert
//            Assert.NotNull(author);
//            Assert.AreEqual(authorId, author.Id);
//        }

//        [Test]
//        public void GetAuthorById_ShouldReturnNull_WhenAuthorDoesNotExist()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int nonExistentAuthorId = 999;

//            // Act
//            var author = _database.GetAuthorById(nonExistentAuthorId);

//            // Assert
//            Assert.IsNull(author);
//        }

//        [Test]
//        public void UpdateAuthor_ShouldModifyAuthorDetails_WhenAuthorExists()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int authorId = 1;
//            var updatedAuthor = new Author(authorId, "Updated Name", "Updated Bio");

//            // Act
//            var author = _database.UpdateAuthor(authorId, updatedAuthor);

//            // Assert
//            Assert.NotNull(author);
//            Assert.AreEqual(updatedAuthor.Name, author.Name);
//            Assert.AreEqual(updatedAuthor.Bio, author.Bio);
//        }

//        [Test]
//        public void UpdateAuthor_ShouldReturnNull_WhenAuthorDoesNotExist()
//        {
//            // Arrange
//            var database = new FakeDatabase();
//            int nonExistentAuthorId = 999;

//            // Act
//            var updatedAuthor = _database.UpdateAuthor(nonExistentAuthorId, new Author(999, "Name", "Bio"));

//            // Assert
//            Assert.IsNull(updatedAuthor);
//        }
//    }
//}
