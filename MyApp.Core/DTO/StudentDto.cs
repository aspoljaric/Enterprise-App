using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.DTO
{
    public class StudentDto : BaseDto
    {
        public StudentDto()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string MobilePhone { get; set; }
    }
}
