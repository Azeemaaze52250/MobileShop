using System;
using System.Collections.Generic;

namespace MobileShop.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
    }
}
