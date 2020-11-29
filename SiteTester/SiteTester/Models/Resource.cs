using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTester.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public DateTime TestTime { get; set; }
        public bool IsAvailable { get; set; }
        public long Ping { get; set; }
        public string Url { get; set; }
    }
}
