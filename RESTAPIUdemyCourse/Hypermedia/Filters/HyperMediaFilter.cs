using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPIUdemyCourse.Hypermedia.Filters
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions _hyperMediaFilterOptions;

        public HyperMediaFilter(HyperMediaFilterOptions hypermediaFilterOptions)
        {
            _hyperMediaFilterOptions = hypermediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            tryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void tryEnrichResult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult)
            {
                var enricher = _hyperMediaFilterOptions.ContentResponseEnricherList.FirstOrDefault(p => p.CanEnrich(context));
                if (enricher != null) Task.FromResult(enricher.Enrich(context));
            };
        }
    }
}
