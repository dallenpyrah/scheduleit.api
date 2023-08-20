using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleIt.Business.Managers;
using ScheduleIt.Contracts.Company;
using ScheduleIt.Data.Models; // Assuming your Company model is defined here

namespace ScheduleIt.Service.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly CompaniesManager _companiesManager;

        public CompaniesController(ILogger<CompaniesController> logger, CompaniesManager companiesManager)
        {
            _logger = logger;
            _companiesManager = companiesManager;
        }

        [HttpGet("health")]
        public string HealthCheck()
        {
            return "OK";
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            try
            {
                List<Company?> companies = await _companiesManager.GetCompanies();
                if (!companies.Any())
                    return NotFound("No companies could be found");
                return Ok(companies);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanyById(int id)
        {
            try
            {
                Company? company = await _companiesManager.GetCompanyById(id);
                return Ok(company);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Company with id {id} could not be found");
                return NotFound($"Company with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(CreateCompanyRequest createCompanyRequest)
        {
            try
            {
                Company company = await _companiesManager.CreateCompany(createCompanyRequest);
                return Ok(company);
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
        public async Task<ActionResult<Company>> UpdateCompany(int id, Company updateCompany)
        {
            try
            {
                updateCompany.Id = id;
                Company company = await _companiesManager.UpdateCompany(updateCompany);
                return Ok(company);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Company with id {id} could not be found");
                return NotFound($"Company with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            try
            {
                Company company = await _companiesManager.DeleteCompany(id);
                return Ok(company);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Company with id {id} could not be found");
                return NotFound($"Company with id {id} could not be found");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
