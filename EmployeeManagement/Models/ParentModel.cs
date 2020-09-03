using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class ParentModel
    {
        EmployeeModel EmployeeModel { get; set; }
        DepartmentModel DepartmentModel { get; set; }
    }
}
