import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Employee } from '../app/Employee';
import { EmployeeDTO } from '../app/Employee';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
 
  constructor(private httpclient: HttpClient) { }

  GetEmployees(): Observable<Employee[]>{
    return this.httpclient.get<Employee[]>('/Api/Employee');
  }

  GetEmployeeById(Id: number): Observable<Employee>{
    return this.httpclient.get<Employee>('/Api/Employee/'+Id);
  }
  InsertEmployee(employee: EmployeeDTO) {

    return this.httpclient.post<Employee>('/Api/Employee', employee);
}

  UpdateEmployee(employee: EmployeeDTO): Observable<Employee>{
 
    return this.httpclient.put<Employee>('/Api/Employee', employee);
  }

  DeleteEmployee(Id: number){
    return this.httpclient.delete('/Api/Employee/'+Id);
  }

  UserAuthentication(UserName: string,Password: string):Observable<any>{
   let credentials='username=' +UserName  + '&password=' +Password +'&grant_type=password'; 
   var reqHeader = new HttpHeaders({'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
  return this.httpclient.post<any>('/token',encodeURI(credentials),{headers:reqHeader});
}
}
