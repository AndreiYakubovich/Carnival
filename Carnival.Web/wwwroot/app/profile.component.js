"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var profile_service_1 = require("./services/profile.service");
var ErrorMessageService_1 = require("./services/ErrorMessageService");
var Profile_1 = require("./models/Profile");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var ProfileComponent = (function () {
    function ProfileComponent(profileservice, errorMessageService) {
        this.profileservice = profileservice;
        this.errorMessageService = errorMessageService;
        this.profile = null;
    }
    ProfileComponent.prototype.initTestData = function () {
        var newProfile = new Profile_1.Profile();
        newProfile.id = null;
        newProfile.name = null;
        newProfile.bio = null;
        return newProfile;
    };
    ProfileComponent.prototype.ngOnInit = function () {
        this.getProfile();
        this.profile = this.initTestData();
    };
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
    ProfileComponent.prototype.getProfile = function () {
        var _this = this;
        this.profileservice.getProfile()
            .subscribe(function (data) {
            if (data != null && data.statusCode === 200) {
                _this.profile = data.value.result;
            }
            else if (data == null || data.statusCode === 204) {
                _this.errorMessageService.showError('Get', "No data available");
            }
            else {
                _this.errorMessageService.showError('Get', "An error occurred");
            }
        }, function (error) {
            _this.errorMessageService.showError('Get', JSON.stringify(error));
        });
    };
    return ProfileComponent;
}());
ProfileComponent = __decorate([
    core_1.Component({
        selector: 'profile',
        templateUrl: 'partial/ProfileComponent',
        providers: [profile_service_1.ProfileService],
    }),
    __metadata("design:paramtypes", [profile_service_1.ProfileService, ErrorMessageService_1.ErrorMessageService])
], ProfileComponent);
exports.ProfileComponent = ProfileComponent;
//# sourceMappingURL=profile.component.js.map