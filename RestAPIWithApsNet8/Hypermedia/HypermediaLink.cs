using System.Text;

namespace RestAPIWithApsNet8.Hypermedia
{
    public class HypermediaLink
    {
        public string Rel { get; set; }
        private string href;
        public string Href
        {
            get 
            { 
                
                lock (this) 
                { 
                    StringBuilder  sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string Type { get; set; }
        public string Action { get; set; }

    }
}
