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
        this.tableMode = 'list';
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
    ProfileComponent.prototype.changeMode = function (newMode, thisItem, event) {
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
    };
    ProfileComponent.prototype.SaveProfile = function (event) {
        var _this = this;
        event.preventDefault();
        if (!this.profile) {
            return;
        }
        this.profileservice.addProfile(this.profile)
            .subscribe(function (data) {
            _this.errorMessageService.showSuccess('Add', "ok");
            _this.tableMode = 'list';
        }, function (error) {
            _this.errorMessageService.showError('Get', JSON.stringify(error));
        });
    };
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