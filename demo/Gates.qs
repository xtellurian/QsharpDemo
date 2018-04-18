namespace Quantum.demo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

	operation XGateExample (initial: Result) : (Result) 
	{
		body 
		{
			mutable result = One;
			using (qubits = Qubit[1])
			{
				Set(initial, qubits[0]); // initialise a qubit

				X(qubits[0]);
				
				set result = M(qubits[0]);
				Set(Zero, qubits[0]); // we must always reset out qubits to a zero state before exiting the operation
			}
			return result;
		}
	}

	// inital and result are the same, because Z acts by rotation 180 degrees around Z axis (Bloch Sphere)  
	operation ZGateExample (initial: Result) : (Result) 
	{
		body 
		{
			mutable result = One;
			using (qubits = Qubit[1])
			{
				Set(initial, qubits[0]); // initialise a qubit

				Z(qubits[0]);
				
				set result = M(qubits[0]);
				Set(Zero, qubits[0]); // we must always reset out qubits to a zero state before exiting the operation
			}
			return result;
		}
	}

	operation HGateExample (count : Int, initial: Result) : (Int) 
	{
		body 
		{
			mutable numOnes = 0;
			using (qubits = Qubit[1])
			{
				for(i in 0..count) 
				{
					Set(initial, qubits[0]); // initialise a qubit
					H(qubits[0]); // use the Hadamard gate
					let result = M(qubits[0]); // measure the Qubit
					if(result == One)
					{
						set numOnes = numOnes + 1;
					}
				}
				Set(Zero, qubits[0]); // we must always reset out qubits to a zero state before exiting the operation
			}
			return numOnes;
		}
	}

	operation CNOTGateExample (control: Result, target: Result) : (Result, Result) 
	{
		body 
		{
			mutable targetMeasurement = Zero;
			mutable controlMeasurement = Zero;
			using (qubits = Qubit[2])
			{
				Set(control, qubits[0]);
				Set(target, qubits[1]);

				CNOT(qubits[0], qubits[1]);
				
				set controlMeasurement = M(qubits[0]);
				set targetMeasurement = M(qubits[1]);

				Set(Zero, qubits[0]);
				Set(Zero, qubits[1]);
			}
			return (controlMeasurement, targetMeasurement);
		}
	}
}
