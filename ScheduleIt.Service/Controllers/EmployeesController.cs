using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleIt.Business.Managers;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly EmployeesManager _employeesManager;

    public EmployeesController(ILogger<EmployeesController> logger, EmployeesManager employeesManager)
    {
        _logger = logger;
        _employeesManager = employeesManager;
    }
}