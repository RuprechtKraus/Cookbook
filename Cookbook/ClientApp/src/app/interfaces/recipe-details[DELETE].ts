interface IngredientsForCategory {
  title: string;
  list: string[];
} 

export interface RecipeDetails {
  categories: IngredientsForCategory[],
  steps: string[];
}