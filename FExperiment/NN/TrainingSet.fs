module TrainingSet

type TrainingSet(input:List<double>, output:List<double>)=
    member val input: List<double> = input
    member val output: List<double> = output
    member val error: double = 0.0 with get,set