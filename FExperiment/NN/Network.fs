module Network

open Neuron
open ILayer
open Layer
open InputLayer
open OutputLayer

type Network() = 
    member val label = "";
    member val inputLayer: InputLayer = null with get, set
    member val hiddenLayers: List<Layer> = [] with get,set
    member val outputLayer: OutputLayer = null with get, set
    member val learnRate = 0.3;

    member this.addInputLayer(amountOfNeurons) = 
        let layer = new InputLayer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.inputLayer <- layer;

    member this.addOutputLayer(amountOfNeurons) = 
        let layer = new OutputLayer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.outputLayer <- layer;

    member this.addHiddenLayer(amountOfNeurons) = 
        let layer = new Layer()
        do (layer:> ILayer<Neuron>).generateNeurons(amountOfNeurons)
        this.hiddenLayers <- this.hiddenLayers @ [layer]
    
    member this.build() =
        let inputLayer = (this.inputLayer:>ILayer<Neuron>)
        do inputLayer.connectTo(this.hiddenLayers.[0]);

        for i = 0 to (this.hiddenLayers.Length-1) do
            let layer = this.hiddenLayers.[i];
            if (i+1) = this.hiddenLayers.Length then
                do (layer:>ILayer<Neuron>).connectTo(this.outputLayer);
                //break?
            else do
                let nextLayer = this.hiddenLayers.[i+1];
                (layer:>ILayer<Neuron>).connectTo(nextLayer);
   