using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; }
    }
}
