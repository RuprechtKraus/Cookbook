import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';

import { Category } from '../../../interfaces/category';
import { CategoriesService } from '../../../services/categories.service';
import { RecipesService } from '../../../services/recipes.service';
import { LocationService } from '../../../services/location.service';
import { RecipePreview } from 'src/app/interfaces/recipe';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  categories: Category[] = [];
  recipes: RecipePreview[] = [];
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
    // this._recipesService.getRecipePreviews().
    //   subscribe((recipes: RecipeToLoad[]) => this.recipes = recipes);
  }

  onSubmit(): void {

  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }

}
