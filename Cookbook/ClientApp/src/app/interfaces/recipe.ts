export interface Recipe {
  id: number;
  title: string;
  desc: string;
  author: string;
  tags: string[];
  favs: number;
  likes: number;
  cookingTime: number;
  persons: number;
  imageUrl: string;
  imageAlt: string;
}