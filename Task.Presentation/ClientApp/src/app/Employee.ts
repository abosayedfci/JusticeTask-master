export class Employee {
  id: number;
  name: string;
  hiringDate: Date;
  age: number;
  
}
export class EmployeeDTO {
  constructor(ID: number,
    Name: string,
    HiringDate: Date,
    Age: number) {
    this.ID = ID;
    this.Name = Name;
    this.HiringDate = HiringDate;
    this.Age = Age;
  }
  ID: number;
  Name: string;
  HiringDate: Date;
  Age: number;

}
