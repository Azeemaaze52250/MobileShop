using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class Users
    {
        public int UserId { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("User Role")]
        public string UserRole { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
