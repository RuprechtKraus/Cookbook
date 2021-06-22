import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';

import { RecipeToLoad } from '../interfaces/recipe';
import { Category } from '../interfaces/category';
import { CategoriesService } from '../categories.service';
import { RecipesService } from '../recipes.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  categories: Category[] = [];
  recipes: RecipeToLoad[] = [];
  searchForm = this._formBuilder.group({
    searchText: ''
  });

  constructor(
    private _categoriesService: CategoriesService,
    private _recipesService: RecipesService,
    private _formBuilder: FormBuilder,
    private _location: Location
  ) { }

  ngOnInit() {
    this._categoriesService.getCategories()
      .subscribe((categories: Category[]) => this.categories = categories);
    this._recipesService.getRecipes().
      subscribe((recipes: RecipeToLoad[]) => this.recipes = recipes);
  }

  onSubmit(): void {

  }

  goBack(): void {
    // this._location.back();
  }

}
