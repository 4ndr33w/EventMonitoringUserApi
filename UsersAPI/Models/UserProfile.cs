using System.Diagnostics.CodeAnalysis;

namespace UsersAPI.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public long TelegramId { get; set; }

        [MaxLength(50)]
        [MaybeNull]
        public string Name { get; set; }
        [MaxLength(50)]
        [MaybeNull]
        public string Region { get; set; }
        [MaxLength(50)]
        [MaybeNull]
        public string City { get; set; }
        [MaxLength(50)]
        [MaybeNull]
        public string Company { get; set; }
        [MaybeNull]
        public int Age { get; set; }
        [MaybeNull]
        public char Gender { get; set; }
        [MaybeNull]
        public decimal TotalResult { get; set; }
        [MaybeNull]
        public decimal LastAddedResult { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserProfile(UserProfile user)
        {
            TelegramId = user.TelegramId;
            Name = user.Name;
            Region = user.Region;
            City = user.City;
            Company = user.Company;
            Age = user.Age;
            Gender = user.Gender;
            TotalResult = user.TotalResult;
            LastAddedResult = user.LastAddedResult;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
        }

        public UserProfile(long telegramId, string name, string region, string city, string company, int age, char gender, decimal totalResult, decimal lastResult, DateTime createdAt, DateTime updatedAt)
        {
            TelegramId = telegramId;
            Name = name;
            Region = region;
            City = city;
            Company = company;
            Age = age;
            Gender = gender;
            TotalResult = totalResult;
            LastAddedResult = lastResult;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public UserProfile() //(long telegramId, string name, string region, string city, string company, int age, char gender, decimal totalResult, decimal lastResult, DateTime createdAt, DateTime updatedAt)
        {
            //TelegramId = telegramId;
            //Name = name;
            //Region = region;
            //City = city;
            //Company = company;
            //Age = age;
            //Gender = gender;
            //TotalResult = totalResult;
            //LastAddedResult = lastResult;
            //CreatedAt = createdAt;
            //UpdatedAt = updatedAt;
        }
    }
}
