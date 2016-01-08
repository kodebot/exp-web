import {Component} from "angular2/core";
import {RadioListComponent} from "../radio/radio-list.component";
import {PlayerComponent} from "../player/player.component";
import "../../assets/js/app.js";
import "../../assets/js/app.plugin.js";

@Component({
    selector: "app-shell",
    templateUrl: "app/shell/shell.html",
    directives: [RadioListComponent, PlayerComponent]
})
export class ShellComponent{
    test:RadioListComponent;
}