# QsharpDemo
This repo uses Q# to explain some basic concepts in Quantum Computing


## Getting Started

- Follow [these instructions](https://docs.microsoft.com/en-us/quantum/quantum-installconfig) to download and install Visual Studio 2017 and the Microsoft Quantum Development Kit (QDK)
- Clone this repository
- Open `/demo/demo.sln`
- Run the project - you should see the following output (press any key between stages):

```
Measurements are in the computational basis, and have type: Microsoft.Quantum.Simulation.Core.Result. This time we measured a Zero

 ========== X Gate ==========
Equivalent to a classical NOT gate on computational basis
X-Gate on a Zero returns a: One
X-Gate on a One returns a: Zero

 ========== Z Gate ==========
Doesn't change qubits in a known state (i.e. without superposition)
Z-Gate on a Zero returns a: Zero
Z-Gate on a One returns a: One

 ========== Hadamard Gate ==========
Puts a qubit in a superposition - Measurements are equally likely to be Zero or One
Hadamard-Gate on a Zero measures One 51% of the time
Hadamard-Gate on a One measures One 50% of the time

 ========== CNOT Gate ==========
Target is flipped when Control is One
Target: Zero, Control: Zero ->  measures Target: Zero
Target: Zero,  Control: One ->  measures Target: One
Target: One,  Control: Zero ->  measures Target: One
Target: One,   Control: One ->  measures Target: Zero

 ========== Bell State & Teleportation ==========
The following uses a Hadamard gate (no entanglement), to get a superposition of states that, when measured, agree ~50% of the time
Init:Zero 0s=502  1s=498  agree=50%
Init:One  0s=485  1s=515  agree=48%
Now we add a CNOT Gate to get entanglement, and get agreement 100% of the time
Press any key...
Init:Zero 0s=515  1s=485  agree=100%
Init:One  0s=516  1s=484  agree=100%

Press any key to exit

```
