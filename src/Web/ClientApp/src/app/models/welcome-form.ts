import {
    FormControl,
    FormGroup,
    Validators,
  } from '@angular/forms';
  
  export class WelcomeForm {
    private _group: FormGroup;
  
    private _controls: {
      player1: FormControl
      player2: FormControl
    };
  
    constructor() {
      this._controls = {
        player1: new FormControl(null, [Validators.required, Validators.maxLength(35)]),
        player2: new FormControl(null, [Validators.required, Validators.maxLength(35)]),
      };
      
      this._group = new FormGroup(this._controls);
    }
  
    public get group(): FormGroup {
      return this._group;
    }
  
    public get controls() {
      return this._controls;
    }
  
    public disable(): void {
      this._group.disable();
    }
  
    public enable(): void {
      this._group.enable();
    }

    public get data(): string[] {
      return [this.controls.player1.value?.trim(), this.controls.player2.value?.trim()];
    }
  
    // Method to validate each field of form
    public validateForm(): void {
      Object.keys(this._group.controls).forEach((field) => {
        const control = this._group.get(field);
        if (control instanceof FormControl) {
          control.markAsTouched({ onlySelf: true });
          if (control.invalid) {
            control.markAsDirty();
            control.updateValueAndValidity({ onlySelf: true });
          }
        } else if (control instanceof FormGroup) {
          this.validateForm();
        }
      });
    }
  }
  