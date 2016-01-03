import {Component} from "angular2/core";
import {RadioListComponent} from "../radio/radio-list.component";

@Component({
    selector: "app-shell",
    templateUrl: "app/shell/shell.html",
    directives: [RadioListComponent]
})
export class ShellComponent{
    test:RadioListComponent;
}