import { Component, ElementRef, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormControl,Validators } from '@angular/forms';
import { UserApi } from 'src/app/api/users/user.api';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { faEllipsisVertical } from '@fortawesome/free-solid-svg-icons';
import { faCircleExclamation } from '@fortawesome/free-solid-svg-icons';
import { User } from 'src/app/api/users/user.model';

class ExpandableUser extends User{
  public expanded: boolean;
  constructor(data: any = null){
    super(data);
    this.expanded=false
  }
}

@Component({
  selector: 'app-users',
  templateUrl: './users.page.html',
  styleUrls: ['./users.page.css'],

})
export class UsersPage {
  public faCircleExclamation = faCircleExclamation;
  public faEllipsisVertical = faEllipsisVertical;
  public users: ExpandableUser[];
  public userid: string;
  public modalTitle: string = "";
  public isCreateUserModalOpen = false;
  public isEditUserModalOpen = false;
  public isDeleteUserModalOpen = false;
  public expandedUser: ExpandableUser;
  public isDropdownOpen: { [key: string]: boolean } = {};   
  public lastOpenedDropdownId: string | null = null;

  public userVariable: User = {
    id: '',
    firstName: '',
    lastName: '',
    email: ''
  };

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private userAPI: UserApi, private elementRef: ElementRef) {
  }

  public ngOnInit(): void {
    this.loadUsers();
  }

  public openModal(modalType: string, user?: User) {
    this.modalTitle = modalType;

    if(modalType === 'Create User') {
     this.isCreateUserModalOpen = true;
     this.userVariable = {
      id: '',
      firstName: '',
      lastName: '',
      email: ''
    };
    } 
    else if(modalType === 'Edit User') {
      this.isEditUserModalOpen = true;
      this.modalTitle = modalType;
        this.userVariable = {
        id: user.id,
        firstName: user.firstName, 
        lastName: user.lastName,
        email: user.email,
      };
    }
    else if (modalType === 'Delete User') {
      this.isDeleteUserModalOpen= true;
    }   
    }
 
    public closeModal(modalType: string) {
    if(modalType === 'Create User'){
      this.isCreateUserModalOpen = false;
      this.loadUsers();
     }   
     else if(modalType === 'Edit User'){
        this.isEditUserModalOpen=false;
     }  
    else if (modalType === 'Delete User') {
          this.isDeleteUserModalOpen = false;
    }
   }

   public toggleDropdown(expandedUser: ExpandableUser){
    if(this.expandedUser!= expandedUser && this.expandedUser != null){     
        this.expandedUser.expanded = false;
    }

    if(expandedUser.expanded){
      expandedUser.expanded=false;
      this.expandedUser=null;
    }else{
      expandedUser.expanded = true;
      this.expandedUser = expandedUser;
    }
  }

  public closeDropdown(){
      if(this.expandedUser != null){
        this.expandedUser.expanded = false;
        this.expandedUser = null;
      }
  }

  public createUser() {
    this.userAPI.CreateUser(this.userVariable).subscribe({
      next: (response) => {
        console.log('Response:', response);
        if(!response.success){
          alert(response.messages.join('\n'));
        }
        else{
          this.userVariable = {
            id: '',
            firstName: '',
            lastName: '',
            email: ''
          };
          this.closeModal('Create User');
          this.loadUsers();
        }
      }
    });
  }

  public updateUser() {
    this.userAPI.UpdateUser(this.userVariable, this.userVariable.id).subscribe({
      next: (response) => {
        console.log(response);

        if(!response.success){
          alert(response.messages.join('\n'));
        }
        else{
          this.loadUsers();

          this.userVariable = {
            id: '',
            firstName: '',
            lastName: '',
            email: ''
          };
        }
      }
    })
  }

  public deleteUser(userId: string) {
    this.userAPI.DeleteUser(userId).subscribe({
      next: (response) => {
        console.log(userId);
        console.log('User deleted successfully', response);
        this.loadUsers();
        this.closeModal('Delete User');
      },
      error: (error) => {
        console.error('Error deleting user', error);
      },
    });
  }

  private loadUsers(): void{
    this.userAPI.GetUsers().subscribe(result=>{
      this.users = result.data.map((user: any)=>new ExpandableUser(user));
    });
  }
}
