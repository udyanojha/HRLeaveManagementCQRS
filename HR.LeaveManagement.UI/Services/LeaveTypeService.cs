using AutoMapper;
using HR.LeaveManagement.UI.ApiClient;
using HR.LeaveManagement.UI.Contracts;
using HR.LeaveManagement.UI.Models.LeaveTypes;
using HR.LeaveManagement.UI.Services.Base;
using static HR.LeaveManagement.UI.Pages.LeaveType.GetLeaveTypeDetails;

namespace HR.LeaveManagement.UI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IWebApiExecuter _client;
        private readonly IMapper _mapper;

        public LeaveTypeService(IWebApiExecuter webApiExecuter, IMapper mapper) : base(webApiExecuter)
        {
            _client = webApiExecuter;
            _mapper = mapper;

        }


        public async Task<LeaveTypeVM> CreateLeaveType(LeaveTypeVM leaveType)
        {
            var command = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
            var leaveTypeCreated = await _client.InvokePost<CreateLeaveTypeCommand>($"api/LeaveTypes", command);
            return _mapper.Map<LeaveTypeVM>(leaveTypeCreated);
        }

        public async Task DeleteLeaveType(string id)
        {
            await _client.InvokeDelete($"api/LeaveTypes/{id}");
        }

        public async Task<LeaveTypeDetailsDto> GetLeaveTypeDetails(int id)
        {
            var leaveTypeDetails = await _client.InvokeGet<LeaveTypeDetailsDto>($"api/LeaveTypes/{id}");
            //return _mapper.Map<LeaveTypeVM>(leaveTypeDetails);
            return leaveTypeDetails;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.InvokeGet<List<LeaveTypeVM>>("api/LeaveTypes");
            return _mapper.Map<List<LeaveTypeVM>>( leaveTypes );
        }

        public async Task UpdateLeaveType(LeaveTypeVM leaveType)
        {

            var leaveTypeToUpdate = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
            await _client.InvokePut($"api/LeaveTypes", leaveTypeToUpdate);

        }


    }
}
