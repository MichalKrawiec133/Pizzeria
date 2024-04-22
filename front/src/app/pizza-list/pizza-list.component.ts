import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { PizzaService } from '../shared/pizza.service';
import { Pizza } from '../shared/pizza.model';
import { Router } from '@angular/router';
import { loginStatusService } from '../shared/loginStatus.service';

@Component({
  selector: 'app-pizza-list',
  templateUrl: './pizza-list.component.html',
  styleUrls: ['./pizza-list.component.css']
})
export class PizzaListComponent implements OnInit{

  constructor(public service: PizzaService, public loginStatusService: loginStatusService, private router: Router) {}
  
  ngOnInit(): void{

    this.service.getPizzas();

    if(this.loginStatusService.isLoggedIn == true && this.service.bufAddToCart!= null){

      this.service.cartInventory.push(this.service.bufAddToCart);
      
    }

    this.service.cartCounter = this.service.cartInventory.length;
    console.log(this.service.bufAddToCart)
  }


  onAddToCart(pz:Pizza){

    if(confirm('Dodać do koszyka?')){
        if(!this.loginStatusService.isLoggedIn)
        {
          
          this.service.bufAddToCart = pz;
          console.log(pz)
          this.router.navigate(['Login']);
          
          
        }else{

          this.service.cartInventory.push(pz);
          this.service.cartCounter = this.service.cartInventory.length;
          
        };

    }

  }

  logout(): void {
    this.loginStatusService.isAdmin = false;
    this.loginStatusService.isLoggedIn = false;
    this.loginStatusService.Imie = '';
    this.service.cartInventory = [];
    this.service.showCartInventory=false;
  }
  

  onCart(){
    
    if(this.service.showCartInventory == true){

      this.service.showCartInventory = false;

    }else{

      this.service.showCartInventory = true; 

    }
    

  }

  getCartPrice(): number {
    let totalPrice = 0;
    for (let cI of this.service.cartInventory) {
      totalPrice += cI.productPrice;
    }
    return totalPrice;
  }
  
  removeFromCart(cI: Pizza){

    const index = this.service.cartInventory.indexOf(cI);
    if (index !== -1) {
    this.service.cartInventory.splice(index, 1);
  }

  }

  onLogin(){
    if(!this.loginStatusService.isLoggedIn){

      this.router.navigate(['Login']);

    }

  }
}
