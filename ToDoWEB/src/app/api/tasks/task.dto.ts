import { Task } from "./task.model"; 

export class CreateUpdateTaskDTO {
  public readonly assignmentName: string;
  public readonly assignmentDescription: string;
  public readonly assignmentDate?: string;
  public readonly statusId?: string;

  constructor(data: Task) {
      this.assignmentName = data.assignmentName;
      this.assignmentDescription = data.assignmentDescription;
      this.statusId = data.status.id;
      this.assignmentDate = new Date(data.assignmentDate)?.toInputDateString();
  }
}