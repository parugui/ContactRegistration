import { Component, OnInit } from '@angular/core';
import { IContact } from '../../models/IContact';
import { ContactService } from '../../services/Contact.Service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html'
})
export class ContactComponent implements OnInit {

  listContacts: Array<IContact> = [];
  error: string;
  countRegister: string;
  edit: boolean;
  isNaturalPerson: boolean = true;
  contact: IContact = {
    idContact: null, name: "", cpf: "", birthday: null, gender: 1, companyName: "", tradeName: "", cnpj: "", zipCode: "", country: "",
    state: "", city: "",  addressLine1: "", addressLine2: ""
  }

  nameHasError: boolean = false;
  cpfHasError: boolean = false;
  companyNameHasError: boolean = false;
  companyCnpjHasError: boolean = false;

  constructor(private readonly contactService: ContactService) {}

  ngOnInit(): void {
    this.Initialize();
    this.Search();
  }

  Initialize() {
    this.error = "";
    this.countRegister = "";
    this.edit = false;
    this.isNaturalPerson = true;
    this.nameHasError = false;
    this.cpfHasError = false;
    this.companyNameHasError = false;
    this.companyCnpjHasError = false;
  }

  Search() {
    this.contactService.List().subscribe(
      data => {
        if (data !== undefined) {
          if (data.friendlyErrorMessage !== null && data.friendlyErrorMessage !== undefined && data.friendlyErrorMessage.trim() !== "") {
            this.countRegister = data.friendlyErrorMessage;
          }
          else {
            this.listContacts = data.data as Array<IContact>;
          }
        }
      },
      error => {
        this.HandlerError(error);
      }
    );
  }

  Delete(idContact: number) {
    this.error = "";
    this.contactService.Delete(idContact).subscribe(
      data => {
        if (data !== null && data !== undefined) {
          if (data.friendlyErrorMessage !== null && data.friendlyErrorMessage !== undefined && data.friendlyErrorMessage.trim() !== "") {
            this.HandlerError(data.friendlyErrorMessage);
          }
        }
        else {
          this.back();
        }
      },
      error => {
        this.HandlerError(error);
      }
    );
  }

  Edit(idContact: number) {
    this.error = "";
    this.contactService.Select(idContact).subscribe(
      data => {
        if (data !== null && data !== undefined) {
          if (data.friendlyErrorMessage !== null && data.friendlyErrorMessage !== undefined && data.friendlyErrorMessage.trim() !== "") {
            this.HandlerError(data.friendlyErrorMessage);
          }
          else {
            this.contact = data.data as IContact;
            var cpf = this.contact.cpf;

            if (cpf !== null && cpf !== undefined && cpf !== "")
              this.isNaturalPerson = true;
            else
              this.isNaturalPerson = false;

            this.edit = true;

          }
        }
        else {
          this.back();
        }
      },
      error => {
        this.HandlerError(error);
      }
    );
  }

  back() {
    this.Initialize();
    this.Search();
  }

  AddContact() {
    this.edit = true;
    this.contact.idContact = null;
    this.contact.name = "";
    this.contact.cpf = "";
    this.contact.birthday = null;
    this.contact.gender = 1;
    this.contact.companyName = "";
    this.contact.tradeName = "";
    this.contact.cnpj = "";
    this.contact.zipCode = "";
    this.contact.country = "";
    this.contact.state = "";
    this.contact.city = "";
    this.contact.addressLine1 = "";
    this.contact.addressLine2 = "";

  }

  updateBirthDate(event) {
    var data: string = event.target.value;
    this.contact.birthday = data;

  }

  save() {

    this.CleanPersonControl();
    this.validateFields();

    if (this.companyNameHasError ||
      this.companyCnpjHasError ||
      this.nameHasError ||
      this.cpfHasError) {
      return;
    }

    if (this.contact.idContact === null) {
      this.Insert();
    }
    else
      this.Update();
  }

  CleanPersonControl() {

    if (this.isNaturalPerson) {
      this.contact.companyName = "";
      this.contact.tradeName = "";
      this.contact.cnpj = "";
      this.companyNameHasError = false;
      this.companyCnpjHasError = false;
    }
    else {
      this.contact.name = "";
      this.contact.cpf = "";
      this.contact.birthday = "";
      this.nameHasError = false;
      this.cpfHasError = false;
    }
  }

  Insert() {
    this.contactService.Insert(this.contact).subscribe(
      data => {
        if (data !== null && data !== undefined) {
          if (data.friendlyErrorMessage !== null && data.friendlyErrorMessage !== undefined && data.friendlyErrorMessage.trim() !== "") {
            this.countRegister = data.friendlyErrorMessage;
          }

        }
        else {
          this.back();
        }
      },
      error => {
        this.HandlerError(error);
      }
    );

  }

  Update() {
    this.contactService.Update(this.contact).subscribe(
      data => {
        if (data !== null && data !== undefined) {
          if (data.friendlyErrorMessage !== null && data.friendlyErrorMessage !== undefined && data.friendlyErrorMessage.trim() !== "") {
            this.countRegister = data.friendlyErrorMessage;
          }

        }
        else {
          this.back();
        }
      },
      error => {
        this.HandlerError(error);
      }
    );
  }

  selectedGenderType(event) {
    const selectElement = event.target;
    this.contact.gender = selectElement.selectedIndex +1;
  }

  validateContactName() {

    var name = this.contact.name;

    if (name !== null && name !== undefined && name !== "") {
      this.nameHasError = false;
    }
    else {
      this.nameHasError = true;

    }
  }
  validateContactCPF() {

    var cpf = this.contact.cpf;

    if (cpf !== null && cpf !== undefined && cpf !== "" && cpf.length === 11) {
      this.cpfHasError = false;
    }
    else {
      this.cpfHasError = true;

    }
  }
  validateCompanyName() {

    var value = this.contact.companyName;

    if (value !== null && value !== undefined && value !== "") {
      this.companyNameHasError = false;
    }
    else {
      this.companyNameHasError = true;

    }
  }

  validateCompanyCNPJ() {

    var value = this.contact.cnpj;

    if (value !== null && value !== undefined && value !== "" && value.length === 14) {
      this.companyCnpjHasError = false;
    }
    else {
      this.companyCnpjHasError = true;

    }
  }
  
  

  validateFields() {

    if (this.isNaturalPerson) {
      this.validateContactName();
      this.validateContactCPF();
    }
    else {
      this.validateCompanyName();
      this.validateCompanyCNPJ();
    }
  }

  HandlerError(error: string) {
    this.error = error;
  }
  
}
