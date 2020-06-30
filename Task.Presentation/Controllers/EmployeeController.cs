using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.DAL.Models;
using Task.Business;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBal _EmployeeBal;
        private ILoggerManager _logger;
        public EmployeeController(IEmployeeBal EmployeeBal, ILoggerManager logger)
        {
            _EmployeeBal = EmployeeBal;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _EmployeeBal.GetEmployees();
            return Ok(Employees);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {

            var Employee = _EmployeeBal.GetEmployeeById(id);
            return Ok(Employee);
        }



        [HttpPost]
        public IActionResult Create([FromBody]Employee Employee)
        {

            int result = _EmployeeBal.Create(Employee);
            return Ok(result);

        }

        // POST: Employee/Edit/5
        [HttpPut]
        public IActionResult Edit([FromBody]Employee Employee)
        {

            int result = _EmployeeBal.Edit(Employee);
            return Ok(result);
        }



        // POST: Employee/Delete/5
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _EmployeeBal.Delete(id);
            return Ok(result);


        }
    }
}