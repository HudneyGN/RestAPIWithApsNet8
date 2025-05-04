using RestAPIWithApsNet8.Hypermedia;
using RestAPIWithApsNet8.Hypermedia.Abstract;

namespace RestAPIWithApsNet8.Data.VO;

public class BooksVO : ISupportsHyperMedia
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public decimal Price { get; set; }

    public DateTime LaunchDate { get; set; }

    public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
}
