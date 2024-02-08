namespace Feliz

open Fable.Core
open Fable.Core.JsInterop
open Feliz

module ReactSignatureCanvas =

    let signatureCanvas : obj = importDefault "react-signature-canvas"

    [<Erase>]
    type CanvasProps =
        static member inline width (v: int) = "width" ==> v
        static member inline height (v: int) = "height" ==> v
        static member inline create (v: seq<string * obj>) = createObj v
        static member inline className (v: string) = "className" ==> v

    [<Erase>]
    type SignatureCanvas =
        static member inline velocityFilterWeight (v : float)  = "velocityFilterWeight" ==> v
        static member inline minWidth             (v : float)  = "minWidth"             ==> v
        static member inline maxWidth             (v : float)  = "maxWidth"             ==> v
        static member inline minDistance          (v : float)  = "minDistance"          ==> v
        static member inline dotSize              (v : float)  = "dotSize"              ==> v
        static member inline throttle             (v : float)  = "throttle"             ==> v
        static member inline penColor             (v : string) = "penColor"             ==> v
        static member inline backgroundColor      (v : string) = "backgroundColor"      ==> v

        static member inline canvasProps v =
            "canvasProps" ==> (CanvasProps.create (v |> Seq.append [CanvasProps.className "signature-canvas"]))

        static member inline ref v = "ref" ==> v

        static member inline create props =
            Interop.reactApi.createElement (signatureCanvas, createObj !!props)

        static member inline clearCanvas (ref : IRefValue<obj>) =
            ref.current?clear()

        static member inline getSignatureDataUrl (ref : IRefValue<obj>) : string =
            ref.current?getTrimmedCanvas()?toDataURL("image/png")

