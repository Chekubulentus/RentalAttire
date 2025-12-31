using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Application.Employees.Queries.GetAllEmployees;

namespace RentalAttireBackend.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("employees-all")]
        public async Task<ActionResult<Result<List<EmployeeDTO>>>> GetAllEmployeesAsync()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());

            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }
    }
}
