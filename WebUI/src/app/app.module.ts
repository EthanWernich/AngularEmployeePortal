import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './department/department.component';
import { ShowDepComponent } from './department/show-dep/show-dep.component';
import { AddEditComponent } from './department/add-edit/add-edit.component';
import { EmployeeComponent } from './employee/employee.component';
import { ShowEmpComponent } from './employee/show-emp/show-emp.component';
import { AddEditEmpComponent } from './employee/add-edit-emp/add-edit-emp.component';
import { SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { EmployeetasksComponent } from './employeetasks/employeetasks.component';
import { AddEditTasksComponent } from './employeetasks/add-edit-tasks/add-edit-tasks.component';
import { ShowTasksComponent } from './employeetasks/show-tasks/show-tasks.component';


@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    ShowDepComponent,
    AddEditComponent,
    EmployeeComponent,
    ShowEmpComponent,
    AddEditEmpComponent,
    EmployeetasksComponent,
    AddEditTasksComponent,
    ShowTasksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
