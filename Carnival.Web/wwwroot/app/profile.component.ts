import { Component, OnInit } from '@angular/core';
import { ProfileService } from './services/profile.service';
import { TestData } from './models/testData';
import { ViewModelResponse } from './models/viewModelResponse';
import { ErrorResponse } from './models/errorResponse';
import { ErrorMessageService } from './services/ErrorMessageService';
import { Observable } from 'rxjs/Rx';

import { Profile } from './models/Profile';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'profile',
    templateUrl: 'partial/ProfileComponent',
    providers: [ProfileService],
})

export class ProfileComponent implements OnInit {
    profile: Profile = null;
    errorMessage: string;
    tableMode: string = 'list';

    constructor(private profileservice: ProfileService, private errorMessageService: ErrorMessageService) { }

    initTestData(): Profile {
        let newProfile = new Profile();
        newProfile.id = null;
        newProfile.name = null;
        newProfile.bio = null;
        return newProfile;
    }

    ngOnInit() {
        this.getProfile();
        this.profile = this.initTestData();
    }

    changeMode(newMode: string, thisItem: Profile, event: any): void {
        event.preventDefault();
        this.tableMode = newMode;

        switch (newMode) {
            case 'edit':
                this.profile = Object.assign({}, thisItem);
                break;

            case 'list':
            default:
                this.profile = Object.assign({}, thisItem);
                break;
        }
    }

    SaveProfile(event: any) {
        event.preventDefault();
        if (!this.profile) { return; }
        this.profileservice.addProfile(this.profile)
            .subscribe((data: ViewModelResponse) => {
                        this.errorMessageService.showSuccess('Add', "ok");
                         this.tableMode='list'
                },
                (error: any) => {
                    this.errorMessageService.showError('Get', JSON.stringify(error));
                });
    }

    getProfile() {
        this.profileservice.getProfile()
            .subscribe((data: ViewModelResponse) => {
                    if (data != null && data.statusCode === 200) {
                        this.profile = data.value.result;
                    }
                    else if (data == null || data.statusCode === 204) {
                        this.errorMessageService.showError('Get', "No data available");
                    }
                    else {
                        this.errorMessageService.showError('Get', "An error occurred");
                    }
                },
                (error: any) => {
                    this.errorMessageService.showError('Get', JSON.stringify(error));
                });
    }
    // editProfile(event: any) {
    //     event.preventDefault();
    //     if (!this.profile) { return; }
    //     this.profileservice.editProfile(this.profile)
    //         .subscribe((data: ViewModelResponse) => {
    //                 if (data != null && data.statusCode === 200) {
    //                     this.errorMessageService.showSuccess('Update', "updated ok");
    //                     this.profile = data.value;
    //                     this.getProfile();
    //                 }
    //                 else {
    //                     this.errorMessageService.showError('Update', this.errorMessageService.formattedErrorResponse(data.value));
    //                 }
    //             },
    //             (error: any) => {
    //                 this.errorMessageService.showError('Update', JSON.stringify(error));
    //             });
    // }
    //
    // deleteProfile(itemToDelete: Profile, event: any) {
    //     event.preventDefault();
    //     this.profileservice.deleteProfile(itemToDelete)
    //         .subscribe((data: ViewModelResponse) => {
    //                 if (data != null && data.statusCode === 200) {
    //                     this.errorMessageService.showSuccess('Delete', data.value);
    //                     this.getProfile();
    //                 }
    //                 else {
    //                     this.errorMessageService.showError('Delete', "An error occurred");
    //                 }
    //             },
    //             (error: any) => {
    //                 this.errorMessageService.showError('Delete', JSON.stringify(error));
    //             });
    // }
}
