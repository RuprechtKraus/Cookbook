import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';
import { ModalWindowComponent } from '../modal-window/modal-window.component';
import { ModalWindowService } from '../modal-window/modal-window.service';
import { CustomValidators } from 'src/app/helpers/validators';

@Component({
  selector: 'app-registration-modal',
  templateUrl: './registration-modal.component.html',
  styleUrls: ['./registration-modal.component.css']
})
export class RegistrationModalComponent implements OnInit {
  @ViewChild(ModalWindowComponent) modal: ModalWindowComponent;

  registrationForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private _formBuilder: FormBuilder,
    private _accountService: AccountService,
    private _modalService: ModalWindowService) { }

  ngOnInit(): void {
    this.registrationForm = this._formBuilder.group({
      name: ['', Validators.required],
      login: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirm: ['', Validators.required]
    },
    { validators: CustomValidators.MustMatch("password", "confirm") }
    );
  }

  public get FormControls() {
    return this.registrationForm.controls;
  }
  
  onSubmit(): void {
    this.submitted = true;

    if (this.registrationForm.invalid) {
      return;
    }
    
    this.clearForm();
  }

  close(): void {
    this.modal.close();
    this.clearForm();
  }

  clearForm(): void {
    this.loading = false;
    this.submitted = false;
    this.registrationForm.reset();
  }

  openLoginModal(): void {
    this.close();
    this._modalService.open("login-modal");
  }
}