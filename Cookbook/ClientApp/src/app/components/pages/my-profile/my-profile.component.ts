import { Component, OnInit } from '@angular/core';
import { UserDTO } from 'src/app/dtos/user-dto';
import { AccountService } from 'src/app/services/account.service';

import { RecipeToLoad } from '../../../interfaces/recipe';
import { LocationService } from '../../../services/location.service';
import { RecipesService } from '../../../services/recipes.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css'],
})
export class MyProfileComponent implements OnInit {
  hidePass: boolean = true;
  myRecipes: RecipeToLoad[] = [];
  user: UserDTO = {
    name: "",
    login: "",
    about: "",
    recipesCount: 0,
    likesCount: 0,
    favoritesCount: 0
  };

  constructor(
    private _recipesService: RecipesService,
    private _locationService: LocationService,
    private _accountService: AccountService
  ) {
  }

  ngOnInit(): void {
    this.loadUserData();
    this.loadRecipes();
  }

  switchPassField(): void {
    this.hidePass = !(this.hidePass === true);
  }

  loadUserData(): void {
    this._accountService
      .getByID(this._accountService.userValue.userID)
      .subscribe((response) => { this.user = response; });
  }

  loadRecipes(): void {
    this._recipesService
      .getRecipes()
      .subscribe(
        (recipes: RecipeToLoad[]) =>
          (this.myRecipes = recipes.filter((r) => r.id === 1 || r.id === 2))
      );
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }
}
