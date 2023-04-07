namespace HR.LeaveManagement.UI.Models.LeaveTypes
{
    public class CreateLeaveTypeCommand 
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
