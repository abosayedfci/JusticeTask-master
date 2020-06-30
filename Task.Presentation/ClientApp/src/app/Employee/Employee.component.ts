import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee, EmployeeDTO } from '../Employee';
import { EmployeeService } from '../Employee.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-Employee',
  templateUrl: './Employee.component.html'
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.GetAllEmployees();
  }



  EmployeeList: Employee[];
  Employee: Employee;
  employeeIdUpdate = null;
  employeeForm = new FormGroup({
    name: new FormControl('', Validators.required),
    age: new FormControl(''),
    hiringDate: new FormControl(''),
    
  });
  OnSubmit() {
    if (this.employeeIdUpdate == null) {
      const employee = this.employeeForm.value;
      this.InsertEmployee(employee);
    }
    else {
      const employee = this.employeeForm.value;
      this.UpdateEmployee(employee);
    }
  }

  GetAllEmployees() {

    this.employeeService.GetEmployees().subscribe(data => { this.EmployeeList = data; });
    var ss = this.EmployeeList;
  }
  GetEmployeeById(Id: number) {
    this.employeeService.GetEmployeeById(Id).subscribe(data => {
      this.SetemployeeFormValues(data);
    });
  }
  SetemployeeFormValues(employee: Employee) {
    this.employeeForm.controls['name'].setValue(employee.name);
    this.employeeForm.controls['age'].setValue(employee.age);
    this.employeeForm.controls['hiringDate'].setValue(employee.hiringDate);
    this.employeeIdUpdate = employee.id;
  }
  InsertEmployee(employee: Employee) {
    let greeter = new EmployeeDTO(employee.id, employee.name, employee.hiringDate, employee.age);
    this.employeeService.InsertEmployee(greeter).subscribe(() => {
      this.GetAllEmployees();
    });
  }
  UpdateEmployee(employee: Employee) {
    employee.id = this.employeeIdUpdate;
    let greeter = new EmployeeDTO(employee.id, employee.name, employee.hiringDate, employee.age);
    this.employeeService.UpdateEmployee(greeter).subscribe(() => {
      this.employeeIdUpdate = null;
      this.GetAllEmployees();
    });
  }
  DeleteEmployee(Id: number) {
    this.employeeService.DeleteEmployee(Id).subscribe(() => {
      this.employeeIdUpdate = null;
      this.GetAllEmployees();
    });
  }

  //public url: string = "https://localhost:44391/api/Employee"
  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<Employee[]>(this.url).subscribe(result => {
  //    this.Employees = result;
  //  }, error => console.error(error));
  //}
}


