namespace Dal.Models
{
    public class User
    {
        public int Id { get; set; }
        #nullable disable
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        #nullable enable
        public int Role { get; set; }
    }
}
