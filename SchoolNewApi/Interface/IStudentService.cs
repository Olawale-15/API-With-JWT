using SchoolNewApi.DTOs;
using SchoolNewApi.Response;

namespace SchoolNewApi.Interface
{
    public interface IStudentService
    {
        BaseResponse CreateStudent(CreateStudentRequestModel model);
        BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model);
        BaseResponse DeleteStudent(int id);
        StudentModel GetStudent(int id);
        StudentsModel GetStudents();
    }
}
