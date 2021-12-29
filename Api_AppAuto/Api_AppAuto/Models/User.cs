using System;
using System.Collections.Generic;

#nullable disable

namespace Api_AppAuto.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phonenumber { get; set; }
        public string Password { get; set; }
    }
}
