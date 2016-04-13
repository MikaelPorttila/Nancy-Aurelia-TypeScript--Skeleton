import {Router, RouterConfiguration} from 'aurelia-router'
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

export class App {

    static inject = [HttpClient];
    constructor(httpClient: HttpClient) {
        httpClient.configure(config => {
            config
                .useStandardConfiguration()
                .withBaseUrl('/api')
                .withDefaults({
                    credentials: '*'
                });
        });
    }

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Aurelia';
        config.map([
            { route: ['', 'welcome'], name: 'welcome',      moduleId: 'welcome',      nav: true, title: 'Welcome' },
            { route: 'users',         name: 'users',        moduleId: 'users',        nav: true, title: 'Github Users' },
            { route: 'child-router',  name: 'child-router', moduleId: 'child-router', nav: true, title: 'Child Router' }
        ]);
    }
}
