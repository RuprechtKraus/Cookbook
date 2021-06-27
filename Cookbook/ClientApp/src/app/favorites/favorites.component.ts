import { Component, OnInit } from '@angular/core';

import { RecipeToLoad } from '../interfaces/recipe';
import { RecipesService } from '../recipes.service';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { LocationService } from '../location.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit {
  favRecipes: RecipeToLoad[] = [];

  constructor(
    private _recipesService: RecipesService,
    private _locationService: LocationService
  ) { }

  ngOnInit(): void {
    this.getFavoriteRecipes();
  }

  getFavoriteRecipes(): void {
    this._recipesService.getRecipes()
      .subscribe((recipes: RecipeToLoad[]) => this.favRecipes = recipes.filter(
        r => (r.id === 1 || r.id === 3)
        ));
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }

}
