module Neuron

open Connection

type Neuron()= 
    member this.addOutGoingConnection(connection: Connection) =
        printf("todo")

    member this.addIncomingConnection(connection: Connection) =
        printf("todo")

    member this.feedForward() =
        printf("todo")
    
    member this.propagate(layer: Layer) = 
        printf("todo")

    member this.update(learnRate:double) =
        printf("")