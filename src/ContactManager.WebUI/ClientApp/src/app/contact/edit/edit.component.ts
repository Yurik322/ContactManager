import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact';
import { ContactService } from '../../shared/services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  contact: Contact;
  id: number;
  errorMessage: string;

  constructor(private contactService: ContactService,
              private activatedRoute: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.id = +this.activatedRoute.snapshot.params['id'];
    if (this.id >= 0) {
      const contactByIdUrl = `api/contacts/${this.id}`;
      this.contactService.getData(contactByIdUrl).subscribe(result => {
        this.contact = <Contact>result;
      }, error => this.errorMessage = <any>error);
    }
  }

  onSubmit(form: NgForm) {
    const apiUrl = `api/contacts/${this.contact.id}`;
    this.contactService.updateContact(apiUrl, this.contact)
      .subscribe(result => {
        this.router.navigate(['/contacts/list']);
      }, error => this.errorMessage = error);
  }

}
