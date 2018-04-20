namespace Quantum.demo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;


	operation BellTest (count : Int, initial: Result, entangle: Bool) : (Int,Int,Int)
    {
        body
        {
            mutable numOnes = 0;
            mutable agree = 0;
            using (qubits = Qubit[2])
            {
                for (test in 1..count)
                {
                    Set (initial, qubits[0]);
                    Set (Zero, qubits[1]);

                    
					H(qubits[0]); 
					if(entangle)
					{
						CNOT(qubits[0],qubits[1]); // add this CNOT gate to engangle our qubits
					}
                    

                    let res = M (qubits[0]);

                    if (M (qubits[1]) == res) 
                    {
                        set agree = agree + 1;
                    }

                    // Count the number of ones we saw:
                    if (res == One)
                    {
                        set numOnes = numOnes + 1;
                    }
                }

                Set(Zero, qubits[0]);
                Set(Zero, qubits[1]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count-numOnes, numOnes, agree);
        }
    }
}