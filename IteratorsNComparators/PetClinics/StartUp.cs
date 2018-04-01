using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Pet> createdPets = new Dictionary<string, Pet>();
        Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();
        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {

            string[] commands = Console.ReadLine().Split();
            Console.ForegroundColor = ConsoleColor.Red;

            try
            {
                switch (commands[0])
                {
                    case "Create":
                        if (commands[1] == "Pet")
                        {
                            createdPets.Add(commands[2], new Pet(commands[2], int.Parse(commands[3]), commands[4]));
                        }
                        else if (commands[1] == "Clinic")
                        {
                            clinics.Add(commands[2], new Clinic(commands[2], int.Parse(commands[3])));
                        }

                        break;

                    case "Add":
                        Console.WriteLine(clinics[commands[2]].AddPet(createdPets[commands[1]]));
                        break;

                    case "Release":
                        Console.WriteLine(clinics[commands[1]].ReleaseAnimal());
                        break;

                    case "Print":
                        if (commands.Length == 3)
                        {
                            Console.WriteLine(clinics[commands[1]].Print(int.Parse(commands[2]) - 1));
                        }
                        else
                        {
                            Console.Write(clinics[commands[1]].Print());
                        }
                        break;

                    case "HasEmptyRooms":
                        Console.WriteLine(clinics[commands[1]].HasEmptyRooms());
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}