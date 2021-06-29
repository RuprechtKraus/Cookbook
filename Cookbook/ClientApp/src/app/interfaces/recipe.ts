import { Ingredient } from "./ingredient";

interface RecipeBase {
  id?: number;
  title?: string;
  desc?: string;
  user?: string;
  tags?: string[];
  cookingTime?: number;
  servings?: number;
}

export interface RecipeToLoad extends RecipeBase {
  favs: number;
  likes: number;
  imageUrl?: string;
}

export interface RecipeToEdit extends RecipeBase {
  ingredients?: Ingredient[];
  steps?: string[];
}