import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayout } from './layouts/main/main.layout';
import { RouterModule } from '@angular/router';
import { ModalComponent } from './components/modal/modal.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    MainLayout,
    ModalComponent,
    DropdownComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule

  ],
  exports: [
    ModalComponent,
    DropdownComponent,
  ]
})
export class SharedModule { }
