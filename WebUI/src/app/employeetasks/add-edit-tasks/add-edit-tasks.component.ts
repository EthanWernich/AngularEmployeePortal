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

  public selectedEmployee = <IEmployee>{};

  // @Input() task: any;
  EmployeeName: string;
  Id: number;
  EmployeeId: number;
  Department: string;
  DateOfJoining: string;
  Description: string;

  DepartmentList: any = [];
  EmployeeList: IEmployee[] = [];

  ngOnInit(): void {
    // this.loadDepartmentList();
    this.loadEmployeeList();
  }

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
      // this.EmployeeName = this.task.EmployeeName;
      // this.Id = this.task.Id;
      // this.DateOfJoining = this.task.DateOfJoining;
      // this.Tasks = this.task.Tasks;
      // this.EmployeeId = data.Id;
    });
  }

  addTasks() {
    // this.tasks = {
    //   id: this.selectedEmployee.Id,

    // EmployeeId: this.EmployeeId,
    // EmployeeName: this.EmployeeName,
    // Department: this.Department,
    // Tasks: this.Tasks,
    // };
    var taskObject = {
      employeeId: this.selectedEmployee.Id,
      employeeName: this.selectedEmployee.EmployeeName,
      department: this.selectedEmployee.Department,
      tasks: this.Description,
    } as ITasks;

    this.service
      .addTasks(taskObject, this.selectedEmployee.Id)
      .subscribe((res) => {
        alert(res.toString());
      });
  }
  updateTasks() {
    //   var val = {
    //     // Id: this.task.Id,
    //     EmployeeName: this.EmployeeName,
    //     Department: this.Department,
    //     DateOfJoining: this.DateOfJoining,
    //     Tasks: this.Description,
    //   };
    //   this.service.updateTasks(val, this.task.Id).subscribe((res) => {
    //     alert(res.toString());
    //   });
  }
}
