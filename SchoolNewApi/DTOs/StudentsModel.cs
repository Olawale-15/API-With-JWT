using SchoolNewApi.Response;

namespace SchoolNewApi.DTOs
{
    public class StudentsModel:BaseResponse
    {
        public ICollection<StudentDetailsModel>? Details { get; set; }
    }
}
