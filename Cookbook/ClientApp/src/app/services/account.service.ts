import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LoginUserDTO } from '../dtos/login-user-dto';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private _userSubject: BehaviorSubject<LoginUserDTO>;
  public user: Observable<LoginUserDTO>;

  constructor(
    private _router: Router, 
    private _http: HttpClient) {
      this._userSubject = new BehaviorSubject<LoginUserDTO>(JSON.parse(localStorage.getItem("user")));
      this.user = this._userSubject.asObservable();
  }

  public get userValue(): LoginUserDTO {
    return this._userSubject.value;
  }

  login(login: string, password: string): Observable<LoginUserDTO> {
    return this._http.post<LoginUserDTO>("api/user/authenticate", { login, password })
      .pipe(map(user => {
        localStorage.setItem("user", JSON.stringify(user));
        this._userSubject.next(user);
        this._router.navigate(["/"]).then(() => window.location.reload());
        return user;
      }))
  }

  logout(): void {
    localStorage.removeItem("user");
    this._userSubject.next(null);
    this._router.navigate(["/"]).then(() => window.location.reload());
  }
}
