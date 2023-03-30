using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Domain.LeaveRequest>
{
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<CancelLeaveRequestCommandHandler> _appLogger;

    public CancelLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IAppLogger<CancelLeaveRequestCommandHandler> appLogger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _appLogger = appLogger;
    }

    public async Task<Domain.LeaveRequest> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(leaveRequest), request.Id);
        }
        leaveRequest.Cancelled = true;

        // Re-evaluate the employee's allocations for the leave type

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Leave Request for the Id {request.Id} has been cancelled successfully",
                Subject = "Leave Request Cancelled"
            };
            await _emailSender.SendEmail(email);
        } 
        catch (Exception ex)
        {
            _appLogger.LogWarning("Email not sent!!!", ex.Message);
        }
        await _leaveRequestRepository.UpdateAsync(leaveRequest);
        return leaveRequest;
    }
}
