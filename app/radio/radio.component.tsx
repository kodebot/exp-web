///<reference path="../../typings/react/react.d.ts"/>
import * as React from "react";

export class RadioComponent extends React.Component<any, any>{
    constructor(props: any) {
        super(props);
    }

    render() {
        return (
            <div>
                <a href="#" className="jp-play-me pull-right m-t-sm m-l text-md">
                    <i className="icon-control-play text"></i>
                    <i className="icon-control-pause text-active"></i>
                </a>
                <a href="#" className="pull-left thumb-sm m-r">
                    <img src="assets/images/radios/tamil/{{radio.imgName}}.jpg" alt="..." />
                </a>

                <a className="clear" href="#" data-click ="play(radio)">
                   <span className="block text-ellipsis">{this.props.radio.name}</span>
                   <small className="text-muted">{this.props.radio.description}</small>
                </a>
            </div >
        );
    }
}