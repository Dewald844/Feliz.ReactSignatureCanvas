namespace App

open Feliz
open Feliz.Router
open Wrap.ReactSignatureCanvas

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member HelloWorld() = Html.h1 "Hello World"

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let (count, setCount) = React.useState(0)
        Html.div [
            Html.h1 count
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Increment"
            ]
        ]

    /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Components.SignatureTest ()
                | [ "hello" ] -> Components.HelloWorld()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
        ]

    [<ReactComponent>]
    static member SignatureTest () : ReactElement =

        Html.div [
            prop.children [
                SignatureCanvas.create [
                    SignatureCanvas.minWidth 0.5
                    SignatureCanvas.maxWidth 2.5
                    SignatureCanvas.penColor "blue"
                    SignatureCanvas.velocityFilterWeight 0.7
                    SignatureCanvas.minDistance 5.0
                    SignatureCanvas.dotSize 1.0
                    SignatureCanvas.throttle 16.0
                ]
            ]
        ]