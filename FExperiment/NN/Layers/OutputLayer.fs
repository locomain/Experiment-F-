module OutputLayer

open ILayer
open Layer
open Neuron

[<AllowNullLiteralAttribute>]
type OutputLayer() = 
    inherit Layer()

    member val error = 0.0 with get, set

    member this.propagate()=
        this.calculateError()
        (this:>ILayer<Neuron>).leftConnectionLayer.propagate()

    member this.setTargets(targets: List<double>) = 
        let self = (this:>ILayer<Neuron>)
        for i = 0 to (targets.Length-1) do
            self.neurons.[i].target <- targets.[i]
            
    member this.calculateError()=
        let mutable error = 0.0
        let self = (this:>ILayer<Neuron>)
        for neuron in self.neurons do 
            error <- error+neuron.calculateError(null);
        this.error <- error;