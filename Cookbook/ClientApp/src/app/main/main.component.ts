import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { CategoriesService } from '../categories.service';
import { Category } from '../interfaces/category';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  categories?: Category[] = [];
  searchForm = this._formBuilder.group({
    searchText: ''
  });

  constructor(
    private _categoriesService: CategoriesService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this._categoriesService.getCategories()
      .subscribe(
        (response) => {
          this.categories = response;
        },
        (error) => {
          console.log(error.error);
        })
  }

  onSubmit(): void {
    
  }
}
