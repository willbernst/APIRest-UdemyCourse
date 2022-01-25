using System.Collections.Generic;

namespace RESTAPIUdemyCourse.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
