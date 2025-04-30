using System.ComponentModel.DataAnnotations.Schema;
using RestAPIWithApsNet8.Model.Base;

namespace RestAPIWithApsNet8.Model
{
    [Table("books")] // no linus não localiza a tabela person
    public class Books : BaseEntity
    {
        //removido Id, herdando da BaseEntity
        
        [Column("title")]
        public string Title { get; set; }

        [Column("author")] 
        public string Author  { get; set; }

        [Column("price")]
        public decimal Price { get; set; }


        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

    }
}
