namespace Layer

open Neuron
open Connection

[<AllowNullLiteralAttribute>]
type public Layer(amountOfNeurons) as this = 
    member val neurons: List<Neuron> = this.generateNeurons(amountOfNeurons);
    member val rightConnectionLayer: Layer = new Layer(0) with get, set
    member val leftConnectionLayer: Layer = new Layer(0) with get, set
    
    member this.generateNeurons(amount): List<Neuron>  = 
        [ for i in 0 .. amount -> new Neuron() ]

    member this.connectTo(layer: Layer, indexedWeights: List<double>)=
        this.rightConnectionLayer <- layer
        layer.leftConnectionLayer <- this
        for neuron in this.neurons do
            let index = List.findIndex(fun n->n = neuron) this.neurons;
            for rightNeuron in layer.neurons do 
                let rightIndex = List.findIndex(fun n->n = neuron) layer.neurons
                let connection = if indexedWeights.Length<1 then new Connection() else new Connection()
                neuron.addOutGoingConnection(connection)
                rightNeuron.addIncomingConnection(connection);

    member this.feedForward() =
        for neuron in this.neurons do
            do neuron.feedForward()
        this.rightConnectionLayer.feedForward()

    member this.propagate() =
        for neuron in this.neurons do
            do neuron.propagate(this)
        if this.leftConnectionLayer = new Layer(0) then
            do this.leftConnectionLayer.propagate()
               
                



