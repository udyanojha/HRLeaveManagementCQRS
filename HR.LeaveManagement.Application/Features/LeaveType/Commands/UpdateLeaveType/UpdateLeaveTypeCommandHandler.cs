using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Domain.LeaveType>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }
        public async Task<Domain.LeaveType> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data TODO
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult =await validator.ValidateAsync(request);

            if(validationResult.Errors.Any())
            {
                _logger.LogInformation("Validation error in  {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestException("Invalid leave type", validationResult);
            }

            // Convert to Domain Entity object
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
            // add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            _logger.LogInformation("Leave Type Updated for {0}", request.Id);
            return leaveTypeToUpdate;
        }
    }
}
