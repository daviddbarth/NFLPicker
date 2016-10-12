import { Injectable }     from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Schedule }           from './schedule';
import { Observable }     from 'rxjs/Observable';

@Injectable()
export class ScheduleService {

    private scheduleUrl: string = 'http://localhost:52807/api/Schedule';  // URL to web API

    constructor(private http: Http) { }

    getSchedule(): Observable<Schedule> {
        return this.http.get(this.scheduleUrl, { headers: this.getHeaders()})
            .map(this.extractData)
            .catch(this.handleError);
    }

    extractData(res: Response): Schedule {
        let body = res.json();
        //return body.data || {};
        return toSchedule(body);
        //return body.results.map(toSchedule);
        
    }

//    function toPerson(r: any): Person {
//    let person = <Person>({
//        id: extractId(r),
//        url: r.url,
//        name: r.name,
//        weight: r.mass,
//        height: r.height,
//    });
//    console.log('Parsed person:', person);
//    return person;
//}

    private getHeaders() {
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        return headers;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}

function toSchedule(r: any): Schedule {
    let schedule = <Schedule>({
        SeasonName: r.SeasonName,
        Value: r.Value
    });
    return schedule;
}
