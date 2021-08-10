using System.Text.Json.Serialization;

namespace Task1.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string GroupName { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
