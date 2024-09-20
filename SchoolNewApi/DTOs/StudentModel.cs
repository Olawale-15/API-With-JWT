using SchoolNewApi.Response;

namespace SchoolNewApi.DTOs
{
    public class StudentModel:BaseResponse
    {
        public StudentDetailsModel? Details { get; set; }
    }
}
