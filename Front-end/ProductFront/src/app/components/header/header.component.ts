import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtModel } from '../../models/JwtModel';
import { JwtDecoderService } from '../../services/jwtService/jwt-decoder.service';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  userJwt: JwtModel | null = null;

  constructor(private router: Router, private jwtService: JwtDecoderService) { }
  
  ngOnInit() {
    this.userJwt = this.jwtService.getDecodedToken()
  }

  toPage(page: string) {
    this.router.navigate([`/${page}`]);
  }
}
