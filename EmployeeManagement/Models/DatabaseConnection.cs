using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class DatabaseConnection
    {
        public DatabaseConnection(DbConnection connection)
        {
            this.Connection = connection;
        }
        internal DbConnection Connection { get; }
    }
}
