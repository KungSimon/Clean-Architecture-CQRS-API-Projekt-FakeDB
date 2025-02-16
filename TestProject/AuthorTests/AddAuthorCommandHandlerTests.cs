using Application.Authors.Commands_Authors.CreateAuthor;
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

namespace TestProject.AuthorTestsAuthor
{
    [TestFixture]
    public class AddAuthorCommandHandlerTests
    {
        private FakeDatabase _fakeDatabase; 
        private FakeAuthorRepository _fakeAuthorRepository;
        private ILogger<CreateAuthorCommandHandler> _logger;

        [SetUp]
        public void Setup()
        {
            _fakeDatabase = new FakeDatabase();
            _fakeAuthorRepository = new FakeAuthorRepository(_fakeDatabase);
            _logger = A.Fake<ILogger<CreateAuthorCommandHandler>>();
        }

        [Test]
        public async Task Handle_ShouldAddAuthorToDatabase()
        {

            var handler = new CreateAuthorCommandHandler(_fakeAuthorRepository, _logger);
            var author = new Author { Id = Guid.NewGuid(), Name = "Test Author" };
            var command = new CreateAuthorCommand(author);

            var result = await handler.Handle(command, default);

            Assert.That(result.IsSuccessful, Is.True); 
            Assert.That(result.Message, Is.EqualTo("Author successfully added.")); 
            Assert.That(result.Data.Name, Is.EqualTo("Test Author")); 
            Assert.That(_fakeDatabase.Authors.Count, Is.EqualTo(4));
        }


        [Test]
        public async Task Handle_ShouldReturnFailure_WhenDuplicateAuthorAdded()
        {

            var handler = new CreateAuthorCommandHandler(_fakeAuthorRepository, _logger);
            var existingAuthor = new Author { Id = Guid.NewGuid(), Name = "Duplicate Author" };
            _fakeDatabase.Authors.Add(existingAuthor);

            var command = new CreateAuthorCommand(existingAuthor);


            var result = await handler.Handle(command, default);

            Assert.That(result.IsSuccessful, Is.False);
            Assert.That(result.Message, Is.EqualTo("An author with this name already exists."));
            Assert.That(result.Data, Is.Null);
            Assert.That(_fakeDatabase.Authors.Count, Is.EqualTo(4));
        }

    }
}
