import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateShotComponent } from './update-shot.component';

describe('UpdateShotComponent', () => {
  let component: UpdateShotComponent;
  let fixture: ComponentFixture<UpdateShotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateShotComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateShotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
