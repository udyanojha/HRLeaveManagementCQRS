using HR.LeaveManagement.Application.Features.LeaveAllocation.Command.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Query.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Query.GetLeaveAllocations;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LeaveAllocationsController : Controller
{
    private readonly IMediator _mediator;

    public LeaveAllocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedInUser = false)
    {
        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationsListQuery());
        return Ok(leaveAllocations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery
        {
            Id = id
        });
        return Ok(leaveAllocation);
    }

    [HttpPost]
    public async Task<ActionResult<LeaveAllocation>> Post(CreateLeaveAllocationCommand leaveAllocation)
    {
        var leaveAllocationCreated = await _mediator.Send(leaveAllocation);
        return Ok(leaveAllocationCreated);
    }

}
