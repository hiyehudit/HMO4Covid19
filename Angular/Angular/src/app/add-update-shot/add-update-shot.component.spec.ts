import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateShotComponent } from './add-update-shot.component';

describe('AddUpdateShotComponent', () => {
  let component: AddUpdateShotComponent;
  let fixture: ComponentFixture<AddUpdateShotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateShotComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddUpdateShotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
