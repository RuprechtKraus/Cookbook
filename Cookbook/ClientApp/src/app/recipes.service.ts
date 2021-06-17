import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Recipe } from './interfaces/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {

  constructor(
    private _http: HttpClient
  ) { }

  getRecipes() {
    return this._http.get<Recipe[]>('../assets/data/recipes.json').toPromise();
  }
}
