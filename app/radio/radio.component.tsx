///<reference path="../../typings/react/react.d.ts"/>
import * as React from "react";

export class RadioComponent extends React.Component<any, any>{
    private _imageUrl: string;

    constructor(props: any) {
        super(props);
    }

    render() {
        this._imageUrl = `assets/images/radios/tamil/${this.props.radio.imgName}.jpg`;

        return (
            <li className="list-group-item clearfix" >
                <div>
                    <a href="#" className="jp-play-me pull-right m-t-sm m-l text-md">
                        <i className="icon-control-play text"></i>
                        <i className="icon-control-pause text-active"></i>
                    </a>
                    <a href="#" className="pull-left thumb-sm m-r">
                        <img src= {this._imageUrl} alt="..." />
                    </a>

                    <a className="clear" href="#" onClick ={this.props.onClick}>
                        <span className="block text-ellipsis">{this.props.radio.name}</span>
                        <small className="text-muted">{this.props.radio.description}</small>
                    </a>
                </div >
            </li>
        );
    }
}