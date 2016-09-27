using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Entities;
using MyApp.Core.Data;
using MyApp.Core.Services;
using MyApp.Infrastructure;
using AutoMapper;
using System.Transactions;
using MyApp.Core.DTO;

namespace MyApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public StudentDto GetById(int Id)
        {
            var student = _unitOfWork.StudentRepository.GetByID(Id);

            if (student != null)
            {
                Mapper.CreateMap<Student, StudentDto>();
                var studentModel = Mapper.Map<Student, StudentDto>(student);
                return studentModel;
            }
            return null;
        }

        public IEnumerable<StudentDto> GetAll()
        {
            var student = _unitOfWork.StudentRepository.GetAll().ToList();

            if (student.Any())
            {
                Mapper.CreateMap<Student, StudentDto>();
                var studentModel = Mapper.Map<List<Student>, List<StudentDto>>(student);
                return studentModel;
            }
            return null;
        }

        public int Create(StudentDto student)
        {
            using (var scope = new TransactionScope())
            {
                Mapper.CreateMap<StudentDto, Student>();
                var s = Mapper.Map<StudentDto, Student>(student);
                _unitOfWork.StudentRepository.Insert(s);
                _unitOfWork.Save();
                scope.Complete();
                return student.Id;
            }
        }

        public bool Update(int Id, StudentDto student)
        {
            var success = false;
            if (student != null)
            {
                using (var scope = new TransactionScope())
                {
                    var s = _unitOfWork.StudentRepository.GetByID(Id);
                    if (s != null)
                    {
                        Mapper.CreateMap<StudentDto, Student>();
                        Mapper.Map(student, s);
                        _unitOfWork.StudentRepository.Update(s);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool Delete(int Id)
        {
            var success = false;
            if (Id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var s = _unitOfWork.StudentRepository.GetByID(Id);
                    if (s != null)
                    {

                        _unitOfWork.StudentRepository.Delete(s);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
