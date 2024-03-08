import { Component, Input, Output, EventEmitter } from '@angular/core';
import { faXmarkSquare } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  faXmarkSquare = faXmarkSquare;
  @Input() title: string;
  @Input() isOpen: boolean;
  @Output() closeModal = new EventEmitter<void>();
}
