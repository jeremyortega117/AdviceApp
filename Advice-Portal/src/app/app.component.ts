import { Component } from '@angular/core';
import { ApiQuestions } from './services/api-questions.service';
import { Questions } from './classes/questions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Advice Portal';
  constructor(private _ApiQuestions: ApiQuestions){
  }

  listquestions:Questions[];

  ngOnInit(){
    this._ApiQuestions.getquestions()
    .subscribe(
      data=>{
        this.listquestions = data;
      }
    );
  }
}
