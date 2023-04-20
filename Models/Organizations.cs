using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace net_react.Models
{
    
    public class Organizations
    {
        public int Id { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("fullname")]
        public string? FullName { get; set; }

        [JsonProperty("shortname")]
        public string? ShortName { get; set; }

        [JsonProperty("inn")]
        [MaxLength(10)]
        public string Inn { get; set; }

        [JsonProperty("ogrnip")]
        [MaxLength(15)]
        public string? Ogrnip { get; set; }
        
        [JsonProperty("ogrn")]
        [MaxLength(13)]
        public string? Ogrn { get; set; }

        [JsonProperty("registrationDate")]
        public DateOnly RegistrationDate { get; set; }

        [JsonProperty("innSkan")]
        public bool InnSkan { get; set; }

        [JsonProperty("ogrnSkan")]
        public bool OgrnSkan { get; set; }

        [JsonProperty("ogrnipSkan")]
        public bool OgrnipSkan { get; set; }

        [JsonProperty("egripSkan")]
        public bool EgripSkan { get; set; }

        [JsonProperty("officeRentSkan")]
        public bool OfficeRentSkan { get; set; }

        public ICollection<OrganizationsRequisites> OrganizationsRequisites { get; set; } = new List<OrganizationsRequisites>();
    }
    public class LegalOrganization
    {
        public string type { get; set; }

        public string fullname { get; set; }

        public string shortname { get; set; }

        public string inn { get; set; }

        public string ogrn { get; set; }

        public DateOnly registrationDate { get; set; }

        public IFormFile innSkan { get; set; }

        public IFormFile ogrnSkan { get; set; }

        public IFormFile egripSkan { get; set; }

        public IFormFile? officeRentSkan { get; set; }

    }

    public class IndividualOrganization
    {
        public string type { get; set; }

        public string inn { get; set; }

        public string ogrnip { get; set; }

        public DateOnly registrationDate { get; set; }

        public IFormFile innSkan { get; set; }

        public IFormFile ogrnipSkan { get; set; }

        public IFormFile egripSkan { get; set; }

        public IFormFile? officeRentSkan { get; set; }

    }
}
