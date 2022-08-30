import { Component, OnInit, Input } from '@angular/core';
import { IEmployee, ITasks } from 'src/app/Models';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-tasks',
  templateUrl: './add-edit-tasks.component.html',
  styleUrls: ['./add-edit-tasks.component.css'],
})
export class AddEditTasksComponent implements OnInit {
  constructor(private service: SharedService) {}

  @Input() task = <ITasks>{};

  public selectedEmployee = <IEmployee>{};

  EmployeeName: string;
  Id: number;
  EmployeeId: number;
  Department: string;
  Description: string;
  StartTime: Date;
  EndTime: Date;
  CompletedOn: Date;

  DepartmentList: any = [];
  EmployeeList: IEmployee[] = [];

  ngOnInit(): void {
    this.loadEmployeeList();

    this.Id = this.task.Id;
    this.selectedEmployee = this.task.Employee;
    this.Description = this.task.Description;
    this.StartTime = this.task.StartTime;
    this.EndTime = this.task.EndTime;
    this.CompletedOn = this.task.CompletedOn;
  }

  // loadData() {

  // }

  // loadDepartmentList() {
  //   this.service.getDepList().subscribe((data: any) => {
  //     this.DepartmentList = data;

  //     this.EmployeeName = this.task.EmployeeName;
  //     this.Department = this.task.Department;
  //   });
  // }

  loadEmployeeList() {
    this.service.getEmpList().subscribe((data: IEmployee[]) => {
      this.EmployeeList = data;
    });
  }

  addTasks() {
    var taskObject = {
      EmployeeId: this.task.EmployeeId,
      Description: this.Description,
      StartTime: this.StartTime,
      EndTime: this.EndTime,
      CompletedOn: this.CompletedOn,
    } as ITasks;

    this.service.addTasks(taskObject, this.task.EmployeeId).subscribe((res) => {
      alert(res.toString());
    });
  }

  updateTasks() {
    var taskObject = {
      Id: this.Id,
      EmployeeId: this.selectedEmployee.Id,
      Description: this.Description,
      StartTime: this.StartTime,
      EndTime: this.EndTime,
      CompletedOn: this.CompletedOn,
    } as ITasks;

    this.service
      .updateTasks(taskObject, this.selectedEmployee.Id)
      .subscribe((res) => {
        alert(res.toString());
      });
  }
}
