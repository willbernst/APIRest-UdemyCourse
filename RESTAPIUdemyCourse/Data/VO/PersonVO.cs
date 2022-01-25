using RESTAPIUdemyCourse.Hypermedia;
using RESTAPIUdemyCourse.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Data.VO
{
    public class PersonVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Enabled { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
