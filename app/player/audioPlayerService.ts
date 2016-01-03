import {Injectable, OnInit} from "angular2/core";

declare var document;
declare var $;

@Injectable()
export class AudioPlayerService {
    play(url: string, title: string) {
        let player = $("#jquery_jplayer_1");

        player.jPlayer({
            ready: function() {
                $(this).jPlayer("setMedia", {
                    title: title,
                    m4a: url
                });
                $(this).jPlayer("play");
            },
            cssSelectorAncestor: "#jp_container_1",
            swfPath: "/js", // todo: fix this
            supplied: "m4a, oga",
            useStateClassSkin: true,
            autoBlur: false,
            smoothPlayBar: true,
            keyEnabled: true,
            remainingDuration: true,
            toggleDuration: true
        });
        
        player.jPlayer("setMedia", {title: title,  m4a: url});
        player.jPlayer("play");
    }

}

