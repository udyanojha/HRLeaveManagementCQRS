using AutoMapper;
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
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data TODO
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = validator.Validate(request);

            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid leave type", validationResult);
            }

            // Convert to Domain Entity object
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
            // add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return leaveTypeToUpdate.Id;
        }
    }
}
