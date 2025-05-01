using System.Text.Json.Serialization;

namespace RestAPIWithApsNet8.Data.VO;

public class PersonVO
{
   // [JsonPropertyName ("Code")]  as do MySql
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Gender { get; set; }
}
