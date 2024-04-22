import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class loginStatusService {

    public isLoggedIn = false;
    public isAdmin = false;
    public Imie:string = '';
  
}