import { Component, OnInit, ViewEncapsulation, ɵɵtrustConstantResourceUrl } from '@angular/core';
import { ENTER, SPACE } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';

import { TimeOption } from '../interfaces/time-option';
import { Ingredient } from '../interfaces/ingredient';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RecipeCreateComponent implements OnInit {
  readonly separatorKeysCodes = [ENTER, SPACE] as const;
  tags: string[] = [];
  steps: string[] = [""];
  stepsRemovable: boolean = false;
  selectedTime: number;
  ingredients: Ingredient[] = [
    {
      title: "",
      list: ""
    }
  ];
  timeOptions: TimeOption[] = [
    { value: 30, viewValue: '30 мин' },
    { value: 60, viewValue: '60 мин' },
    { value: 90, viewValue: '90 мин' },
    { value: 120, viewValue: '120 мин' }
  ];

  constructor(
  ) { }

  ngOnInit(): void {

  }

  addTag(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.tags.push(value);
    }
    event.input.value = "";
  }

  removeTag(tag: string): void {
    const index = this.tags.indexOf(tag);
    if (index >= 0) {
      this.tags.splice(index, 1);
    }
  }

  addIngredientsCategory(): void {
    this.ingredients.push({
      title: "",
      list: ""
    });
  }

  removeIngredientsCategory(ingToRemove: Ingredient): void {
    const index = this.ingredients.indexOf(ingToRemove);
    if (index > 0) {
      this.ingredients.splice(index, 1);
    }
  }

  addStep(): void {
    this.steps.push("");
    this.stepsRemovable = true;
  }

  removeStep(step: string): void {
    const index = this.steps.indexOf(step);
    if (index > 0) {
      this.steps.splice(index, 1);
      if (this.steps.length === 1) {
        this.stepsRemovable = false;
      }
    }
  }

  onSubmit(): void {
    console.log(this.ingredients);
    console.log(this.steps);
  }

  trackByIndex(index: number, obj: any): number {
    return index;
  }
}
