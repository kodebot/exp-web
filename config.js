System.config({
  baseURL: "/",
  defaultJSExtensions: true,
  transpiler: "typescript",
  typescriptOptions: {
    "tsconfig": true
  },
  paths: {
    "npm:*": "jspm_packages/npm/*",
    "github:*": "jspm_packages/github/*"
  },
  bundles: {
    "app.bundle.js": [
      "app/boot.js",
      "github:twbs/bootstrap@3.3.6.js",
      "app/shell/shell.component.js",
      "github:twbs/bootstrap@3.3.6/css/bootstrap.css!github:systemjs/plugin-css@0.1.20.js",
      "npm:animate.css@3.4.0//animate.css!github:systemjs/plugin-css@0.1.20.js",
      "npm:font-awesome@4.5.0/css/font-awesome.css!github:systemjs/plugin-css@0.1.20.js",
      "npm:simple-line-icons@2.2.3/css/simple-line-icons.css!github:systemjs/plugin-css@0.1.20.js",
      "assets/css/font.css!github:systemjs/plugin-css@0.1.20.js",
      "assets/css/jplayer.flat.css!github:systemjs/plugin-css@0.1.20.js",
      "assets/css/app.css!github:systemjs/plugin-css@0.1.20.js",
      "assets/css/styles.css!github:systemjs/plugin-css@0.1.20.js",
      "app/radio/radio-list.component.js",
      "npm:react@0.14.6.js",
      "npm:react-dom@0.14.6.js",
      "github:twbs/bootstrap@3.3.6/js/bootstrap.js",
      "app/player/player.component.js",
      "app/player/audioPlayerService.js",
      "app/radio/radio.component.js",
      "npm:react@0.14.6/react.js",
      "npm:jplayer@2.9.2.js",
      "npm:react-dom@0.14.6/index.js",
      "github:components/jquery@2.2.0.js",
      "npm:jquery@2.2.0.js",
      "npm:react@0.14.6/lib/React.js",
      "npm:jplayer@2.9.2/dist/jplayer/jquery.jplayer.js",
      "npm:react@0.14.6/lib/ReactDOM.js",
      "github:components/jquery@2.2.0/jquery.js",
      "npm:jquery@2.2.0/dist/jquery.js",
      "npm:react@0.14.6/lib/Object.assign.js",
      "npm:react@0.14.6/lib/ReactCurrentOwner.js",
      "npm:react@0.14.6/lib/ReactDOMServer.js",
      "npm:react@0.14.6/lib/ReactIsomorphic.js",
      "npm:react@0.14.6/lib/deprecated.js",
      "npm:react@0.14.6/lib/ReactVersion.js",
      "npm:fbjs@0.6.1/lib/ExecutionEnvironment.js",
      "npm:react@0.14.6/lib/ReactReconciler.js",
      "npm:react@0.14.6/lib/renderSubtreeIntoContainer.js",
      "github:jspm/nodelibs-process@0.1.2.js",
      "npm:react@0.14.6/lib/ReactDOMTextComponent.js",
      "npm:react@0.14.6/lib/ReactPerf.js",
      "npm:fbjs@0.6.1/lib/warning.js",
      "npm:react@0.14.6/lib/ReactInstanceHandles.js",
      "npm:react@0.14.6/lib/ReactDefaultInjection.js",
      "npm:react@0.14.6/lib/ReactMount.js",
      "npm:react@0.14.6/lib/ReactUpdates.js",
      "npm:react@0.14.6/lib/findDOMNode.js",
      "npm:react@0.14.6/lib/ReactElement.js",
      "npm:react@0.14.6/lib/ReactServerRendering.js",
      "npm:react@0.14.6/lib/ReactChildren.js",
      "npm:react@0.14.6/lib/ReactComponent.js",
      "npm:react@0.14.6/lib/ReactDOMFactories.js",
      "npm:react@0.14.6/lib/ReactClass.js",
      "npm:react@0.14.6/lib/ReactElementValidator.js",
      "npm:react@0.14.6/lib/onlyChild.js",
      "npm:react@0.14.6/lib/escapeTextContentForBrowser.js",
      "npm:fbjs@0.6.1/lib/emptyFunction.js",
      "npm:react@0.14.6/lib/ReactRootIndex.js",
      "npm:react@0.14.6/lib/ClientReactRootIndex.js",
      "npm:react@0.14.6/lib/ServerReactRootIndex.js",
      "npm:react@0.14.6/lib/ReactDOMFeatureFlags.js",
      "npm:react@0.14.6/lib/ReactEmptyComponentRegistry.js",
      "npm:react@0.14.6/lib/ReactInstanceMap.js",
      "npm:react@0.14.6/lib/shouldUpdateReactComponent.js",
      "npm:react@0.14.6/lib/ReactInjection.js",
      "npm:react@0.14.6/lib/ReactReconcileTransaction.js",
      "npm:react@0.14.6/lib/SVGDOMPropertyConfig.js",
      "npm:react@0.14.6/lib/ReactMarkupChecksum.js",
      "npm:fbjs@0.6.1/lib/containsNode.js",
      "npm:react@0.14.6/lib/ReactRef.js",
      "github:jspm/nodelibs-process@0.1.2/index.js",
      "npm:react@0.14.6/lib/ReactComponentBrowserEnvironment.js",
      "npm:fbjs@0.6.1/lib/invariant.js",
      "npm:react@0.14.6/lib/ReactBrowserEventEmitter.js",
      "npm:fbjs@0.6.1/lib/emptyObject.js",
      "npm:react@0.14.6/lib/ReactPropTypes.js",
      "npm:react@0.14.6/lib/DOMChildrenOperations.js",
      "npm:react@0.14.6/lib/DOMPropertyOperations.js",
      "npm:react@0.14.6/lib/setTextContent.js",
      "npm:react@0.14.6/lib/validateDOMNesting.js",
      "npm:react@0.14.6/lib/BeforeInputEventPlugin.js",
      "npm:react@0.14.6/lib/ChangeEventPlugin.js",
      "npm:react@0.14.6/lib/DefaultEventPluginOrder.js",
      "npm:react@0.14.6/lib/EnterLeaveEventPlugin.js",
      "npm:react@0.14.6/lib/HTMLDOMPropertyConfig.js",
      "npm:react@0.14.6/lib/ReactBrowserComponentMixin.js",
      "npm:react@0.14.6/lib/ReactDefaultBatchingStrategy.js",
      "npm:react@0.14.6/lib/ReactDOMComponent.js",
      "npm:react@0.14.6/lib/ReactEventListener.js",
      "npm:react@0.14.6/lib/SelectEventPlugin.js",
      "npm:react@0.14.6/lib/SimpleEventPlugin.js",
      "npm:react@0.14.6/lib/ReactDefaultPerf.js",
      "npm:react@0.14.6/lib/DOMProperty.js",
      "npm:react@0.14.6/lib/ReactUpdateQueue.js",
      "npm:react@0.14.6/lib/instantiateReactComponent.js",
      "npm:react@0.14.6/lib/setInnerHTML.js",
      "npm:react@0.14.6/lib/CallbackQueue.js",
      "npm:react@0.14.6/lib/PooledClass.js",
      "npm:react@0.14.6/lib/Transaction.js",
      "npm:react@0.14.6/lib/ReactServerBatchingStrategy.js",
      "npm:fbjs@0.6.1/lib/mapObject.js",
      "npm:fbjs@0.6.1/lib/keyOf.js",
      "npm:react@0.14.6/lib/getIteratorFn.js",
      "npm:react@0.14.6/lib/adler32.js",
      "npm:react@0.14.6/lib/ReactEmptyComponent.js",
      "npm:fbjs@0.6.1/lib/isTextNode.js",
      "npm:process@0.11.2.js",
      "npm:react@0.14.6/lib/canDefineProperty.js",
      "npm:fbjs@0.6.1/lib/keyMirror.js",
      "npm:react@0.14.6/lib/ReactPropTypeLocationNames.js",
      "npm:react@0.14.6/lib/ReactServerRenderingTransaction.js",
      "npm:react@0.14.6/lib/traverseAllChildren.js",
      "npm:react@0.14.6/lib/ReactNoopUpdateQueue.js",
      "npm:react@0.14.6/lib/ReactPropTypeLocations.js",
      "npm:react@0.14.6/lib/ReactComponentEnvironment.js",
      "npm:react@0.14.6/lib/EventPluginHub.js",
      "npm:react@0.14.6/lib/ReactNativeComponent.js",
      "npm:react@0.14.6/lib/ReactInputSelection.js",
      "npm:react@0.14.6/lib/ReactOwner.js",
      "npm:react@0.14.6/lib/ReactDOMIDOperations.js",
      "npm:react@0.14.6/lib/EventConstants.js",
      "npm:react@0.14.6/lib/EventPluginRegistry.js",
      "npm:react@0.14.6/lib/isEventSupported.js",
      "npm:react@0.14.6/lib/ViewportMetrics.js",
      "npm:react@0.14.6/lib/isTextInputElement.js",
      "npm:react@0.14.6/lib/getEventTarget.js",
      "npm:react@0.14.6/lib/ReactDOMButton.js",
      "npm:fbjs@0.6.1/lib/shallowEqual.js",
      "npm:fbjs@0.6.1/lib/getActiveElement.js",
      "npm:fbjs@0.6.1/lib/getUnboundedScrollPosition.js",
      "npm:react@0.14.6/lib/getEventCharCode.js",
      "npm:react@0.14.6/lib/ReactEventEmitterMixin.js",
      "npm:react@0.14.6/lib/FallbackCompositionState.js",
      "npm:react@0.14.6/lib/SyntheticCompositionEvent.js",
      "npm:react@0.14.6/lib/SyntheticInputEvent.js",
      "npm:react@0.14.6/lib/SyntheticMouseEvent.js",
      "npm:react@0.14.6/lib/SyntheticFocusEvent.js",
      "npm:react@0.14.6/lib/SyntheticKeyboardEvent.js",
      "npm:react@0.14.6/lib/SyntheticTouchEvent.js",
      "npm:react@0.14.6/lib/SyntheticDragEvent.js",
      "npm:react@0.14.6/lib/SyntheticUIEvent.js",
      "npm:react@0.14.6/lib/SyntheticClipboardEvent.js",
      "npm:react@0.14.6/lib/SyntheticWheelEvent.js",
      "npm:react@0.14.6/lib/ReactDefaultPerfAnalysis.js",
      "npm:react@0.14.6/lib/quoteAttributeValueForBrowser.js",
      "npm:fbjs@0.6.1/lib/performanceNow.js",
      "npm:react@0.14.6/lib/ReactMultiChild.js",
      "npm:fbjs@0.6.1/lib/EventListener.js",
      "npm:react@0.14.6/lib/Danger.js",
      "npm:react@0.14.6/lib/ReactMultiChildUpdateTypes.js",
      "npm:react@0.14.6/lib/EventPropagators.js",
      "npm:react@0.14.6/lib/SyntheticEvent.js",
      "npm:react@0.14.6/lib/AutoFocusUtils.js",
      "npm:react@0.14.6/lib/CSSPropertyOperations.js",
      "npm:react@0.14.6/lib/ReactDOMInput.js",
      "npm:react@0.14.6/lib/ReactDOMOption.js",
      "npm:react@0.14.6/lib/ReactDOMSelect.js",
      "npm:react@0.14.6/lib/ReactDOMTextarea.js",
      "npm:react@0.14.6/lib/ReactCompositeComponent.js",
      "npm:fbjs@0.6.1/lib/isNode.js",
      "npm:process@0.11.2/browser.js",
      "npm:react@0.14.6/lib/forEachAccumulated.js",
      "npm:fbjs@0.6.1/lib/focusNode.js",
      "npm:react@0.14.6/lib/getEventModifierState.js",
      "npm:react@0.14.6/lib/ReactErrorUtils.js",
      "npm:react@0.14.6/lib/EventPluginUtils.js",
      "npm:react@0.14.6/lib/accumulateInto.js",
      "npm:react@0.14.6/lib/ReactDOMSelection.js",
      "npm:react@0.14.6/lib/getTextContentAccessor.js",
      "npm:react@0.14.6/lib/CSSProperty.js",
      "npm:fbjs@0.6.1/lib/memoizeStringOnly.js",
      "npm:react@0.14.6/lib/getEventKey.js",
      "npm:fbjs@0.6.1/lib/performance.js",
      "npm:fbjs@0.6.1/lib/camelizeStyleName.js",
      "npm:react@0.14.6/lib/dangerousStyleValue.js",
      "npm:fbjs@0.6.1/lib/hyphenateStyleName.js",
      "npm:fbjs@0.6.1/lib/createNodesFromMarkup.js",
      "npm:fbjs@0.6.1/lib/getMarkupWrap.js",
      "npm:react@0.14.6/lib/ReactChildReconciler.js",
      "npm:react@0.14.6/lib/flattenChildren.js",
      "npm:react@0.14.6/lib/LinkedValueUtils.js",
      "npm:react@0.14.6/lib/getNodeForCharacterOffset.js",
      "npm:fbjs@0.6.1/lib/camelize.js",
      "npm:fbjs@0.6.1/lib/hyphenate.js",
      "npm:fbjs@0.6.1/lib/createArrayFromMixed.js",
      "npm:fbjs@0.6.1/lib/toArray.js"
    ]
  },

  map: {
    "animate.css": "npm:animate.css@3.4.0",
    "bootstrap": "github:twbs/bootstrap@3.3.6",
    "bootstrap-slider": "github:seiyria/bootstrap-slider@6.0.6",
    "clean-css": "npm:clean-css@3.4.9",
    "css": "github:systemjs/plugin-css@0.1.20",
    "font-awesome": "npm:font-awesome@4.5.0",
    "jplayer": "npm:jplayer@2.9.2",
    "jquery": "npm:jquery@2.2.0",
    "jquery-slimscroll": "npm:jquery-slimscroll@1.3.6",
    "react": "npm:react@0.14.6",
    "react-dom": "npm:react-dom@0.14.6",
    "simple-line-icons": "npm:simple-line-icons@2.2.3",
    "slimscroll": "npm:slimscroll@0.9.1",
    "text": "github:systemjs/plugin-text@0.0.4",
    "typescript": "npm:typescript@1.8.0",
    "github:jspm/nodelibs-assert@0.1.0": {
      "assert": "npm:assert@1.3.0"
    },
    "github:jspm/nodelibs-buffer@0.1.0": {
      "buffer": "npm:buffer@3.6.0"
    },
    "github:jspm/nodelibs-constants@0.1.0": {
      "constants-browserify": "npm:constants-browserify@0.0.1"
    },
    "github:jspm/nodelibs-crypto@0.1.0": {
      "crypto-browserify": "npm:crypto-browserify@3.11.0"
    },
    "github:jspm/nodelibs-events@0.1.1": {
      "events": "npm:events@1.0.2"
    },
    "github:jspm/nodelibs-http@1.7.1": {
      "Base64": "npm:Base64@0.2.1",
      "events": "github:jspm/nodelibs-events@0.1.1",
      "inherits": "npm:inherits@2.0.1",
      "stream": "github:jspm/nodelibs-stream@0.1.0",
      "url": "github:jspm/nodelibs-url@0.1.0",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "github:jspm/nodelibs-https@0.1.0": {
      "https-browserify": "npm:https-browserify@0.0.0"
    },
    "github:jspm/nodelibs-os@0.1.0": {
      "os-browserify": "npm:os-browserify@0.1.2"
    },
    "github:jspm/nodelibs-path@0.1.0": {
      "path-browserify": "npm:path-browserify@0.0.0"
    },
    "github:jspm/nodelibs-process@0.1.2": {
      "process": "npm:process@0.11.2"
    },
    "github:jspm/nodelibs-stream@0.1.0": {
      "stream-browserify": "npm:stream-browserify@1.0.0"
    },
    "github:jspm/nodelibs-string_decoder@0.1.0": {
      "string_decoder": "npm:string_decoder@0.10.31"
    },
    "github:jspm/nodelibs-url@0.1.0": {
      "url": "npm:url@0.10.3"
    },
    "github:jspm/nodelibs-util@0.1.0": {
      "util": "npm:util@0.10.3"
    },
    "github:jspm/nodelibs-vm@0.1.0": {
      "vm-browserify": "npm:vm-browserify@0.0.4"
    },
    "github:twbs/bootstrap@3.3.6": {
      "jquery": "github:components/jquery@2.2.0"
    },
    "npm:JSONStream@1.0.7": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "jsonparse": "npm:jsonparse@1.2.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "through": "npm:through@2.3.8"
    },
    "npm:acorn@1.2.2": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "stream": "github:jspm/nodelibs-stream@0.1.0"
    },
    "npm:amdefine@1.0.0": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "module": "github:jspm/nodelibs-module@0.1.0",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:asn1.js@4.3.0": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "bn.js": "npm:bn.js@4.6.4",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "inherits": "npm:inherits@2.0.1",
      "minimalistic-assert": "npm:minimalistic-assert@1.0.0",
      "vm": "github:jspm/nodelibs-vm@0.1.0"
    },
    "npm:assert@1.3.0": {
      "util": "npm:util@0.10.3"
    },
    "npm:astw@2.0.0": {
      "acorn": "npm:acorn@1.2.2"
    },
    "npm:brace-expansion@1.1.2": {
      "balanced-match": "npm:balanced-match@0.3.0",
      "concat-map": "npm:concat-map@0.0.1"
    },
    "npm:browser-pack@6.0.1": {
      "JSONStream": "npm:JSONStream@1.0.7",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "combine-source-map": "npm:combine-source-map@0.7.1",
      "defined": "npm:defined@1.0.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "through2": "npm:through2@2.0.0",
      "umd": "npm:umd@3.0.1"
    },
    "npm:browser-resolve@1.11.0": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "resolve": "npm:resolve@1.1.6"
    },
    "npm:browserify-aes@1.0.5": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "buffer-xor": "npm:buffer-xor@1.0.3",
      "cipher-base": "npm:cipher-base@1.0.2",
      "create-hash": "npm:create-hash@1.1.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "evp_bytestokey": "npm:evp_bytestokey@1.0.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "inherits": "npm:inherits@2.0.1",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:browserify-cipher@1.0.0": {
      "browserify-aes": "npm:browserify-aes@1.0.5",
      "browserify-des": "npm:browserify-des@1.0.0",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "evp_bytestokey": "npm:evp_bytestokey@1.0.0"
    },
    "npm:browserify-des@1.0.0": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "cipher-base": "npm:cipher-base@1.0.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "des.js": "npm:des.js@1.0.0",
      "inherits": "npm:inherits@2.0.1"
    },
    "npm:browserify-rsa@4.0.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "constants": "github:jspm/nodelibs-constants@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "randombytes": "npm:randombytes@2.0.2"
    },
    "npm:browserify-sign@4.0.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "browserify-rsa": "npm:browserify-rsa@4.0.0",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "create-hash": "npm:create-hash@1.1.2",
      "create-hmac": "npm:create-hmac@1.1.4",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "elliptic": "npm:elliptic@6.1.0",
      "inherits": "npm:inherits@2.0.1",
      "parse-asn1": "npm:parse-asn1@5.0.0",
      "stream": "github:jspm/nodelibs-stream@0.1.0"
    },
    "npm:browserify-zlib@0.1.4": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "pako": "npm:pako@0.2.8",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "readable-stream": "npm:readable-stream@2.0.5",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:browserify@13.0.0": {
      "JSONStream": "npm:JSONStream@1.0.7",
      "assert": "npm:assert@1.3.0",
      "browser-pack": "npm:browser-pack@6.0.1",
      "browser-resolve": "npm:browser-resolve@1.11.0",
      "browserify-zlib": "npm:browserify-zlib@0.1.4",
      "buffer": "npm:buffer@4.3.0",
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "concat-stream": "npm:concat-stream@1.5.1",
      "console-browserify": "npm:console-browserify@1.1.0",
      "constants-browserify": "npm:constants-browserify@1.0.0",
      "crypto-browserify": "npm:crypto-browserify@3.11.0",
      "defined": "npm:defined@1.0.0",
      "deps-sort": "npm:deps-sort@2.0.0",
      "domain-browser": "npm:domain-browser@1.1.7",
      "duplexer2": "npm:duplexer2@0.1.4",
      "events": "npm:events@1.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "glob": "npm:glob@5.0.15",
      "has": "npm:has@1.0.1",
      "htmlescape": "npm:htmlescape@1.1.0",
      "https-browserify": "npm:https-browserify@0.0.1",
      "inherits": "npm:inherits@2.0.1",
      "insert-module-globals": "npm:insert-module-globals@7.0.1",
      "isarray": "npm:isarray@0.0.1",
      "labeled-stream-splicer": "npm:labeled-stream-splicer@2.0.0",
      "module-deps": "npm:module-deps@4.0.5",
      "os-browserify": "npm:os-browserify@0.1.2",
      "parents": "npm:parents@1.0.1",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "path-browserify": "npm:path-browserify@0.0.0",
      "process": "npm:process@0.11.2",
      "punycode": "npm:punycode@1.3.2",
      "querystring-es3": "npm:querystring-es3@0.2.1",
      "read-only-stream": "npm:read-only-stream@2.0.0",
      "readable-stream": "npm:readable-stream@2.0.5",
      "resolve": "npm:resolve@1.1.6",
      "shasum": "npm:shasum@1.0.2",
      "shell-quote": "npm:shell-quote@1.4.3",
      "stream-browserify": "npm:stream-browserify@2.0.1",
      "stream-http": "npm:stream-http@2.1.0",
      "string_decoder": "npm:string_decoder@0.10.31",
      "subarg": "npm:subarg@1.0.0",
      "syntax-error": "npm:syntax-error@1.1.4",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0",
      "through2": "npm:through2@2.0.0",
      "timers-browserify": "npm:timers-browserify@1.4.2",
      "tty-browserify": "npm:tty-browserify@0.0.0",
      "url": "npm:url@0.11.0",
      "util": "npm:util@0.10.3",
      "vm-browserify": "npm:vm-browserify@0.0.4",
      "xtend": "npm:xtend@4.0.1"
    },
    "npm:buffer-xor@1.0.3": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:buffer@3.6.0": {
      "base64-js": "npm:base64-js@0.0.8",
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "ieee754": "npm:ieee754@1.1.6",
      "isarray": "npm:isarray@1.0.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:buffer@4.3.0": {
      "base64-js": "npm:base64-js@1.0.2",
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "ieee754": "npm:ieee754@1.1.6",
      "isarray": "npm:isarray@1.0.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:builtin-status-codes@1.0.0": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "http": "github:jspm/nodelibs-http@1.7.1"
    },
    "npm:cipher-base@1.0.2": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "inherits": "npm:inherits@2.0.1",
      "stream": "github:jspm/nodelibs-stream@0.1.0",
      "string_decoder": "github:jspm/nodelibs-string_decoder@0.1.0"
    },
    "npm:clean-css@3.4.9": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "commander": "npm:commander@2.8.1",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "http": "github:jspm/nodelibs-http@1.7.1",
      "https": "github:jspm/nodelibs-https@0.1.0",
      "os": "github:jspm/nodelibs-os@0.1.0",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "source-map": "npm:source-map@0.4.4",
      "url": "github:jspm/nodelibs-url@0.1.0",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:combine-source-map@0.7.1": {
      "convert-source-map": "npm:convert-source-map@1.1.3",
      "inline-source-map": "npm:inline-source-map@0.6.1",
      "lodash.memoize": "npm:lodash.memoize@3.0.4",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "source-map": "npm:source-map@0.4.2"
    },
    "npm:commander@2.8.1": {
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "events": "github:jspm/nodelibs-events@0.1.1",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "graceful-readlink": "npm:graceful-readlink@1.0.1",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:concat-stream@1.5.1": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "inherits": "npm:inherits@2.0.1",
      "readable-stream": "npm:readable-stream@2.0.5",
      "typedarray": "npm:typedarray@0.0.6"
    },
    "npm:console-browserify@1.1.0": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "date-now": "npm:date-now@0.1.4",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:constants-browserify@0.0.1": {
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:constants-browserify@1.0.0": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "constants": "github:jspm/nodelibs-constants@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:convert-source-map@1.1.3": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0"
    },
    "npm:core-util-is@1.0.2": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0"
    },
    "npm:create-ecdh@4.0.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "elliptic": "npm:elliptic@6.1.0"
    },
    "npm:create-hash@1.1.2": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "cipher-base": "npm:cipher-base@1.0.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "inherits": "npm:inherits@2.0.1",
      "ripemd160": "npm:ripemd160@1.0.1",
      "sha.js": "npm:sha.js@2.4.4"
    },
    "npm:create-hmac@1.1.4": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "create-hash": "npm:create-hash@1.1.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "inherits": "npm:inherits@2.0.1",
      "stream": "github:jspm/nodelibs-stream@0.1.0"
    },
    "npm:crypto-browserify@3.11.0": {
      "browserify-cipher": "npm:browserify-cipher@1.0.0",
      "browserify-sign": "npm:browserify-sign@4.0.0",
      "create-ecdh": "npm:create-ecdh@4.0.0",
      "create-hash": "npm:create-hash@1.1.2",
      "create-hmac": "npm:create-hmac@1.1.4",
      "diffie-hellman": "npm:diffie-hellman@5.0.1",
      "inherits": "npm:inherits@2.0.1",
      "pbkdf2": "npm:pbkdf2@3.0.4",
      "public-encrypt": "npm:public-encrypt@4.0.0",
      "randombytes": "npm:randombytes@2.0.2"
    },
    "npm:deps-sort@2.0.0": {
      "JSONStream": "npm:JSONStream@1.0.7",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "shasum": "npm:shasum@1.0.2",
      "subarg": "npm:subarg@1.0.0",
      "through2": "npm:through2@2.0.0"
    },
    "npm:des.js@1.0.0": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "inherits": "npm:inherits@2.0.1",
      "minimalistic-assert": "npm:minimalistic-assert@1.0.0"
    },
    "npm:detective@4.3.1": {
      "acorn": "npm:acorn@1.2.2",
      "defined": "npm:defined@1.0.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2"
    },
    "npm:diffie-hellman@5.0.1": {
      "bn.js": "npm:bn.js@4.6.4",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "miller-rabin": "npm:miller-rabin@4.0.0",
      "randombytes": "npm:randombytes@2.0.2",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:domain-browser@1.1.7": {
      "events": "github:jspm/nodelibs-events@0.1.1"
    },
    "npm:domhelper@0.9.1": {
      "browserify": "npm:browserify@13.0.0",
      "classie": "npm:classie@1.0.0",
      "util-extend": "npm:util-extend@1.0.3"
    },
    "npm:duplexer2@0.1.4": {
      "readable-stream": "npm:readable-stream@2.0.5"
    },
    "npm:elliptic@6.1.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "brorand": "npm:brorand@1.0.5",
      "hash.js": "npm:hash.js@1.0.3",
      "inherits": "npm:inherits@2.0.1",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:evp_bytestokey@1.0.0": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "create-hash": "npm:create-hash@1.1.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0"
    },
    "npm:fbjs@0.6.1": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:font-awesome@4.5.0": {
      "css": "github:systemjs/plugin-css@0.1.20"
    },
    "npm:glob@5.0.15": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "events": "github:jspm/nodelibs-events@0.1.1",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "inflight": "npm:inflight@1.0.4",
      "inherits": "npm:inherits@2.0.1",
      "minimatch": "npm:minimatch@3.0.0",
      "once": "npm:once@1.3.3",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "path-is-absolute": "npm:path-is-absolute@1.0.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:graceful-readlink@1.0.1": {
      "fs": "github:jspm/nodelibs-fs@0.1.2"
    },
    "npm:has@1.0.1": {
      "function-bind": "npm:function-bind@1.0.2"
    },
    "npm:hash.js@1.0.3": {
      "inherits": "npm:inherits@2.0.1"
    },
    "npm:https-browserify@0.0.0": {
      "http": "github:jspm/nodelibs-http@1.7.1"
    },
    "npm:https-browserify@0.0.1": {
      "http": "github:jspm/nodelibs-http@1.7.1"
    },
    "npm:inflight@1.0.4": {
      "once": "npm:once@1.3.3",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "wrappy": "npm:wrappy@1.0.1"
    },
    "npm:inherits@2.0.1": {
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:inline-source-map@0.6.1": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "source-map": "npm:source-map@0.4.2"
    },
    "npm:insert-module-globals@7.0.1": {
      "JSONStream": "npm:JSONStream@1.0.7",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "combine-source-map": "npm:combine-source-map@0.7.1",
      "concat-stream": "npm:concat-stream@1.5.1",
      "is-buffer": "npm:is-buffer@1.1.1",
      "lexical-scope": "npm:lexical-scope@1.2.0",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "npm:process@0.11.2",
      "through2": "npm:through2@2.0.0",
      "xtend": "npm:xtend@4.0.1"
    },
    "npm:is-buffer@1.1.1": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0"
    },
    "npm:jplayer@2.9.2": {
      "jquery": "npm:jquery@2.2.0"
    },
    "npm:jquery-slimscroll@1.3.6": {
      "jquery": "npm:jquery@2.2.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:json-stable-stringify@0.0.1": {
      "jsonify": "npm:jsonify@0.0.0"
    },
    "npm:jsonparse@1.2.0": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "http": "github:jspm/nodelibs-http@1.7.1"
    },
    "npm:labeled-stream-splicer@2.0.0": {
      "inherits": "npm:inherits@2.0.1",
      "isarray": "npm:isarray@0.0.1",
      "stream-splicer": "npm:stream-splicer@2.0.0"
    },
    "npm:lexical-scope@1.2.0": {
      "astw": "npm:astw@2.0.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:miller-rabin@4.0.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "brorand": "npm:brorand@1.0.5"
    },
    "npm:minimatch@3.0.0": {
      "brace-expansion": "npm:brace-expansion@1.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0"
    },
    "npm:module-deps@4.0.5": {
      "JSONStream": "npm:JSONStream@1.0.7",
      "browser-resolve": "npm:browser-resolve@1.11.0",
      "concat-stream": "npm:concat-stream@1.5.1",
      "defined": "npm:defined@1.0.0",
      "detective": "npm:detective@4.3.1",
      "duplexer2": "npm:duplexer2@0.1.4",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "inherits": "npm:inherits@2.0.1",
      "parents": "npm:parents@1.0.1",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "readable-stream": "npm:readable-stream@2.0.5",
      "resolve": "npm:resolve@1.1.6",
      "stream-combiner2": "npm:stream-combiner2@1.1.1",
      "subarg": "npm:subarg@1.0.0",
      "through2": "npm:through2@2.0.0",
      "xtend": "npm:xtend@4.0.1"
    },
    "npm:once@1.3.3": {
      "wrappy": "npm:wrappy@1.0.1"
    },
    "npm:os-browserify@0.1.2": {
      "os": "github:jspm/nodelibs-os@0.1.0"
    },
    "npm:pako@0.2.8": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:parents@1.0.1": {
      "path-platform": "npm:path-platform@0.11.15",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:parse-asn1@5.0.0": {
      "asn1.js": "npm:asn1.js@4.3.0",
      "browserify-aes": "npm:browserify-aes@1.0.5",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "create-hash": "npm:create-hash@1.1.2",
      "evp_bytestokey": "npm:evp_bytestokey@1.0.0",
      "pbkdf2": "npm:pbkdf2@3.0.4",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:path-browserify@0.0.0": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:path-is-absolute@1.0.0": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:path-platform@0.11.15": {
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:pbkdf2@3.0.4": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "create-hmac": "npm:create-hmac@1.1.4",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:process-nextick-args@1.0.6": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:process@0.11.2": {
      "assert": "github:jspm/nodelibs-assert@0.1.0"
    },
    "npm:public-encrypt@4.0.0": {
      "bn.js": "npm:bn.js@4.6.4",
      "browserify-rsa": "npm:browserify-rsa@4.0.0",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "create-hash": "npm:create-hash@1.1.2",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "parse-asn1": "npm:parse-asn1@5.0.0",
      "randombytes": "npm:randombytes@2.0.2"
    },
    "npm:punycode@1.3.2": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:randombytes@2.0.2": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:react-dom@0.14.6": {
      "react": "npm:react@0.14.6"
    },
    "npm:react@0.14.6": {
      "fbjs": "npm:fbjs@0.6.1",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:read-only-stream@2.0.0": {
      "readable-stream": "npm:readable-stream@2.0.5"
    },
    "npm:readable-stream@1.1.13": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "core-util-is": "npm:core-util-is@1.0.2",
      "events": "github:jspm/nodelibs-events@0.1.1",
      "inherits": "npm:inherits@2.0.1",
      "isarray": "npm:isarray@0.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "stream-browserify": "npm:stream-browserify@1.0.0",
      "string_decoder": "npm:string_decoder@0.10.31"
    },
    "npm:readable-stream@2.0.5": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "core-util-is": "npm:core-util-is@1.0.2",
      "events": "github:jspm/nodelibs-events@0.1.1",
      "inherits": "npm:inherits@2.0.1",
      "isarray": "npm:isarray@0.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "process-nextick-args": "npm:process-nextick-args@1.0.6",
      "string_decoder": "npm:string_decoder@0.10.31",
      "util-deprecate": "npm:util-deprecate@1.0.2"
    },
    "npm:resolve@1.1.6": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "systemjs-json": "github:systemjs/plugin-json@0.1.0"
    },
    "npm:ripemd160@1.0.1": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:sha.js@2.4.4": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "inherits": "npm:inherits@2.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:shasum@1.0.2": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "crypto": "github:jspm/nodelibs-crypto@0.1.0",
      "json-stable-stringify": "npm:json-stable-stringify@0.0.1",
      "sha.js": "npm:sha.js@2.4.4"
    },
    "npm:shell-quote@1.4.3": {
      "array-filter": "npm:array-filter@0.0.1",
      "array-map": "npm:array-map@0.0.0",
      "array-reduce": "npm:array-reduce@0.0.0",
      "jsonify": "npm:jsonify@0.0.0"
    },
    "npm:slimscroll@0.9.1": {
      "browserify": "npm:browserify@13.0.0",
      "classie": "npm:classie@1.0.0",
      "domhelper": "npm:domhelper@0.9.1",
      "util-extend": "npm:util-extend@1.0.3"
    },
    "npm:source-map@0.4.2": {
      "amdefine": "npm:amdefine@1.0.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "path": "github:jspm/nodelibs-path@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:source-map@0.4.4": {
      "amdefine": "npm:amdefine@1.0.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:stream-browserify@1.0.0": {
      "events": "github:jspm/nodelibs-events@0.1.1",
      "inherits": "npm:inherits@2.0.1",
      "readable-stream": "npm:readable-stream@1.1.13"
    },
    "npm:stream-browserify@2.0.1": {
      "events": "github:jspm/nodelibs-events@0.1.1",
      "inherits": "npm:inherits@2.0.1",
      "readable-stream": "npm:readable-stream@2.0.5"
    },
    "npm:stream-combiner2@1.1.1": {
      "duplexer2": "npm:duplexer2@0.1.4",
      "readable-stream": "npm:readable-stream@2.0.5"
    },
    "npm:stream-http@2.1.0": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "builtin-status-codes": "npm:builtin-status-codes@1.0.0",
      "inherits": "npm:inherits@2.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "stream": "github:jspm/nodelibs-stream@0.1.0",
      "to-arraybuffer": "npm:to-arraybuffer@1.0.1",
      "url": "github:jspm/nodelibs-url@0.1.0",
      "xtend": "npm:xtend@4.0.1"
    },
    "npm:stream-splicer@2.0.0": {
      "inherits": "npm:inherits@2.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "readable-stream": "npm:readable-stream@2.0.5"
    },
    "npm:string_decoder@0.10.31": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0"
    },
    "npm:subarg@1.0.0": {
      "minimist": "npm:minimist@1.2.0"
    },
    "npm:syntax-error@1.1.4": {
      "acorn": "npm:acorn@1.2.2"
    },
    "npm:through2@2.0.0": {
      "process": "github:jspm/nodelibs-process@0.1.2",
      "readable-stream": "npm:readable-stream@2.0.5",
      "util": "github:jspm/nodelibs-util@0.1.0",
      "xtend": "npm:xtend@4.0.1"
    },
    "npm:through@2.3.8": {
      "process": "github:jspm/nodelibs-process@0.1.2",
      "stream": "github:jspm/nodelibs-stream@0.1.0"
    },
    "npm:timers-browserify@1.4.2": {
      "process": "npm:process@0.11.2"
    },
    "npm:to-arraybuffer@1.0.1": {
      "buffer": "github:jspm/nodelibs-buffer@0.1.0"
    },
    "npm:umd@3.0.1": {
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:url@0.10.3": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "punycode": "npm:punycode@1.3.2",
      "querystring": "npm:querystring@0.2.0",
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:url@0.11.0": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "punycode": "npm:punycode@1.3.2",
      "querystring": "npm:querystring@0.2.0"
    },
    "npm:util-deprecate@1.0.2": {
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:util-extend@1.0.3": {
      "assert": "github:jspm/nodelibs-assert@0.1.0"
    },
    "npm:util@0.10.3": {
      "inherits": "npm:inherits@2.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:vm-browserify@0.0.4": {
      "indexof": "npm:indexof@0.0.1"
    }
  }
});
