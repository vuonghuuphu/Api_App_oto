using System;
using System.Collections.Generic;

#nullable disable

namespace Api_AppAuto.Models
{
    public partial class Oder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}
