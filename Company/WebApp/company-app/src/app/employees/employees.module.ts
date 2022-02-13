import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { EmployeeService } from "../shared/employee.service";
import { EmployeeAddComponent } from "./employee-add/employee-add.component";
import { EmployeesRoutingModule } from "./employees-routing.module";
import { EmployeesComponent } from "./employees.component";

@NgModule({
    imports: [
        CommonModule,
        EmployeesRoutingModule
    ],
    declarations: [
        EmployeesComponent,
        EmployeeAddComponent
    ],
    providers: [EmployeeService]
})
export class EmployeesModule { }