// Learn more about F# at http://fsharp.org

open System
open Network
open TrainingSet

open Neuron
open ILayer

[<EntryPoint>]
let main argv =
    let network = new Network()
    network.addInputLayer(2)
    network.addHiddenLayer(4) |> ignore
    network.addHiddenLayer(1) |> ignore
    network.addOutputLayer(1)
    network.build()

    //Console.WriteLine((network.outputLayer:>ILayer<Neuron>).neurons.Length)

    let trainingSets: List<TrainingSet> = [
        new TrainingSet([0.0;0.0],[0.0])
        new TrainingSet([1.0;0.0],[1.0])
        new TrainingSet([0.0;1.0],[1.0])
        new TrainingSet([1.0;1.0],[0.0])
    ]
    //2147483647
    network.train(trainingSets,2147483647,0.0002)

    Console.WriteLine("1,0->1 = {0}",network.run([1.0;0.0]));
    Console.WriteLine("1,1->0 = {0}",network.run([1.0;1.0]));
    Console.WriteLine("0,1->1 = {0}",network.run([0.0;1.0]));
    Console.WriteLine("0,0->0 = {0}",network.run([0.0;0.0]));
    
    0 
