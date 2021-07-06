import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../models/contact';

@Pipe({
  name: 'contactFilter'
})
export class ContactFilterPipe implements PipeTransform {

  transform(value: Contact[], filterBy: string): Contact[] {
    filterBy = filterBy ? filterBy.toLocaleLowerCase() : null;
    return filterBy ? value.filter((contact: Contact) =>
      contact.name.toLocaleLowerCase().indexOf(filterBy) !== -1) : value;
  }

}
