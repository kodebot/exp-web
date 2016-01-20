///<reference path="../../typings/react/react.d.ts"/>
///<reference path="../../typings/react/react-dom.d.ts"/>
import * as React from "react";
import {render} from "react-dom";

export class ShellComponent extends React.Component<any, any>{
    constructor(props: any) {
        super(props);
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
                        // side content - currently playing image and comments
                        <aside className="col-sm-3 no-padder" id="sidebar">
                            <section className="vbox animated fadeInUp">
                                <section className="scrollable">
                                    //currently playing
                                    </section>
                                </section>
                            </aside>
                            //side content -currently playing image and comments
                            <section className="col-sm-4 no-padder bg">
                                <section className="vbox">
                                    <section className="scrollable hover">
                                        // radio-list
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
                            // player
                            </footer >
                </section >
            // <a href="#" className="hide nav-off-screen-block" data-toggle="class:nav-off-screen,open" data-target="#nav,html"></a>
        );
    }
}

render(<ShellComponent/>, document.getElementById("mountnode"));