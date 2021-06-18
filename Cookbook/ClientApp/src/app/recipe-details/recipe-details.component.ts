import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Recipe } from '../interfaces/recipe';
import { RecipeDetails } from '../interfaces/recipe-details';
import { RecipesService } from '../recipes.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  recipe?: Recipe;
  id: number;
  details: RecipeDetails;

  constructor(
    private _route: ActivatedRoute,
    private _recipeService: RecipesService
  ) { 
    this.id = Number(this._route.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.getRecipe();
    this.getRecipeDetails();
  }

  getRecipe(): void {
    this._recipeService.getRecipes()
      .subscribe((recipes: Recipe[]) => this.recipe = recipes.find(r => r.id === this.id));
  }

  getRecipeDetails(): void {
    this._recipeService.getRecipeDetails()
      .subscribe((details: RecipeDetails) => this.details = details[0]);
  }

}
