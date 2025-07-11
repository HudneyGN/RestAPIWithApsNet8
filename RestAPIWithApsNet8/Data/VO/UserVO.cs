using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestAPIWithApsNet8.Hypermedia;
using RestAPIWithApsNet8.Hypermedia.Abstract;

namespace RestAPIWithApsNet8.Data.VO
{
    public class UserVO // : ISupportsHyperMedia
    {
        // public long Id { get; set; }
        
        public string UserName { get; set; }
        
        //public string FullName { get; set; }

        public string Password { get; set; }

        //public string RefreshToken { get; set; }
        
        //public DateTime RefreshTokenExpiryTipe { get; set; }
        // public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
    }
}
