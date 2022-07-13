import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { RecipeToLoad } from '../../../interfaces/recipe';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.css']
})
export class RecipeCardComponent implements OnInit {
  @Input() recipe?: RecipeToLoad;
  onDetailPage: boolean;

  constructor(
    public _router: Router
  ) { }

  ngOnInit(): void {
    this.onDetailPage = (this._router.url === '/recipes');
  }

}
