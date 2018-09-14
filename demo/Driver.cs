using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using System.Linq;

namespace Quantum.demo
{
    class Driver
    {
        static void Main(string[] args)
        {
            QubitMeasurement();
            //QuantumGates();
            //Teleportation();
            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }

        //  Creating and Measuring
        private static void QubitMeasurement()
        {
            System.Console.WriteLine("Press any key to measure a 'quantum' state");
            System.Console.ReadKey();
            using (var sim = new QuantumSimulator())
            {
                var result = MeasureAQubit.Run(sim).Result;
                System.Console.WriteLine($"\nMeasurements are in the computational basis.\n" +
                    $"Measurements are of type: {result.GetType()}.\n" +
                    $"This time we measured a {result}");
            }
            System.Console.ReadKey();
            System.Console.WriteLine();
        }

        // Gates
        private static void QuantumGates()
        {
            System.Console.WriteLine("Press any key to experiment with quantum gates");
            System.Console.ReadKey();
            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine($" ========== X Gate ==========");
                System.Console.WriteLine($"Equivalent to a classical NOT gate on computational basis");

                var firstResult = XGateExample.Run(sim, Result.Zero).Result;
                var secondResult = XGateExample.Run(sim, Result.One).Result;

                System.Console.WriteLine($"X-Gate on a Zero returns a: {firstResult}");
                System.Console.WriteLine($"X-Gate on a One returns a: {secondResult}");
            }
            System.Console.ReadKey();
            System.Console.WriteLine();

            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine($" ========== Z Gate ==========");
                System.Console.WriteLine($"Doesn't change qubits in a known state (i.e. without superposition)");

                var firstResult = ZGateExample.Run(sim, Result.Zero).Result;
                var secondResult = ZGateExample.Run(sim, Result.One).Result;

                System.Console.WriteLine($"Z-Gate on a Zero returns a: {firstResult}");
                System.Console.WriteLine($"Z-Gate on a One returns a: {secondResult}");
            }
            System.Console.ReadKey();
            System.Console.WriteLine();

            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine($" ========== Hadamard Gate ==========");
                System.Console.WriteLine($"Puts a qubit in a superposition - Measurements are equally likely to be Zero or One");

                var firstResult = HGateExample.Run(sim, 100, Result.Zero).Result;
                var secondResult = HGateExample.Run(sim, 100, Result.One).Result;

                System.Console.WriteLine($"Hadamard-Gate on a Zero measures One {firstResult}% of the time");
                System.Console.WriteLine($"Hadamard-Gate on a One measures One {secondResult}% of the time");
            }
            System.Console.ReadKey();
            System.Console.WriteLine();

            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine($" ========== CNOT Gate ==========");
                System.Console.WriteLine($"Target is flipped when Control is One");

                var (firstControl, firstTarget ) = CNOTGateExample.Run(sim, Result.Zero, Result.Zero).Result;
                var (secondControl, secondTarget ) = CNOTGateExample.Run(sim, Result.Zero, Result.One).Result;
                var (thirdControl, thirdTarget ) = CNOTGateExample.Run(sim, Result.One, Result.Zero).Result;
                var (fourthControl, fourthTarget ) = CNOTGateExample.Run(sim, Result.One, Result.One).Result;

                System.Console.WriteLine($"Target: Zero, Control: Zero ->  measures Target: {firstTarget} ");
                System.Console.WriteLine($"Target: Zero,  Control: One ->  measures Target: {secondTarget}");
                System.Console.WriteLine($"Target: One,  Control: Zero ->  measures Target: {thirdTarget}");
                System.Console.WriteLine($"Target: One,   Control: One ->  measures Target: {fourthTarget}");
            }
            System.Console.ReadKey();
            System.Console.WriteLine();
        }

        // Bell Test
        private static void Bell()
        {
            System.Console.WriteLine("Press any key to measure some Bell states");
            System.Console.ReadKey();
            var n = 1000;
            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine($" ========== Bell State & Teleportation ==========");
                System.Console.WriteLine($"The following uses a Hadamard gate (no entanglement), " +
                    $"to get a superposition of states that, when measured, agree ~50% of the time");
                // Try initial values
                Result[] initials = new Result[] { Result.Zero, Result.One };
                foreach (Result initial in initials)
                {
                    var res = BellTest.Run(sim, n, initial, false).Result;
                    var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree * 100 / n}%");
                }

                System.Console.WriteLine($"Now we add a CNOT Gate to get entanglement, and get agreement 100% of the time");
                System.Console.WriteLine("Press any key...");
                System.Console.ReadKey();
                foreach (Result initial in initials)
                {
                    var res = BellTest.Run(sim, n, initial, true).Result;
                    var (numZeros, numOnes, agree) = res;
                    System.Console.WriteLine(
                        $"Init:{initial,-4} 0s={numZeros,-4} 1s={numOnes,-4} agree={agree * 100/n}%");
                }
            }
            System.Console.ReadKey();
            System.Console.WriteLine();
        }

        // source: https://github.com/Microsoft/Quantum
        private static void Teleportation ()
        {
            using (var sim = new QuantumSimulator())
            {
                var rand = new System.Random();

                foreach (var idxRun in Enumerable.Range(0, 8))
                {
                    var sent = rand.Next(2) == 0;
                    var received = TeleportClassicalMessage.Run(sim, sent).Result;
                    System.Console.WriteLine($"Round {idxRun}:\tSent {sent},\tgot {received}.");
                    System.Console.WriteLine(sent == received ? "Teleportation successful!!\n" : "\n");
                }
            }

            System.Console.WriteLine("\n\nPress Enter to continue...\n\n");
            System.Console.ReadLine();
        }
    }
}