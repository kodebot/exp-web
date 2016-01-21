///<reference path="../../typings/react/react.d.ts"/>
import * as React from "react";
import {RadioComponent} from "./radio.component";

export class RadioListComponent extends React.Component<any, any>{
    constructor(props: any) {
        super(props);
    }

    render() {
        return (
            <ul className="list-group list-group-lg no-bg auto m-b-none m-t-n-xxs">
                <li className="list-group-item clearfix" >
                    <RadioComponent />
                </li>
            </ul>
        );
    }
}