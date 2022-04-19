import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppModule } from '../../app.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule],
    bootstrap: [AppComponent],
    declarations: [FooterComponent]
})
export class AppServerModule { }
