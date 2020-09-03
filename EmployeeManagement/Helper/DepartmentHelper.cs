using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Models;
using Dapper;

namespace EmployeeManagement.Helper
{
    public class DepartmentHelper
    {
        private DatabaseConnection _databaseConnection;

        public DepartmentHelper(DatabaseConnection databaseConnection)
        {
            this._databaseConnection = databaseConnection;
        }
        public IEnumerable<DepartmentModel> Select_DepartmentDetails()
        {
            var departmentData = _databaseConnection.Connection.Query<DepartmentModel>("Select * from DepartmentInfo");
            return departmentData;
        }
        public DepartmentModel Select_DepartmentDetails_ByID(int DepartmentID)
        {
            var departmentData = _databaseConnection.Connection.QuerySingle<DepartmentModel>("Select * from DepartmentInfo Where DepartmentID = @DepartmentID ", new { DepartmentID });
            return departmentData;
        }
        public int Insert(DepartmentModel departmentModel)
        {
            var departmentData = _databaseConnection.Connection.Execute("INSERT INTO DepartmentInfo( DepartmentName, Description) VALUES ( @DepartmentName,@Description)", departmentModel);
            return departmentData;
        }
        public int Update(DepartmentModel departmentModel)
        {
            var departmentData = _databaseConnection.Connection.Execute("UPDATE DepartmentInfo SET DepartmentName=@DepartmentName, Description=@Description WHERE DepartmentID=@DepartmentID", departmentModel);
            return departmentData;
        }
        public int Delete(int DepartmentID)
        {
            var departmentData = _databaseConnection.Connection.Execute("DELETE FROM DepartmentInfo WHERE DepartmentID=@DepartmentID", new { DepartmentID });
            return departmentData;
        }
    }
}
