import {HttpClient} from 'aurelia-fetch-client';
export class Welcome {

    http: HttpClient;

    fetchTest: boolean = false;

    static inject = [HttpClient];
    constructor(http) {
        this.http = http;
    }

    activate() {

        // setup test: fetch data from api.
        this.http.fetch('test').then((response) => {
            this.fetchTest = true;
        });
    }

}

