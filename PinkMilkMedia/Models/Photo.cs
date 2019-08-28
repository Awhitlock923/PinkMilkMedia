using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string path { get; set; }
        public string AlbumId { get; set; }
        public Album Album { get; set; }
        
    }
}
