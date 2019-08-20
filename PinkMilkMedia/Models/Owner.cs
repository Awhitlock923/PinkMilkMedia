using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class Owner: IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
