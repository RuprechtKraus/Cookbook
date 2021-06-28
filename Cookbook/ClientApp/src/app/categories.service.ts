import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';

import { Category } from './interfaces/category';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(
    private _http: HttpClient
  ) { }

  getCategories(): Observable<Category[]> {
    return this._http.get<Category[]>('api/Categories').pipe(catchError(this.handleError));
  }

  getCategory(id: number): Observable<Category> {
    return this._http.get<Category>('api/Categories/' + id).pipe(catchError(this.handleError));
  }


  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
