using System.Diagnostics.CodeAnalysis;

namespace UsersAPI.Models
{
    public class BackupResults
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Result { get; set; }
        public decimal Veloresult { get; set; }
        public char Gender { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    //public class CityList
    //{
    //    [Key]
    //    int Id;
    //    string CityName;
    //}
}
