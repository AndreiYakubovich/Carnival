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
    // addTestData(event: any) {
    //     event.preventDefault();
    //     if (!this.testData) { return; }
    //     this.sampleDataService.addSampleData(this.testData)
    //         .subscribe((data: ViewModelResponse) => {
    //                 if (data != null && data.statusCode == 200) {
    //                     //use this to save network traffic; just pushes new record into existing
    //                     this.testDataList.push(data.value);
    //                     // or keep these 2 lines; subscribe to data, but then refresh all data anyway
    //                     //this.testData = data.value;
    //                     //this.getTestData();
    //                     this.errorMessageService.showSuccess('Add', "data added ok");
    //                 }
    //                 else {
    //                     this.errorMessageService.showError('Add', this.errorMessageService.formattedErrorResponse(data.value));
    //                 }
    //             },
    //             (error: any) => {
    //                 this.errorMessageService.showError('Get', JSON.stringify(error));
    //             });
    // }

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
