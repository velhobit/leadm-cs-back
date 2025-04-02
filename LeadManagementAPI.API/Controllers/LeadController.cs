using LeadManagementAPI.Domain.Services;
using LeadManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeadManagementAPI.Controllers
{
    [Route("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly LeadService _leadService;

        public LeadController(LeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetAllLeads()
        {
            var leads = await _leadService.GetLeadsAsync("Invited");
            return Ok(leads);
        }

        [HttpGet("invited")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetInvitedLeads()
        {
            var leads = await _leadService.GetLeadsAsync("Invited");
            return Ok(leads);
        }

        [HttpGet("accepted")]
        public async Task<ActionResult<IEnumerable<Lead>>> GetAcceptedLeads()
        {
            var leads = await _leadService.GetLeadsAsync("Accepted");
            return Ok(leads);
        }

        [HttpPut("{id}/change-status")]
        public async Task<ActionResult<Lead>> ChangeStatus(int id, [FromBody] ChangeStatusRequest request)
        {
            var lead = await _leadService.ChangeStatusAsync(id, request.NewStatus);
            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }
    }
}
