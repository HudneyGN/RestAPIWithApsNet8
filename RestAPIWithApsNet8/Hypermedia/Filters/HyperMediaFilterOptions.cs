using RestAPIWithApsNet8.Hypermedia.Abstract;

namespace RestAPIWithApsNet8.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher> ();

    }
}
