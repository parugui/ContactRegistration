import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ConfigService {
  private appConfig: Object = null;

  constructor(private readonly http: HttpClient) { }

  loadAppConfig() {
    return this.http.get('./assets/data/appConfig.json')
      .toPromise()
      .then(data => {
        this.appConfig = data;
      });
  }

  public getApiUrl() {
    return this.appConfig["apiUrl"];
  }


 
}
