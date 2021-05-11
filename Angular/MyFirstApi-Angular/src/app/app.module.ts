import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Import Angular Forms
import { FormsModule}  from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { MemberListComponent } from './member-list/member-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    MemberListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
