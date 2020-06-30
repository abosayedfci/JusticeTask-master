using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Task.Business;
using LoggerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Api.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeBal _EmployeeBal;
        private ILoggerManager _logger;
        public EmployeeController(IEmployeeBal EmployeeBal , ILoggerManager logger)
        {
            _EmployeeBal = EmployeeBal;
            _logger = logger; 
        }

        
       [HttpGet]
       [Route("api/Employee")]
      public IActionResult Index()
        {
                var Employees = _EmployeeBal.GetEmployees();
                return StatusCode(200 , Employees);
        }


        [HttpGet]
        [Route("api/Employee/{id}")]
        public IActionResult Details(int id)
        {
           
                var Employee = _EmployeeBal.GetEmployeeById(id);
                return StatusCode(200, Employee);
        
           

            
        }


        
        [HttpPost]
        [Route("api/Employee")]
        public IActionResult Create( Employee Employee)
        {
          
                int result = _EmployeeBal.Create(Employee);
                return StatusCode(200, result);
           
        }

        // POST: Employee/Edit/5
        [HttpPut]
        [Route("api/Employee")]
        public IActionResult Edit([FromBody]Employee Employee)
        {
           
                int result = _EmployeeBal.Edit(Employee);
                return StatusCode(200, result);
           
           

        }



        // POST: Employee/Delete/5
        [HttpDelete]
        [Route("api/Employee/{id}")]
        public IActionResult Delete(int id)
        {
           
                int result = _EmployeeBal.Delete(id);
              
                return StatusCode(200, result);
           

        }
    }
}