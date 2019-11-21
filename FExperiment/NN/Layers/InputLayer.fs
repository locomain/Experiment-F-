module InputLayer

open ILayer
open Layer
open Neuron

[<AllowNullLiteralAttribute>]
type InputLayer() = 
    inherit Layer()

    member this.set(value: List<float>) =
        let self = (this:>ILayer<Neuron>)
        if value.Length = self.neurons.Length then printf("test")
    
