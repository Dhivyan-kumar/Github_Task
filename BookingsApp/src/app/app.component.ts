import { Component,EventEmitter,Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { ContactComponent } from './contact/contact.component';
import { BookComponent } from './book/book.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,
            FormsModule, 
            RouterOutlet, 
            HeaderComponent,
            ContactComponent,
            BookComponent,
            HomeComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BookingsApp';
  featureLoaded='';
  onNavigate(feature:string){
    this.featureLoaded=feature;
  }
}
