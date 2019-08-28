using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public UserType Type { get; set; }
    }

    public enum UserType
    {
        User,
        Administrator
    }
}
