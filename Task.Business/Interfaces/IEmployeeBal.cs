using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL;
using Task.DAL.Models;

namespace Task.Business
{
  public  interface IEmployeeBal
    {
         List<Employee> GetEmployees();


        Employee GetEmployeeById(int id);


         int Create(Employee Employee);

         int Edit(Employee Employee);

         int Delete(int id);
    }
}
