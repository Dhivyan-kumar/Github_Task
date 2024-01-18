import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BookComponent } from '../book/book.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule,BookComponent,CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
formSelected:boolean=false;
showForm(){
  this.formSelected=!this.formSelected;
}
}
