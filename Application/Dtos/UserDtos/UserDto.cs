using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
    public class UserDto
    {
        public required string UserName { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
