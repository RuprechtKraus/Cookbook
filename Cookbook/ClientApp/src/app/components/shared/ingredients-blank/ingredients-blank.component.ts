import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

import { Ingredient } from '../../../interfaces/ingredient';

@Component({
  selector: 'app-ingredients-blank',
  templateUrl: './ingredients-blank.component.html',
  styleUrls: ['./ingredients-blank.component.css']
})
export class IngredientsBlankComponent implements OnInit {
  @Input() removable: boolean = false;
  @Input() ingredient: Ingredient;
  @Output() remove = new EventEmitter<Ingredient>();

  constructor( ) { 
    
  }

  ngOnInit(): void {
  }

  onClick(): void {
    this.remove.emit(this.ingredient);
  }

}
