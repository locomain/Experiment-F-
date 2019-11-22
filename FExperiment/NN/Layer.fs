namespace Layer

open Connection            
open Neuron
open ILayer
open System

[<AllowNullLiteralAttribute>]
type public Layer(amountOfNeurons) = 
    interface ILayer<Neuron> with

        member val rightConnectionLayer: ILayer<Neuron> = null with get, set
        member val leftConnectionLayer: ILayer<Neuron> = null with get, set
        member val neurons: List<Neuron> = [] with get, set

        ///
        ///
        ///
        member this.generateNeurons(amount: int): unit = 
            let self = (this:>ILayer<Neuron>)
            self.neurons <- [ for i in 0 .. amount-1 -> new Neuron() ]
        ///
        ///
        ///
        member this.connectTo(layer: ILayer<Neuron>)=
            let self = (this:>ILayer<Neuron>);         
            self.rightConnectionLayer <- layer
            layer.leftConnectionLayer <- this
            for index = 0 to (self.neurons.Length-1) do
                let neuron = self.neurons.[index]
                for rightIndex = 0 to (layer.neurons.Length-1) do 
                    let rightNeuron = layer.neurons.[rightIndex]
                    let connection = new Connection()
                    do neuron.addOutGoingConnection(connection) |> ignore
                    do rightNeuron.addIncomingConnection(connection) |> ignore
        ///
        ///
        ///
        member this.feedForward() =
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.feedForward()
            if self.rightConnectionLayer <> null then
                do self.rightConnectionLayer.feedForward()

        ///
        ///
        ///
        member this.propagate() =
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.propagate(this)
            if self.leftConnectionLayer <> null then
                do self.leftConnectionLayer.propagate()
        ///
        ///
        ///
        member this.update(learnRate: float)=
            let self = (this:>ILayer<Neuron>);
            for neuron in self.neurons do
                do neuron.update(learnRate)
            if self.rightConnectionLayer <> null then
                do self.rightConnectionLayer.update(learnRate)

    

               

