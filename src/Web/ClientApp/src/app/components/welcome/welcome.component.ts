import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { WelcomeForm } from 'src/app/models/welcome-form';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html'
})
export class WelcomeComponent implements OnDestroy {
  @Output() playersReady: EventEmitter<string[]> = new EventEmitter();
  form: WelcomeForm;
  private destroyed = new Subject();
  
  constructor(){
    this.form = new WelcomeForm();
    this.form.group.statusChanges.pipe(takeUntil(this.destroyed)).subscribe((status) => {
      this.validateForm();
    });
  }

  ngOnDestroy() {
    this.destroyed.next(null);
    this.destroyed.complete();
  }

  startGame() {
    this.validateForm();
    if (!this.form.group.invalid) {
     this.playersReady.emit(this.form.data);
    }
  }

  private validateForm(): void {
    this.form.validateForm();
  }
}
