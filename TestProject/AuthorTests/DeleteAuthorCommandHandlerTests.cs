using Application.Authors.Commands_Authors.CreateAuthor;
using Application.Authors.Commands_Authors.DeleteAuthor;
using Castle.Core.Logging;
using Domain;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.AuthorTests
{
    [TestFixture]
    public class DeleteAuthorCommandHandlerTests
    {
        private FakeDatabase _fakeDatabase;
        private FakeAuthorRepository _fakeRepository;
        private ILogger<DeleteAuthorCommandHandler> _logger;

        [SetUp]
        public void Setup()
        {
            _fakeDatabase = new FakeDatabase();
            _fakeRepository = new FakeAuthorRepository(_fakeDatabase);
            _logger = A.Fake<ILogger<DeleteAuthorCommandHandler>>();
        }

        [Test]
        public async Task Handle_ShouldDeleteAuthorFromDatabase()
        {
            var handler = new DeleteAuthorCommandHandler(_fakeRepository, _logger);
            var author = new Author { Id = Guid.NewGuid(), Name = "Test Author" };
            _fakeDatabase.Authors.Add(author);

            var command = new DeleteAuthorCommand(author.Id);

            var result = await handler.Handle(command, default);

            Assert.That(result.IsSuccessful, Is.True);
            Assert.That(result.Message, Is.EqualTo("Author successfully deleted."));
            Assert.That(result.Data.Count, Is.EqualTo(3));
            Assert.That(!result.Data.Any(a => a.Id == author.Id));
        }

        [Test]
        public async Task Handle_ShouldReturnFailure_WhenAuthorToDeleteDoesNotExist()
        {

            var handler = new DeleteAuthorCommandHandler(_fakeRepository, _logger);
            var command = new DeleteAuthorCommand(Guid.NewGuid());

            var result = await handler.Handle(command, default);


            Assert.That(result.IsSuccessful, Is.False);
            Assert.That(result.Message, Is.EqualTo("Author not found."));
            Assert.That(result.Data, Is.Null);
        }
    }
}
