import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersPage } from './users.page';

describe('UsersPage', () => {
  let component: UsersPage;
  let fixture: ComponentFixture<UsersPage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsersPage]
    });
    fixture = TestBed.createComponent(UsersPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
