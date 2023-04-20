using net_react.Models;
using System.ComponentModel.DataAnnotations;

namespace net_react.Interfaces
{
    public interface IOrganizationRepositiory
    {
        Task<ICollection<Organizations>> GetAllAsync();
        Task<Organizations?> AddOneLegalAsync(LegalOrganization organization);
        Task<Organizations?> AddOneIndividualAsync(IndividualOrganization organization);
    }
}
