import { Component } from '@angular/core';
import { Fruits } from './../shared/fruit.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-fruit-list',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './fruit-list.component.html',
  styleUrl: './fruit-list.component.css'
})
export class FruitListComponent {
  fruits:Fruits[]=[
    {id:1,name:'Apple'},
    {id:2, name:'Orange'}
   ];
   selectedFruit:Fruits|any;
   onSelect(fruit:any){
    this.selectedFruit=fruit;
   }
}
