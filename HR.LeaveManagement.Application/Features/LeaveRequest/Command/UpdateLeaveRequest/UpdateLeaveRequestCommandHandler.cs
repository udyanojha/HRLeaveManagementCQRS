using AutoMapper;
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

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Command.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Domain.LeaveRequest>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

    public UpdateLeaveRequestCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, 
        ILeaveRequestRepository leaveRequestRepository, IEmailSender emailSender, IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _appLogger = appLogger;
    }

    public async Task<Domain.LeaveRequest> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        if(leaveRequest is null)
        {
            throw new NotFoundException(nameof(leaveRequest), request.Id);
        }
        var validator = new UpdateLeaveRequestCommandValidator(_leaveRequestRepository, _leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        if(validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }

        _mapper.Map(request, leaveRequest);

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

       try
        {
            var email = new EmailMessage
            {
                To = string.Empty, /*Email from employee record*/
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} has been updated succesfully",
                Subject = "Leave Request Submitted",
            };
            await _emailSender.SendEmail(email);
        } catch (Exception ex)
        {
            _appLogger.LogWarning(ex.Message);
        }

        return leaveRequest;
    }
}
