import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';

import { CategoriesService } from '../../../services/categories.service';
import { Category } from '../../../interfaces/category';
import { ModalWindowService } from '../../shared/modal-window/modal-window.service';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements OnInit {
  categories?: Category[] = [];
  searchForm = this._formBuilder.group({
    searchText: '',
  });
  isLoggedIn: boolean = false;

  constructor(
    private _categoriesService: CategoriesService,
    private _formBuilder: UntypedFormBuilder,
    private _modalService: ModalWindowService,
    private _accountServoce: AccountService
  ) {
    this.isLoggedIn = _accountServoce.userValue != null;
  }

  ngOnInit() {
    this._categoriesService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  onSubmit(): void {}

  openModal(id: string) {
    this._modalService.open(id);
  }
}
