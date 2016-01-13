import {Component, EventEmitter, Output} from "angular2/core";
import {AudioPlayerService} from "../player/audioPlayerService";

@Component({
    selector:"radio",
    templateUrl:"app/radio/radio.html",
    inputs:["radio"],
    providers:[AudioPlayerService]

})
export class RadioComponent{
    public radio:any
    @Output() radioChange:EventEmitter<any>;
    constructor(private _audioPlayerService: AudioPlayerService) {
        this.radioChange = new EventEmitter<any>();
     }

    play(radio:any) {
        this.radioChange.emit(radio);
        this._audioPlayerService.play(radio.streamUrl, radio.name);
    }
}