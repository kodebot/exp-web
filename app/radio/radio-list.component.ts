import {Component, OnInit, Output, EventEmitter} from "angular2/core";
import {Http, HTTP_PROVIDERS}  from "angular2/http";
import "rxjs/add/operator/map";

import {RadioComponent} from "./radio.component";
import {PlayerComponent} from "../player/player.component";

declare var $: any;

@Component({
    selector: "radio-list",
    providers: [HTTP_PROVIDERS],
    directives: [RadioComponent, PlayerComponent],
    templateUrl: "app/radio/radio-list.html",
    inputs:["currentlyPlaying"]

})
export class RadioListComponent {
    radios: any[];
    @Output() radioChange: EventEmitter<any>;
    constructor(private _http: Http) {
        this.radioChange = new EventEmitter<any>();
    }

    ngOnInit() {
        this._http.get("https://raw.githubusercontent.com/vmanikandan001/Vaanoli/master/list.json")
            .map(response => response.json())
            .subscribe(result => this.radios = result.radios);
    }
    
    public currentRadioChanged(radio){
        console.log("list");
        this.radioChange.emit(radio);
    }


}