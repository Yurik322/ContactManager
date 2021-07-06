import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../models/contact';

@Pipe({
  name: 'contactFilterByStatus'
})
export class ContactFilterByStatusPipe implements PipeTransform {

  transform(value: Contact[], filter: any): Contact[] {

    filter = filter > -1 ? filter : null;
    return filter ? value.filter((contact: Contact) =>
      contact.married == filter) : value;
  }
}
