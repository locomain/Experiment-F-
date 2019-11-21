// Learn more about F# at http://fsharp.org

open System
open Network

[<EntryPoint>]
let main argv =
    let network = new Network()
    network.addInputLayer(2)
    network.addHiddenLayer(4) |> ignore
    network.addHiddenLayer(1) |> ignore
    network.addOutputLayer(1)

    network.build()

    Console.WriteLine("harroo wuuurld");
    //printfn(nmb)
    0 
