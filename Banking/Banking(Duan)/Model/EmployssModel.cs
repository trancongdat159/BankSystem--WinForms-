using Banking.Model;
using System;

namespace Banking.Model
{
    internal class EmployeeModel : IModel
    {

        public string id { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public EmployeeModel(string id, string password, string role)
        {
            this.id = id;
            this.password = password;
            this.role = role;
        }

        // Parameterless constructor
        public EmployeeModel() { }

    }
}
