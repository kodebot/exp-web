///<reference path="../../typings/react/react.d.ts"/>
///<reference path="../../typings/react/react-dom.d.ts"/>
import * as React from "react";
import {render} from "react-dom";

import {PlayerComponent} from "../player/player.component";
import {RadioListComponent} from "../radio/radio-list.component";
import {CurrentlyPlayingComponent} from "../currently-playing/currently-playing.component";
import {AudioPlayerService} from "../player/audioPlayerService";

export class ShellComponent extends React.Component<any, any>{
    private _audioPlayerService: AudioPlayerService;
    constructor(props: any) {
        super(props);
        this.state = { currentRadio: {} };

        this._audioPlayerService = new AudioPlayerService();
    }

    updateCurrentlyPlaying(radio: any) {
        this.setState({ currentRadio: radio });
        this._audioPlayerService.play(radio.streamUrl, radio.name);
    }

    render() {
        return (
            <section className="vbox">
                <section className="w-f-md">
                    <section className="hbox stretch bg-black dker">
                        <section className="col-sm-2 no-padder lt">
                            <section className="vbox">
                                ads here
                                </section>
                            </section>
                            <aside className="col-sm-3 no-padder" id="sidebar">
                            <section className="vbox animated fadeInUp">
                                <section className="scrollable">
                                        <CurrentlyPlayingComponent radio={this.state.currentRadio}/>
                                    </section>
                                </section>
                                </aside>
                            <section className="col-sm-4 no-padder bg">
                                <section className="vbox">
                                    <section className="scrollable hover">
                                        <RadioListComponent onRadioChange={this.updateCurrentlyPlaying.bind(this) }/>
                                        </section>
                                    </section>
                                </section>
                            <section className="col-sm-2 no-padder lt">
                                <section className="vbox">
                                    ads here
                                    </section>
                                </section>
                        </section>
                    </section>
                        <footer className="footer bg-success dker">
                            <PlayerComponent />
                            </footer >
                </section >

        );
    }
}

render(<ShellComponent/>, document.getElementById("mountnode"));