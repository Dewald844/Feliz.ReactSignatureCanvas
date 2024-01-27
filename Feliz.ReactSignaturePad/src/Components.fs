namespace App

open Feliz
open Fable.Core.JsInterop
open Wrap.ReactSignatureCanvas

type Components =

    [<ReactComponent>]
    static member SignatureTest () : ReactElement =

        let signatureCanvas = React.useRef null

        let (signatureL : List<string>), setSignatureL = React.useState []

        let clearCanvas = fun () -> signatureCanvas.current?clear()
        let saveSignature = fun () ->
            let image = signatureCanvas.current?getTrimmedCanvas()?toDataURL("image/png")
            printf $"Signature image saved: %A{image}"
            setSignatureL (image::signatureL)
            clearCanvas()

        Html.div [
            prop.style [
                style.justifyContent.center
                style.flexWrap.wrap
                style.width 500
            ]
            prop.children [
                Html.div [
                    prop.style [ style.border (1, borderStyle.dashed, "#43b02a") ]
                    prop.children [
                        SignatureCanvas.create [
                            SignatureCanvas.ref signatureCanvas
                            SignatureCanvas.penColor "Black"
                            SignatureCanvas.velocityFilterWeight 0.7
                            SignatureCanvas.minDistance 5.0
                            SignatureCanvas.throttle 5
                            SignatureCanvas.canvasProps [
                                CanvasProps.width 500
                                CanvasProps.height 250
                            ]
                        ]
                ] ]
                Html.button [
                    prop.text "Clear canvas"
                    prop.onClick (fun _ -> clearCanvas ())
                ]
                Html.button [
                    prop.text "Save signature"
                    prop.onClick (fun _ -> saveSignature ())
                ]
                Html.div [
                    prop.children (
                        signatureL
                        |> List.map (fun img ->
                            Html.img [
                                prop.src img
                            ]
                            )
                        )
                ]
            ]
        ]