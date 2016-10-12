import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent }  from './app.component';
import { ScheduleEntryComponent } from './schedule/schedule-entry.component';
import './rxjs-operators';

@NgModule({
    imports: [BrowserModule, HttpModule, JsonpModule ],
    declarations: [AppComponent, ScheduleEntryComponent ],
    bootstrap: [AppComponent]
})
export class AppModule { }
