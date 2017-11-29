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
    selector: 'my-about',
    templateUrl: 'partial/aboutComponent'
})

export class AboutComponent implements OnInit {
    constructor() { }

    ngOnInit() {

    }


}
