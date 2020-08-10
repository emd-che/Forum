import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  getAllUsers(){
    return this.http.get('/api/users').pipe(map(result=> result));
  }

  testAdmin(){
    return this.http.get('/api/users/TestAdmin').pipe(map(result=> result));
  }
}
