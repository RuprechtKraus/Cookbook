import { Component, OnInit } from '@angular/core';
import { ENTER, SPACE } from '@angular/cdk/keycodes';

import { TimeOption } from '../interfaces/time-option';
import { Ingredient } from '../interfaces/ingredient';
import { MatChipInputEvent } from '@angular/material/chips';
import { ServingOption } from '../interfaces/serving-options';
import { RecipeToEdit } from '../interfaces/recipe';
import { LocationService } from '../location.service';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css'],
})
export class RecipeCreateComponent implements OnInit {
  readonly allowedFileTypes = ['jpeg', 'png'] as const;
  readonly separatorKeysCodes = [ENTER, SPACE] as const;
  tags: string[] = [];
  steps: string[] = [""];
  stepsRemovable: boolean = false;
  selectedTime: number = null;
  recipe: RecipeToEdit = {
    title: null,
    desc: null,
    user: null,
    tags: [],
    cookingTime: null,
    servings: null,
    ingredients: [{
      title: null,
      list: null
    }],
    steps: [ null ]
  };
  timeOptions: TimeOption[] = [
    { value: 30, viewValue: '30' },
    { value: 60, viewValue: '60' },
    { value: 90, viewValue: '90' },
    { value: 120, viewValue: '120' }
  ];
  servingOptions: ServingOption[] = [
    { value: 1, viewValue: '1' },
    { value: 2, viewValue: '2' },
    { value: 3, viewValue: '3' },
    { value: 4, viewValue: '4' },
    { value: 5, viewValue: '5' },
    { value: 6, viewValue: '6 ' }
  ];

  constructor(
    private _locationService: LocationService
  ) { }

  ngOnInit(): void {

  }

  addTag(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.recipe.tags.push(value);
    }
    event.input.value = "";
  }

  removeTag(tag: string): void {
    const index = this.recipe.tags.indexOf(tag);
    if (index >= 0) {
      this.recipe.tags.splice(index, 1);
    }
  }

  addIngredientsCategory(): void {
    this.recipe.ingredients.push({
      title: null,
      list: null
    });
  }

  removeIngredientsCategory(ingToRemove: Ingredient): void {
    const index = this.recipe.ingredients.indexOf(ingToRemove);
    if (index >= 0) {
      this.recipe.ingredients.splice(index, 1);
    }
  }

  addStep(): void {
    this.recipe.steps.push("");
    this.stepsRemovable = true;
  }

  removeStep(step: string): void {
    const index = this.recipe.steps.indexOf(step);
    if (index >= 0) {
      this.recipe.steps.splice(index, 1);
      if (this.recipe.steps.length === 1) {
        this.stepsRemovable = false;
      }
    }
  }

  onSubmit(): void {
    console.log(this.recipe);
  }

  imageUploaded(event: any): void {
    const file = event.target.files[0];
    const fileType = file.type.split('/')[1];

    if (this.allowedFileTypes.includes(fileType)) {
      console.log('File uploaded');
    }
  }

  trackByIndex(index: number, obj: any): number {
    return index;
  }

  onGoBackClick(): void {
    this._locationService.goBack();
  }
}
