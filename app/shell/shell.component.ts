import {Component} from "angular2/core";
import {RadioListComponent} from "../radio/radio-list.component";
import {PlayerComponent} from "../player/player.component";
import {CurrentlyPlayingComponent} from "../currently-playing/currently-playing.component";

@Component({
    selector: "app-shell",
    templateUrl: "app/shell/shell.html",
    directives: [RadioListComponent, PlayerComponent, CurrentlyPlayingComponent]
})
export class ShellComponent{
    test:RadioListComponent;
}