import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Profile } from '../models/Profile';
import { AuthService } from '../security/auth.service';

@Injectable()
export class ProfileService {

    private url: string = 'api/Profile';

    constructor(private http: Http, private authService: AuthService) { }

    getProfile() {
        return this.http.get(this.url, { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    addProfile(testData: Profile) {
        return this.http
            .post(this.url, JSON.stringify(testData), { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    editProfile(testData: Profile) {
        return this.http
            .put(this.url, JSON.stringify(testData), { headers: this.authService.authJsonHeaders() })
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    deleteProfile(itemToDelete: Profile) {
        return this.http.delete(this.url + '/' + itemToDelete.id, { headers: this.authService.authJsonHeaders() })
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    // from https://angular.io/docs/ts/latest/guide/server-communication.html
    private handleError(error: Response | any) {
        // In a real world app, we might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}
