module ILayer

[<AllowNullLiteralAttribute>]
type ILayer<'T> = 
    abstract member neurons: List<'T> with get, set
    abstract member rightConnectionLayer: ILayer<'T> with get, set
    abstract member leftConnectionLayer: ILayer<'T> with get, set

    abstract member feedForward: unit -> unit
    abstract member propagate: unit -> unit
    abstract member update: double -> unit
    abstract member connectTo: ILayer<'T> -> unit
    abstract member generateNeurons: int -> unit