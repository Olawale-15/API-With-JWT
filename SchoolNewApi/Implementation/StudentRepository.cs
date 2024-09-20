using SchoolNewApi.Context;
using SchoolNewApi.Entities;
using SchoolNewApi.Interface;

namespace SchoolNewApi.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        public StudentRepository(ApplicationContext context) { 
            _context = context;
        }
        public Student Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        public Student? Get(Func<Student, bool> student)
        {
            var getStudent = _context.Students.FirstOrDefault(student);
            return getStudent;
        }

        public IList<Student> GetStudents()
        {
            var getStudents = _context.Students.ToList();
            return getStudents;
        }

        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}
