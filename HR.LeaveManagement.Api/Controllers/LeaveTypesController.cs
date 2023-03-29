using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : Controller
{
    private readonly IMediator _mediator;

    public LeaveTypesController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    // GET: LeaveTypesController

    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypesQueryRequest());
        return leaveTypes;
    }

    // GET: LeaveTypesController by Id
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<LeaveTypeDetailsDto>> Get([FromRoute] int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return Ok(leaveType);
    }

    [HttpPost]
    public async Task<ActionResult<LeaveType>> CreateLeaveType(CreateLeaveTypeCommand leaveType)
    {
        var leaveTypeToCreate = await _mediator.Send(leaveType);
        return Ok(leaveTypeToCreate);
    }

    [HttpPut]
    public async Task<ActionResult<LeaveType>> UpdateLeaveType(UpdateLeaveTypeCommand leaveType)
    {
        var leaveTypeToUpdate = await _mediator.Send(leaveType);
        return Ok(leaveTypeToUpdate);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<LeaveType>> DeleteLeaveType([FromRoute] int id)
    {
        var command = new DeleteLeaveTypeCommand
        {
            Id = id
        };
        var leaveTypeToDelete = await _mediator.Send(command);
        return Ok(leaveTypeToDelete);
    }


}
