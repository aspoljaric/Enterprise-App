using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Entities;
using MyApp.Core.DTO;

namespace MyApp.Core.Services
{
    public interface IStudentService
    {
        StudentDto GetById(int Id);
        IEnumerable<StudentDto> GetAll();
        int Create(StudentDto student);
        bool Update(int Id, StudentDto student);
        bool Delete(int Id);
    }
}
