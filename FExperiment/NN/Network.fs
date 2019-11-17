module Network

open Layer

type Network(inputAmount,hiddenLayerAmount,hiddenLayerNeurons, outputAmount) = 
    member this.label = "";
    member this.inputLayer = this.addInputLayer(inputAmount);
    member this.hiddenLayers = [ for i in 0 ..hiddenLayerAmount -> new Layer(hiddenLayerNeurons)];
    member this.outputLayer = this.addOutputLayer(outputAmount);
    member this.learnRate = 0.3;

    member this.addInputLayer(amountOfNeurons) = 
        new Layer(amountOfNeurons);

    member this.addOutputLayer(amountOfNeurons) = 
        new Layer(amountOfNeurons)

