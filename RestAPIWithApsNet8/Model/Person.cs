using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIWithApsNet8.Model
{
    [Table("person")] // no linus não localiza a tabela person
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
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
