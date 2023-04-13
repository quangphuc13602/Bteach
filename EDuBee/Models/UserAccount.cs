using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EDuBee.Models
{
    public partial class UserAccount
    {
        public int IduserAccount { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Avatar { get; set; }
        public int? Idschool { get; set; }
        public int? Idrole { get; set; }

        public virtual Role IdroleNavigation { get; set; }
        public virtual School IdschoolNavigation { get; set; }
    }
}
