import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { CategoriesService } from '../categories.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  categories = this._categoriesService.getCategories();
  searchForm = this._formBuilder.group({
    searchText: ''
  });

  constructor(
    private _categoriesService: CategoriesService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {

  }

  onSubmit(): void {
    
  }

}
