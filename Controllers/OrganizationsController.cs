using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_react.Interfaces;
using net_react.Models;
using net_react.Repository;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace net_react.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationRepositiory _organizationRepository;

        public OrganizationsController(IOrganizationRepositiory organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Organizations>))]
        public async Task<IActionResult> GetAll()
        {
            var organizations = await _organizationRepository.GetAllAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(organizations);
        }

        [HttpPost("legal")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddLegalOrganization([FromForm] LegalOrganization organization)
        {
            if (organization == null)
                return BadRequest(ModelState);

            string path = Path.Combine("Images", "Legal", $"{organization.inn}");

            if (Directory.Exists(path))
            {
            }
            else
            {
                Directory.CreateDirectory(path);

                if (organization.innSkan != null)
                {
                    var innSkan = Path.Combine(path, "inn" + Path.GetExtension(organization.innSkan.FileName));
                    using (var stream = System.IO.File.Create(innSkan))
                    {
                        await organization.innSkan.CopyToAsync(stream);
                    }
                }
                if (organization.ogrnSkan != null)
                {
                    var ogrnSkan = Path.Combine(path, "ogrn" + Path.GetExtension(organization.ogrnSkan.FileName));
                    using (var stream = System.IO.File.Create(ogrnSkan))
                    {
                        await organization.ogrnSkan.CopyToAsync(stream);
                    }
                }
                if (organization.egripSkan != null)
                {
                    var egripSkan = Path.Combine(path, "egrip" + Path.GetExtension(organization.egripSkan.FileName));
                    using (var stream = System.IO.File.Create(egripSkan))
                    {
                        await organization.egripSkan.CopyToAsync(stream);
                    }
                }
                if (organization.officeRentSkan != null)
                {
                    var officeRentSkan = Path.Combine(path, "office_rent" + Path.GetExtension(organization.officeRentSkan.FileName));
                    using (var stream = System.IO.File.Create(officeRentSkan))
                    {
                        await organization.officeRentSkan.CopyToAsync(stream);
                    }
                }
            }

            var newOrganisation = await _organizationRepository.AddOneLegalAsync(organization);

            return Ok(organization);
        }

        [HttpPost("individual")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddIndividualOrganization([FromForm] IndividualOrganization organization)
        {
            if (organization == null)
                return BadRequest(ModelState);

            string path = Path.Combine("Images", "Individual", $"{organization.inn}");

            if (Directory.Exists(path))
            {
            }
            else
            {
                Directory.CreateDirectory(path);

                if (organization.innSkan != null)
                {
                    var innSkan = Path.Combine(path, "inn" + Path.GetExtension(organization.innSkan.FileName));
                    using (var stream = System.IO.File.Create(innSkan))
                    {
                        await organization.innSkan.CopyToAsync(stream);
                    }
                }
                if (organization.ogrnipSkan != null)
                {
                    var orgnipSkan = Path.Combine(path, "ogrnip" + Path.GetExtension(organization.ogrnipSkan.FileName));
                    using (var stream = System.IO.File.Create(orgnipSkan))
                    {
                        await organization.ogrnipSkan.CopyToAsync(stream);
                    }
                }
                if (organization.egripSkan != null)
                {
                    var egripSkan = Path.Combine(path, "egrip" + Path.GetExtension(organization.egripSkan.FileName));
                    using (var stream = System.IO.File.Create(egripSkan))
                    {
                        await organization.egripSkan.CopyToAsync(stream);
                    }
                }
                if (organization.officeRentSkan != null)
                {
                    var officeRentSkan = Path.Combine(path, "office_rent" + Path.GetExtension(organization.officeRentSkan.FileName));
                    using (var stream = System.IO.File.Create(officeRentSkan))
                    {
                        await organization.officeRentSkan.CopyToAsync(stream);
                    }
                }
            }

            var newOrganisation = await _organizationRepository.AddOneIndividualAsync(organization);

            return Ok(organization);
        }
    }
}
