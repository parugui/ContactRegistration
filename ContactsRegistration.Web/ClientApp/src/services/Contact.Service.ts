import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContact } from "../models/IContact";
import { IResult } from "../models/IResult";
import { ConfigService } from "./config.Service";


@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private readonly http: HttpClient,
    private readonly config: ConfigService) {
    
  }

  List(): Observable<IResult> {

    return <Observable<IResult>>this.http.get(this.config.getApiUrl() + '/Contact/List').pipe(
    );
  }

  Insert(contact: IContact) {
    return <Observable<IResult>>this.http.post(this.config.getApiUrl() + '/Contact', contact).pipe(
    );
  }

  Update(contact: IContact) {
    return <Observable<IResult>>this.http.put(this.config.getApiUrl() + '/Contact', contact).pipe(
    );
  }

  Delete(IdContact: number) {
    return <Observable<IResult>>this.http.delete(this.config.getApiUrl() + '/Contact?IdContact=' + IdContact).pipe(
    );
  }

  Select(IdContact: number) {
    return <Observable<IResult>>this.http.get(this.config.getApiUrl() + '/Contact?IdContact=' + IdContact).pipe(
    );
  }
}
