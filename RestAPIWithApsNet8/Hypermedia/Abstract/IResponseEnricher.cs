using Microsoft.AspNetCore.Mvc.Filters;

namespace RestAPIWithApsNet8.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context); // pesquisar o que é Task 
    }
}
