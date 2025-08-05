using RestAPIWithApsNet8.Hypermedia.Abstract;

namespace RestAPIWithApsNet8.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirections { get; set; }

        public Dictionary<string, Object> Filters { get; set; }

        public List<T> List { get; set; }

        public PagedSearchVO()
        {
        }

        public PagedSearchVO(int currentPage, int pageSize, int totalResults, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalResults = totalResults;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, int totalResults, string sortFields, string sortDirections, Dictionary<string, object> filters) 
            : this(currentPage, pageSize, totalResults, sortFields, sortDirections)
        {
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sortDirections)
           
        {
            CurrentPage = 10;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }
        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}
