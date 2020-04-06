import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AuthGuard} from './auth.guard'
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { AccountComponent } from './account/account.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegisterComponent } from './register/register.component';
import { ComponentHelpComponent } from './component-help/component-help.component';
import { GameCalendarComponent } from './game-calendar/game-calendar.component';
import { GameOverviewComponent } from './game-overview/game-overview.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { GameListComponent } from './game-list/game-list.component';
import { SignUpComponent} from './sign-up/signup.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AccountComponent,
    LoginComponent,
    AdminComponent,
    RegisterComponent,
    ComponentHelpComponent,
    FetchDataComponent,
    GameCalendarComponent,
    GameOverviewComponent,
    PlayerListComponent,
    GameListComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      {path:  'auth', loadChildren:  './auth/auth.module#AuthModule'},
      //{ path: '', pathMatch: 'full', redirectTo: 'login'},
      { path: 'gameoverview', component: GameOverviewComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'account', component: AccountComponent },
      { path: 'login', component: LoginComponent },
      { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
      { path: 'register', component: RegisterComponent },
      { path: 'help', component: ComponentHelpComponent },
      { path: "gamelist", component: GameListComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
