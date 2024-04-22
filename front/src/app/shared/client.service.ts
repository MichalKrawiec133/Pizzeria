import { Injectable } from '@angular/core';
import { Client, Client2 } from './client.model';
import { HttpClient } from '@angular/common/http'
import { NgForm } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(public http:HttpClient) { }

  formData:Client = new Client();
  kli:Client2 = new Client2();
 
  public list:Client[];

  readonly baseURL = 'http://localhost:7109/api/Client/'
  readonly updateURL = 'http://localhost:7109/api/Client/edit/'

  postClient(){

    return this.http.post(this.baseURL, this.formData);
    
  }

  refreshList(){

    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as Client[]);

    
  }

  deleteClient(id:number){
    return this.http.delete(`${this.baseURL}${id}`);
  }

  updateClientt(id:number){
    
    this.kli.ClientFirstName = this.formData.clientFirstName
    this.kli.ClientLastName = this.formData.clientLastName
    this.kli.ClientPesel = this.formData.clientPesel
    this.kli.ClientEmail = this.formData.clientEmail
    this.kli.ClientHash = this.formData.clientHash
    this.kli.ClientRole = this.formData.clientRole

    return this.http.patch(`${this.updateURL}${id}`, this.kli)


  }
 

}
