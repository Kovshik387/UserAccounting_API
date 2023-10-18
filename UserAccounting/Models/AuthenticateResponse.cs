using UserAccounting.DAL.Entity;

namespace UserAccounting.Models
{
    public class AuthenticateResponse
    {
        public int Userid { get; set; }
        public string Loginname { get; set; } = null!;
        public string Passwordhash { get; set; } = null!;
        public int Role { get; set; }
        public string? Token { get; set; }   

        public AuthenticateResponse(UserLoginData user, string token)
        {
            Userid = user.Userid; Loginname = user.Loginname; 
            Passwordhash = user.Passwordhash; Role = user.Role;
            this.Token = token;
        }
    }
}
