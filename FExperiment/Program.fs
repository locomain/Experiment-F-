// Learn more about F# at http://fsharp.org

open System
open Network
open TrainingSet

[<EntryPoint>]
let main argv =
    let network = new Network()
    network.addInputLayer(2)
    network.addHiddenLayer(4) |> ignore
    network.addHiddenLayer(1) |> ignore
    network.addOutputLayer(1)
    network.build()

    let trainingSets: List<TrainingSet> = [
        new TrainingSet([0.0;0.0],[0.0])
        new TrainingSet([1.0;0.0],[1.0])
        new TrainingSet([0.0;1.0],[1.0])
        new TrainingSet([1.0;1.0],[0.0])
    ]

    network.train(trainingSets,2147483647,0.0002)
    

    Console.WriteLine("harroo wuuurld");
    //printfn(nmb)
    0 
