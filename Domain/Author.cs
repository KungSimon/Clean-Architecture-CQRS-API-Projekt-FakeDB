using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public Author() { }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
           
        }
    }
}
