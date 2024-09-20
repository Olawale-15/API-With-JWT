using SchoolNewApi.Entities;

namespace SchoolNewApi.Interface
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        Student Update(Student student);
        bool Delete(Student student);
        Student? Get(Func<Student, bool> student);
        IList<Student> GetStudents();
    }
}
