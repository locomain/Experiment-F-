module TrainingSet

type TrainingSet(input:List<double>, output:List<double>)=
    member val input: List<double> = input
    member val output: List<double> = output