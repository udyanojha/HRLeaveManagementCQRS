﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public record DeleteLeaveTypeCommand : IRequest<Domain.LeaveType>
    {
        public int Id { get; set; }
    }
}
