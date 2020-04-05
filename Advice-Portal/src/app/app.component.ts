import { Component } from '@angular/core';
import { ApiQuestions } from './services/api-questions.service';
import { Questions } from './classes/questions';
import { ApiAnswers } from './services/api-answers.service';
import { Answers } from './classes/answers';
import { ApiAccounts } from './services/api-accounts.service';
import { Accounts } from './classes/accounts';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Advice Portal';
  constructor(
    private _ApiQuestions: ApiQuestions,
    private _ApiAnswers: ApiAnswers,
    private _ApiAccounts: ApiAccounts
    ){
  }

  listquestions:Questions[];
  listanswers:Answers[];
  listaccounts:Accounts[];

  ngOnInit(){

    this._ApiQuestions.getquestions()
    .subscribe(
      data=>{
        this.listquestions = data;
      }
    );

      this._ApiAnswers.getanswers()
      .subscribe(
        data=>{
          this.listanswers = data;
        }
      );
      this._ApiAccounts.getaccounts()
      .subscribe(
        data=>{
          this.listaccounts = data;
        }
      )
  }
}
