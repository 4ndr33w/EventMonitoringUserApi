using System.Diagnostics.CodeAnalysis;

namespace WebSite.Models
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public long TelegramId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public decimal TotalResult { get; set; }
        public decimal LastAddedResult { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
