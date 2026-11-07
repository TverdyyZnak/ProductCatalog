import { inject, Injectable, PLATFORM_ID } from '@angular/core';
import { DOCUMENT, isPlatformBrowser } from '@angular/common';
import { JwtModel } from '../../models/JwtModel';
import { jwtDecode } from 'jwt-decode';

interface AspNetJwtPayload {
  'http://xmlsoap.org'?: string;
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'?: string;
  isBlocked?: string;
  exp?: number;
}

@Injectable({
  providedIn: 'root'
})
export class JwtDecoderService {
  private document = inject(DOCUMENT);
  private platformId = inject(PLATFORM_ID);

  getDecodedToken(): JwtModel | null {
    if (!isPlatformBrowser(this.platformId)) {
      return null;
    }

    const token = this.getCookie('JCook');
    if (!token) {
      return null;
    }

    try {
      const decoded = jwtDecode<AspNetJwtPayload>(token);

      // Маппим значения, используя точные строки-ключи
      return {
        id: decoded['http://xmlsoap.org'] ?? '',
        role: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ?? '',
        isBlocked: decoded.isBlocked === 'True' || decoded.isBlocked === 'true',
        exp: decoded.exp ?? 0
      };
    } catch (error) {
      console.error('Ошибка парсинга JWT:', error);
      return null;
    }
  }

  private getCookie(name: string): string | null {
    if (!this.document || !this.document.cookie) {
      return null;
    }

    const nameLenPlus = (name.length + 1);
    const cookies = this.document.cookie.split(';');

    for (let i = 0; i < cookies.length; i++) {
      const c = cookies[i].trim();
      if (c.substring(0, nameLenPlus) === (name + '=')) {
        return c.substring(nameLenPlus);
      }
    }
    return null;
  }
}
