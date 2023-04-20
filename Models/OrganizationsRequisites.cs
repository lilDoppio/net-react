using Microsoft.EntityFrameworkCore;

namespace net_react.Models
{
    public class OrganizationsRequisites
    {
        public int OrganizationId { get; set; }
        public int RequisitesId { get; set; }
        public Organizations Organizations { get; set; }
        public Requisites Requisites { get; set; }
    }
}
