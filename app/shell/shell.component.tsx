///<reference path="../../typings/tsd.d.ts"/>

import React from "react";
import {render} from "react-dom";

import {PlayerComponent} from "../player/player.component";
import {RadioListComponent} from "../radio/radio-list.component";
import {CurrentlyPlayingComponent} from "../currently-playing/currently-playing.component";
import {AudioPlayerService} from "../player/audioPlayerService";

export class ShellComponent extends React.Component<any, any> implements React.ComponentLifecycle<any, any>{
    private _audioPlayerService: AudioPlayerService;
    constructor(props: any) {
        super(props);
        this.state = { radios: [], currentIndex: 0 };

        this._audioPlayerService = new AudioPlayerService();
    }
    previousOrNextSelected(prev: boolean) {
        var newRadioIndex = 0;
        if (prev) {
            if (this.state.currentIndex === 0) {
                newRadioIndex = this.state.radios.length - 1;
            } else {
                newRadioIndex = this.state.currentIndex - 1;
            }
        } else {
            if (this.state.currentIndex === this.state.radios.length - 1) {
                newRadioIndex = 0;
            } else {
                newRadioIndex = this.state.currentIndex + 1;
            }
        }
        this.updateCurrentlyPlaying(this.state.radios[newRadioIndex]);
    }

    updateCurrentlyPlaying(radio: any) {
        this.state.radios.forEach((item, index) => {
            if (item.id === radio.id) {
                item.currentlyPlaying = true;
                this.state.currentIndex = index;
            } else {
                item.currenltyPlaying = false;
            }

        });

        this.setState(this.state);
        this._audioPlayerService.play(radio.streamUrl, radio.name);
    }

    componentDidMount() {
        $.get("https://raw.githubusercontent.com/vmanikandan001/Vaanoli/master/list.json")
            .done(data => {
                this.setState({ radios: JSON.parse(data).radios.map(radio => { radio.key = radio.id; return radio; }) });
                if (this.state.radios) {
                    // play the first radio by default
                    this.updateCurrentlyPlaying(this.state.radios[0]);
                }

            })
            .fail(error => {
                console.log(error);
            });
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
                        <section className="col-sm-6 no-padder bg">
                            <section className=" bg-success dker">
                                <PlayerComponent onPreviousOrNext={this.previousOrNextSelected.bind(this) }/>
                            </section>
                            <section className="vbox">
                                <section className="scrollable hover  w-f-md">
                                    <RadioListComponent onRadioChange={this.updateCurrentlyPlaying.bind(this) } radios={this.state.radios}/>
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
                <footer className="bg-success">
                    this is footer
                </footer>
            </section >

        );
    }
}

render(<ShellComponent/>, document.getElementById("mountnode"));