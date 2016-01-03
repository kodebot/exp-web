import {Component, OnInit} from "angular2/core";
import {Http, HTTP_PROVIDERS}  from "angular2/http";
import "rxjs/add/operator/map";

import {RadioComponent} from "./radio.component";
import {PlayerComponent} from "../player/player.component";

@Component({
       selector:"radio-list",
       providers: [HTTP_PROVIDERS],
       directives:[RadioComponent, PlayerComponent],
       templateUrl:"app/radio/radio-list.html",

})
export class RadioListComponent {
    radios:any[];
    constructor(private _http:Http){
    }
    
    ngOnInit(){
        this._http.get("https://raw.githubusercontent.com/vmanikandan001/Vaanoli/master/list.json")
        .map(response => response.json())
        .subscribe(result => this.radios = result.radios);
    }
}