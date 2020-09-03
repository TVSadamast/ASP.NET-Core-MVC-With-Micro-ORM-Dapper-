using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeManagement.Models;
using Dapper;

namespace EmployeeManagement.Helper
{
    public class EmployeeHelper
    {
        private DatabaseConnection _databaseConnection;

        public EmployeeHelper(DatabaseConnection databaseConnection)
        {
            this._databaseConnection = databaseConnection;
        }
        public IEnumerable<EmployeeModel> Select_EmployeeDetails()
        {
            var employeeData = _databaseConnection.Connection.Query<EmployeeModel>("SELECT dbo.EmployeeInfo.EmployeeID, dbo.EmployeeInfo.Name, dbo.EmployeeInfo.Surname, dbo.EmployeeInfo.Contact, dbo.EmployeeInfo.Qualification, dbo.DepartmentInfo.DepartmentName, dbo.EmployeeInfo.Address FROM dbo.EmployeeInfo Left outer join dbo.DepartmentInfo On dbo.EmployeeInfo.Department = dbo.DepartmentInfo.DepartmentID ORDER BY dbo.EmployeeInfo.EmployeeID");
            return employeeData;
        }
        public EmployeeModel Select_EmployeeDetails_ByID(int EmployeeID)
        {
            var employeeData = _databaseConnection.Connection.QuerySingle<EmployeeModel>("SELECT dbo.EmployeeInfo.EmployeeID, dbo.EmployeeInfo.Name, dbo.EmployeeInfo.Surname, dbo.EmployeeInfo.Contact, dbo.EmployeeInfo.Qualification, dbo.DepartmentInfo.DepartmentName , dbo.EmployeeInfo.Address FROM dbo.EmployeeInfo, dbo.DepartmentInfo WHERE dbo.EmployeeInfo.EmployeeID = @EmployeeID and dbo.DepartmentInfo.DepartmentID = dbo.EmployeeInfo.Department", new { EmployeeID });
            return employeeData;
        }
        public int Insert(EmployeeModel employeeModel)
        {
            var employeeData = _databaseConnection.Connection.Execute("INSERT INTO EmployeeInfo(Name, Surname, Contact, Qualification, Department, Address) VALUES (@Name, @Surname, @Contact, @Qualification, @DepartmentName, @Address)", employeeModel);
            return employeeData;
        }
        public int Update(EmployeeModel employeeModel)
        {
            var employeeData = _databaseConnection.Connection.Execute("UPDATE EmployeeInfo SET Name=@Name, Surname=@Surname, Contact=@Contact, Qualification=@Qualification, Department=@DepartmentName, Address=@Address WHERE EmployeeID=@EmployeeID", employeeModel);
            return employeeData;
        }
        public int Delete(int EmployeeID)
        {
            var employeeData = _databaseConnection.Connection.Execute("DELETE FROM EmployeeInfo WHERE EmployeeID=@EmployeeID", new { EmployeeID });
            return employeeData;
        }

        public IEnumerable<DepartmentModel> Select_DepartmentName()
        {
            var departmentName = _databaseConnection.Connection.Query<DepartmentModel>("Select DepartmentID, DepartmentName From DepartmentInfo");
            return departmentName;
        }
    }
}
