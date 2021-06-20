import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngregientsBlankComponent } from './ingregients-blank.component';

describe('IngregientsBlankComponent', () => {
  let component: IngregientsBlankComponent;
  let fixture: ComponentFixture<IngregientsBlankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngregientsBlankComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IngregientsBlankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
