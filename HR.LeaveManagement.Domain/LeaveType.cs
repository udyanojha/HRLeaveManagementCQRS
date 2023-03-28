using HR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain;
public class LeaveType : BaseEntity
{
    //[StringLength(50)] Not good practise (Do client side validation)
    public string Name { get; set; }
    public int DefaultDays { get; set; }

}
