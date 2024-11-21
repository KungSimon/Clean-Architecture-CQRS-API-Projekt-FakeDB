using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public Author(int id, string name, string bio)
        {
            Id = id;
            Name = name;
            Bio = bio;
        }
    }
}
