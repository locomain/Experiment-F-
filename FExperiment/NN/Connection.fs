module Connection

type public Connection(weight) = 
    member val value: double = 0.0 with get, set
    member val weight: double = 0.0 with get, set
    
    member this.push(value: double) = 
        this.value <- value;