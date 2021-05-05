import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  
  constructor(
    private _http: HttpClient
  ) { }

  getCategories() {
    return this._http.get<{iconUrl: string, title: string, desc: string}[]>('../assets/data/categories.json');
  }

}
