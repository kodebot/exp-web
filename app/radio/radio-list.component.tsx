///<reference path="../../typings/tsd.d.ts"/>

import React from "react";
import {RadioComponent} from "./radio.component";
import $ from "jquery";

export class RadioListComponent extends React.Component<any, any> implements React.ComponentLifecycle<any, any>{
    constructor(props: any) {
        super(props);
        this.state = { radios: [] };
    }

    render() {
        let radiosComponents = this.state.radios.map(radio => <RadioComponent key={radio.id} radio={radio} onClick={this.props.onRadioChange.bind(this, radio) }/>);
        return (

            <ul className="list-group list-group-lg no-bg auto m-b-none m-t-n-xxs">
                    {radiosComponents}
                </ul>
        );
    }

    componentDidMount() {
        $.get("https://raw.githubusercontent.com/vmanikandan001/Vaanoli/master/list.json")
            .done(data => {
                this.setState({ radios: JSON.parse(data).radios.map(radio => { radio.key = radio.id; return radio; }) });
                if(this.state.radios){
                    // play the first radio by default
                    this.props.onRadioChange(this.state.radios[0]);
                }
                
            })
            .fail(error => {
                console.log(error);
            });
    }


}