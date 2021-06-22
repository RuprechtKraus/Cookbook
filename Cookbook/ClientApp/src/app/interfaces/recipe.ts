import { Ingredient } from "./ingredient";

interface RecipeBase {
  id: number;
  title: string;
  desc: string;
  author: string;
  tags: string[];
  cookingTime: number;
  persons: number;
  imageUrl: string;
}

export interface RecipeToLoad extends RecipeBase {
  favs: number;
  likes: number;
  imageAlt: string;
}

export interface RecipeToSave extends RecipeBase {
  ingredients: Ingredient[];
  steps: string[];
}