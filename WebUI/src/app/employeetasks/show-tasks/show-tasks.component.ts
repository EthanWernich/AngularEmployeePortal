import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-tasks',
  templateUrl: './show-tasks.component.html',
  styleUrls: ['./show-tasks.component.css'],
})
export class ShowTasksComponent implements OnInit {
  constructor(private service: SharedService) {}

  TasksList: any = [];

  ModalTitle: string;
  ActivateAddEditTaskComp: boolean = false;
  task: any;

  ngOnInit(): void {
    this.refreshTasksList();
  }

  addClick() {
    this.task = {
      Id: 0,
      EmployeeName: '',
      Department: '',
      Tasks: '',
    };
    this.ModalTitle = 'Add Task';
    this.ActivateAddEditTaskComp = true;
  }

  editClick(task: any) {
    console.log(task);
    this.task = task;
    this.ModalTitle = 'Edit Tasks';
    this.ActivateAddEditTaskComp = true;
  }

  deleteClick(task: any) {
    if (confirm('Are you sure??')) {
      this.service.deleteEmployee(task.Id).subscribe((data) => {
        alert(data.toString());
        this.refreshTasksList();
      });
    }
  }

  closeClick() {
    this.ActivateAddEditTaskComp = false;
    this.refreshTasksList();
  }

  refreshTasksList() {
    this.service.getTasksList().subscribe((data) => {
      this.TasksList = data;
    });
  }
}
