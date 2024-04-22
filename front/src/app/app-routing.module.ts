import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PizzaListComponent } from './pizza-list/pizza-list.component';
import { ClientComponent } from './client/client.component';
import { LoginFormComponent } from './login-form/login-form.component';

const routes: Routes = [
  {path: 'Product', component: PizzaListComponent},
  {path: 'Client', component: ClientComponent},
  {path: 'Login', component: LoginFormComponent},
  {path: '', component:PizzaListComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
