namespace RestAPIWithApsNet8.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HypermediaLink> Links { get; set; }
    }
}
