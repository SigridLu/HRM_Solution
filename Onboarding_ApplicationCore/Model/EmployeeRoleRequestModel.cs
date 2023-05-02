using System;
using Onboarding_ApplicationCore.Entity;

namespace Onboarding_ApplicationCore.Model
{
    public class EmployeeRoleRequestModel
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }

        // Foreign Key
        public string Name { get; set; }
        public string ABBR { get; set; }

        //naviagational property
        public ICollection<Employee>? Employees { get; set; }
        public List<EmployeeRole>? RoleName { get; set; }
    }
}

