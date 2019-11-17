module ILayer

type ILayer = 
    abstract member feedForward: unit ->unit
    abstract member propagate: double ->unit