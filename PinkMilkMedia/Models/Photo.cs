using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class Photo
    {
        public int id { get; set; }
        public string path { get; set; }
        

        public List<Album> Album { get; set; }
    }
}
