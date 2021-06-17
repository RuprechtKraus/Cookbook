export interface RecipeDetails {
  categories:
  {
    title: string;
    list: string[];
  }[],
  ingredients: string[];
  steps: string[];
}