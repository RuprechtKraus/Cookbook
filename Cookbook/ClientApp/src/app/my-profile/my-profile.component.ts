import { Component, OnInit } from '@angular/core';

import { RecipeToLoad } from '../interfaces/recipe';
import { RecipeCardComponent } from '../recipe-card/recipe-card.component';
import { RecipesService } from '../recipes.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {
  hidePass: boolean = true;
  myRecipes: RecipeToLoad[] = [];

  constructor(
    private _recipesService: RecipesService
  ) { }

  ngOnInit(): void {
    this.getRecipes();
  }

  switchPassField(): void {
    this.hidePass = !(this.hidePass === true)
  }

  getRecipes(): void {
    this._recipesService.getRecipes().
      subscribe((recipes: RecipeToLoad[]) => this.myRecipes = recipes);
  }

}
