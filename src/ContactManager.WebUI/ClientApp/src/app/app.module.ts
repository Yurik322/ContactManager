import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ListComponent } from './contact/list/list.component';
import { CreateComponent } from './contact/create/create.component';
import { EditComponent } from './contact/edit/edit.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ContactFilterPipe} from './contact/filters/contact-filter.pipe';
import { ContactFilterByStatusPipe } from './contact/filters/contact-filter-by-status.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ListComponent,
    CreateComponent,
    EditComponent,
    PageNotFoundComponent,
    ContactFilterPipe,
    ContactFilterByStatusPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
