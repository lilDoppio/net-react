using System.ComponentModel.DataAnnotations;

namespace net_react.Models
{
    public class Requisites
    {
        public int Id { get; set; }
        public string Bic { get; set; }
        public string BankName { get; set; }
        public string PaymentAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public ICollection<OrganizationsRequisites> OrganizationsRequisites { get; set; } = new List<OrganizationsRequisites>();
        
    }
}
