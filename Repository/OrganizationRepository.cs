using net_react.Data;
using net_react.Interfaces;
using Microsoft.EntityFrameworkCore;
using net_react.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json.Nodes;

namespace net_react.Repository
{
    public class OrganizationRepository : IOrganizationRepositiory
    {
        private readonly DataContext _context;

        public OrganizationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Organizations>> GetAllAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<Organizations?> AddOneLegalAsync(LegalOrganization organization)
        {
            var existingOrganization = await _context.Organizations.FirstOrDefaultAsync(org => org.Inn == organization.inn);

            if (existingOrganization != null)
            {
                return existingOrganization;
            }

            var InnSkan = organization.innSkan == null ? false : true;
            var OgrnSkan = organization.ogrnSkan == null ? false : true;
            var EgripSkan = organization.egripSkan == null ? false : true;
            var OfficeRentSkan = organization.officeRentSkan == null ? false : true;

            Organizations obj = new Organizations 
            { 
                Type = organization.type,
                FullName = organization.fullname,
                ShortName = organization.shortname,
                Inn = organization.inn,
                Ogrn = organization.ogrn,
                RegistrationDate = organization.registrationDate,
                InnSkan = InnSkan,
                OgrnSkan = OgrnSkan,
                OgrnipSkan = false,
                EgripSkan = EgripSkan,
                OfficeRentSkan = OfficeRentSkan,
            }; 

            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return await _context.Organizations.FirstOrDefaultAsync(org => org.Inn == organization.inn);
        }

        public async Task<Organizations?> AddOneIndividualAsync(IndividualOrganization organization)
        {
            var existingOrganization = await _context.Organizations.FirstOrDefaultAsync(org => org.Inn == organization.inn);

            if (existingOrganization != null)
            {
                return existingOrganization;
            }

            var InnSkan = organization.innSkan == null ? false : true;
            var OgrnipSkan = organization.ogrnipSkan == null ? false : true;
            var EgripSkan = organization.egripSkan == null ? false : true;
            var OfficeRentSkan = organization.officeRentSkan == null ? false : true;

            Organizations obj = new Organizations
            {
                Type = organization.type,
                Inn = organization.inn,
                Ogrnip = organization.ogrnip,
                RegistrationDate = organization.registrationDate,
                InnSkan = InnSkan,
                OgrnSkan = false,
                OgrnipSkan = OgrnipSkan,
                EgripSkan = EgripSkan,
                OfficeRentSkan = OfficeRentSkan,
            };

            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return await _context.Organizations.FirstOrDefaultAsync(org => org.Inn == organization.inn);
        }
    }
}
