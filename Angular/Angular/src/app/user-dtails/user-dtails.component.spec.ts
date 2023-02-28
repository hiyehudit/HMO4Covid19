import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDtailsComponent } from './user-dtails.component';

describe('UserDtailsComponent', () => {
  let component: UserDtailsComponent;
  let fixture: ComponentFixture<UserDtailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserDtailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserDtailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
