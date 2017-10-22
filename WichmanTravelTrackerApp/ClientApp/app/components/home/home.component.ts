import { Component, Inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from "rxjs/Rx";

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    http: Http;
    baseUrl: string;
    public locations: Location[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Locations').subscribe(result => {
            this.locations = result.json() as Location[];
        }, error => console.error(error));

        this.http = http;
        this.baseUrl = baseUrl;
    }

    addLocation(inputLoc: HTMLInputElement, visit: boolean) {
        let newId = this.locations.length + 1;
        let newLocation = { id: newId, location: inputLoc.value, visited: visit };
        this.createLocation(newLocation as Location);
        this.locations.push(newLocation as Location);
        inputLoc.value = ' ';
    }

    createLocation(location: Location) {
        this.http.post(this.baseUrl + 'api/Locations/', location)
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'))
            .subscribe();

    }

    switchVisited(id: number) {
        this.changeVisited(id);
        let arrIndex = id - 1;                
        this.locations[arrIndex].visited = !this.locations[arrIndex].visited;


    }

    changeVisited(id: number) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        this.http.put(this.baseUrl + 'api/Locations/', id, options)
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'))
            .subscribe();

    }
}

interface Location {
    id: number,
    location: string;
    visited: boolean;

}
