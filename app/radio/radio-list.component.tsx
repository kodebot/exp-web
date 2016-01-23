///<reference path="../../typings/react/react.d.ts"/>
///<reference path="../../typings/jquery/jquery.d.ts"/>
import * as React from "react";
import {RadioComponent} from "./radio.component";
import * as $ from "jquery";

export class RadioListComponent extends React.Component<any, any> implements React.ComponentLifecycle<any, any>{
    constructor(props: any) {
        super(props);
        this.state = { radios: [] };
    }

    render() {
        let radiosComponents = this.state.radios.map(radio => <RadioComponent radio={radio} onClick={this.props.onRadioChange.bind(this, radio) }/>);
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
                console.log(data);
                
            })
            .fail(error => {
                console.log(error);
            });
    }


}