using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalAttireBackend.Application.Common.Models;
using RentalAttireBackend.Application.Employees.Commands.CreateEmployee;
using RentalAttireBackend.Application.Employees.EmployeeDTOs;
using RentalAttireBackend.Application.Employees.Queries.GetAllEmployees;
using RentalAttireBackend.Application.Employees.Queries.GetEmployeeById;

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
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());

            return result.IsSuccess ? Ok(result.SuccessMessage) : BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });

            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeCommand request)
        {
            var result = await _mediator.Send(request);

            return result.IsSuccess ? Ok(result.SuccessMessage) : BadRequest(result.ErrorMessage);
        }
    }
}
