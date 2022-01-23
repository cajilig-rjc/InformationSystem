using System.ComponentModel.DataAnnotations;

namespace InformationSystem.Models
{
    public class Cases
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => ((DateTime.Today.Year * 100 + DateTime.Today.Month) * 100 + DateTime.Today.Day) - ((DateOfBirth.Year * 100 + DateOfBirth.Month) * 100 + DateOfBirth.Day);
        public string ContactNumber { get; set; }
        public Status Status { get; set; }
        public string CityOrProvince { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string PurokOrSitio { get; set; }
        public string Address { get; set; }
        DateTime Created { get; set; }
        DateTime? LastUpdated { get; set; }
    }
}
