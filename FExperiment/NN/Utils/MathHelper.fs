module MathHelper

open System

type MathHelper()=
    static member E: float = 2.718281828459045;

    ///
    /// Sigmoid activation function
    ///
    static member sigmoid(value): float =
        1.0/(1.0+(MathHelper.E**(0.0-value)))

    ///
    /// Creates a random double between 0.5 and -0.5
    ///
    static member random(): double = 
        let min: double = -0.5
        let max: double = 0.5
        floor (Random().NextDouble() * (max - min + 1.0)) + min 

    ///
    /// Creates a single error value from a list
    ///
    static member collectiveError(errors: List<float>)=
        let sum = List.reduce(fun sum i -> sum + i * i ) errors 
        sum / (double errors.Length)

