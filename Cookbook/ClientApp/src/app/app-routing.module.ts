import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainComponent } from './main/main.component';
import { RecipesComponent } from './recipes/recipes.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { RecipeCreateComponent } from './recipe-create/recipe-create.component';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { FavoritesComponent } from './favorites/favorites.component';


const routes: Routes = [
  { path: '', component: MainComponent },
  { path: 'recipes', component: RecipesComponent },
  { path: 'details/:id', component: RecipeDetailsComponent },
  { path: 'create', component: RecipeCreateComponent },
  { path: 'my-profile', component: MyProfileComponent },
  { path: 'favorites', component: FavoritesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
