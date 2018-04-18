namespace Quantum.demo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

	operation MeasureAQubit () : (Result)
	{
		body
		{
			mutable result = One; // create a mutable measurement result
			using (qubits = Qubit[1]) // use a qubit
			{
				set result = M(qubits[0]); // set the variable result as the measurement of a qubit
			}
			return (result); // return the measurement
		}
	}
}
