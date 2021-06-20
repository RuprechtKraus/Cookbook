import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ENTER, SPACE } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';

import { TimeOption } from '../interfaces/time-option';

@Component({
  selector: 'app-recipe-create',
  templateUrl: './recipe-create.component.html',
  styleUrls: ['./recipe-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RecipeCreateComponent implements OnInit {
  selectedTime: number;
  tags: string[] = [];
  timeOptions: TimeOption[] = [
    { value: 30, viewValue: '30 мин' },
    { value: 60, viewValue: '60 мин' },
    { value: 90, viewValue: '90 мин' },
    { value: 120, viewValue: '120 мин' }
  ];
  readonly separatorKeysCodes = [ENTER, SPACE] as const;
  recipeForm = this._formBuilder.group({
    title: "",
    desc: ""
  });

  constructor(
    private _formBuilder: FormBuilder
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
}
