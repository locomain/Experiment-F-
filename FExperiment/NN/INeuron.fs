module INeuron

open ILayer

type INeuron = 
    abstract addOutGoingConnection: unit->unit
    abstract addinComingConnection: unit->unit
    abstract feedForward: unit->unit
    abstract propagate: ILayer->unit
    abstract learnRate: double->unit