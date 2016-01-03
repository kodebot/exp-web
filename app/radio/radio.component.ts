import {Component} from "angular2/core";

@Component({
    selector:"radio",
    templateUrl:"app/radio/radio.html",
    inputs:["radio"]
})
export class RadioComponent{
    public radio:any
}