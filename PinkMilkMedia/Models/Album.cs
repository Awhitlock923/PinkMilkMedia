using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class Album
    {
        public int Id { get; set; }
        public DateTime DateOfShoot { get; set; }
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string link { get; set; }
        public Owner Owner { get; set; }
        public Owner Fullame { get; set; }     
    }
}
