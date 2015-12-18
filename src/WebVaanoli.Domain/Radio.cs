using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVaanoli.Domain
{
    public class Radio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StreamUrl { get; set; }
        public string StreamQuality { get; set; }
        public string Genre { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
