import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GameResultComponent } from './components/game-result/game-result.component';
import { MoveSelectionComponent } from './components/move-selection/move-selection.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { WinnerResultComponent } from './components/winner-result/winner-result.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameResultComponent,
    MoveSelectionComponent,
    WelcomeComponent,
    WinnerResultComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
