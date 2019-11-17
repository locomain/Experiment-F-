// Learn more about F# at http://fsharp.org

open System
open Network

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let network = new Network(2,10,10,1)
    0 
