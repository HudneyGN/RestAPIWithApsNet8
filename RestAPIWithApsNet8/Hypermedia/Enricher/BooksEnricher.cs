using System.Text;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Hypermedia.Constants;

namespace RestAPIWithApsNet8.Hypermedia.Enricher
{
    public class BooksEnricher : ContentResponseEnricher<BooksVO>
    {
        protected override Task EnrichModel(BooksVO content, IUrlHelper urlHelper)
        {
            var path = "api/books";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationsType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationsType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationsType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationsType.self,
                Type = "int"
            });
            return Task.CompletedTask;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }

    }
}
