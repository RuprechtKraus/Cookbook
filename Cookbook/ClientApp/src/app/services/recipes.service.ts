import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RecipeToLoad } from '../interfaces/recipe[DELETE]';
import { RecipeDetails } from '../interfaces/recipe-details[DELETE]';
import { Observable } from 'rxjs';
import { Recipe, RecipePreview } from '../interfaces/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  private _recipesUrl = '../assets/data/recipes.json';
  // private _recipeDetailsUrl = '../assets/data/recipe-details.json';
  recipeDetails: string[];

  constructor(
    private _http: HttpClient
  ) { }

  getRecipePreviews(): Observable<RecipePreview[]> {
    return this._http.get<RecipePreview[]>(this._recipesUrl);
  }

  getRecipeByID(id: number): Observable<Recipe> {
    return this._http.get<Recipe>(`api/recipe/${id}`);
  }
}
