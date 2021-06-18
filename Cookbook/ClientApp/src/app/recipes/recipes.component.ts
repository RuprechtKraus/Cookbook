import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { Recipe } from '../interfaces/recipe';
import { Category } from '../interfaces/category';
import { CategoriesService } from '../categories.service';
import { RecipesService } from '../recipes.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  categories: Category[] = [];
  recipes: Recipe[] = [];
  searchForm = this._formBuilder.group({
    searchText: ''
  });

  constructor(
    private _categoriesService: CategoriesService,
    private _recipesService: RecipesService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this._categoriesService.getCategories()
      .subscribe((categories: Category[]) => this.categories = categories);
    this._recipesService.getRecipes().
      subscribe((recipes: Recipe[]) => this.recipes = recipes);
  }

  onSubmit(): void {

  }

}
