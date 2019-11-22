module Neuron

open Connection
open ILayer
open MathHelper
open System

type Neuron() = 
    member val bias:  float = MathHelper.random() with get, set 
    member val error: float = 0.0 with get, set
    member val delta: float = 0.0 with get, set
    member val value: float = 0.0 with get, set
    member val target: float = 0.0 with get, set

    member val inputConnections: List<Connection> = [] with get, set
    member val outputConnections: List<Connection> = [] with get, set
   
   ///
   /// Adds an outgoing connection
   ///
    member this.addOutGoingConnection(connection: Connection) =
        this.outputConnections <- this.outputConnections @ [connection]
    
    ///
    /// Adds an incoming connection
    ///
    member this.addIncomingConnection(connection: Connection) =
        this.inputConnections <- this.inputConnections @ [connection]

    ///
    /// Feedforward and activates the neuron values
    ///
    member this.feedForward() =
        do this.transfer();
        do this.activate();
        for connection in this.outputConnections do
            do connection.push(this.value)

    ///
    /// Creates a product based on incoming connections
    ///
    member this.transfer() =
        if this.inputConnections.Length > 0 then do
            let mutable sum = 0.0
            for input in this.inputConnections do
                sum <- sum+(input.value*input.weight)
            sum <- sum+this.bias
            this.value <- sum

    ///
    /// Activates the transfered values
    ///
    member this.activate()=
        this.value <- MathHelper.sigmoid(this.value)

    ///
    /// Backpropagates to calculate the error of the neuron
    ///
    member this.propagate(layer: ILayer<Neuron>) = 
        do this.calculateError(layer) |> ignore

    ///
    /// Updates the weights in incomming connections
    ///
    member this.update(learnRate:float) =
        for connection in this.inputConnections do
            connection.weight <- connection.weight + this.delta * connection.value * learnRate
        this.bias <- this.bias+(learnRate*this.delta)
    
    ///
    /// Calculates the neurons error
    ///
    member this.calculateError(layer:ILayer<Neuron>): float = //TODO double check
        let mutable error = 0.0
        if layer <> null then 
            for neuron in layer.rightConnectionLayer.neurons do //finding the shared connection 
                for connection in neuron.inputConnections do
                    for outputConnection in this.outputConnections do
                        if connection = outputConnection then
                            error <- error + connection.weight * neuron.delta
            this.error <- error
        else 
            this.error <- this.target-this.value//plain error
        this.delta <- this.value * (1.0-this.value) * this.error
        this.error