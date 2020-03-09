import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { AccountComponent } from './account/account.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SignUpComponent } from './sign-up/signup.component';
import { ComponentHelpComponent } from './component-help/component-help.component';
import { GameCalendarComponent } from './game-calendar/game-calendar.component';
import { GameOverviewComponent } from './game-overview/game-overview.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AccountComponent,
    SignUpComponent,
    ComponentHelpComponent,
    FetchDataComponent,
    GameCalendarComponent,
    GameOverviewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'gameoverview', component: GameOverviewComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'account', component: AccountComponent },
      { path: 'sign-up', component: SignUpComponent },
      { path: 'help', component: ComponentHelpComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
