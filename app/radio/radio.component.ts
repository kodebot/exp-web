import {Component} from "angular2/core";
import {AudioPlayerService} from "../player/audioPlayerService";

@Component({
    selector:"radio",
    templateUrl:"app/radio/radio.html",
    inputs:["radio"],
    providers:[AudioPlayerService]

})
export class RadioComponent{
    public radio:any
    constructor(private _audioPlayerService: AudioPlayerService) { }

    play(radio:any) {
        this._audioPlayerService.play(radio.streamUrl, radio.name);
    }
}