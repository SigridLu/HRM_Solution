using System;
namespace Onboarding_ApplicationCore.Model
{
    public class EmployeeRoleResponseModel
    {
        public int Id { get; set; }
        public string LookupCode { get; set; }

        // Foreign Key
        public string Name { get; set; }
        public string ABBR { get; set; }
    }
}

