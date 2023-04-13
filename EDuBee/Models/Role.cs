using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EDuBee.Models
{
    public partial class Role
    {
        public Role()
        {
            UserAccount = new HashSet<UserAccount>();
        }

        public int Idrole { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; }
    }
}
