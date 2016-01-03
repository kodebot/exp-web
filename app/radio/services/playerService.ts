// this uses audio web api - not currently used due to CORS issue.
import {Injectable} from "angular2/core";

@Injectable()
export class PlayerService {
    // reference : http://www.html5rocks.com/en/tutorials/webaudio/intro/
    private static _context: AudioContext;

    constructor() {
        PlayerService._context = PlayerService._context || new AudioContext();
    }

    play(url: string): void {
        this.loadUrl(url)
            .then((buffer) => this.playBuffer(buffer))
            .catch(this.onError);
    }

    private loadUrl(url: string): Promise<AudioBuffer> {
        var request = new XMLHttpRequest();
        request.open('GET', url, true);
        request.responseType = 'arraybuffer';

        // Decode asynchronously
        var decodePromise = new Promise((resolve, reject) => {
            request.onload = () => {
                PlayerService._context.decodeAudioData(request.response, (buffer) => resolve(buffer), () => reject("error"));
            }
            request.send();
        });

        return decodePromise;
    }

    private playBuffer(buffer: AudioBuffer) {
        var source = PlayerService._context.createBufferSource(); // creates a sound source
        source.buffer = buffer;                    // tell the source which sound to play
        source.connect(PlayerService._context.destination);       // connect the source to the context's destination (the speakers)
        source.start(0);                           // play the source now
        // note: on older systems, may have to use deprecated noteOn(time);
    }

    private onError(error: any) {
        console.log(error);
        
     }
}