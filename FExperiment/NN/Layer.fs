namespace Layer

open Connection            
open Neuron

[<AllowNullLiteralAttribute>]
type public Layer(amountOfNeurons) as this = 
    member val neurons: List<Neuron> = this.generateNeurons(amountOfNeurons);
    member val rightConnectionLayer: Layer = null with get, set
    member val leftConnectionLayer: Layer = null with get, set
    
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
        if this.leftConnectionLayer <> null then
            do this.leftConnectionLayer.propagate()
    
    member this.update(learnRate: double)=
        for neuron in this.neurons do
            do neuron.update(learnRate)
        if this.rightConnectionLayer <> null then
            do this.rightConnectionLayer.update(learnRate)
               

