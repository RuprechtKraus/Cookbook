interface IngredientsForCategory {
  title: string;
  list: string[];
} 

export interface RecipeDetails {
  categories: IngredientsForCategory[],
  ingredients: string[];
  steps: string[];
}