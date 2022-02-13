import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeeAddComponent } from "./employee-add/employee-add.component";
import { EmployeesComponent } from "./employees.component";

const employeesRoutes: Routes = [
    {
        path: '',
        component: EmployeesComponent
    },
    {
        path: 'employee-add',
        component: EmployeeAddComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(employeesRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class EmployeesRoutingModule { }