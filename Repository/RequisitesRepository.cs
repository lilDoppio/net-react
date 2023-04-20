using Microsoft.EntityFrameworkCore;
using net_react.Data;
using net_react.Interfaces;
using net_react.Models;

namespace net_react.Repository
{
    public class RequisitesRepository : IRequisitesRepository
    {
        private readonly DataContext _context;

        public RequisitesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Requisites>> GetAllAsync()
        {
            return await _context.Requisites.ToListAsync();
        }

        //public async Task<ICollection<OrganizationsRequisites>> GetAllRelationsAsync()
        //{
        //    return await _context.OrganizationsRequisites.ToListAsync();
        //}

        public async Task<Requisites?> AddOneAsync(Requisites requisites, string inn)
        {
            var existingRequisites = await _context.Requisites.FirstOrDefaultAsync(req => req.Bic == requisites.Bic);
            var realtionOrganization = await _context.Organizations.FirstOrDefaultAsync(org => org.Inn == inn);

            if (existingRequisites != null && realtionOrganization != null)
            {
                return null;
            }

            await _context.AddAsync(requisites);
            await _context.SaveChangesAsync();

            var newRequisites = await _context.Requisites.FirstOrDefaultAsync(req => req.Bic == requisites.Bic);

            if (newRequisites != null && realtionOrganization != null)
            {
                var relation = new OrganizationsRequisites();

                relation.Organizations = realtionOrganization;
                relation.Requisites = newRequisites;

                await _context.OrganizationsRequisites.AddAsync(relation);

                newRequisites.OrganizationsRequisites.Add(relation);
                realtionOrganization.OrganizationsRequisites.Add(relation);

                await _context.SaveChangesAsync();

                return existingRequisites;
            }

            return null;
        }
    }
}
