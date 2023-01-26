using System.Text.Json.Serialization;

namespace TestAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
