﻿using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetAllEmployeeService();
        Employee AddEmployeeService(Employee employee);
        Employee UpdateEmployeeService(Employee employee);
        void DeleteEmployeeService(int id);
        Employee GetEmployeeByIdService(int id);
    }
}
