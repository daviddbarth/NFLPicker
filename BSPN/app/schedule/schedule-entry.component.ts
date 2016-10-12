import { Component } from '@angular/core';
import { ScheduleService } from './schedule-service';
import { Schedule }           from './schedule';
import { Observable }     from 'rxjs/Observable';

@Component({
    selector: 'nfl-scheduleEntry',
    templateUrl: 'app/schedule/schedule-entry.component.html',
    providers: [ScheduleService]
})
export class ScheduleEntryComponent {

    pageTitle: string = "Schedule Entry";
    pageSubTitle: string = "sub title";
    schedule: Schedule = new Schedule();
    myBody: any;

    constructor(private scheduleService: ScheduleService) { }

    ngOnInit()
    {
        this.scheduleService.getSchedule().subscribe(sch => this.schedule = sch);

        //x.subscribe(s => this.schedule = s);
        //var y = this.schedule.SeasonName;
        
    }

    getSchedule() {
        this.scheduleService.getSchedule();
    }
}



