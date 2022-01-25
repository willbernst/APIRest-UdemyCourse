using RESTAPIUdemyCourse.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
