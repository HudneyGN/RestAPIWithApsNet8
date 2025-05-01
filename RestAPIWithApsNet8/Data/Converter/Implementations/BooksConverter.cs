using RestAPIWithApsNet8.Data.Converter.Contract;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Data.Converter.Implementations
{
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO>
    {
        public Books Parse(BooksVO origin)
        {
            if (origin == null) return null;
            return new Books
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price, 
                LaunchDate = origin.LaunchDate,
            };
        }
        public BooksVO Parse(Books origin)
        {
            if (origin == null) return null;
            return new BooksVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate,
            };
        }
        public List<Books> Parse(List<BooksVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BooksVO> Parse(List<Books> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
