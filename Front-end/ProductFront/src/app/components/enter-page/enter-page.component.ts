import { Component, Inject, OnInit } from '@angular/core';
import { JwtDecoderService } from '../../services/jwtService/jwt-decoder.service';
import { JwtModel } from '../../models/JwtModel';
import { UserService } from '../../services/users/user.service';

@Component({
  selector: 'app-enter-page',
  imports: [],
  templateUrl: './enter-page.component.html',
  styleUrl: './enter-page.component.css'
})
export class EnterPageComponent implements OnInit { 

  userJwt: JwtModel | null = null;

  constructor(private userService: UserService, private jwtService: JwtDecoderService) { }

  ngOnInit(){
    this.userJwt = this.jwtService.getDecodedToken()
  }

  login(login: string, password: string){
    this.userService.login(login, password).subscribe({
      next: (resp) => {
        window.location.reload()
      },
      error: (message: string) => {
        alert(message)
      }
    })
  }

  logout(){
    this.userService.logout().subscribe({
      next: (resp) => {
        alert("Выход из системы")
        window.location.reload()
      }
    })
  }

  reg(login: string, pass: string, role: string){
    this.userService.regNewUser(login, pass, role).subscribe({
      next: (resp) =>{
        alert("Новый пользователь создан")
      }
    })
  }
}
