using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class AuthorDto
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public required string Name { get; set; }


        [Required(ErrorMessage = "Bio is required.")]
        [StringLength(100, ErrorMessage = "Bio is too long.")]
        public required string Bio { get; set; }
    }
}
