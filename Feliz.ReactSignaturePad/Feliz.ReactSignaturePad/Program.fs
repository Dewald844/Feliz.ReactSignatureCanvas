namespace Wrap

open Fable
open Fable.Core
open Fable.Core.JsInterop
open Feliz

module ReactSignatureCanvas =

    let signatureCanvas : obj = import "SignatureCanvas" "react-signature-canvas"

    [<Erase>]
    type SignatureCanvas =
        static member inline velocityFilterWeight (v : float) = "velocityFilterWeight" ==> v
        static member inline minWidth (v : float) = "minWidth" ==> v
        static member inline maxWidth (v : float) = "maxWidth" ==> v
        static member inline minDistance (v : float) = "minDistance" ==> v
        static member inline dotSize (v : float) = "dotSize" ==> v
        static member inline throttle (v : float) = "throttle" ==> v
        static member inline penColor (v : string) = "penColor" ==> v
        static member inline create props = Interop.reactApi.createElement (signatureCanvas, createObj !!props)
