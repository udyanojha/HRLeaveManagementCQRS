using HR.LeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Command.ChangeLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Query.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.Features.LeaveRequest.Query.GetLeaveRequestList;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : Controller
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetLeaveRequestListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailsDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LeaveRequest>> Post(CreateLeaveRequestCommand leaveRequest)
        {
            return Ok(await _mediator.Send(leaveRequest));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LeaveRequest>> Put(UpdateLeaveRequestCommand leaveRequest)
        {
            return Ok(await _mediator.Send(leaveRequest));
        }

        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LeaveRequest>> Put(CancelLeaveRequestCommand leaveRequest)
        {
            return Ok(await _mediator.Send(leaveRequest));
        }

        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LeaveRequest>> Put(ChangeLeaveRequestApprovalCommand leaveRequest)
        {
            return Ok(await _mediator.Send(leaveRequest));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LeaveRequest>> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
