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

  private handleError<T>(operation = 'undefined operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    }
  }

  getRecipes(): Observable<RecipeToLoad[]> {
    return this._http.get<RecipeToLoad[]>(this._recipesUrl);
  }

  // getRecipe(id: number): Observable<Recipe> { }

  getRecipeDetails(): Observable<RecipeDetails> {
    return this._http.get<RecipeDetails>(this._recipeDetailsUrl);
  }
}
