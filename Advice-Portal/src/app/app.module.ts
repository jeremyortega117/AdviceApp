import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiQuestions } from './services/api-questions.service';
import { ApiAnswers } from './services/api-answers.service';
import { ApiAccounts } from './services/api-accounts.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,

  ],
  providers: [
    ApiQuestions,
    ApiAnswers,
    ApiAccounts
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
