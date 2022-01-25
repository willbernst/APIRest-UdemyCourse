using RESTAPIUdemyCourse.Hypermedia;
using RESTAPIUdemyCourse.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Data.VO
{
    public class CompanyVO : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string StockName { get; set; }
        public string StockSector { get; set; }
        public string Ein { get; set; }
        public string Address { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
