import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { Recipe } from '../interfaces/recipe';
import { CategoriesService } from '../categories.service';
import { RecipesService } from '../recipes.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  categories = this._categoriesService.getCategories();
  recipes?: Recipe[] = [];
  searchForm = this._formBuilder.group({
    searchText: ''
  });

  constructor(
    private _categoriesService: CategoriesService,
    private _recipesService: RecipesService,
    private _formBuilder: FormBuilder
  ) { }

  async ngOnInit(): Promise<void> {
    this.recipes = await this._recipesService.getRecipes();
  }

  onSubmit(): void {

  }

}
