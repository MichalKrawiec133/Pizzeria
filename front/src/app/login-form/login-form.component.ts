import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Login } from 'src/app/shared/login.model';
import { LoginService } from '../shared/login.service';
import { Md5 } from 'ts-md5';
import { loginStatusService } from '../shared/loginStatus.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {

  constructor(public service:LoginService, private loginStatusService: loginStatusService , private router: Router ){}


  onSubmit(){
    if(this.loginStatusService.isLoggedIn){
      if(this.loginStatusService.isAdmin){

        this.router.navigate(['Client']);

      }
      
      this.router.navigate(['Product']);

    }else{

      this.service.hashedFormData.clientEmail = this.service.formData.clientEmail
      this.service.hashedFormData.clientHash = Md5.hashStr(this.service.formData.clientHash)
      //console.log(this.service.hashedFormData)
      console.log(this.loginStatusService.isAdmin)


      this.service.postClient().then(result => {
        if (result && this.loginStatusService.isAdmin) {

          this.router.navigate(['Client']);

        } else if (result){

          this.router.navigate(['Product']);

        }else{
          
          this.service.loginFailed = true;

        }
      });
      
      

    }
    

  }
}
