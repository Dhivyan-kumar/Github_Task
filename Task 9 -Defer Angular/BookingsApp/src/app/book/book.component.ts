import { Component } from '@angular/core';
import { FormsModule,NgForm } from '@angular/forms';
import { NgForOf } from '@angular/common';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [FormsModule,NgForOf],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
numbers:number[]=[1,2,3,4,5,6,7,8,9,10];
cost:number=0;
selectedField:{resType:string, Roomcount:number,Personcount:number, Childrencount:number, Restfac:string}=
{
  resType:'',Roomcount:0,Personcount:0,Childrencount:0,Restfac:''
};

onSubmit(form:any){
  if(this.selectedField.resType=='Room')
  {
    if(this.selectedField.Restfac=='Yes')
    {
      this.cost=(this.selectedField.Roomcount*500)+(this.selectedField.Personcount*300)+(this.selectedField.Childrencount*100);
      console.log(this.cost);
    }
    else
    {
      this.cost=(this.selectedField.Roomcount*400)+(this.selectedField.Personcount*300)+(this.selectedField.Childrencount*100);
      console.log(this.cost);
    }
  }
  else
  {
    if(this.selectedField.Restfac=='Yes')
    {
      this.cost=(this.selectedField.Roomcount*700)+(this.selectedField.Personcount*300)+(this.selectedField.Childrencount*100);
      console.log(this.cost);
    }
    else
    {
      this.cost=(this.selectedField.Roomcount*600)+(this.selectedField.Personcount*300)+(this.selectedField.Childrencount*100);
      console.log(this.cost);
    }
  }
}
}
