import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApiQuestions
{
    constructor(private httpclient: HttpClient){}

    getquestions(): Observable<any>{
        return this.httpclient.get('https://localhost:44360/api/Questions')
    }
}