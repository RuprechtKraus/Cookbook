import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RecipeToLoad } from '../interfaces/recipe';
import { RecipeDetails } from '../interfaces/recipe-details';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  private _recipesUrl = '../assets/data/recipes.json';
  private _recipeDetailsUrl = '../assets/data/recipe-details.json';
  recipeDetails: string[];

  constructor(
    private _http: HttpClient
  ) { }

  getRecipes(): Observable<RecipeToLoad[]> {
    return this._http.get<RecipeToLoad[]>(this._recipesUrl);
  }

  getRecipeDetails(): Observable<RecipeDetails> {
    return this._http.get<RecipeDetails>(this._recipeDetailsUrl);
  }
}
