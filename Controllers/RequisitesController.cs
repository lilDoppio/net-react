using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_react.Interfaces;
using net_react.Models;

namespace net_react.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequisitesController : Controller
    {
        private readonly IRequisitesRepository _requisitesRepository;

        public RequisitesController(IRequisitesRepository requisitesRepository)
        {
            _requisitesRepository = requisitesRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Requisites>))]
        public async Task<IActionResult> GetAll()
        {
            var requisites = await _requisitesRepository.GetAllAsync();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(requisites);
        }

        //[HttpGet("orgreq")]
        //[ProducesResponseType(200, Type = typeof(ICollection<Requisites>))]
        //public async Task<IActionResult> GetAllOrgReq()
        //{
        //    var requisites = await _requisitesRepository.GetAllRelationsAsync();

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(requisites);
        //}

        [HttpPost("{inn}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Consumes("application/json")]
        public async Task<IActionResult> AddRequisities(List<Requisites> requisites, string inn)
        {
            List<Requisites> newRequisitesList = new();

            foreach (var requisite in requisites)
            {
                if (requisite != null)
                {
                    var newRequisites = await _requisitesRepository.AddOneAsync(requisite, inn);

                    if (newRequisites != null)
                        newRequisitesList.Add(newRequisites);
                }
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(newRequisitesList);
        }
    }
}
