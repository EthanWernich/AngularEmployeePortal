import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEmployee } from './Models';
import { IDepartment } from './Models';
import { ITasks } from './Models';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  readonly APIUrl = 'http://localhost:5000/api';
  readonly PhotoUrl = 'http://localhost:5000/Photo/';

  constructor(private http: HttpClient) {}

  getDepList(): Observable<IDepartment[]> {
    return this.http.get<IDepartment[]>(this.APIUrl + '/department');
  }

  addDepartment(val: any) {
    return this.http.post(this.APIUrl + '/Department', val);
  }

  updateDepartment(val: any, departmentId: number) {
    return this.http.put(this.APIUrl + `/Department/${departmentId}`, val);
  }

  deleteDepartment(val: any) {
    return this.http.delete(this.APIUrl + '/Department/' + val);
  }

  getEmpList(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.APIUrl + '/Employee');
  }

  addEmployee(val: any) {
    return this.http.post(this.APIUrl + '/Employee', val);
  }

  updateEmployee(val: any, Id: number) {
    return this.http.put(this.APIUrl + `/Employee/${Id}`, val);
  }

  deleteEmployee(val: any) {
    return this.http.delete(this.APIUrl + '/Employee/' + val);
  }

  UploadPhoto(val: any) {
    return this.http.post(this.APIUrl + '/Employee/uploadedFile', val);
  }
  getTasksList(): Observable<ITasks[]> {
    return this.http.get<ITasks[]>(this.APIUrl + '/EmployeeTasks');
  }
  addTasks(val: any, EmployeeId: number) {
    return this.http.post(
      this.APIUrl + `/EmployeeTasks/Employee/${EmployeeId}`,
      val
    );
  }
  updateTasks(val: any, Id: number) {
    return this.http.put(this.APIUrl + `/Department/${Id}`, val);
  }

  deleteTasks(val: any) {
    return this.http.delete(this.APIUrl + '/EmployeeTasks/' + val);
  }
}
