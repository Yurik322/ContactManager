import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './contact/list/list.component';
import { CreateComponent } from './contact/create/create.component';
import { EditComponent } from './contact/edit/edit.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: 'contacts/list', pathMatch: 'full'},
  { path: 'contacts/list', component: ListComponent },
  { path: 'contacts/create', component: CreateComponent },
  { path: 'contacts/edit/:id', component: EditComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }
