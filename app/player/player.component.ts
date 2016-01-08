import {Component} from "angular2/core";
import "../../assets/js/app.js";
import "../../assets/js/app.plugin.js";

@Component({
    selector: "player",
    templateUrl: "app/player/player.html"

})
export class PlayerComponent {
    constructor() {
        alert("test");
    }
}