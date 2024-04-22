import { Injectable } from '@angular/core';
import { Login } from './login.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { NgForm } from '@angular/forms';
import { loginStatusService } from './loginStatus.service'
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(public http:HttpClient, private loginStatusService: loginStatusService) { }

  formData:Login = new Login();
  hashedFormData:Login = new Login();

  public loginFailed:boolean;

  readonly baseURL = 'http://localhost:7109/api/Login'


  postClient(): Promise<boolean> {
    return new Promise<boolean>((resolve, reject) => {
      this.http.post(this.baseURL, this.hashedFormData).subscribe(
        (response: any) => {
          if (response && response.isAdmin === true) {
            this.loginStatusService.isAdmin = true;
          }
          
          this.loginStatusService.isLoggedIn = true;
          this.loginStatusService.Imie = response.clientName;
          resolve(true);
        },
        (error: HttpErrorResponse) => {
          if (error.status === 401) {
            resolve(false);
          } else {
            resolve(false);
          }
        }
      );
    });
  }
  

}
