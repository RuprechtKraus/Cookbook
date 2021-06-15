import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Category } from './interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(
    private _http: HttpClient
  ) { }

  getCategories() {
    return this._http.get<Category[]>('../assets/data/categories.json').toPromise();
  }

}
