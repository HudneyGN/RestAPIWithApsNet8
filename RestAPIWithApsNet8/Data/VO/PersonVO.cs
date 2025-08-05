using RestAPIWithApsNet8.Hypermedia;
using RestAPIWithApsNet8.Hypermedia.Abstract;

namespace RestAPIWithApsNet8.Data.VO;

public class PersonVO : ISupportsHyperMedia
{
    // [JsonPropertyName ("Code")]  as do MySql
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Gender { get; set; }
    public bool Enable { get; set; }
    public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
}
