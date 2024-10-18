import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-winner-result',
  templateUrl: './winner-result.component.html'
})
export class WinnerResultComponent {
  @Input() winner : string = '';
  @Output() restartGame: EventEmitter<void> = new EventEmitter();


  playAgain() {
    this.restartGame.emit();
  }
}
