using System.ComponentModel.DataAnnotations;

namespace InformationSystem.Models
{
    public class Cases
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => (DateTime.Now.Year - DateOfBirth.Year);
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
