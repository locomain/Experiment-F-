module Neuron

open Connection
open ILayer

type Neuron()= 
    member this.addOutGoingConnection(connection: Connection) =
        printf("todo")

    member this.addIncomingConnection(connection: Connection) =
        printf("todo")

    member this.feedForward() =
        printf("todo")
    
    member this.propagate(layer: ILayer) = 
        printf("todo")

    member this.update(learnRate:double) =
        printf("")