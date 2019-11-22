module Connection

open System

type public Connection() = 
    member val value: float = 0.0 with get, set
    member val weight: float = Random().NextDouble() with get, set
    
    member this.push(value: float) = 
        this.value <- value;