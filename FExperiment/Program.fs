// Learn more about F# at http://fsharp.org

open System
open Network
open TrainingSet
open MathHelper
open Neuron
open ILayer

[<EntryPoint>]
let main argv =

    let network = new Network()
    network.addInputLayer(2)
    network.addHiddenLayer(4) |> ignore
    network.addHiddenLayer(1) |> ignore
    network.addOutputLayer(1)
    network.setLearnRate(0.3)
    network.build()

    let trainingSets: List<TrainingSet> = [
        new TrainingSet([0.0;0.0],[0.0])
        new TrainingSet([1.0;0.0],[1.0])
        new TrainingSet([0.0;1.0],[1.0])
        new TrainingSet([1.0;1.0],[0.0])
    ]
    //2147483647
    network.train(trainingSets,100000,0.0002)

    Console.WriteLine("1,0->1 = {0}", Math.Round(network.run([1.0;0.0]).[0]));
    Console.WriteLine("1,1->0 = {0}", Math.Round(network.run([1.0;1.0]).[0]));
    Console.WriteLine("0,1->1 = {0}", Math.Round(network.run([0.0;1.0]).[0]));
    Console.WriteLine("0,0->0 = {0}", Math.Round(network.run([0.0;0.0]).[0]));
    
    0 
