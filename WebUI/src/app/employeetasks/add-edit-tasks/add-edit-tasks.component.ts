import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-tasks',
  templateUrl: './add-edit-tasks.component.html',
  styleUrls: ['./add-edit-tasks.component.css'],
})
export class AddEditTasksComponent implements OnInit {
  constructor(private service: SharedService) {}

  @Input() task: any;
  EmployeeName: string;
  EmployeeId: number;
  Department: string;
  DateOfJoining: string;
  Tasks: string;

  DepartmentList: any = [];
  EmployeeList: any = [];

  ngOnInit(): void {
    this.loadDepartmentList();
    this.loadEmployeeList();
  }

  loadDepartmentList() {
    this.service.getDepList().subscribe((data: any) => {
      this.DepartmentList = data;

      this.EmployeeName = this.task.EmployeeName;
      this.Department = this.task.Department;
    });
  }
  loadEmployeeList() {
    this.service.getEmpList().subscribe((data: any) => {
      this.EmployeeList = data;

      this.EmployeeName = this.task.EmployeeName;
      this.EmployeeId = this.task.EmployeeId;
      this.DateOfJoining = this.task.DateOfJoining;
      this.Tasks = this.task.Tasks;
    });
  }

  addTasks() {
    var val = {
      Id: this.task.Id,
      EmployeeId: this.EmployeeId,
      EmployeeName: this.EmployeeName,
      Department: this.Department,
      DateOfJoining: this.DateOfJoining,
      Tasks: this.Tasks,
    };

    this.service.addTasks(val).subscribe((res) => {
      alert(res.toString());
    });
  }
  updateTasks() {
    var val = {
      Id: this.task.Id,
      EmployeeName: this.EmployeeName,
      Department: this.Department,
      DateOfJoining: this.DateOfJoining,
      Tasks: this.Tasks,
    };

    this.service.updateTasks(val, this.task.Id).subscribe((res) => {
      alert(res.toString());
    });
  }
}
