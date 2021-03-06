import { Component, OnInit } from '@angular/core';
import { SampleDataService } from './services/sampleData.service';
import { TestData } from './models/testData';
import { ViewModelResponse } from './models/viewModelResponse';
import { ErrorResponse } from './models/errorResponse';
import { ErrorMessageService } from './services/ErrorMessageService';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Component({
    selector: 'blog',
    templateUrl: 'partial/BlogComponent'
})

export class BlogComponent implements OnInit {
    testDataList: TestData[] = [];
    selectedItem: TestData = null;
    testData: TestData = null;
    tableMode: string = 'list';

    showForm: boolean = true;
    errorMessage: string;

    constructor(private sampleDataService: SampleDataService, private errorMessageService: ErrorMessageService) { }

    initTestData(): TestData {
        var newTestData = new TestData();
        newTestData.id = null;
        newTestData.username = null;
        newTestData.text = null;
        return newTestData;
    }

    ngOnInit() {
        this.tableMode = 'add';
        this.getTestData();
        this.testData = this.initTestData();
        this.selectedItem = new TestData();
    }

    changeMode(newMode: string, thisItem: TestData, event: any): void {
        event.preventDefault();
        this.tableMode = newMode;

        if (this.testDataList.length === 0 || this.testData == null) {
            this.tableMode = 'add';
        }

        switch (newMode) {
            case 'add':
                this.testData = this.initTestData();
                break;

            case 'edit':
                this.testData = Object.assign({}, thisItem);
                break;

            case 'list':
            default:
                this.testData = Object.assign({}, thisItem);
                break;
        }
    }

    selectCurrentItem(thisItem: TestData, event: any) {
        event.preventDefault();
        this.selectedItem = thisItem;
        this.testData = Object.assign({}, thisItem);
    }

    addTestData(event: any) {
        event.preventDefault();
        if (!this.testData) { return; }
        this.sampleDataService.addSampleData(this.testData)
            .subscribe((data: ViewModelResponse) => {
                    if (data != null && data.statusCode == 200) {
                        //use this to save network traffic; just pushes new record into existing
                        this.testDataList.push(data.value);
                        // or keep these 2 lines; subscribe to data, but then refresh all data anyway
                        //this.testData = data.value;
                        //this.getTestData();
                        this.errorMessageService.showSuccess('Add', "data added ok");
                    }
                    else {
                        this.errorMessageService.showError('Add', this.errorMessageService.formattedErrorResponse(data.value));
                    }
                },
                (error: any) => {
                    this.errorMessageService.showError('Get', JSON.stringify(error));
                });
    }

    getTestData() {
        this.sampleDataService.getSampleData()
            .subscribe((data: ViewModelResponse) => {
                    if (data != null && data.statusCode === 200) {
                        this.testDataList = data.value;
                        this.errorMessageService.showSuccess('Get', "data fetched ok");
                        if (this.testDataList != null && this.testDataList.length > 0) {
                            this.selectedItem = this.testDataList[0];
                            this.tableMode = 'list';
                        } else {
                            this.tableMode = 'add';
                        }
                    }
                    else if (data == null || data.statusCode === 204) {
                        this.tableMode = 'add';
                        this.errorMessageService.showError('Get', "No data available");
                    }
                    else {
                        this.tableMode = 'add';
                        this.errorMessageService.showError('Get', "An error occurred");
                    }
                },
                (error: any) => {
                    this.errorMessageService.showError('Get', JSON.stringify(error));
                });
    }

    editTestData(event: any) {
        event.preventDefault();
        if (!this.testData) { return; }
        this.sampleDataService.editSampleData(this.testData)
            .subscribe((data: ViewModelResponse) => {
                    if (data != null && data.statusCode === 200) {
                        this.errorMessageService.showSuccess('Update', "updated ok");
                        this.testData = data.value;
                        this.getTestData();
                    }
                    else {
                        this.errorMessageService.showError('Update', this.errorMessageService.formattedErrorResponse(data.value));
                    }
                },
                (error: any) => {
                    this.errorMessageService.showError('Update', JSON.stringify(error));
                });
    }

    deleteRecord(itemToDelete: TestData, event: any) {
        event.preventDefault();
        this.sampleDataService.deleteRecord(itemToDelete)
            .subscribe((data: ViewModelResponse) => {
                    if (data != null && data.statusCode === 200) {
                        this.errorMessageService.showSuccess('Delete', data.value);
                        this.getTestData();
                    }
                    else {
                        this.errorMessageService.showError('Delete', "An error occurred");
                    }
                },
                (error: any) => {
                    this.errorMessageService.showError('Delete', JSON.stringify(error));
                });
    }
}
