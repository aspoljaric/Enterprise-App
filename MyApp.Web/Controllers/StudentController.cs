using AutoMapper;
using MyApp.Core.DTO;
using MyApp.Core.Entities;
using MyApp.Core.Services;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.Web.Controllers
{
    public class StudentController : ApiController
    {


        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }


        // GET api/product
        public HttpResponseMessage Get()
        {
            var students = _studentService.GetAll();

            if (students != null)
            {
                var studentEntities = students as List<StudentDto> ?? students.ToList();
                if (studentEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, studentEntities);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Students not found");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var student = _studentService.GetById(id);
            if (student != null)
                return Request.CreateResponse(HttpStatusCode.OK, student);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No student found for this id");
        }

        // POST api/product
        public int Post([FromBody] StudentDto student)
        {
            return _studentService.Create(student);
        }

        // PUT api/product/5
        public bool Put(int id, [FromBody]StudentDto student)
        {
            if (id > 0)
            {
                return _studentService.Update(id, student);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _studentService.Delete(id);
            return false;
        }


    }
}
