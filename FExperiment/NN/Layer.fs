namespace Layer

open Neuron

type Layer(amountOfNeurons) = 
    member this.neurons = this.generateNeurons(amountOfNeurons);
    member this.rightConnectionLayer = null;
    member this.leftConnectionLayer = null;
    
    member this.generateNeurons(amount): List<Neuron>  = 
        [ for i in 0 .. amount -> new Neuron() ]
