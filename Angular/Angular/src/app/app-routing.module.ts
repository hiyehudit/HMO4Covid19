import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUpdateShotComponent } from './add-update-shot/add-update-shot.component';
import { AddUserComponent } from './add-user/add-user.component';
import { AppComponent } from './app.component';
import { PersonDTO } from './classes/PersonDTO';
import { ClientListComponent } from './client-list/client-list.component';
import { AuthGuard } from './helpers/auth.guard';
import { HomeComponent } from './home/home.component';
import { UpdateShotComponent } from './update-shot/update-shot.component';
import {UserDtailsComponent} from './user-dtails/user-dtails.component'


const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./users/user/users.module').then(x => x.UsersModule);
const routes: Routes = [
  {
    path: 'ClientList', 
    component:ClientListComponent, 
  },
  {
    path:'addUser/:tz',
    component: AddUserComponent
  },
  {
    path:'userDtails/:id/addupdateShot/:tz',
    component: AddUpdateShotComponent
  },
  {
    path:'updateShot/:id/:tz',
    component: UpdateShotComponent
  },
  {
    
    path:'userDtails/:id',
    // data:Client,
    component:UserDtailsComponent
  },
  { path: '', component:ClientListComponent, canActivate: [AuthGuard] },
  { path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
  { path: 'account', loadChildren: accountModule },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
