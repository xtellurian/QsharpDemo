# QsharpDemo
This repo uses Q# to explain some basic concepts in Quantum Computing


## Getting Started

- Follow [these instructions](https://docs.microsoft.com/en-us/quantum/quantum-installconfig) to download and install Visual Studio 2017 and the Microsoft Quantum Development Kit (QDK)
- Clone this repository
- Open `/demo/demo.sln`
- Run the project - you should see the following output (press any key between stages):

```
Measured: Zero of type Microsoft.Quantum.Simulation.Core.Result
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
Hadamard-Gate on a Zero measures One 55% of the time
Hadamard-Gate on a One measures One 49% of the time

 ========== CNOT Gate ==========
Target is flipped when Control is One
Target: Zero, Control: Zero ->  measures Target: Zero
Target: Zero,  Control: One ->  measures Target: One
Target: One,  Control: Zero ->  measures Target: One
Target: One,   Control: One ->  measures Target: Zero

 ========== Bell State & Teleportation ==========
Two qubits are used. Firstly, lets just use a Hadamard gate (no entanglement)
Init:Zero 0s=471  1s=529  agree=47%
Init:One  0s=492  1s=508  agree=49%
Next lets just use a Hadamard gate *and* a CNOT Gate to get entanglement
Init:Zero 0s=506  1s=494  agree=100%
Init:One  0s=514  1s=486  agree=100%

Press any key to exit

```
