import { IngredientsSection } from "./ingredients-section";
import { RecipeStep } from "./recipe-step";

export interface RecipeBase {
  recipeID: number;
  name: string;
  description: string;
  timesLiked: number;
  timesFavorited: number;
  cookingTimeInMinutes: number;
  servingsAmount: number;
  user: string;
  tags: string[];
  imageURL: string;
}

export type RecipePreview = RecipeBase;

export interface Recipe extends RecipeBase {
  steps: RecipeStep[];
  ingredientsSections: IngredientsSection[];
}