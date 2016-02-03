///<reference path="../../typings/tsd.d.ts"/>
import * as React from "react";

export class PlayerComponent extends React.Component<any, any>{
    constructor(public props: any) {
        super(props)
    }

    render() {
        return (
            <div id="jp_container_N">
    <div className="jp-type-playlist">
        <div id="jplayer_N" className="jp-jplayer hide"></div>
        <div className="jp-gui">
            <div className="jp-video-play hide">
                <a className="jp-video-play-icon">play</a>
                </div>
            <div className="jp-interface">
                <div className="jp-controls">
                    <div><a className="jp-previous"><i className="icon-control-rewind i-lg"></i></a></div>
                    <div>
                        <a className="jp-play"><i className="icon-control-play i-2x"></i></a>
                        <a className="jp-pause hid"><i className="icon-control-pause i-2x"></i></a>
                        </div>
                    <div><a className="jp-next"><i className="icon-control-forward i-lg"></i></a></div>
                    <div className="hide"><a className="jp-stop"><i className="fa fa-stop"></i></a></div>
                    <div className="jp-progress hidden-xs">
                        <div className="jp-title text-lt">
                            </div>
                        </div>

                    <div className="hidden-xs hidden-sm">
                        <a className="jp-mute" title="mute"><i className="icon-volume-2"></i></a>
                        <a className="jp-unmute hid" title="unmute"><i className="icon-volume-off"></i></a>
                        </div>
                    <div className="hidden-xs hidden-sm jp-volume">
                        <div className="jp-volume-bar dk">
                            <div className="jp-volume-bar-value lter"></div>
                            </div>
                        </div>

                    <div className="hide">
                        <a className="jp-full-screen" title="full screen"><i className="fa fa-expand"></i></a>
                        <a className="jp-restore-screen" title="restore screen"><i className="fa fa-compress text-lt"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        <div className="jp-no-solution hide">
            <span>Update Required</span> To play the media you will need to either update your browser to a recent version
            or update your <a href="http://get.adobe.com/flashplayer/" target="_blank">Flash plugin</a>.
            </div>
        </div>
                </div>
        );
    }
}