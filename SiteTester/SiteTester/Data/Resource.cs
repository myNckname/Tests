using System;

namespace SiteTester.Data
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
