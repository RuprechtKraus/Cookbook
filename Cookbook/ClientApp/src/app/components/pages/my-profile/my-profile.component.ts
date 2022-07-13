import { Component, OnInit } from '@angular/core';

import { RecipeToLoad } from '../../../interfaces/recipe';
import { LocationService } from '../../../services/location.service';
import { RecipesService } from '../../../services/recipes.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {
  hidePass: boolean = true;
  myRecipes: RecipeToLoad[] = [];

  constructor(
    private _recipesService: RecipesService,
    private _locationService: LocationService
  ) { }

  ngOnInit(): void {
    this.getRecipes();
  }

  switchPassField(): void {
    this.hidePass = !(this.hidePass === true)
  }

  getRecipes(): void {
    this._recipesService.getRecipes().
      subscribe((recipes: RecipeToLoad[]) => this.myRecipes = recipes.filter(
        r => (r.id === 1 || r.id === 2)
      ));
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }

}
