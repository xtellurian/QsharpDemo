namespace Quantum.demo
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;



	// HELPER METHODS
	operation Set (desired: Result, q1: Qubit) : ()
    {
        body
        {
            let current = M(q1);
            if (desired != current)
            {
                X(q1);
            }
        }
    }
}
