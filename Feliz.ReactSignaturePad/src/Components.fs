namespace App

open Feliz
open Fable.Core.JsInterop
open Feliz.ReactSignatureCanvas

type Components =

    [<ReactComponent>]
    static member SignatureTest () : ReactElement =

        let canvasRef = React.useRef null

        let (signatureL : List<string>), setSignatureL = React.useState []

        let saveSignature = fun () ->
            let image = SignatureCanvas.getSignatureDataUrl canvasRef
            setSignatureL (image::signatureL)
            SignatureCanvas.clearCanvas canvasRef

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
                            SignatureCanvas.ref canvasRef
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
                    prop.onClick (fun _ -> SignatureCanvas.clearCanvas canvasRef)
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