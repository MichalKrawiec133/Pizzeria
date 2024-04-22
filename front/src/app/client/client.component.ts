import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ClientService } from '../shared/client.service';
import { Client } from '../shared/client.model';
import { Router } from '@angular/router';
import { loginStatusService } from '../shared/loginStatus.service';
import { Md5 } from 'ts-md5';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styles: [
  ]
})
export class ClientComponent implements OnInit{

  constructor(public service: ClientService, public router: Router, private loginService: loginStatusService) {}
  
ngOnInit(): void{

  if(!this.loginService.isLoggedIn){

    this.loginService.Imie ='';
    this.loginService.isAdmin= false;
    this.router.navigate(['Product']);

  }

  this.service.refreshList();

}
 
logout(){

  this.loginService.Imie ='';
  this.loginService.isAdmin= false;
  this.loginService.isLoggedIn=false;
  this.router.navigate(['Product']);

}

onDelete(id:number){
  if(confirm('Na pewno?'))
  {
  this.service.deleteClient(id)
  .subscribe(
    res=>{
      this.service.refreshList();
    },
    err=>{console.log(err)}
  )
}
}
onEdit(cl: Client){

 
  this.service.formData.clientId = cl.clientId
  this.service.formData.clientFirstName = cl.clientFirstName
  this.service.formData.clientLastName = cl.clientLastName
  this.service.formData.clientPesel = cl.clientPesel
  this.service.formData.clientEmail = cl.clientEmail
  this.service.formData.clientHash = cl.clientHash
  this.service.formData.clientRole = cl.clientRole


}


}
