using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public Author(Guid id, string name, string bio)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bio = bio;
        }
    }
}
