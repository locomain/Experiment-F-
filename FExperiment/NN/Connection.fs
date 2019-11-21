module Connection

type public Connection(weight) = 
    member val value: float = 0.0 with get, set
    member val weight: float = 0.0 with get, set
    
    member this.push(value: float) = 
        this.value <- value;