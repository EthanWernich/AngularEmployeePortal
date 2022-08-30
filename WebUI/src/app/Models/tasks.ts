import { IEmployee } from './employee';

export interface ITasks {
  Id: number;
  EmployeeId: number;
  Description: string;
  StartTime: Date;
  EndTime: Date;
  CompletedOn: Date;
  Employee: IEmployee;
}
