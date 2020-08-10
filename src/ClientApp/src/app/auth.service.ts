import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from './model/user.model';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userData = new BehaviorSubject<User>(new User());
  constructor(private http: HttpClient, private router: Router) { }
  


  setUserDetails() {
    if (localStorage.getItem('authToken')) {
      const userDetails = new User();
      const decodeUserDetails = JSON.parse(window.atob(localStorage.getItem('authToken').split('.')[1]));

      userDetails.username = decodeUserDetails.sub;
      userDetails.email = decodeUserDetails.email;
      userDetails.role = decodeUserDetails.role;
      userDetails.isLoggedIn = true;

      this.userData.next(userDetails);
    }
  }

  login(userDetails) {
    return this.http.post<any>('/login', userDetails).pipe(map(response => {
      localStorage.setItem('authToken', response.token);
      this.setUserDetails();
      return response;
    }))
  }
  logout(){
    localStorage.removeItem('authToken');
    this.router.navigate(['/login']);
    this.userData.next(new User());
  }
}
