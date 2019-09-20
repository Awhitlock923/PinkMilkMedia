using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Models
{
    public class AlbumWrapper
    {
        public Album Album { get; set; }
        public List<Owner> CurrentUsers { get; set; }
    }
}
