using HR.LeaveManagement.UI.Models.LeaveTypes;
using HR.LeaveManagement.UI.Services.Base;

namespace HR.LeaveManagement.UI.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeDetailsDto> GetLeaveTypeDetails(int id);
        //Task<Response<LeaveTypeVM>> CreateLeaveType(LeaveTypeVM leaveType);
        Task<LeaveTypeVM> CreateLeaveType(LeaveTypeVM leaveType);
        Task UpdateLeaveType(LeaveTypeVM leaveType);
        Task DeleteLeaveType(string id);

    }
}
