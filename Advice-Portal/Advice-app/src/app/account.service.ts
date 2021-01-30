import { Injectable } from '@angular/core';
import { EMLINK } from 'constants';
import { of } from 'rxjs';
import { Accounts } from './Accounts';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  account = <Accounts> {
    ID: 1,
    FNAME: 'Joe',
    LNAME: 'Shmo',
    PASSWORD: '123',
    ACCESS_LEVEL: 1,
    EMAIL: 'joeshmo@email.com',
    PHONE: '123-456-7890',
    USERNAME: 'ogjoe',
    DEPT_ID: 1,
  };

  Accounts = <Account[]>{};

  constructor(private http: HttpClient) { }

  getAccount(){
    return of(this.account)
  }

  getAccounts(){
    return this.http.get<Account[]>('https://http://localhost:4200/api/Accounts');
  }

  getAccountById(id: number){
    return this.http.get<Account>('https://http://localhost:4200/api/Accounts/{id}');
  }
}
