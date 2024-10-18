import { Component, Input } from '@angular/core';
import { Round } from 'src/app/models/round';

@Component({
  selector: 'app-game-result',
  templateUrl: './game-result.component.html',
  styleUrl: './game-result.component.css'
})
export class GameResultComponent {
  @Input() results: Round[] = [];
}
