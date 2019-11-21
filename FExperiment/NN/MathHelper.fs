module MathHelper

open System

type MathHelper()=
    static member E: double = 2.71828;

    static member sigmoid(value): double =
        1.0/(1.0+(MathHelper.E**(0.0-value)))

    static member random(): double = 
        let min: double = -0.5
        let max: double = 0.5
        floor (Random().NextDouble() * (max - min + 1.0)) + min 

    static member collectiveError(errors: List<double>)=
        let sum = List.reduce(fun sum i -> sum + i * i ) errors //TODO validate let sum = errors.reduce((sum, i)=>{ return sum + i * i }, 0);
        sum / (double errors.Length)

