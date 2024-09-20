namespace SchoolNewApi.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        //public string MatricNo { get; set; } = "Clh-22" + new Random().Next(1000000, 9999999).ToString();
        public string Address { get; set; } = default!;
    }
}
