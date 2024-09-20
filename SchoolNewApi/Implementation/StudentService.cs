using SchoolNewApi.DTOs;
using SchoolNewApi.Entities;
using SchoolNewApi.Interface;
using SchoolNewApi.Response;

namespace SchoolNewApi.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public BaseResponse CreateStudent(CreateStudentRequestModel model)
        {
            var getStudentEmail = _studentRepository.Get(x => x.Email == model.Email);
            if (getStudentEmail == null) {
                Student student = new Student
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                };

                var createStudent = _studentRepository.Create(student);
                return new BaseResponse
                {
                    Message = "Student sucessfully created",
                    Status = true
                };

            }
            return new BaseResponse
            {
                Message = "Email already exist",
                Status = false
            };
          
        }

        public BaseResponse DeleteStudent(int id)
        {
           var getStudent = _studentRepository.Get(x => x.Id == id);
            if (getStudent == null) {
                return new BaseResponse
                {
                    Message = "student not  found",
                    Status = false
                };
            }
            _studentRepository.Delete(getStudent);
            return new BaseResponse
            {
                Message = "Student sucessfuly deleted",
                Status = true
            };
        }

        public StudentModel GetStudent(int id)
        {
            var getStudent = _studentRepository.Get(x => x.Id == id);
            if (getStudent != null)
            {
                var student = new StudentDetailsModel
                {
                    Id = getStudent.Id,
                    FirstName = getStudent.FirstName,
                    LastName = getStudent.LastName,
                    Email = getStudent.Email,
                    Address = getStudent.Address,
                };
                return new StudentModel
                {
                    Details = student,
                    Message = "student information found",
                    Status = true
                };
            }

            return new StudentModel
            {
                Message = "student information not found",
                Status = false
            };
        }

        public StudentsModel GetStudents()
        {
            var getStudents = _studentRepository.GetStudents();
            var students = getStudents.Select(x => new StudentDetailsModel (){ 
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Address = x.Address,
            }).ToList();
            return new StudentsModel
            {
                Details = students,
                Message = "List of student registered",
                Status= true
            };
        }

        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model)
        {
            var getStudent = _studentRepository.Get(x => x.Id == id);
            if(getStudent != null)
            {
                getStudent.FirstName = model.FirstName;
                getStudent.LastName = model.LastName;
                getStudent.Email = model.Email;
                getStudent.Address = model.Address;
                _studentRepository.Update(getStudent);
                return new BaseResponse
                {
                    Message = "Student information updated sucessfuly",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "student not found",
                Status = false
            };
        }
    }
}
