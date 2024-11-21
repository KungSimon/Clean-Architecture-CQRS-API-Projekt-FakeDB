using Application;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class AuthorUnitTests
    {
        private FakeDatabase _fakeDatabase;
        //private BookMethods _authorMethods;

        [SetUp]
        public void Setup()
        {
            _fakeDatabase = new FakeDatabase();
            //_authorMethods = new BookMethods();
        }

        //[Test]
        //public void AddNewAuthor_ShouldAddAuthorToDatabase()
        //{
            //var newAuthor = _authorMethods.AddNewAuthor(3, "New Author", "Bio3");

            //Assert.That(newAuthor, Is.Not.Null);
            //Assert.That(_fakeDatabase.Authors, Has.Exactly(3).Items);
        //}
    }
}
