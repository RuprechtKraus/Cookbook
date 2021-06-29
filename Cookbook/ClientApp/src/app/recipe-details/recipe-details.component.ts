import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RecipeToLoad } from '../interfaces/recipe';
import { RecipeDetails } from '../interfaces/recipe-details';
import { LocationService } from '../location.service';
import { RecipesService } from '../recipes.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  recipe?: RecipeToLoad = {
    id: null,
    title: "",
    desc: "",
    user: "",
    tags: [],
    cookingTime: null,
    servings: null,
    favs: null,
    likes: null,
    imageUrl: ""
  };
  id: number;
  details: RecipeDetails;

  constructor(
    private _route: ActivatedRoute,
    private _recipeService: RecipesService,
    private _locationService: LocationService
  ) { 
    this.id = Number(this._route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.getRecipe();
    this.getRecipeDetails();
  }

  getRecipe(): void {
    this._recipeService.getRecipes()
      .subscribe((recipes: RecipeToLoad[]) => this.recipe = recipes.find(r => r.id === this.id));
  }

  getRecipeDetails(): void {
    this._recipeService.getRecipeDetails()
      .subscribe((details: RecipeDetails) => this.details = details[0]);
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }
}
