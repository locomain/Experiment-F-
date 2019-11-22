module Network

open Neuron
open ILayer
open Layer
open InputLayer
open OutputLayer
open TrainingSet
open MathHelper
open System

type Network() = 
    member val inputLayer: InputLayer = null with get, set
    member val hiddenLayers: List<Layer> = [] with get,set
    member val outputLayer: OutputLayer = null with get, set
    member val learnRate = 0.3 with get,set

    ///
    /// Adds a input layer to the network
    ///
    member this.addInputLayer(amountOfNeurons) = 
        let layer = new InputLayer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.inputLayer <- layer;
    
    ///
    /// Adds a output layer to the network
    ///
    member this.addOutputLayer(amountOfNeurons) = 
        let layer = new OutputLayer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.outputLayer <- layer;

    ///
    /// Adds a hidden layer to the network with the given amount of neurons
    ///
    member this.addHiddenLayer(amountOfNeurons) = 
        let layer = new Layer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.hiddenLayers <- this.hiddenLayers @ [layer]
    
    ///
    /// Sets the learnrate of the network
    ///
    member this.setLearnRate(rate: float)=
        this.learnRate <- rate

    ///
    /// Builds the network topology
    ///
    member this.build() =
        let inputLayer = (this.inputLayer:>ILayer<Neuron>)
        do inputLayer.connectTo(this.hiddenLayers.[0]);

        for i = 0 to (this.hiddenLayers.Length-1) do
            let layer = this.hiddenLayers.[i];
            if (i+1) = this.hiddenLayers.Length then
                do (layer:>ILayer<Neuron>).connectTo(this.outputLayer);
            else do
                let nextLayer = this.hiddenLayers.[i+1];
                (layer:>ILayer<Neuron>).connectTo(nextLayer);
    ///
    /// Trains the network
    ///
    member this.train(data: List<TrainingSet>, iterations:int, until:float) =
        let mutable trainingError = 100.0
        let mutable i = 0

        while (i<iterations) do 
            i <- i+1
            let mutable errors = [];
            for j = 0 to (data.Length-1) do 
                let set = data.[j]
                this.outputLayer.setTargets(set.output)
                this.run(set.input) |> ignore
                this.propagate()
                this.update()
                if i % 1000 = 0 then do Console.WriteLine("Network: error = {0} on iteration {1} for set {2}",this.outputLayer.error,i,j)//TODO
                set.error <- this.outputLayer.error
                errors <- errors @ [set.error]
                trainingError <- MathHelper.collectiveError(errors)
        Console.WriteLine("\n\nNETWORK: DONE TRAINING AFTER {0} ITERATIONS!",i);

    ///
    /// Propagates the network from back to front
    ///
    member this.propagate()=
        do this.outputLayer.propagate();
    
    ///
    /// Update the network with by de amount of the learnrate
    ///
    member this.update()=
        (this.inputLayer:>ILayer<Neuron>).update(this.learnRate)
    
    ///
    /// Runs a network query
    ///
    member this.run(data: List<float>): List<float> =
        this.inputLayer.set(data)
        this.inputLayer.feedForward()
        let values = (this.outputLayer:>ILayer<Neuron>).neurons |> List.map(fun neuron -> neuron.value )  
        List.sort values
        