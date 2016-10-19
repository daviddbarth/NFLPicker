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
    schedule: Schedule = new Schedule();

    constructor(private scheduleService: ScheduleService) { }

    ngOnInit()
    {
        this.scheduleService.getSchedule().subscribe(sch => this.schedule = sch);

        var box = document.createElement('input');
        var div = document.getElementById('Games');
        document.body.appendChild(box);
        
        //box.innerText = "Hello";
    }

}



