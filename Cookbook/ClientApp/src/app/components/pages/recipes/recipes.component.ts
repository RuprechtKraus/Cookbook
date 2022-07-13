import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';

import { RecipeToLoad } from '../../../interfaces/recipe';
import { Category } from '../../../interfaces/category';
import { CategoriesService } from '../../../services/categories.service';
import { RecipesService } from '../../../services/recipes.service';
import { LocationService } from '../../../services/location.service';

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
    private _formBuilder: UntypedFormBuilder,
    private _locationService: LocationService
  ) { }

  ngOnInit() {
    this._categoriesService.getCategories().
      subscribe((categories: Category[]) => this.categories = categories);
    this._recipesService.getRecipes().
      subscribe((recipes: RecipeToLoad[]) => this.recipes = recipes);
  }

  onSubmit(): void {

  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }

}
