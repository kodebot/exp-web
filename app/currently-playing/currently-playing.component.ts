import {Component} from "angular2/core";

@Component({
    selector: "currently-playing",
    templateUrl: "app/currently-playing/currently-playing.html",
    inputs:["radio"]
})
export class CurrentlyPlayingComponent {
    radio:any;
    constructor() {
    }
    
    
}