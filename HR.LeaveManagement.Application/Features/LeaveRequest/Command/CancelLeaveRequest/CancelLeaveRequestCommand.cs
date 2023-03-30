using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Command.CancelLeaveRequest;

public class CancelLeaveRequestCommand : IRequest<Domain.LeaveRequest>
{
    public int Id { get; set; }
}
