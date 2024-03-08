import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksRoutingModule } from './tasks-routing.module';
import { TasksPage } from './pages/tasks/tasks.page';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SharedModule } from '@shared/shared.module'; 
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TasksPage,
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    TasksRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class TasksModule { }
