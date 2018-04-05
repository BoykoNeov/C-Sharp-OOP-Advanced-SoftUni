using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<TrafficLight> inputLights = Console.ReadLine().Split().Select(x => (TrafficLight)Enum.Parse(typeof(TrafficLight), x)).ToList();
        TrafficLight[] values = Enum.GetValues(typeof(TrafficLight)).Cast<TrafficLight>().ToArray();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < inputLights.Count; j++)
            {
                int trafficLightValue = (int)inputLights[j];
                trafficLightValue++;
                trafficLightValue %= values.Length;
                inputLights[j] = values[trafficLightValue];
            }

            Console.WriteLine(string.Join(" ", inputLights));
        }
    }
}