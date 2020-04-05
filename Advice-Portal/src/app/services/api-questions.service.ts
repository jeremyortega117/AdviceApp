import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

import {Questions } from '../classes/questions';

@Injectable()
export class ApiQuestions
{
    constructor(private httpclient: HttpClient){}

    getquestions(): Observable<any>{
        return this.httpclient.get('https://localhost:44360/api/Questions')
    }
    getquestionbyid(): Observable<any>{
        let param = new HttpParams().set('account_ID', "1");
        return this.httpclient.get('https://localhost:44360/api/Questions', {params:param});
    }
    post(oquestion:Questions): Observable<any>{
        return this.httpclient.post('https://localhost:44360/api/Questions',oquestion);
    }
}