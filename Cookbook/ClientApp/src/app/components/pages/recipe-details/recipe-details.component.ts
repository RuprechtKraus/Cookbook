import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RecipeToLoad } from '../../../interfaces/recipe[DELETE]';
import { RecipeDetails } from '../../../interfaces/recipe-details[DELETE]';
import { LocationService } from '../../../services/location.service';
import { RecipesService } from '../../../services/recipes.service';
import { Recipe } from 'src/app/interfaces/recipe';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css'],
})
export class RecipeDetailsComponent implements OnInit {
  // recipe?: RecipeToLoad = {
  //   id: null,
  //   title: "",
  //   desc: "",
  //   author: "",
  //   tags: [],
  //   cookingTime: null,
  //   servings: null,
  //   favs: null,
  //   likes: null,
  //   imageUrl: ""
  // };
  details: RecipeDetails;
  recipe: Recipe;

  constructor(
    private _recipeService: RecipesService,
    private _locationService: LocationService
  ) {
  }

  ngOnInit() {
    this.loadRecipe();
  }

  loadRecipe(): void {
    this._recipeService.getRecipeByID(this.recipe.recipeID).subscribe((response) => {
      this.recipe = response;
    });
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }
}
