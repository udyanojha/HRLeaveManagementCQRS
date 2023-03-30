using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Query.GetLeaveAllocationDetails;

public class LeaveAllocationDetailsDto // Related leave Toye is being used Line 14
{
    public int Id { get; set; }
    public int NumberOfays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }  // Dto to Dto No ref. to Domain Object
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
