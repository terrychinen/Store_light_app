using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    public class UserData
    {
        private static EmployeeModel employeeInstance = null;
        private static Token tokenInstance = null;

        public static Token getToken()
        {
            return tokenInstance;
        }

        public static Token setToken(Token token)
        {
            tokenInstance = token;
            return tokenInstance;
        }


        public static EmployeeModel getEmployee()
        {
            return employeeInstance;
        }

        public static EmployeeModel setEmployee(EmployeeModel employee)
        {
            employeeInstance = employee;
            return employeeInstance;
        }



    }
}
