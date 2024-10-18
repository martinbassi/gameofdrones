import { Component, EventEmitter, input, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-move-selection',
  templateUrl: './move-selection.component.html'
})
export class MoveSelectionComponent {
  @Input() currentRound: number = 0;
  @Output() moveSelected: EventEmitter<string> = new EventEmitter();
  @Input() playerName: string = '';
  selectionForm = new FormGroup({
    movement: new FormControl('', {validators: [Validators.required], updateOn: 'blur'})
  },{ updateOn: 'submit' });
  @Input() movements: string[] = [];

  moveSelection() {
    if (this.selectionForm.invalid) {
      this.selectionForm.markAllAsTouched();
    }
    else {
      this.moveSelected.emit(this.selectionForm.get("movement").value);
      this.selectionForm.reset();
    }
  }
}
