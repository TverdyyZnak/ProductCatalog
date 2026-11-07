import { Component, OnInit } from '@angular/core';
import { JwtModel } from '../../models/JwtModel';
import { Router } from '@angular/router';
import { JwtDecoderService } from '../../services/jwtService/jwt-decoder.service';
import { UserActionService } from '../../services/userActions/user-action.service';
import { UserAction } from '../../models/UserAction';
import { User } from '../../models/User';
import { UserService } from '../../services/users/user.service';

@Component({
  selector: 'app-admin-page',
  imports: [],
  templateUrl: './admin-page.component.html',
  styleUrl: './admin-page.component.css'
})
export class AdminPageComponent implements OnInit {
  isOpen: boolean = false
  userJwt: JwtModel | null = null
  userActions: UserAction[] | null = null
  users: User[] | null = null
  constructor(private router: Router, private jwtService: JwtDecoderService, private userActionService: UserActionService, private userService: UserService) { }
  targetId: string | null = null

  ngOnInit(){
    this.userJwt = this.jwtService.getDecodedToken()
    if(this.userJwt?.role != "Admin"){
      this.router.navigate([])
    }
    this.getUserActions()
    this.getUsers()
  }

  getUserActions(){
    this.userActionService.getUserActions().subscribe({
      next: (resp) => {
        this.userActions = resp
      }
    })
  }

  getUsers(){
    this.userService.getAllUsers().subscribe({
      next: (resp) => {
        this.users = resp
      }
    })
  }

  deleteUser(id: string){
    if(id != this.userJwt?.id){
      this.userService.deleteUser(id).subscribe({
        next: (result) => {
          window.location.reload()
        },
        error: (error: string) => {
          alert("Админ не может удалить сам себя")
        }
      })
    }
  }

  blockUser(id: string){
    if(id != this.userJwt?.id){
      this.userService.blockUser(id).subscribe({
        next: (resp) => {
          window.location.reload()
        }
      })
    }
  }

  unblockUser(id: string){
    if(id != this.userJwt?.id){
      this.userService.unblockUser(id).subscribe({
        next: (resp) => {
          window.location.reload()
        }
      })
    }
  }

  changePassword(id: string, oldPass: string, newPass: string){
    alert(id)
    this.userService.passwodrChange(id, oldPass, newPass).subscribe({
      next: (result) => {

      }
    })
  }



}
