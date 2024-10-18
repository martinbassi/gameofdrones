import { Component } from '@angular/core';
import { Round } from '../models/round';
import { Player } from '../models/player';
import { CreateGameCommand, GameRuleDto, GamesClient, ResultId, SettingsClient } from '../web-api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  currentRound = 0;
  results: Round[] = [];
  players: Player[] = [];
  currentPlayerName = '';
  currentPlayer = 0;
  playerMovements = [];
  winner = '';

  gameRules: GameRuleDto[] = [];
  movements: string[] = [];

  constructor(private settingsClient: SettingsClient, private client: GamesClient) {
    this.getSettings();
  }

  onMoveSelected(move: string) {
    this.playerMovements.push(move);

    if (this.currentPlayer === 1) {
      this.changePlayer(2);
    }
    else {
      this.getResult();
      if (this.existWinner()) {
        this.finishGame();
      }
      else {
        this.startNextRound();
      }
    }
  }

  finishGame() {
    this.publishGame();
    this.resetRound();
    this.currentRound = -1;
  }

  startNextRound() {
    this.currentRound++;
    this.resetRound();
    this.changePlayer(1);
  }

  resetRound() {
    this.playerMovements = [];
    this.currentPlayer = 0;
    this.currentPlayerName = '';
  }

  changePlayer(playerNumber: number) {
    this.currentPlayer = playerNumber;
    this.currentPlayerName = this.players[this.currentPlayer - 1].name;
  }

  onPlayersReady(playerNames: string[]) {
    this.players = playerNames.map(x => ({ name: x, score: 0 }));
    this.currentPlayer = 1;
    this.currentPlayerName = this.players[this.currentPlayer - 1].name;
    this.currentRound = 1;
    this.playerMovements = [];
  }

  getResult() {
    debugger;
    const [move, opMove] = this.playerMovements;
    const rule = this.gameRules.find(x => x.movement === move && x.oppMovement === opMove);
    if (!rule) return;

    const result = rule.resultId;
    let winner: Player;

    if (result === ResultId.Win) {
      winner = this.players[0];
    }
    else if (result === ResultId.Lose) {
      winner = this.players[1];
    }

    this.results.push({ roundNumber: this.currentRound, winner: winner ? winner.name : '-' });

    if (winner) {
      winner.score += 1;
    }
  }

  existWinner(): boolean {
    debugger;
    const winnerPlayer = this.players.find(p => p.score === 3);
    this.winner = winnerPlayer?.name || '';
    return !!this.winner;
  }

  onRestartGame() {
    this.getSettings();
    this.currentRound = 0;
    this.results = [];
    this.players = [];
    this.currentPlayerName = '';
    this.currentPlayer = 0;
    this.playerMovements = [];
    this.winner = '';
  }

  getSettings() {
    this.settingsClient.getSettings().subscribe({
      next: data => {
        this.gameRules = data.rules || [];
        this.movements = data.movements || [];
      },
      error: err => {
        console.error('Error fetching settings', err);
      }
    });
  }

  publishGame() {
    const winner = this.winner;
    const opponent = this.players.find(x => x.name !== winner).name;
    const command = new CreateGameCommand({ winner: winner, opponent: opponent })
    this.client.createGame(command).subscribe({
      next: () => console.log('Game created successfully'),
      error: err => console.error('Error saving game', err)
    });
  }
}
