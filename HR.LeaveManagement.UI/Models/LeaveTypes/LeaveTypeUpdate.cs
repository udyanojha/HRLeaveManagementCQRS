namespace HR.LeaveManagement.UI.Models.LeaveTypes
{
    public class UpdateLeaveTypeCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
   
}
