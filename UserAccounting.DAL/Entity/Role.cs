using System;
using System.Collections.Generic;

namespace UserAccounting.DAL.Entity;

public partial class Role
{
    public int Roleid { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<UserLoginData> UserLoginData { get; set; } = new List<UserLoginData>();
}
