using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.UserDbContext
{
    //IdentityDbContext<ApplicationUser>
    //public class HrLeaveManagementIdentityDbContext : IdentityDbContext<IdentityUser> 
    //{
    //    public HrLeaveManagementIdentityDbContext(DbContextOptions<HrLeaveManagementIdentityDbContext> options)
    //         : base(options)
    //    {

    //    }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //        builder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementIdentityDbContext).Assembly);
    //    } IdentityDbContext<ApplicationUser> 
    //}

    public class HrLeaveManagementIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public HrLeaveManagementIdentityDbContext(DbContextOptions<HrLeaveManagementIdentityDbContext> options)
            : base(options)
        {

        }

        protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementIdentityDbContext).Assembly);
        }
    }
    
}
