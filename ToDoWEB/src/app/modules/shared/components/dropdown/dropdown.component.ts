import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css'],

})
export class DropdownComponent {
  @Input() isOpen: boolean;
  @Output() closeDropdown = new EventEmitter<void>();
}



