import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../shared/services/contact.service';
import { Contact } from '../models/contact';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  contacts: Contact[];
  errorMessage: string;
  filter1 = -1;

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.getAllContacts();
  }

  public getAllContacts = () => {
    const apiAddress = 'api/contacts';
    this.contactService.getContacts(apiAddress)
      .subscribe(res => {
          this.contacts = res as Contact[];
        },
        (error) => {
          this.errorMessage = <any>error;
        });
  }

  deleteContact(contact: Contact): void {
    if (confirm('Are you sure you want to delete this contact?')) {
      const deleteUrl = `api/contacts/${contact.id}`;
      this.contactService.deleteContact(deleteUrl)
        .subscribe(result => {
          const index = this.contacts.indexOf(contact);
          if (index > -1) {
            this.contacts.splice(index, 1);
          }
        }, error => this.errorMessage = <any>error);
    }
  }

  marriedToText(married: any) {
    switch (married) {
      case false:
        return 'No';
      case true:
        return 'Yes';
    }
  }
}
