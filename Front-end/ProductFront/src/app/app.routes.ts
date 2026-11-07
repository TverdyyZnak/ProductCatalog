import { Routes } from '@angular/router';
import { MainPageComponent } from './components/main-page/main-page.component';
import { EnterPageComponent } from './components/enter-page/enter-page.component';
import { AdminPageComponent } from './components/admin-page/admin-page.component';

export const routes: Routes = [
    {path: '', component: MainPageComponent},
    {path: 'enter', component: EnterPageComponent},
    {path: 'admin', component: AdminPageComponent}
];
