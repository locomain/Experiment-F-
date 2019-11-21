module Neuron

open Connection
open ILayer
open MathHelper

type Neuron() = 
    member val bias:  double = MathHelper.random() with get, set 
    member val error: double = 0.0 with get, set
    member val delta: double = 0.0 with get, set
    member val value: double = 0.0 with get, set
    member val target: double = 0.0 with get, set

    member val inputConnections: List<Connection> = [] with get, set
    member val outputConnections: List<Connection> = [] with get, set
   
    member this.addOutGoingConnection(connection: Connection) =
        this.outputConnections <- this.outputConnections @ [connection]

    member this.addIncomingConnection(connection: Connection) =
        this.inputConnections <- this.inputConnections @ [connection]

    member this.feedForward() =
        do this.transfer();
        do this.activate();
        for connection in this.outputConnections do
            do connection.push(this.value)

    member this.transfer() =
        if this.inputConnections.Length > 0 then do
            let mutable sum = 0.0
            for input in this.inputConnections do
                sum <- sum+(input.value*input.weight)
            sum <- sum+this.bias
            this.value <- sum

    member this.activate()=
        this.value <- MathHelper.sigmoid(this.value)

    member this.propagate(layer: ILayer<Neuron>) = 
        do this.calculateError(layer) |> ignore

    member this.update(learnRate:double) =
        for connection in this.inputConnections do
            connection.weight <- connection.weight + this.delta * connection.value * learnRate
    
    member this.calculateError(layer:ILayer<Neuron>): double = //TODO double check
        let mutable error = 0.0
        if layer <> null then 
            for neuron in layer.rightConnectionLayer.neurons do
                for connection in neuron.inputConnections do
                    for outputConnection in this.outputConnections do
                        if connection = outputConnection then
                            error <- error + connection.weight * neuron.delta
            this.error <- error
        else 
            this.error <- this.target-this.value//plain error
            this.delta <- this.value * (1.0 - this.value) * this.error
        this.error