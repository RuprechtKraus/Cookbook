import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

import { Recipe } from './interfaces/recipe';
import { RecipeDetails } from './interfaces/recipe-details';
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

  getRecipes(): Observable<Recipe[]> {
    return this._http.get<Recipe[]>(this._recipesUrl);
  }

  // getRecipe(id: number): Observable<Recipe> { }

  getRecipeDetails(): Observable<RecipeDetails> {
    return this._http.get<RecipeDetails>(this._recipeDetailsUrl);
  }
}
