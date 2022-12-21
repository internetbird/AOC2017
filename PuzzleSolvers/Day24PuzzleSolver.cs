using AOC;
using AOC2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2017.PuzzleSolvers
{
    public class Day24PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            List<BridgeComponent> components = GetInputBridgeComponents();

            const int NumOfIterations = 2000000;
            int maxStrength = 0;

            for (int i = 0; i < NumOfIterations; i++)
            {

                int iterationStrength = GetBridgeStrength(components);

                if (iterationStrength > maxStrength)
                {
                    maxStrength = iterationStrength;
                    Console.WriteLine($"Max strength = {maxStrength}");
                }
            }

            return maxStrength.ToString();

        }

        private int GetBridgeStrength(List<BridgeComponent> components)
        {

            int totalStrength = 0;

            List<BridgeComponent> iterationComponents = GetClonedComponents(components);

            int currentPort = 0;

            BridgeComponent matchedComponent = GetRandomMatchedComponent(currentPort, iterationComponents);

            while (matchedComponent != null)
            {
                totalStrength += currentPort;

                currentPort = matchedComponent.GetOtherPort(currentPort);

                //Add the second port
                totalStrength += currentPort;

                iterationComponents.Remove(matchedComponent);

                matchedComponent = GetRandomMatchedComponent(currentPort, iterationComponents);
            }

            return totalStrength;
        }

        private List<BridgeComponent> GetRandomBridge(List<BridgeComponent> components)
        {
            List<BridgeComponent> iterationComponents = GetClonedComponents(components);

            var bridge = new List<BridgeComponent>();

            int currentPort = 0;

            BridgeComponent matchedComponent = GetRandomMatchedComponent(currentPort, iterationComponents);

            while (matchedComponent != null)
            {
                bridge.Add(matchedComponent);
                currentPort = matchedComponent.GetOtherPort(currentPort);
                iterationComponents.Remove(matchedComponent);
                matchedComponent = GetRandomMatchedComponent(currentPort, iterationComponents);

            }

            return bridge;

        }

        private BridgeComponent GetRandomMatchedComponent(int currentPort, List<BridgeComponent> iterationComponents)
        {
            var allMatchedComponents = iterationComponents.FindAll(component => component.HasMatchForPort(currentPort));

            if (allMatchedComponents.Any())
            {
                int randomIndex = Random.Shared.Next(0, allMatchedComponents.Count());
                return allMatchedComponents[randomIndex];

            }

            return null;
        }

        private List<BridgeComponent> GetClonedComponents(List<BridgeComponent> components)
        {
            var clonedComponents = new List<BridgeComponent>();

            foreach (var component in components)
            {
                var clonedComponent = component.Clone();
                clonedComponents.Add(clonedComponent);
            }

            return clonedComponents;
        }

        private List<BridgeComponent> GetInputBridgeComponents()
        {
            var components = new List<BridgeComponent>();

            string[] lines = InputFilesHelper.GetInputFileLines("day24.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split("/");
                int port1 = int.Parse(parts[0]);
                int port2 = int.Parse(parts[1]);

                var component = new BridgeComponent(port1, port2);
                components.Add(component);
            }


            return components;
        }

        public string SolvePuzzlePart2()
        {
            List<BridgeComponent> components = GetInputBridgeComponents();

            const int NumOfIterations = 2000000;
            int longestStrongest = 0;
            int maxBridgeLength = 0;

            for (int i = 0; i < NumOfIterations; i++)
            {
                List<BridgeComponent> randomBridge = GetRandomBridge(components);

                if (randomBridge.Count() >= maxBridgeLength)
                {
                    if (randomBridge.Count() > maxBridgeLength)
                    {
                        maxBridgeLength = randomBridge.Count();
                        longestStrongest = 0; //Reset the strength for a longer bridge
                    }

                    int bridgeStrength = GetBridgeTotalStrength(randomBridge);

                    if (bridgeStrength > longestStrongest)
                    {
                        longestStrongest = bridgeStrength;
                    }

                    Console.WriteLine($"Max bridge length = {maxBridgeLength},  Max strength = {longestStrongest}");
                }
            }


            return longestStrongest.ToString();
        }

        private int GetBridgeTotalStrength(List<BridgeComponent> randomBridge)
        {
            int result = randomBridge.Sum(component => component.Ports.Sum());

            return result;
        }
    }
}
