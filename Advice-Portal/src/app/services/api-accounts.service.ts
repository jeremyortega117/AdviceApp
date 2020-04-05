import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApiAccounts
{
    constructor(private httpclient: HttpClient){}

    getaccounts(): Observable<any>{
        return this.httpclient.get('https://localhost:44360/api/Accounts')
    }
}