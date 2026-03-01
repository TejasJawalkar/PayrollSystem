import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
import { ShowMessageBoxInput } from '../../../core/modules/classes/MessageBoxInput';

@Injectable({
  providedIn: 'root',
})
export class MessageBoxService {
  constructor() {}
  ShowMessageBox(messageBox: ShowMessageBoxInput) {
    Swal.fire({
      title: messageBox.title,
      text: messageBox.text,
      icon: messageBox.icon as any,
      grow: messageBox.grow ? 'row' : false,
      confirmButtonText: messageBox.confirmButtonText,
      confirmButtonColor: messageBox.confirmButtonColor,
    });
  }
}
