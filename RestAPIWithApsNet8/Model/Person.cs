using System.ComponentModel.DataAnnotations.Schema;
using RestAPIWithApsNet8.Model.Base;

namespace RestAPIWithApsNet8.Model
{
    [Table("person")] // no linus não localiza a tabela person
    public class Person: BaseEntity
    {
        //removido Id, herdando da BaseEntity

        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
