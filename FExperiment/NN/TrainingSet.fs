module TrainingSet

type TrainingSet(input:List<float>, output:List<float>)=
    member val input: List<float> = input
    member val output: List<float> = output
    member val error: float = 0.0 with get,set