import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pizza } from '../shared/pizza.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor(public http: HttpClient) { }
  readonly baseURL = 'http://localhost:7109/api/Product'; 

  public listPizza:Pizza[];

  public bufAddToCart:Pizza;
  public cartCounter:number = 0;
  public cartInventory:Pizza[] = [];
  public showCartInventory:boolean=false;
  
  getPizzas() {
    this.http.get<Pizza[]>(this.baseURL)
    .subscribe(listPizza =>{
      this.listPizza = listPizza;
      //console.log(this.listPizza);
      
    })
    
  }


  
}
