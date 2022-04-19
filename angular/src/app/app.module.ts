import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PreloadAllModules, RouterModule } from '@angular/router';

import { appRoutes } from './routes';
import { AppComponent } from './components/app/app.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/app/nav-menu/nav-menu.component';
import { FooterComponent } from './components/app/footer/footer.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ShareModule } from './components/shared/share.module';
import { ServiceModule } from './services/services.module';
import { CartComponent } from './components/cart/cart.component';

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    HomeComponent,
    NavMenuComponent,
    NotFoundComponent,
    CartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes, {preloadingStrategy: PreloadAllModules}),
    ShareModule,
    ServiceModule, 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
