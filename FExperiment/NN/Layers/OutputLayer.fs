﻿module OutputLayer

open ILayer
open Layer
open Neuron
open System

[<AllowNullLiteralAttribute>]
type OutputLayer() = 
    inherit Layer()

    member val error: float = 0.0 with get, set

    ///
    ///
    ///
    member this.propagate()=
        this.calculateError()
        (this:>ILayer<Neuron>).leftConnectionLayer.propagate()

    ///
    ///
    ///
    member this.setTargets(targets: List<float>) = 
        let self = (this:>ILayer<Neuron>)
        for i = 0 to (targets.Length-1) do
            self.neurons.[i].target <- targets.[i]

    ///
    ///
    ///  
    member this.calculateError()=
        let mutable error = 0.0
        let self = (this:>ILayer<Neuron>)
        for neuron in self.neurons do 
            error <- error+neuron.calculateError(null); //TODO check neuron / output neuron
        this.error <- error;