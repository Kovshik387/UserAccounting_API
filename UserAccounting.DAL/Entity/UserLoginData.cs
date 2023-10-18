using System;
using System.Collections.Generic;

namespace UserAccounting.DAL.Entity;

public partial class UserLoginData
{
    public int Userid { get; set; }

    public string Loginname { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public int Role { get; set; }

    public virtual Role RoleNavigation { get; set; } = null!;
}
