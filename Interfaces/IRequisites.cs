using net_react.Models;

namespace net_react.Interfaces
{
    public interface IRequisitesRepository
    {
        Task<ICollection<Requisites>> GetAllAsync();
        //Task<ICollection<OrganizationsRequisites>> GetAllRelationsAsync();
        Task<Requisites?> AddOneAsync(Requisites requisites, string inn);
    }
}
