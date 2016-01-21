import {Injectable, EventEmitter} from "angular2/core";


@Injectable()
export class CurrentlyPlayingNotificationService {
    radioChanged: EventEmitter<any>;

    constructor() {
        this.radioChanged = new EventEmitter<any>();
    }

    notifyRadioChange(radio: any) {
        this.radioChanged.emit(radio);
    }
}