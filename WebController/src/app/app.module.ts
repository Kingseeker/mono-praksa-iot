import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { ENV_PROVIDERS } from './environment';
import { AgmCoreModule } from '@agm/core';

import { BaasicApp } from 'baasic-sdk-angular';
import { BaasicService } from './baasic.service';
import { MapComponent } from './map.component'

@NgModule({
  bootstrap: [ AppComponent ],
  declarations: [
    AppComponent,
    MapComponent
  ],
  /**
   * Import Angular's modules.
   */
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AgmCoreModule.forRoot({
            apiKey: 'AIzaSyCsw0uYu6GO101Yz5UD9_sbLaxop0ELj-M'
    }),
    BaasicApp.forRoot('robodata', {
            apiRootUrl: "api.baasic.com",
            apiVersion: "v1"      
    })
  ],
  /**
   * Expose our Services and Providers into Angular's dependency injection.
   */
  providers: [
    ENV_PROVIDERS,
    BaasicService
  ]
})
export class AppModule {}
