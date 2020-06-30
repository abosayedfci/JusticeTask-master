using System;
using System.Collections.Generic;
using System.Linq;
using Task.DAL.Models;
using Task.DAL.Repository;

namespace Task.Business
{
    public  class EmployeeBal : IEmployeeBal
    {
        private IGenericRepository<Employee> Employeeepository = null;
        public EmployeeBal() {

            this.Employeeepository = new GenericRepository<Employee>();
        }
        public List<Employee> GetEmployees()
        {
            try
            {
                return  Employeeepository.SelectAll().ToList();
            }
            catch (Exception ex)
            {
                throw; 
              
            }
         
        }


        public Employee GetEmployeeById(int id)
        {
            try
            {
                return Employeeepository.SelectByID(id);
            }
            catch (Exception ex)
            {
                throw ;

            }

        }


        public int Create(Employee Employee)
        {
            try
            {
               
                    Employeeepository.Insert(Employee);
                    Employeeepository.Save();

                return 1;

            }
            catch (Exception ex)
            {
                throw ;

            }

        }

        public int Edit(Employee Employee)
        {
            try
            {
                Employeeepository.Update(Employee);
                Employeeepository.Save();
                return 1; 
            }
            catch (Exception ex)
            {
                throw ;

            }
        }

        public int Delete(int id)
        {
            try
            {
                Employeeepository.Delete(id);
                Employeeepository.Save();
                return 1; 
            }
            catch (Exception ex)
            {
                throw ;

            }


        }
    }
}
