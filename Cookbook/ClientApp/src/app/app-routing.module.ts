import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainComponent } from './components/pages/main/main.component';
import { RecipesComponent } from './components/pages/recipes/recipes.component';
import { RecipeDetailsComponent } from './components/pages/recipe-details/recipe-details.component';
import { RecipeCreateComponent } from './components/pages/recipe-create/recipe-create.component';
import { MyProfileComponent } from './components/pages/my-profile/my-profile.component';
import { FavoritesComponent } from './components/pages/favorites/favorites.component';


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
