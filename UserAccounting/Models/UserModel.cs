namespace UserAccounting.Models
{
    public class UserModel
    {
        public string Loginname { get; set; } = null!;

        public string Passwordhash { get; set; } = null!;

        public int Role { get; set; }
    }
}
