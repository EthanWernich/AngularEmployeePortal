export interface ITasks {
  id: number;
  employeeId: number;
  employeeName: string;
  department: string;
  tasks: string;
  startTime: Date;
  endTime: Date;
  completedOn: Date;
}
