import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { setTheme } from 'ngx-bootstrap/utils';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';;

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {LOCALE_ID, DEFAULT_CURRENCY_CODE} from '@angular/core';
import localePt from '@angular/common/locales/pt';
import {DatePipe, registerLocaleData} from '@angular/common';
import { ClientesComponent } from './clientes/clientes.component';
import { DateTimeFormatPipe } from './_helps/DateTimeFormat.pipe';

registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent,
      PedidosComponent,
      ClientesComponent,
      NavComponent,
      DateTimeFormatPipe
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: "pt"
    },
    {
      provide:  DEFAULT_CURRENCY_CODE,
      useValue: 'BRL'
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {
    setTheme('bs4');
    BsDatepickerModule
  }
 }
