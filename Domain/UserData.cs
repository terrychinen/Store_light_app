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
        private static Employee employeeInstance = null;
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


        public static Employee getEmployee()
        {
            return employeeInstance;
        }

        public static Employee setEmployee(Employee employee)
        {
            employeeInstance = employee;
            return employeeInstance;
        }



    }
}
