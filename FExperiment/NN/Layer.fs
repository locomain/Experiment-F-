namespace Layer

open Connection            
open Neuron
open ILayer

[<AllowNullLiteralAttribute>]
type public Layer(amountOfNeurons) as this = 
    
    member this.generateNeurons(amount): List<Neuron>  = 
        [ for i in 0 .. amount -> new Neuron() ]

    interface ILayer<Neuron> with

        member val rightConnectionLayer: ILayer<Neuron> = null with get, set
        member val leftConnectionLayer: ILayer<Neuron> = null with get, set
        member val neurons: List<Neuron> = this.generateNeurons(amountOfNeurons) with get, set
        
        member this.connectTo(layer: ILayer<Neuron>) ( indexedWeights: List<double>)= //TODO check assignment
            let self = (this:>ILayer<Neuron>);
            self.rightConnectionLayer <- layer
            layer.leftConnectionLayer <- this
            for neuron in self.neurons do
                let index = List.findIndex(fun n->n = neuron) self.neurons;
                for rightNeuron in layer.neurons do 
                    let rightIndex = List.findIndex(fun n->n = neuron) layer.neurons
                    let connection = if indexedWeights.Length<1 then new Connection() else new Connection()
                    neuron.addOutGoingConnection(connection)
                    rightNeuron.addIncomingConnection(connection);

        member this.feedForward() =
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.feedForward()
            self.rightConnectionLayer.feedForward()

        member this.propagate() =
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.propagate(this)
            if self.leftConnectionLayer <> null then
                do self.leftConnectionLayer.propagate()
        
        member this.update(learnRate: double)=
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.update(learnRate)
            if self.rightConnectionLayer <> null then
                do self.rightConnectionLayer.update(learnRate)

    

               

