import {Component, ChangeDetectionStrategy} from "angular2/core";
import {CurrentlyPlayingNotificationService} from "./currently-playing-notification.service";

@Component({
    selector: "currently-playing",
    templateUrl: "app/currently-playing/currently-playing.html",
    directives: []
})
export class CurrentlyPlayingComponent {
    radio: any = {name:"lankasri fm", imgName:"lankasri-fm"};
    constructor(private _currentlyPlayingNotificationService: CurrentlyPlayingNotificationService) {
        this.radio = {name:"lankasri fm", imgName:"lankasri-fm"};
        _currentlyPlayingNotificationService.radioChanged.subscribe(radio => this.radio = radio);
    }
}