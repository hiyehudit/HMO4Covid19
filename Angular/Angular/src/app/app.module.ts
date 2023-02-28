import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClientListComponent } from './client-list/client-list.component';
import { UserDtailsComponent } from './user-dtails/user-dtails.component';
import { AddUpdateShotComponent } from './add-update-shot/add-update-shot.component';
import { UpdateShotComponent } from './update-shot/update-shot.component';
import { AlertComponent } from './alert/alert.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import {  ErrorInterceptor } from './helpers/error.interceptor';
import { JwtInterceptor } from './helpers/jwt.interceptor';
// import { fakeBackendProvider } from './helpers/fake-backend';
@NgModule({
    declarations: [
        AppComponent,
        AddUserComponent,
        ClientListComponent,
        UserDtailsComponent,
        AddUpdateShotComponent,
        UpdateShotComponent,
        HomeComponent,
        UsersComponent,
        AlertComponent

    ],
    exports: [ReactiveFormsModule],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        // provider used to create fake backend
        // fakeBackendProvider
    ],
    bootstrap: [AppComponent],
    imports: [
        FormsModule,
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        ReactiveFormsModule,
        CommonModule,
    ]
})
export class AppModule { }
