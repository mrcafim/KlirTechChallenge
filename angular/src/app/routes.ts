import { Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

export const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent},
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    { path: 'cart', component: CartComponent },
    { path: 'products', loadChildren: './components/products/products.module#ProductsModule'},
    { path: '**', component: NotFoundComponent},
];