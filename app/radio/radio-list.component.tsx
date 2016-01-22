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
        console.log(this.state);

        let radiosComponents = this.state.radios.map(radio => <RadioComponent radio={radio} />);
        return (
            <ul className="list-group list-group-lg no-bg auto m-b-none m-t-n-xxs">
                <li className="list-group-item clearfix" >
                    {radiosComponents}
                    </li>
                </ul>
        );
    }

    componentDidMount() {
        $.get("https://raw.githubusercontent.com/vmanikandan001/Vaanoli/master/list.json")
            .done(data => {
                console.log(data);
                this.setState({ radios: JSON.parse(data).radios });
            })
            .fail(error => {
                console.log(error);
            });
    }


}