import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';
import {RouterModule} from '@angular/router';
import {appRoutes} from './app.routing';
import { DashboardComponent } from './dashboard/dashboard.component';
import {TitleBarComponent} from './title-bar/title-bar.component';
import {ContentComponent} from './content/content.component';
import {StatusBarComponent} from './status-bar/status-bar.component';
import {
    BreadcrumbModule, ButtonModule, DataTableModule, MenuModule, MessageModule, MessagesModule, SharedModule,
    ToolbarModule
} from 'primeng/primeng';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {StatsService} from './services/stats.service';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


@NgModule({
    declarations: [
        AppComponent,
        TitleBarComponent,
        ContentComponent,
        StatusBarComponent,
        DashboardComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        MenuModule,
        HttpClientModule,
        CommonModule,
        BreadcrumbModule,
        ToolbarModule,
        ButtonModule,
        DataTableModule,
        SharedModule,
        MessageModule,
        MessagesModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [StatsService],
    bootstrap: [AppComponent]
})
export class AppModule { }
