module Network

open Layer

type Network(inputAmount,hiddenLayerAmount,outputAmount) = 

    member this.label = "";
    member this.inputLayer = this.addInputLayer(inputAmount);
    member this.hiddenLayer = [];
    member this.outputLayer = null;
    member this.learnRate = 0.3;

    member this.addInputLayer(amountOfNeurons) = 
        new Layer(amountOfNeurons);

