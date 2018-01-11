import { Component, OnInit } from '@angular/core';
import {MenuItem, Message} from 'primeng/primeng';
import {StatsService} from '../services/stats.service';

import {Faciltiy} from '../model/facility';

@Component({
  selector: 'liveapp-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

    public bcItems: MenuItem[];
    public bcHome: MenuItem;
    public title: string;
    public statsService: StatsService;

    public facilities: Faciltiy[];
    public errorMessage: Message[];
    public loading: boolean;
    public recordCount: number;

    constructor(statsservice: StatsService) {
        this.statsService = statsservice;
    }

    ngOnInit() {
        this.loading = true;
        this.title = 'Site Uploads';
        this.bcItems = [
            {label: 'Dashboard'}
        ];

        this.bcHome = {icon: 'fa fa-home', url: '/'};

        this.statsService.getSitesCount()
            .subscribe(
                p => {
                    this.recordCount = p;

                },
                e => {
                    this.errorMessage = [];
                    this.errorMessage.push({severity: 'error', summary: 'Error Loading Summary', detail: <any>e});
                },
                () => {
                    this.loading = false;
                    console.log(this.recordCount);
                }
            );

        this.statsService.getSites()
            .subscribe(
                p => {
                    this.facilities = p;
                },
                e => {
                    this.errorMessage = [];
                    this.errorMessage.push({severity: 'error', summary: 'Error Loading Summary', detail: <any>e});
                },
                () => {
                    this.loading = false;
                }
            );
    }

}
