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

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    HomeComponent,
    NavMenuComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes, {preloadingStrategy: PreloadAllModules}),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
