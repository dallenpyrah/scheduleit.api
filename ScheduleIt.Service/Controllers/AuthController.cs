using Microsoft.AspNetCore.Mvc;
using ScheduleIt.Business.Exceptions;
using ScheduleIt.Contracts.Auth;
using ScheduleIt.Contracts.Employee;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly AuthManager _authManager;

    public AuthController(ILogger<AuthController> logger, AuthManager authManager)
    {
        _logger = logger;
        _authManager = authManager;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            string jwtToken = await _authManager.Login(request);
            object response = new {token = jwtToken};
            return Ok(response);
        }
        catch (KeyNotFoundException e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
        catch (InvalidPasswordException e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error logging in");
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterEmployeeRequest registerEmployeeRequest)
    {
        try
        {
            string jwtToken = await _authManager.RegisterEmployee(registerEmployeeRequest);
            return Ok(jwtToken);
        }
        catch (DuplicateEmailException e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
        catch (KeyNotFoundException e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error registering");
            return StatusCode(500, e.Message);
        }
    }

}