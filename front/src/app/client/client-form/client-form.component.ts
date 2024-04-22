import { formatCurrency } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Client } from 'src/app/shared/client.model';
import { ClientService } from '../../shared/client.service';
import { Md5 } from 'ts-md5';


@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styles: [
  ]
})
export class ClientFormComponent {

  constructor(public service:ClientService ){}


    onSubmit(form:NgForm){
      
      const clientHash = Md5.hashStr(form.value.ClientHash).toString();
      
      this.service.formData.clientHash = clientHash;

      this.service.postClient().subscribe(

        res => {
          this.resetForm(form);
          alert("Dodano pomyślnie");
          this.service.refreshList();},
        err => {console.log(err)}

      )

    }
    updateClient(id:number, form:NgForm){

      this.service.updateClientt(id).subscribe(

        res => {
          this.resetForm(form);
          alert("Zmieniono pomyślnie");
          this.service.refreshList();},
        err => {console.log(err)}

      )

    }
    

    resetForm(form:NgForm) {
      form.form.reset();
      this.service.formData = new Client();
    }
    
    
}
