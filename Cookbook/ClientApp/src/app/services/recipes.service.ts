import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RecipeToLoad } from '../interfaces/recipe[DELETE]';
import { RecipeDetails } from '../interfaces/recipe-details[DELETE]';
import { Observable } from 'rxjs';
import { Recipe, RecipePreview } from '../interfaces/recipe';
import { RecipeDTO } from '../dtos/recipe-dto';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  private _recipesUrl = '../assets/data/recipes.json';

  constructor(
    private _http: HttpClient
  ) { }

  getRecipePreviews(): Observable<RecipePreview[]> {
    return this._http.get<RecipePreview[]>("api/recipe/GetPreviews");
  }

  getRecipeByID(id: number): Observable<Recipe> {
    return this._http.get<Recipe>(`api/recipe/${id}`);
  }

  createRecipe(recipe: RecipeDTO): Observable<any> {
    return this._http.post("api/recipe", recipe);
  }

  deleteRecipe(id: number): Observable<any> {
    return this._http.delete(`api/recipe/${id}`);
  }
}
