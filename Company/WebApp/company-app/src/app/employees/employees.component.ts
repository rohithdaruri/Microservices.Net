import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../shared/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  public InActiveGrid: boolean = true;
  public employeesList: any = [];
  constructor(private router: Router, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.GetAllEmployees(true);
  }

  addEmployee() {
    this.router.navigate(['employees/employee-add']);
  }

  GetAllEmployees(filter: boolean) {
    this.InActiveGrid = filter;
    this.employeeService.GetAllEmployees(filter).subscribe(result => {
      if (result.isSuccess) {
        this.employeesList = result.data;
      }
      else {
        this.employeesList = result.data;
      }
    });
  }


}
