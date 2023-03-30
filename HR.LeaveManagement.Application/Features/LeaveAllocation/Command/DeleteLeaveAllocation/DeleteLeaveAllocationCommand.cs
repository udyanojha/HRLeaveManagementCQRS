﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommand : IRequest<Domain.LeaveAllocation>
{
    public int Id { get; set; }
}
