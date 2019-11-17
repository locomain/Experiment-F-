module Neuron

open Connection

type Neuron()= 
    member this.addOutGoingConnection(connection: Connection) =
        printf("todo")

    member this.addIncomingConnection(connection: Connection) =
        printf("todo")

    member this.feedForward() =
        printf("todo")
    
    member this.propagate(layer) = 
        printf("todo")