import {Component, EventEmitter, Output} from "angular2/core";
import {AudioPlayerService} from "../player/audioPlayerService";
import {CurrentlyPlayingNotificationService} from "../currently-playing/currently-playing-notification.service";

@Component({
    selector: "radio",
    templateUrl: "app/radio/radio.html",
    inputs: ["radio"],
    providers: [AudioPlayerService]

})
export class RadioComponent {
    public radio: any
    constructor(
        private _audioPlayerService: AudioPlayerService,
        private _currentlyPlayingNotificationService: CurrentlyPlayingNotificationService) {
    }

    play(radio: any) {
        this._audioPlayerService.play(radio.streamUrl, radio.name);
        this._currentlyPlayingNotificationService.notifyRadioChange(radio);
    }
}