module InputLayer

open ILayer
open Layer
open Neuron
open System

[<AllowNullLiteralAttribute>]
type InputLayer() = 
    inherit Layer()

    ///
    /// Sets the initial value for the input neurons
    ///
    member this.set(value: List<float>) =
        let self = (this:>ILayer<Neuron>)
        if value.Length = self.neurons.Length then
            for i = 0 to value.Length-1 do
                let neuron = self.neurons.[i]
                neuron.value <- value.[i]
