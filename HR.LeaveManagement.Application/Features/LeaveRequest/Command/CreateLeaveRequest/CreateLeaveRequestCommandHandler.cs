using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Domain.LeaveRequest>
{
    public Task<Domain.LeaveRequest> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
