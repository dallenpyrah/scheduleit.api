using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleIt.Business.Managers;
using ScheduleIt.Contracts.Company;
using ScheduleIt.Contracts.Role;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Service.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly RolesManager _rolesManager;

        public RolesController(ILogger<RolesController> logger, RolesManager rolesManager)
        {
            _logger = logger;
            _rolesManager = rolesManager;
        }

        [HttpGet("health")]
        public string HealthCheck()
        {
            return "OK";
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetRoles()
        {
            try
            {
                List<Company?> roles = await _rolesManager.GetRoles();
                if (!roles.Any())
                    return NotFound("No roles could be found");
                return Ok(roles);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            try
            {
                Role? role = await _rolesManager.GetRoleById(id);
                return Ok(role);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Role with id {id} could not be found");
                return NotFound($"Role with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(CreateRoleRequest createRoleRequest)
        {
            try
            {
                Role role = await _rolesManager.CreateRole(createRoleRequest);
                return Ok(role);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> UpdateRole(int id, Role updateRole)
        {
            try
            {
                updateRole.Id = id;
                Role role = await _rolesManager.UpdateRole(updateRole);
                return Ok(role);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Role with id {id} could not be found");
                return NotFound($"Role with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            try
            {
                Role role = await _rolesManager.DeleteRole(id);
                return Ok(role);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Role with id {id} could not be found");
                return NotFound($"Role with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
