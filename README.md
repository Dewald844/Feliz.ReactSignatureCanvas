## Feliz wrapper for react-signature-pad

### Before begining firstly run

```bash
npm install react-signature-pad
```

### To run the demo

```bash
cd Feliz.ReactSignaturePad && npm run start
```

## Basic implementation

```fsharp

let canvasRef = React.useRef null

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

```

## Calling the clear method
```fsharp
SignatureCanvas.clearCanvas canvasRef
```

## Saving the canvas as a image
```fsharp
let image = SignatureCanvas.getSignatureDataUrl canvasRef
```

## Contrubutions are always welcome
### Also feel free to submit any issues that you run into

#### Lastly thank you for the support and enjoy !!!
